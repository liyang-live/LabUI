using System;
using System.Data;
using System.Transactions;
using System.Linq;
using SubSonic;
using VNS.Libs;
using VNS.HIS.DAL;
using System.Text;

using SubSonic;
using NLog;
using System.Net.NetworkInformation;
using System.Net;
using System.Collections.Generic;

namespace VNS.HIS.BusRule.Classes
{
    public class KCB_DANGKY
    {
        private NLog.Logger log;
        public KCB_DANGKY()
        {
            log = LogManager.GetCurrentClassLogger();
        }
        public DataTable KcbLaythongtinBenhnhan(long IdBenhnhan)
        {
            return SPs.KcbLaythongtinBenhnhan(IdBenhnhan).GetDataSet().Tables[0];
        }
        public DataTable KcbTiepdonTimkiemBenhnhan(string FromDate, string ToDate, int? ObjectTypeID, int? TrangThai, string TenBenhnhan, int? IdBenhnhan, string MaLuotkham, string MAKHOATHIEN)
        {
            return SPs.KcbTiepdonTimkiemBenhnhan(FromDate, ToDate, ObjectTypeID, TrangThai, TenBenhnhan, IdBenhnhan, MaLuotkham, MAKHOATHIEN).GetDataSet().Tables[0];
        }
       
        public ActionResult InsertRegExam(KcbDangkyKcb objRegExam,KcbLuotkham objLuotkham, ref int v_RegId, int KieuKham)
        {

            bool b_HasLoaded = false;
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var dbscope = new SharedDbConnectionScope())
                    {
                         v_RegId = AddRegExam(objRegExam,objLuotkham,b_HasLoaded, KieuKham);
                    }
                    scope.Complete();
                    return ActionResult.Success;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString);
                return ActionResult.Error;
            }

        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objRegExam"></param>
        /// <param name="b_HasLoaded"></param>
        /// <returns></returns>
        public int AddRegExam(KcbDangkyKcb objRegExam, KcbLuotkham objLuotkham, bool b_HasLoaded, int KieuKham)
        {
            int v_RegId = -1;
            decimal BHYT_PTRAM_TRAITUYENNOITRU = Utility.DecimaltoDbnull(THU_VIEN_CHUNG.Laygiatrithamsohethong("BHYT_PTRAM_TRAITUYENNOITRU", "0", false), 0m);
            try
            {
                using (var scope = new TransactionScope())
                {
                    objRegExam.SttKham = THU_VIEN_CHUNG.LaySothutuKCB(Utility.Int32Dbnull(objRegExam.IdPhongkham, -1));
                    objRegExam.PtramBhyt = objLuotkham.PtramBhyt;
                    objRegExam.PtramBhytGoc = objLuotkham.PtramBhytGoc;
                    if (!THU_VIEN_CHUNG.IsBaoHiem(objLuotkham.IdLoaidoituongKcb))
                        objRegExam.TuTuc = 0;
                    if (Utility.ByteDbnull(objRegExam.TuTuc, 0) == 1)
                    {
                        objRegExam.BhytChitra =0;// objRegExam.DonGia * Utility.DecimaltoDbnull(objLuotkham.PtramBhyt) / 100;
                        objRegExam.BnhanChitra = objRegExam.DonGia;
                    }
                    else
                    {
                        decimal BHCT = 0m;
                        if (objLuotkham.DungTuyen == 1)
                        {
                            BHCT = objRegExam.DonGia * Utility.DecimaltoDbnull(objLuotkham.PtramBhyt) / 100;
                        }
                        else
                        {
                            if (objLuotkham.TrangthaiNoitru <= 0)
                                BHCT = objRegExam.DonGia * (Utility.DecimaltoDbnull(objLuotkham.PtramBhyt, 0) / 100);
                            else//Nội trú cần tính=đơn giá * % đầu thẻ * % tuyến
                                BHCT = objRegExam.DonGia * (Utility.DecimaltoDbnull(objLuotkham.PtramBhytGoc, 0) / 100) * (BHYT_PTRAM_TRAITUYENNOITRU / 100);
                        }

                        objRegExam.BhytChitra =BHCT;// objRegExam.DonGia * Utility.DecimaltoDbnull(objLuotkham.PtramBhyt) / 100;
                        objRegExam.BnhanChitra = objRegExam.DonGia - objRegExam.BhytChitra;
                    }
                   
                    objRegExam.MaKhoaThuchien = globalVariables.MA_KHOA_THIEN;
                    objRegExam.TrangThai = 0;
                    objRegExam.IsNew = true;
                    objRegExam.Save();
                  
                    //Thêm bản ghi trong bảng phân buồng giường để tiện tính toán
                    NoitruPhanbuonggiuong _newItem = new NoitruPhanbuonggiuong();
                    _newItem.IdBenhnhan = objRegExam.IdBenhnhan;
                    _newItem.MaLuotkham = objRegExam.MaLuotkham;
                    _newItem.IdKham = (int)objRegExam.IdKham;
                    _newItem.IdKhoanoitru = objRegExam.IdKhoakcb.Value;
                    _newItem.NgayVaokhoa = objRegExam.NgayDangky.Value;
                    _newItem.IdBacsiChidinh = objRegExam.IdBacsikham;
                    _newItem.NguoiTao = objRegExam.NguoiTao;
                    _newItem.NgayTao = objRegExam.NgayDangky.Value;
                    _newItem.NoiTru =0;
                    _newItem.DuyetBhyt = 0;
                    _newItem.TrongGoi =-1;
                    _newItem.SoLuong = 1;
                    
                    _newItem.DonGia = objRegExam.DonGia;
                    _newItem.PhuThu = objRegExam.PhuThu;
                    _newItem.BnhanChitra = objRegExam.BnhanChitra;
                    _newItem.BhytChitra = objRegExam.BhytChitra;
                    _newItem.TenHienthi = objRegExam.TenDichvuKcb;
                    _newItem.TuTuc = objRegExam.TuTuc;
                    _newItem.TrangthaiXacnhan = 0;
                    _newItem.GiaGoc = objRegExam.DonGia + objRegExam.PhuThu;
                    _newItem.IdBuong = -1;
                    _newItem.IdGiuong = -1;
                    _newItem.IdChuyen = -1;
                    _newItem.IdNhanvienPhangiuong = -1;
                    _newItem.IsNew = true;
                    _newItem.Save();

                    v_RegId = Utility.Int32Dbnull(objRegExam.IdKham);
                    if (objRegExam.IdKham > 0)
                    {
                        KieuKham = Utility.Int32Dbnull(objRegExam.IdDichvuKcb);
                        long _regid = objRegExam.IdKham;
                        //Lấy phí kèm theo trong bảng Quan hệ kiểu khám và đẩy vào bảng T_RegExam
                        //THEM_PHI_DVU_KYC(objLuotkham,objRegExam,  KieuKham);
                        //Lấy phí kèm theo trong bảng DmucPhikemtheoCollection
                        //(cấu hình theo từng phòng khám thay vì theo từng kiểu khám) và đẩy vào bảng T_RegExam
                        THEM_PHI_DVU_KYC(objLuotkham, objRegExam);
                        //Lấy phí dịch vụ trong bảng Quan hệ kiểu khám và đẩy vào bảng CLS
                        //THEM_PHI_DVU_KYC(objLuotkham, KieuKham);


                    }
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return v_RegId;
        }

      

        public void THEM_PHI_DVU_KYC(KcbLuotkham objLuotkham,KcbDangkyKcb objregexam, int KieuKham)
        {
            using (var scope = new TransactionScope())
            {
                DmucDichvukcb objDepartDoctorRelation = DmucDichvukcb.FetchByID(KieuKham);
                if (objDepartDoctorRelation != null)
                {
                    if (Utility.Int32Dbnull(objDepartDoctorRelation.IdPhikemtheo, -1) > 0)
                    {

                        SqlQuery sql = new Select().From(KcbDangkyKcb.Schema).Where(KcbDangkyKcb.Columns.MaLuotkham).
                            IsEqualTo(objLuotkham.MaLuotkham)
                            .And(KcbDangkyKcb.Columns.IdBenhnhan).IsEqualTo(objLuotkham.IdBenhnhan).And(
                                KcbDangkyKcb.Columns.LaPhidichvukemtheo).IsEqualTo(1)
                                .And(KcbDangkyKcb.Columns.IdCha).IsEqualTo(objregexam.IdKham);
                        if (sql.GetRecordCount() > 0)
                        {
                            return;
                        }
                        int IdDv = -1;
                        //Mã ưu tiên của một số đối tượng BHYT ko cần trả phí dịch vụ kèm theo(hiện tại là có mã quyền lợi 1,2,3)
                        string[] maUuTienKkb = globalVariables.gv_strMaUutien.Split(',');

                        if (globalVariables.MA_KHOA_THIEN != "KYC")
                        {
                            if (THU_VIEN_CHUNG.IsNgoaiGio())
                            {
                                IdDv = Utility.Int32Dbnull(objDepartDoctorRelation.IdPhikemtheongoaigio, -1);
                            }
                            else//Khám trong giờ cần xét đối tượng ưu tiên
                            {
                                //var query= from loz in Ma_UuTien.
                                if (!maUuTienKkb.Contains(Utility.sDbnull(objLuotkham.MaQuyenloi, "0")))
                                {
                                    IdDv = Utility.Int32Dbnull(objDepartDoctorRelation.IdPhikemtheo, -1);
                                }
                                else
                                {
                                    IdDv = -1;
                                }
                            }
                        }
                        else//Khám yêu cầu thì luôn bị tính phí dịch vụ kèm theo
                        {
                            IdDv = Utility.Int32Dbnull(objDepartDoctorRelation.IdPhikemtheo, -1);
                        }
                        DmucDichvuclsChitiet lServiceDetail = DmucDichvuclsChitiet.FetchByID(IdDv);
                        long reg_id = objregexam.IdKham;
                        if (lServiceDetail != null)
                        {
                            objregexam.DonGia = lServiceDetail.DonGia.Value;
                            objregexam.PhuThu = 0;
                            objregexam.BhytChitra = 0;
                            objregexam.BnhanChitra = lServiceDetail.DonGia;
                            objregexam.IdCha = reg_id;
                            objregexam.TrangThai = 0;
                            objregexam.SttKham = -1;
                            objregexam.MaKhoaThuchien = globalVariables.MA_KHOA_THIEN;
                            objregexam.TenDichvuKcb = "Phí dịch vụ kèm theo";
                            objregexam.TuTuc = 0;
                            objregexam.KhamNgoaigio = 0;
                            objregexam.LaPhidichvukemtheo = 1;
                            objregexam.IsNew = true;
                            objregexam.Save();
                        }
                    }
                }
                scope.Complete();
            }
        }
        public void THEM_PHI_DVU_KYC(KcbLuotkham objLuotkham, KcbDangkyKcb objregexam)
        {
            using (var scope = new TransactionScope())
            {
                DmucPhikemtheoCollection lstPhikemtheo = new Select().From(DmucPhikemtheo.Schema).Where(DmucPhikemtheo.IdKhoakcbColumn).IsEqualTo(objregexam.IdKhoakcb).ExecuteAsCollection<DmucPhikemtheoCollection>();
                if (lstPhikemtheo != null && lstPhikemtheo.Count > 0)
                {
                    if (Utility.Int32Dbnull(lstPhikemtheo[0].IdPhikemtheo, -1) > 0)
                    {

                        SqlQuery sql = new Select().From(KcbDangkyKcb.Schema).Where(KcbDangkyKcb.Columns.MaLuotkham).
                            IsEqualTo(objLuotkham.MaLuotkham)
                            .And(KcbDangkyKcb.Columns.IdBenhnhan).IsEqualTo(objLuotkham.IdBenhnhan).And(
                                KcbDangkyKcb.Columns.LaPhidichvukemtheo).IsEqualTo(1)
                                .And(KcbDangkyKcb.Columns.IdCha).IsEqualTo(objregexam.IdKham);
                        if (sql.GetRecordCount() > 0)//Chỉ được 1 lần phí dịch vụ kèm theo
                        {
                            return;
                        }
                        int IdDv = -1;
                        //Mã ưu tiên của một số đối tượng BHYT ko cần trả phí dịch vụ kèm theo(hiện tại là có mã quyền lợi 1,2,3)
                        string[] maUuTienKkb = globalVariables.gv_strMaUutien.Split(',');

                        if (globalVariables.MA_KHOA_THIEN != "KYC")
                        {
                            if (THU_VIEN_CHUNG.IsNgoaiGio())
                            {
                                IdDv = Utility.Int32Dbnull(lstPhikemtheo[0].IdPhikemtheongoaigio, -1);
                            }
                            else//Khám trong giờ cần xét đối tượng ưu tiên
                            {
                                //var query= from loz in Ma_UuTien.
                                if (!maUuTienKkb.Contains(Utility.sDbnull(objLuotkham.MaQuyenloi, "0")))
                                {
                                    IdDv = Utility.Int32Dbnull(lstPhikemtheo[0].IdPhikemtheo, -1);
                                }
                                else
                                {
                                    IdDv = -1;
                                }
                            }
                        }
                        else//Khám yêu cầu thì luôn bị tính phí dịch vụ kèm theo
                        {
                            IdDv = Utility.Int32Dbnull(lstPhikemtheo[0].IdPhikemtheo, -1);
                        }
                        DmucDichvuclsChitiet lServiceDetail = DmucDichvuclsChitiet.FetchByID(IdDv);
                        long reg_id = objregexam.IdKham;
                        if (lServiceDetail != null)
                        {
                            objregexam.DonGia = lServiceDetail.DonGia.Value;
                            objregexam.PhuThu = 0;
                            objregexam.BhytChitra = 0;
                            objregexam.BnhanChitra = lServiceDetail.DonGia;
                            objregexam.IdCha = reg_id;
                            objregexam.TrangThai = 0;
                            objregexam.SttKham = -1;
                            objregexam.TenDichvuKcb = "Phí dịch vụ kèm theo";
                            objregexam.MaKhoaThuchien = globalVariables.MA_KHOA_THIEN;
                            objregexam.TuTuc = 0;
                            objregexam.KhamNgoaigio = 0;
                            objregexam.LaPhidichvukemtheo = 1;
                            objregexam.IsNew = true;
                            objregexam.Save();
                        }
                    }
                }
                scope.Complete();

            }
        }
       
        public ActionResult PerformActionDeleteRegExam(int IdKham)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var db = new SharedDbConnectionScope())
                    {
                        KcbDangkyKcb objRegExam = KcbDangkyKcb.FetchByID(IdKham);

                        if (objRegExam != null)
                        {
                            new Delete().From(KcbDangkyKcb.Schema).Where(KcbDangkyKcb.Columns.IdKham).IsEqualTo(objRegExam.IdKham)
                                .Or(KcbDangkyKcb.Columns.IdCha).IsEqualTo(objRegExam.IdKham).Execute();
                           

                            new Delete().From(KcbChandoanKetluan.Schema).Where(KcbChandoanKetluan.Columns.IdKham).IsEqualTo(
                                objRegExam.IdKham).Execute();
                            new Delete().From(NoitruPhanbuonggiuong.Schema).Where(NoitruPhanbuonggiuong.Columns.IdKham).IsEqualTo(
                               objRegExam.IdKham).Execute();
                            new Delete().From(KcbChidinhcl.Schema).Where(KcbChidinhcl.Columns.IdKham).IsEqualTo(
                               objRegExam.IdKham).Execute();
                            new Delete().From(KcbChidinhclsChitiet.Schema).Where(KcbChidinhclsChitiet.Columns.IdKham).IsEqualTo(
                               objRegExam.IdKham).Execute();
                            new Delete().From(KcbDonthuoc.Schema).Where(KcbDonthuoc.Columns.IdKham).IsEqualTo(
                               objRegExam.IdKham).Execute();
                            new Delete().From(KcbDonthuocChitiet.Schema).Where(KcbDonthuocChitiet.Columns.IdKham).IsEqualTo(
                               objRegExam.IdKham).Execute();

                            KcbDangkyKcbCollection lstKham=new Select().From(KcbDangkyKcb.Schema).Where(KcbDangkyKcb.Columns.IdBenhnhan).IsEqualTo(objRegExam.IdBenhnhan)
                                .And(KcbDangkyKcb.Columns.MaLuotkham).IsEqualTo(objRegExam.MaLuotkham).ExecuteAsCollection<KcbDangkyKcbCollection>();
                            if (lstKham.Count <= 0)
                            {
                                KcbLuotkham objluotkham=new Select().From(KcbLuotkham.Schema).Where(KcbLuotkham.Columns.IdBenhnhan).IsEqualTo(objRegExam.IdBenhnhan)
                                .And(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(objRegExam.MaLuotkham).ExecuteSingle<KcbLuotkham>();
                                objluotkham.IdKhoanoitru = -1;
                                objluotkham.IdBuong = -1;
                                objluotkham.IdGiuong = -1;
                                objluotkham.IdNhapvien = -1;
                                objluotkham.IdRavien = -1;
                                objluotkham.TrangthaiNoitru = 0;
                                objluotkham.TrangthaiNgoaitru = 0;
                                objluotkham.TthaiChuyendi = 0;
                                objluotkham.Locked = 0;
                                objluotkham.MabenhChinh = "";
                                objluotkham.MabenhPhu = "";
                                objluotkham.LydoKetthuc = "";
                                objluotkham.IdBenhvienDi = -1;
                                objluotkham.MotaNhapvien = "";
                                objluotkham.MarkOld();
                                objluotkham.IsNew = false;
                                objluotkham.Save();
                            }
                        }
                    }
                    scope.Complete();
                    return ActionResult.Success;
                }
            }
            catch (Exception exception)
            {
                return ActionResult.Error;
            }
        }

        public ActionResult PerformActionDeletePatientExam(string v_Patient_Code, int v_Patient_ID)
        {
            int record = -1;
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var db = new SharedDbConnectionScope())
                    {
                        //LẤY THÔNG TIN CHỈ ĐỊNH DỊCH VỤ CỦA LẦN KHÁM
                        KcbChidinhclCollection objAssignInfo =
                            new KcbChidinhclController().FetchByQuery(
                                KcbChidinhcl.CreateQuery().AddWhere(KcbChidinhcl.Columns.MaLuotkham, Comparison.Equals,
                                                                   v_Patient_Code));
                        //LẤY THÔNG TIN CHỈ ĐỊNH THUỐC CỦA LẦN KHÁM
                        KcbDonthuocCollection prescriptionCollection =
                            new KcbDonthuocController().FetchByQuery(
                                KcbDonthuoc.CreateQuery().AddWhere(KcbDonthuoc.Columns.MaLuotkham,
                                                                     Comparison.Equals, v_Patient_Code));
                        //KIẾM TRA NẾU CÓ THÔNG TIN CHỈ ĐỊNH DV HOẶC THUỐC THÌ KHÔNG ĐC PHÉP XÓA
                        if (prescriptionCollection.Count > 0 || objAssignInfo.Count > 0)
                            return ActionResult.Exception;
                       
                        
                        // XÓA chi định tự động
                        new Delete().From(KcbChidinhcl.Schema).Where(KcbChidinhcl.Columns.MaLuotkham).IsEqualTo(
                            v_Patient_Code)
                            .And(KcbChidinhcl.Columns.IdBenhnhan).IsEqualTo(v_Patient_ID).Execute();

                        
                        //XÓA THÔNG TIN ĐĂNG KÝ KHÁM
                        new Delete().From(KcbDangkyKcb.Schema).Where(KcbDangkyKcb.Columns.MaLuotkham).IsEqualTo(v_Patient_Code)
                            .And(KcbDangkyKcb.Columns.IdBenhnhan).IsEqualTo(v_Patient_ID)
                            .Execute();

                        new Delete().From(NoitruPhanbuonggiuong.Schema).Where(NoitruPhanbuonggiuong.Columns.MaLuotkham).IsEqualTo(v_Patient_Code)
                            .And(NoitruPhanbuonggiuong.Columns.IdBenhnhan).IsEqualTo(v_Patient_ID)
                            .And(NoitruPhanbuonggiuong.Columns.NoiTru).IsEqualTo(0)
                           .Execute();
                       
                        //LẤY VỀ CÁC THÔNG TIN LẦN KHÁM CỦA BỆNH NHÂN
                        KcbLuotkhamCollection tPatientExamCollection =
                            new KcbLuotkhamController().FetchByQuery(
                                KcbLuotkham.CreateQuery().AddWhere(KcbLuotkham.Columns.IdBenhnhan, Comparison.Equals,
                                                                    v_Patient_ID));

                        //XÓA LẦN ĐĂNG KÝ KHÁM CỦA BỆNH NHÂN
                        new Delete().From(KcbLuotkham.Schema).Where(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(
                            v_Patient_Code).Execute();
                        //KIỂM TRA NẾU BỆNH NHÂN CÓ >1 LẦN KHÁM THÌ CHỈ XÓA LẦN ĐĂNG KÝ ĐANG CHỌN. NẾU <= 1 LẦN KHÁM THÌ XÓA LUÔN THÔNG TIN BỆNH NHÂN
                        if (tPatientExamCollection.Count < 2)
                        {
                            new Delete().From(KcbDanhsachBenhnhan.Schema).Where(KcbDanhsachBenhnhan.Columns.IdBenhnhan).IsEqualTo(
                               v_Patient_ID).Execute();
                        }

                    }
                    scope.Complete();
                    return ActionResult.Success;

                }
            }
            catch (Exception ex)
            {
                return ActionResult.Error;
            }
        }
        private decimal SumOfPaymentDetail_NGOAITRU(KcbThanhtoanChitiet[] objArrPaymentDetail)
        {
            decimal SumOfPaymentDetail = 0;
            var sum = (from loz in objArrPaymentDetail.AsEnumerable()
                       where loz.TuTuc == 0
                       select loz).Sum(c => c.DonGia * c.SoLuong);
            //.Sum(c=>c.SoLuong*c.DonGia))
            foreach (KcbThanhtoanChitiet paymentDetail in objArrPaymentDetail)
            {
                if (paymentDetail.TuTuc == 0)
                    SumOfPaymentDetail += (Utility.Int32Dbnull(paymentDetail.SoLuong) *
                                           Utility.DecimaltoDbnull(paymentDetail.DonGia));


            }
            return SumOfPaymentDetail;
        }
        public decimal LayThongPtramBHYT(decimal v_decTotalPrice, KcbLuotkham objLuotkham, ref  decimal PtramBHYT)
        {
            decimal decDiscountTotalMoney = 0;
            SqlQuery q;
            if (!string.IsNullOrEmpty(objLuotkham.MaKcbbd) && THU_VIEN_CHUNG.IsBaoHiem(objLuotkham.IdLoaidoituongKcb.Value))
            {
                ///Kiểm tra xem đối tượng BHYT là đúng tuyến?
                if (objLuotkham.DungTuyen == 1)
                {
                    //Đối tượng mã quyền lợi 1,2 được hưởng 100%
                    if (objLuotkham.MaQuyenloi.ToString() == "1" || objLuotkham.MaQuyenloi.ToString() == "2")
                    {
                        decDiscountTotalMoney = 0;
                        PtramBHYT = 100;
                    }
                    else
                    {
                        switch (globalVariables.gv_strTuyenBHYT)
                        {
                            case "TUYEN1"://Kiểm tra so với >15% lương cơ bản
                                if (v_decTotalPrice >= objLuotkham.LuongCoban * 15 / 100)
                                {
                                    
                                    q = new Select().From(DmucDoituongbhyt.Schema)
                                       .Where(DmucDoituongbhyt.Columns.IdDoituongKcb).IsEqualTo(objLuotkham.IdDoituongKcb)
                                       .And(DmucDoituongbhyt.Columns.MaDoituongbhyt).IsEqualTo(objLuotkham.MaDoituongBhyt);
                                    DmucDoituongbhyt objInsuranceObject = q.ExecuteSingle<DmucDoituongbhyt>();
                                    if (objInsuranceObject != null)
                                    {
                                        PtramBHYT = Utility.DecimaltoDbnull(objInsuranceObject.PhantramBhyt, 0);
                                        decDiscountTotalMoney = v_decTotalPrice * (100 - Utility.DecimaltoDbnull(objInsuranceObject.PhantramBhyt, 0)) / 100;
                                        
                                    }

                                }
                                else//<15% lương cơ bản-->BHYT trả hết
                                {

                                    PtramBHYT = 100;
                                    decDiscountTotalMoney = 0;
                                }
                                break;
                            case "TW"://Tuyến trung ương ko cần so sánh với lương cơ bản
                               
                                q = new Select().From(DmucDoituongbhyt.Schema)
                                   .Where(DmucDoituongbhyt.Columns.IdDoituongKcb).IsEqualTo(objLuotkham.IdDoituongKcb)
                                   .And(DmucDoituongbhyt.Columns.MaDoituongbhyt).IsEqualTo(objLuotkham.MaDoituongBhyt);
                                DmucDoituongbhyt objInsuranceObjectTW = q.ExecuteSingle<DmucDoituongbhyt>();
                                if (objInsuranceObjectTW != null)
                                {
                                    PtramBHYT = Utility.DecimaltoDbnull(objInsuranceObjectTW.PhantramBhyt, 0);
                                    decDiscountTotalMoney = v_decTotalPrice * (100 - Utility.DecimaltoDbnull(objInsuranceObjectTW.PhantramBhyt, 0)) / 100;
                                }
                                break;
                            default://Các tuyến khác-->Mặc định giống tuyến 1
                                if (v_decTotalPrice >= objLuotkham.LuongCoban * 15 / 100)
                                {
                                    q = new Select().From(DmucDoituongbhyt.Schema)
                                       .Where(DmucDoituongbhyt.Columns.IdDoituongKcb).IsEqualTo(objLuotkham.IdDoituongKcb)
                                       .And(DmucDoituongbhyt.Columns.MaDoituongbhyt).IsEqualTo(objLuotkham.MaDoituongBhyt);
                                    DmucDoituongbhyt objInsuranceObject = q.ExecuteSingle<DmucDoituongbhyt>();
                                    if (objInsuranceObject != null)
                                    {
                                        PtramBHYT = Utility.DecimaltoDbnull(objInsuranceObject.PhantramBhyt, 0);
                                        decDiscountTotalMoney = v_decTotalPrice * (100 - Utility.DecimaltoDbnull(objInsuranceObject.PhantramBhyt, 0)) / 100;
                                    }
                                }
                                else
                                {

                                    PtramBHYT = 100;
                                    decDiscountTotalMoney = 0;
                                }
                                break;

                        }


                    }


                }
                else
                {
                    ///Nếu là đối tượng trái tuyến thực hiện lấy % của trái tuyến
                    DmucDoituongkcb objObjectType = DmucDoituongkcb.FetchByID(objLuotkham.IdDoituongKcb);
                    if (objObjectType != null)
                    {
                        decDiscountTotalMoney = v_decTotalPrice * (100 - Utility.DecimaltoDbnull(objObjectType.PhantramTraituyen)) / 100;
                        PtramBHYT = Utility.DecimaltoDbnull(objObjectType.PhantramTraituyen, 0);

                    }

                }


            }
            else//Đối tượng dịch vụ
            {
                //Có thể gán luôn PtramBHYT=0% và decDiscountTotalMoney=0
                DmucDoituongkcb objObjectType = DmucDoituongkcb.FetchByID(objLuotkham.IdDoituongKcb);
                if (objObjectType != null)
                    decDiscountTotalMoney = v_decTotalPrice * (100 - Utility.Int32Dbnull(objObjectType.PhantramDungtuyen, 0)) / 100; ;
                PtramBHYT = Utility.DecimaltoDbnull(objObjectType.PhantramDungtuyen, 0);

            }
            return decDiscountTotalMoney;
        }
        
        public void XuLyChiKhauDacBietBHYT(KcbLuotkham objLuotkham, decimal v_DiscountRate)
        {
            KcbThanhtoanCollection paymentCollection =
                new KcbThanhtoanController().FetchByQuery(
                    KcbThanhtoan.CreateQuery().AddWhere(KcbThanhtoan.Columns.MaLuotkham, Comparison.Equals,
                                                    objLuotkham.MaLuotkham).AND(KcbThanhtoan.Columns.IdBenhnhan,
                                                                                    Comparison.Equals,
                                                                                    objLuotkham.IdBenhnhan));
            foreach (KcbThanhtoan payment in paymentCollection)
            {
                KcbThanhtoanChitietCollection paymentDetailCollection =
                                new KcbThanhtoanChitietController().FetchByQuery(
                                    KcbThanhtoanChitiet.CreateQuery().AddWhere(KcbThanhtoanChitiet.Columns.IdThanhtoan,
                                                                          Comparison.Equals, payment.IdThanhtoan).AND(
                                                                              KcbThanhtoanChitiet.Columns.TuTuc,
                                                                              Comparison.Equals, 0));
                string IsDungTuyen = "DT";
                DmucDoituongkcb objectType = DmucDoituongkcb.FetchByID(objLuotkham.IdDoituongKcb);
                if (objectType != null)
                {
                    switch (objectType.MaDoituongKcb)
                    {
                        case "BHYT":
                            if (Utility.Int32Dbnull(objLuotkham.DungTuyen, "0") == 1) IsDungTuyen = "DT";
                            else
                            {
                                IsDungTuyen = "TT";
                            }
                            break;
                        default:
                            IsDungTuyen = "KHAC";
                            break;
                    }

                }
                foreach (KcbThanhtoanChitiet PaymentDetail in paymentDetailCollection)
                {
                    SqlQuery sqlQuery = new Select().From(DmucBhytChitraDacbiet.Schema)
                     .Where(DmucBhytChitraDacbiet.Columns.IdDichvuChitiet).IsEqualTo(PaymentDetail.IdChitietdichvu)
                     .And(DmucBhytChitraDacbiet.Columns.MaLoaithanhtoan).IsEqualTo(PaymentDetail.IdLoaithanhtoan)
                     .And(DmucBhytChitraDacbiet.Columns.DungtuyenTraituyen).IsEqualTo(IsDungTuyen)
                     .And(DmucBhytChitraDacbiet.Columns.MaDoituongKcb).IsEqualTo(objLuotkham.MaDoituongKcb);
                    DmucBhytChitraDacbiet objDetailDiscountRate = sqlQuery.ExecuteSingle<DmucBhytChitraDacbiet>();
                    if (objDetailDiscountRate != null)
                    {
                        log.Info("Neu trong ton tai trong bang cau hinh chi tiet chiet khau void Id_Chitiet=" + PaymentDetail.IdChitiet);
                        PaymentDetail.PtramBhyt = objDetailDiscountRate.TileGiam;
                        PaymentDetail.BhytChitra = THU_VIEN_CHUNG.TinhBhytChitra(objDetailDiscountRate.TileGiam,
                                                      Utility.DecimaltoDbnull(
                                                          PaymentDetail.DonGia, 0));
                        PaymentDetail.BnhanChitra = THU_VIEN_CHUNG.TinhBnhanChitra(objDetailDiscountRate.TileGiam,
                                                                 Utility.DecimaltoDbnull(
                                                                     PaymentDetail.DonGia, 0));
                    }
                    else
                    {
                        PaymentDetail.PtramBhyt = v_DiscountRate;
                        PaymentDetail.BhytChitra = THU_VIEN_CHUNG.TinhBhytChitra(v_DiscountRate,
                                                       Utility.DecimaltoDbnull(
                                                           PaymentDetail.DonGia, 0));
                        PaymentDetail.BnhanChitra = THU_VIEN_CHUNG.TinhBnhanChitra(v_DiscountRate,
                                                                 Utility.DecimaltoDbnull(
                                                                     PaymentDetail.DonGia, 0));
                    }
                    log.Info("Thuc hien viec cap nhap thong tin lai gia can phai xem lại gia truoc khi thanh toan");




                }

            }

        }
        /// <summary>
        /// HÀM THỰC HIỆN VIỆC LẤY THÔNG TIN CHIÊT KHẤU
        /// </summary>
        /// <returns></returns>
        private string LayChiKhauChiTiet()
        {
            string PTramChiTiet = "KHONG";
            SqlQuery sqlQuery = new Select().From(SysSystemParameter.Schema)
                .Where(SysSystemParameter.Columns.SName).IsEqualTo("PTRAM_CHITIET");
            SysSystemParameter objSystemParameter = sqlQuery.ExecuteSingle<SysSystemParameter>();
            if (objSystemParameter != null) PTramChiTiet = objSystemParameter.SValue;
            return PTramChiTiet;
        }
        public ActionResult PerformActionPaymentChoose(KcbThanhtoan objPayment, KcbLuotkham objLuotkham, KcbThanhtoanChitiet[] objArrPaymentDetail, ref int Payment_Id)
        {

            decimal PtramBHYT = 0;
            ///tổng tiền hiện tại truyền vào của lần payment đang thực hiện
            decimal v_TotalOrginPrice = 0;
            ///tổng tiền đã thanh toán
            decimal v_TotalPaymentDetail = 0;
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var dbscope = new SharedDbConnectionScope())
                    {
                        ///lấy tổng số Payment của mang truyền vào của pay ment hiện tại
                        v_TotalOrginPrice = SumOfPaymentDetail_NGOAITRU(objArrPaymentDetail);


                        KcbThanhtoanCollection paymentCollection =
                            new KcbThanhtoanController().FetchByQuery(
                                KcbThanhtoan.CreateQuery().AddWhere(KcbThanhtoan.Columns.MaLuotkham, Comparison.Equals,
                                                                objLuotkham.MaLuotkham).AND(
                                                                    KcbThanhtoan.Columns.IdBenhnhan, Comparison.Equals,
                                                                    objLuotkham.IdBenhnhan).
                                    AND(KcbThanhtoan.Columns.KieuThanhtoan, Comparison.Equals, 0).AND(
                                        KcbThanhtoan.Columns.TrangThai, Comparison.Equals, 0));


                        foreach (KcbThanhtoan Payment in paymentCollection)
                        {
                            KcbThanhtoanChitietCollection paymentDetailCollection = new Select().From(KcbThanhtoanChitiet.Schema)
                                .Where(KcbThanhtoanChitiet.Columns.IdThanhtoan).IsEqualTo(Payment.IdThanhtoan)
                                .And(KcbThanhtoanChitiet.Columns.TrangthaiHuy).IsEqualTo(0).ExecuteAsCollection
                                <KcbThanhtoanChitietCollection>();

                            foreach (KcbThanhtoanChitiet paymentDetail in paymentDetailCollection)
                            {
                                if (paymentDetail.TuTuc == 0)
                                    v_TotalPaymentDetail += Utility.Int32Dbnull(paymentDetail.SoLuong) *
                                                            Utility.DecimaltoDbnull(paymentDetail.DonGia);

                            }
                        }
                        ///lấy thông tin chiết khấu xem đã thực hiện chưa
                        LayThongPtramBHYT(v_TotalOrginPrice + v_TotalPaymentDetail, objLuotkham, ref PtramBHYT);
                        ///hàm thực hiện việc xử lý lại thông tin 
                        XuLyChiKhauDacBietBHYT(objLuotkham, PtramBHYT);
                        
                        objPayment.TrangthaiIn = 0;
                        objPayment.KieuThanhtoan = 0;
                        objPayment.NguoiIn = string.Empty;
                        //objPayment.TrongGoi = 0;
                        //objPayment.IpMacTao = THU_VIEN_CHUNG.GetMACAddress();
                        //objPayment.IpMayTao = THU_VIEN_CHUNG.GetIP4Address();
                        objPayment.MaThanhtoan = THU_VIEN_CHUNG.TaoMathanhtoan(Convert.ToDateTime(objPayment.NgayThanhtoan));
                        objPayment.IsNew = true;
                        objPayment.MaKhoaThuchien = globalVariables.MA_KHOA_THIEN;
                        objPayment.Save();
                        //StoredProcedure sp = SPs.KcbThanhtoanThemmoi(objPayment.IdThanhtoan, objPayment.MaLuotkham, objPayment.IdBenhnhan,
                        //                  objPayment.NgayThanhtoan, objPayment.StaffId, objPayment.TrangThai,
                        //                  objPayment.NguoiTao, objPayment.CreatedDate, objPayment.NgaySua,
                        //                  objPayment.NguoiSua, objPayment.PaymentCode, objPayment.KieuThanhtoan,
                        //                  objPayment.DaIn, objPayment.NgayIn, objPayment.NgayTHop, objPayment.NguoiIn,
                        //                  objPayment.NguoiTHop, Utility.Int32Dbnull(objPayment.TrongGoi), objPayment.IpMayTao, objPayment.IpMacTao, globalVariables.MA_KHOA_THIEN);
                        //sp.Execute();
                        //objPayment.IdThanhtoan = Utility.Int32Dbnull(sp.OutputValues[0], -1);
                        //objPayment.IdThanhtoan = Utility.Int32Dbnull(_QueryPayment.GetMax(KcbThanhtoan.Columns.IdThanhtoan), -1);
                        log.Info("Lay ma thanh toan cua phan thanh toan Payment_ID={0}", objPayment.IdThanhtoan);
                        ///hàm thực hiện việc mảng thao tác mảng của chi tiết thanh toán

                        switch (LayChiKhauChiTiet())
                        {
                            case "KHONG":
                                objArrPaymentDetail =THU_VIEN_CHUNG.TinhPhamTramBHYT(objLuotkham, objArrPaymentDetail, PtramBHYT);
                                break;
                            case "CO":
                                objArrPaymentDetail = THU_VIEN_CHUNG.TinhPhamTramBHYT(objArrPaymentDetail, objLuotkham, PtramBHYT);
                                break;
                            default:
                                objArrPaymentDetail = THU_VIEN_CHUNG.TinhPhamTramBHYT(objLuotkham, objArrPaymentDetail, PtramBHYT);
                                break;
                        }
                        decimal BN_CT = 0m;
                        foreach (KcbThanhtoanChitiet objPaymentDetail in objArrPaymentDetail)
                        {
                            
                            ///thanh toán phần thuốc);
                            if (THU_VIEN_CHUNG.LayMaDviLamViec() == "DETMAY")
                            {
                                if (objPaymentDetail.IdLoaithanhtoan == 3)
                                {
                                    new Update(KcbDonthuoc.Schema)
                                        .Set(KcbDonthuoc.Columns.TrangthaiThanhtoan).EqualTo(1)
                                        .Set(KcbDonthuoc.Columns.TrangThai).EqualTo(2)///nếu =2 đối với đơn thuốc ngoại trú
                                        .Where(KcbDonthuoc.Columns.IdDonthuoc).IsEqualTo(objPaymentDetail.IdPhieu).Execute();

                                }
                            }

                            
                            switch (THU_VIEN_CHUNG.GetThanhToan_TraiTuyen())
                            {
                                case "PHUTHU":
                                    if (objPaymentDetail.IdLoaithanhtoan == 1)
                                    {
                                        objPaymentDetail.PhuThu = 0;
                                    }
                                    break;


                            }
                            objPaymentDetail.NguoiTao = globalVariables.UserName;
                            objPaymentDetail.NoiTru = 0;
                            //objPaymentDetail.TrongGoi = 0;
                            //objPaymentDetail.IpMacTao = THU_VIEN_CHUNG.GetMACAddress();
                            //objPaymentDetail.IpMayTao = THU_VIEN_CHUNG.GetIP4Address();
                            objPaymentDetail.IdThanhtoan = Utility.Int32Dbnull(objPayment.IdThanhtoan, -1);
                            objPaymentDetail.BnhanChitra = Utility.DecimaltoDbnull(objPaymentDetail.BnhanChitra);
                            BN_CT+=objPaymentDetail.BnhanChitra;
                            objPaymentDetail.TenLoaithanhtoan = THU_VIEN_CHUNG.MaKieuThanhToan(Utility.Int32Dbnull(objPaymentDetail.IdLoaithanhtoan));
                            StoredProcedure spPaymentDetail = SPs.KcbThanhtoanThemchitiet(
                                objPaymentDetail.IdChitiet, objPaymentDetail.IdThanhtoan,
                                objPaymentDetail.SoLuong, objPaymentDetail.DonGia,
                                objPaymentDetail.BhytChitra, objPaymentDetail.BnhanChitra,
                                Utility.DecimaltoDbnull(objPaymentDetail.BnhanChitra),
                                objPaymentDetail.PhuThu, objPaymentDetail.IdPhieu,
                                objPaymentDetail.IdPhieuChitiet, objPaymentDetail.IdDichvu,
                                objPaymentDetail.IdChitietdichvu, objPaymentDetail.IdLoaithanhtoan,
                                objPaymentDetail.TrangthaiHuy, objPaymentDetail.TuTuc,
                                objPaymentDetail.NguoiHuy, objPaymentDetail.NgayHuy,
                                objPaymentDetail.IdPhongkham, objPaymentDetail.IdBacsiChidinh,
                                objPaymentDetail.SttIn, objPaymentDetail.DonviTinh,
                                objPaymentDetail.MaDoituongKcb, objPaymentDetail.PtramBhyt,
                                objPaymentDetail.TenChitietdichvu, Utility.sDbnull(objPaymentDetail.TenChitietdichvu),
                                objPaymentDetail.TenLoaithanhtoan, 0, -1, -1,
                                objPaymentDetail.NoiTru, objPaymentDetail.NguoiTao, "", "");

                            spPaymentDetail.Execute();
                            objPaymentDetail.IdChitiet = Utility.Int32Dbnull(spPaymentDetail.OutputValues[0], -1);
                            UpdateTrangThaiBangChucNang(objPayment, objPaymentDetail);
                            
                        }
                        new Update(KcbThanhtoan.Schema).Set(KcbThanhtoan.TongTienColumn).EqualTo(BN_CT).Where(KcbThanhtoan.IdThanhtoanColumn).IsEqualTo(objPayment.IdThanhtoan).Execute();
                        if (objLuotkham.MaDoituongKcb == "BHYT")
                        {
                            if (globalVariables.gv_strTuyenBHYT == "TW")
                            {
                                SqlQuery sqlQuery = new Select().From(KcbThanhtoanChitiet.Schema)
                                    .Where(KcbThanhtoanChitiet.Columns.IdThanhtoan).In(
                                        new Select(KcbThanhtoan.Columns.IdThanhtoan).From(KcbThanhtoan.Schema).Where(
                                            KcbThanhtoan.Columns.MaLuotkham).IsEqualTo(
                                                objLuotkham.MaLuotkham).And(KcbThanhtoan.Columns.IdBenhnhan).IsEqualTo(
                                                    objLuotkham.IdBenhnhan).And(KcbThanhtoan.Columns.KieuThanhtoan).
                                            IsEqualTo(0).
                                            And(KcbThanhtoan.Columns.TrangThai).IsEqualTo(0))
                                    .And(KcbThanhtoanChitiet.Columns.TrangthaiHuy).IsEqualTo(0)
                                    .And(KcbThanhtoanChitiet.Columns.TuTuc).IsEqualTo(0);

                                KcbThanhtoanChitietCollection objPaymentDetailCollection =
                                    sqlQuery.ExecuteAsCollection<KcbThanhtoanChitietCollection>();
                                decimal TongTien =
                                    Utility.DecimaltoDbnull(objPaymentDetailCollection.Sum(c => c.SoLuong * c.DonGia));
                                LayThongPtramBHYT(TongTien, objLuotkham, ref PtramBHYT);
                                foreach (KcbThanhtoanChitiet objPaymentDetail in objPaymentDetailCollection)
                                {
                                    decimal BHCT = Utility.DecimaltoDbnull(objPaymentDetail.DonGia * PtramBHYT / 100);
                                    decimal BNCT = Utility.DecimaltoDbnull(objPaymentDetail.DonGia - BHCT);
                                    objPaymentDetail.BhytChitra = BHCT;
                                    objPaymentDetail.PtramBhyt = PtramBHYT;
                                    objPaymentDetail.BnhanChitra = BNCT;

                                    //new Update(KcbThanhtoanChitiet.Schema)
                                    //    .Set(KcbThanhtoanChitiet.Columns.PtramBhyt).EqualTo(PtramBHYT)
                                    //    .Set(KcbThanhtoanChitiet.Columns.DiscountRate).EqualTo(BHCT)
                                    //    .Set(KcbThanhtoanChitiet.Columns.DiscountPrice).EqualTo(BNCT)
                                    //    .Where(KcbThanhtoanChitiet.Columns.IdChitiet).IsEqualTo(objPaymentDetail.IdChitiet).Execute();
                                    //new Update(KydongKcbThanhtoanChitiet.Schema)
                                    //    .Set(KydongKcbThanhtoanChitiet.Columns.PtramBhyt).EqualTo(PtramBHYT)
                                    //    .Set(KydongKcbThanhtoanChitiet.Columns.DiscountRate).EqualTo(BHCT)
                                    //    .Set(KydongKcbThanhtoanChitiet.Columns.DiscountPrice).EqualTo(BNCT)
                                    //    .Where(KydongKcbThanhtoanChitiet.Columns.IdChiTietTToan).IsEqualTo(objPaymentDetail.IdChitiet)
                                    //    .And(KydongKcbThanhtoanChitiet.Columns.PaymentDetailType).IsEqualTo(0)
                                    //    .Execute();
                                }
                                objPaymentDetailCollection.SaveAll();
                            }

                        }
                       
                    }
                    scope.Complete();
                    Payment_Id = Utility.Int32Dbnull(objPayment.IdThanhtoan, -1);
                    log.Info("Thuc hien thanh cong viec thanh toan");
                    return ActionResult.Success;
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi thuc hien thanh toan:" + ex.ToString());
                return ActionResult.Error;
            }

        }
        private void UpdateTrangThaiBangChucNang(KcbThanhtoan objPayment, KcbThanhtoanChitiet objPaymentDetail)
        {
            using (var scope = new TransactionScope())
            {
                switch (objPaymentDetail.IdLoaithanhtoan)
                {
                    case 1:
                        new Update(KcbDangkyKcb.Schema)
                            .Set(KcbDangkyKcb.Columns.IdThanhtoan).EqualTo(objPayment.IdThanhtoan)
                            .Set(KcbDangkyKcb.Columns.TrangthaiThanhtoan).EqualTo(1)
                            .Set(KcbDangkyKcb.Columns.NgayThanhtoan).EqualTo(objPayment.NgayThanhtoan)
                            .Where(KcbDangkyKcb.Columns.IdKham).IsEqualTo(objPaymentDetail.IdPhieu).Execute();
                        break;
                    case 2:
                        new Update(KcbChidinhclsChitiet.Schema)
                            .Set(KcbChidinhclsChitiet.Columns.IdThanhtoan).EqualTo(objPayment.IdThanhtoan)
                            .Set(KcbChidinhclsChitiet.Columns.TrangthaiThanhtoan).EqualTo(1)
                            .Set(KcbChidinhclsChitiet.Columns.TrangthaiChuyencls).EqualTo(1)
                            .Set(KcbChidinhclsChitiet.Columns.NgaySua).EqualTo(globalVariables.SysDate)
                            .Set(KcbChidinhclsChitiet.Columns.NguoiSua).EqualTo(globalVariables.UserName)
                            .Set(KcbChidinhclsChitiet.Columns.NgayThanhtoan).EqualTo(objPayment.NgayThanhtoan)
                            .Where(KcbChidinhclsChitiet.Columns.IdChitietchidinh).IsEqualTo(objPaymentDetail.IdChitietdichvu).Execute();
                        break;
                    case 3:
                        new Update(KcbDonthuocChitiet.Schema)
                            .Set(KcbDonthuocChitiet.Columns.IdThanhtoan).EqualTo(objPayment.IdThanhtoan)
                            .Set(KcbDonthuocChitiet.Columns.TrangthaiThanhtoan).EqualTo(1)
                            .Set(KcbDonthuocChitiet.Columns.NgayThanhtoan).EqualTo(objPayment.NgayThanhtoan)
                            .Where(KcbDonthuocChitiet.Columns.IdChitietdonthuoc).IsEqualTo(objPaymentDetail.IdChitietdichvu).Execute();
                        break;
                    case 5:
                        new Update(KcbDonthuocChitiet.Schema)
                            .Set(KcbDonthuocChitiet.Columns.IdThanhtoan).EqualTo(objPayment.IdThanhtoan)
                            .Set(KcbDonthuocChitiet.Columns.TrangthaiThanhtoan).EqualTo(1)
                            .Set(KcbDonthuocChitiet.Columns.NgayThanhtoan).EqualTo(objPayment.NgayThanhtoan)
                            .Where(KcbDonthuocChitiet.Columns.IdChitietdonthuoc).IsEqualTo(objPaymentDetail.IdChitietdichvu).Execute();
                        break;
                    case 4:
                        //new Update(TPatientDept.Schema)
                        //    .Set(TPatientDept.Columns.IdThanhtoan).EqualTo(objPayment.IdThanhtoan)
                        //    .Set(TPatientDept.Columns.TinhtrangThanhtoan).EqualTo(1)
                        //    .Set(TPatientDept.Columns.NgayThanhtoan).EqualTo(objPayment.NgayThanhtoan)
                        //    .Where(TPatientDept.Columns.PatientDeptId).IsEqualTo(objPaymentDetail.Id).Execute();
                        break;
                    case 0:
                        new Update(KcbChidinhclsChitiet.Schema)
                            .Set(KcbChidinhclsChitiet.Columns.IdThanhtoan).EqualTo(objPayment.IdThanhtoan)
                            .Set(KcbChidinhclsChitiet.Columns.TrangthaiThanhtoan).EqualTo(1)
                            .Set(KcbChidinhclsChitiet.Columns.NgayThanhtoan).EqualTo(objPayment.NgayThanhtoan)
                            .Where(KcbChidinhclsChitiet.Columns.IdChitietchidinh).IsEqualTo(objPaymentDetail.IdChitietdichvu)
                            .Execute();
                        new Update(KcbDangkyKcb.Schema)
                           .Set(KcbDangkyKcb.Columns.IdThanhtoan).EqualTo(objPayment.IdThanhtoan)
                           .Set(KcbDangkyKcb.Columns.TrangthaiThanhtoan).EqualTo(1)
                           .Set(KcbDangkyKcb.Columns.NgayThanhtoan).EqualTo(objPayment.NgayThanhtoan)
                           .Where(KcbDangkyKcb.Columns.IdKham).IsEqualTo(objPaymentDetail.IdPhieu)
                           .And(KcbDangkyKcb.Columns.LaPhidichvukemtheo).IsEqualTo(1)
                           .Execute();
                        break;
                }
                scope.Complete();
            }
        }
        public DataTable LayChiDinhCLS_KhongKham(string MaLuotkham, int IdBenhnhan, int ExamID)
        {
            return SPs.KcbTiepdonLaychidinhclsKhongquaphongkham(MaLuotkham, IdBenhnhan, 200).GetDataSet().Tables[0];
        }
        public DataTable LayDsachDvuKCB(string MaLuotkham, long IdBenhnhan)
        {
            return SPs.KcbLaydanhsachdangkyphongkhamTheoIDCode(MaLuotkham, IdBenhnhan).GetDataSet().Tables[0];
        }
       
        /// <summary>
        /// Creates an object wrapper for the LAOKHOA_INPHIEU_KHAMBENH Procedure
        /// </summary>
        public  DataTable LayThongtinInphieuKCB(int RegID)
        {
            return SPs.KcbTiepdonInphieukcb(RegID).GetDataSet().Tables[0];
        }
        public DataTable LayDsachBnhanChoKham()
        {
            DataTable dataTable = new DataTable();

            dataTable = SPs.KcbTiepdonLaydsachBnhanchokham(globalVariables.SysDate,globalVariables.MA_KHOA_THIEN).GetDataSet().Tables[0];
            return dataTable;
        }
        private void UpdatePatientInfo(KcbDanhsachBenhnhan objPatientInfo)
        {
            using (var scope = new TransactionScope())
            {
                new Update(KcbDanhsachBenhnhan.Schema)
                    .Set(KcbDanhsachBenhnhan.Columns.TenBenhnhan).EqualTo(objPatientInfo.TenBenhnhan)
                    .Set(KcbDanhsachBenhnhan.Columns.GioiTinh).EqualTo(objPatientInfo.GioiTinh)
                    .Set(KcbDanhsachBenhnhan.Columns.IdGioitinh).EqualTo(objPatientInfo.IdGioitinh)
                    .Set(KcbDanhsachBenhnhan.Columns.DiachiBhyt).EqualTo(objPatientInfo.DiachiBhyt)
                    .Set(KcbDanhsachBenhnhan.Columns.DiaChi).EqualTo(objPatientInfo.DiaChi)
                    .Set(KcbDanhsachBenhnhan.Columns.NamSinh).EqualTo(objPatientInfo.NamSinh)
                    .Set(KcbDanhsachBenhnhan.Columns.NgheNghiep).EqualTo(objPatientInfo.NgheNghiep)
                    .Set(KcbDanhsachBenhnhan.Columns.Email).EqualTo(objPatientInfo.Email)
                    .Set(KcbDanhsachBenhnhan.Columns.MaQuocgia).EqualTo(objPatientInfo.MaQuocgia)
                    .Set(KcbDanhsachBenhnhan.Columns.MaTinhThanhpho).EqualTo(objPatientInfo.MaTinhThanhpho)
                    .Set(KcbDanhsachBenhnhan.Columns.MaQuanhuyen).EqualTo(objPatientInfo.MaQuanhuyen)
                    .Set(KcbDanhsachBenhnhan.Columns.DienThoai).EqualTo(objPatientInfo.DienThoai)
                    .Set(KcbDanhsachBenhnhan.Columns.CoQuan).EqualTo(objPatientInfo.CoQuan)
                    .Set(KcbDanhsachBenhnhan.Columns.NgaySinh).EqualTo(objPatientInfo.NgaySinh)
                    .Set(KcbDanhsachBenhnhan.Columns.Cmt).EqualTo(objPatientInfo.Cmt)
                    .Set(KcbDanhsachBenhnhan.Columns.NgayTiepdon).EqualTo(objPatientInfo.NgayTiepdon)
                    .Set(KcbDanhsachBenhnhan.Columns.NgaySua).EqualTo(objPatientInfo.NgaySua)
                    .Set(KcbDanhsachBenhnhan.Columns.NguoiSua).EqualTo(objPatientInfo.NguoiSua)
                    .Set(KcbDanhsachBenhnhan.Columns.DanToc).EqualTo(objPatientInfo.DanToc)
                    //.Set(KcbDanhsachBenhnhan.Columns.IpMaySua).EqualTo(globalVariables.IpAddress)
                    .Where(KcbDanhsachBenhnhan.Columns.IdBenhnhan).IsEqualTo(objPatientInfo.IdBenhnhan).Execute();
                scope.Complete();
            }

        }
        public ActionResult AddNewPatientExam(KcbDanhsachBenhnhan objPatientInfo, KcbLuotkham objLuotkham, KcbDangkyKcb objRegExam, int KieuKham)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var dbscope = new SharedDbConnectionScope())
                    {
                        UpdatePatientInfo(objPatientInfo);
                        SqlQuery sqlQueryPatientExam = new Select().From(KcbLuotkham.Schema)
                           .Where(KcbLuotkham.Columns.IdBenhnhan).IsNotEqualTo(objLuotkham.IdBenhnhan)
                           .And(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(objLuotkham.MaLuotkham);
                        if (sqlQueryPatientExam.GetRecordCount() > 0)//Nếu BN khác đã lấy mã này
                        {

                            objLuotkham.MaLuotkham = THU_VIEN_CHUNG.KCB_SINH_MALANKHAM();

                        }
                        objLuotkham.IsNew = true;
                        objLuotkham.Save();
                        if (objLuotkham.TrangthaiNoitru >= 1)
                        {
                            SqlQuery sqlQuery = new Select().From(KcbLuotkham.Schema).Where(
                                KcbLuotkham.Columns.MaLuotkham).IsNotEqualTo(objLuotkham.MaLuotkham)
                                .And(KcbLuotkham.Columns.SoBenhAn).IsEqualTo(objLuotkham.SoBenhAn)
                                .And(KcbLuotkham.Columns.TrangthaiNoitru).IsGreaterThanOrEqualTo(1);

                            if (sqlQuery.GetRecordCount() > 0)
                            {
                                var query = new Update(KcbLuotkham.Schema)
                                     .Set(KcbLuotkham.Columns.SoBenhAn).EqualTo(THU_VIEN_CHUNG.LaySoBenhAn())
                                     .Where(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(objLuotkham.MaLuotkham).
                                     Execute();
                            }

                        }
                        if (objRegExam != null)
                        {
                            objRegExam.MaLuotkham = Utility.sDbnull(objLuotkham.MaLuotkham);
                            objRegExam.IdBenhnhan = Utility.Int32Dbnull(objLuotkham.IdBenhnhan);
                            AddRegExam(objRegExam,objLuotkham, false, KieuKham);
                        }
                        scope.Complete();
                        return ActionResult.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                return ActionResult.Error;
            }
        }
        /// <summary>
        /// HAM THUC HIEN HIEN THEM LAN KHAM CUA BENH NHAN
        /// </summary>
        /// <param name="objPatientInfo"></param>
        /// <param name="objLuotkham"></param>
        /// <returns></returns>
        public ActionResult AddNewPatientExam(KcbDanhsachBenhnhan objPatientInfo, KcbLuotkham objLuotkham,  ref string MaLuotkham)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var dbscope = new SharedDbConnectionScope())
                    {
                        UpdatePatientInfo(objPatientInfo);
                        SqlQuery sqlQueryPatientExam = new Select().From(KcbLuotkham.Schema)
                           .Where(KcbLuotkham.Columns.IdBenhnhan).IsNotEqualTo(objLuotkham.IdBenhnhan)
                           .And(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(objLuotkham.MaLuotkham);
                        if (sqlQueryPatientExam.GetRecordCount() > 0)
                        {

                            objLuotkham.MaLuotkham = THU_VIEN_CHUNG.KCB_SINH_MALANKHAM();

                        }
                        objLuotkham.IsNew = true;
                        objLuotkham.Save();
                        if (objLuotkham.TrangthaiNoitru >= 1)
                        {
                            SqlQuery sqlQuery = new Select().From(KcbLuotkham.Schema).Where(
                                KcbLuotkham.Columns.MaLuotkham).IsNotEqualTo(objLuotkham.MaLuotkham)
                                .And(KcbLuotkham.Columns.SoBenhAn).IsEqualTo(objLuotkham.SoBenhAn)
                                .And(KcbLuotkham.Columns.TrangthaiNoitru).IsGreaterThanOrEqualTo(1);

                            if (sqlQuery.GetRecordCount() > 0)
                            {
                                new Update(KcbLuotkham.Schema)
                                    .Set(KcbLuotkham.Columns.SoBenhAn).EqualTo(THU_VIEN_CHUNG.LaySoBenhAn())
                                    .Where(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(objLuotkham.MaLuotkham).
                                    Execute();
                            }

                        }
                        log.Info("Them moi lan kham cho benh nhan Patient_Code=" + objLuotkham.MaLuotkham);
                        //if (!string.IsNullOrEmpty(patientDept.MaLuotkham))
                        //{
                        //    if (objLuotkham.DepartmentId != -1)
                        //    {
                        //        patientDept.MaLuotkham = objLuotkham.MaLuotkham;
                        //        patientDept.IdBenhnhan = objPatientInfo.IdBenhnhan;
                        //        SqlQuery q = new Select().From(TPatientDept.Schema)
                        //            .Where(TPatientDept.Columns.DepartmentId).IsEqualTo(objLuotkham.DepartmentId)
                        //            .And(TPatientDept.Columns.MaLuotkham).IsEqualTo(patientDept.MaLuotkham)
                        //            .And(TPatientDept.Columns.IdBenhnhan).IsEqualTo(patientDept.IdBenhnhan)
                        //            .And(TPatientDept.Columns.Noitru).IsEqualTo(1);

                        //        if (q.GetRecordCount() <= 0)
                        //        {
                        //            log.Info("them moi thong tin cua khoa phong Department_ID=" + patientDept.DepartmentId);
                        //            patientDept.TrangThai = 0;
                        //            patientDept.IsNew = true;
                        //            patientDept.Save();
                        //        }
                        //        else
                        //        {
                        //            new Update(TPatientDept.Schema)
                        //                .Set(TPatientDept.Columns.DepartmentId).EqualTo(patientDept.DepartmentId)
                        //                .Set(TPatientDept.Columns.NguoiSua).EqualTo(patientDept.NguoiSua)
                        //                .Set(TPatientDept.Columns.NgaySua).EqualTo(patientDept.NgaySua)
                        //                .Where(TPatientDept.Columns.MaLuotkham).IsEqualTo(patientDept.MaLuotkham)
                        //                .And(TPatientDept.Columns.IdBenhnhan).IsEqualTo(patientDept.IdBenhnhan)
                        //                .And(TPatientDept.Columns.DepartmentId).IsEqualTo(objLuotkham.DepartmentId)
                        //                .Execute();
                        //        }
                        //    }
                        //}
                        MaLuotkham = objLuotkham.MaLuotkham;
                        scope.Complete();
                        return ActionResult.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                return ActionResult.Error;
            }
        }

        public ActionResult ThemLankhamMoi(KcbDanhsachBenhnhan objPatientInfo, KcbLuotkham objLuotkham, KcbDangkyKcb objRegExam, int KieuKham,ref long id_kham)
        {
            int v_IdBenhnhan = -1;
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var dbscope = new SharedDbConnectionScope())
                    {
                        objPatientInfo.IsNew = true;
                        objPatientInfo.Save();
                        //Thêm lần khám
                        objLuotkham.IdBenhnhan = objPatientInfo.IdBenhnhan;
                        objLuotkham.SoBenhAn = string.Empty;
                        //Tạm bỏ đoạn này
                        //decimal PtramBHYT = THU_VIEN_CHUNG.TinhPtramBHYT(objLuotkham);
                        //if (PtramBHYT != Utility.DecimaltoDbnull(objLuotkham.PtramBhyt))
                        //{
                        //    log.Info(string.Format("voi benh nhan :{0} va MaLuotkham:{1} ", objPatientInfo.TenBenhnhan, objLuotkham.MaLuotkham));
                        //    log.Info(
                        //        string.Format(
                        //            "truong hop phan tram tinh toan sai void ptramBHYT:{0} va truyen tu ngoai vao :{1} ",
                        //            PtramBHYT, objLuotkham.PtramBhyt));
                        //    objLuotkham.PtramBhyt = PtramBHYT;
                        //}
                        objLuotkham.SttKham = THU_VIEN_CHUNG.LaySTTKhamTheoDoituong(objLuotkham.IdDoituongKcb);
                        objLuotkham.NgayTao = globalVariables.SysDate;
                        objLuotkham.NguoiTao = globalVariables.UserName;
                        objLuotkham.IsNew = true;
                        objLuotkham.Save();
                        SqlQuery sqlQueryPatientExam = new Select().From(KcbLuotkham.Schema)
                         .Where(KcbLuotkham.Columns.IdBenhnhan).IsNotEqualTo(objLuotkham.IdBenhnhan)
                         .And(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(objLuotkham.MaLuotkham);
                        if (sqlQueryPatientExam.GetRecordCount() > 0)
                        {
                            string patientCode = THU_VIEN_CHUNG.KCB_SINH_MALANKHAM();
                            new Update(KcbLuotkham.Schema)
                                .Set(KcbLuotkham.Columns.MaLuotkham).EqualTo(patientCode)
                                .Where(KcbLuotkham.Columns.IdBenhnhan).IsEqualTo(objLuotkham.IdBenhnhan)
                                .And(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(objLuotkham.MaLuotkham).Execute();
                            objLuotkham.MaLuotkham = patientCode;
                        }
                        //Đoạn này Rem lại vì ko có ý nghĩa ngoại trú
                        //if (objLuotkham.TrangThai >= 1)
                        //{
                        //    SqlQuery sqlQuery = new Select().From(KcbLuotkham.Schema).Where(
                        //        KcbLuotkham.Columns.MaLuotkham).IsNotEqualTo(objLuotkham.MaLuotkham)
                        //        .And(KcbLuotkham.Columns.SoBenhAn).IsEqualTo(objLuotkham.SoBenhAn)
                        //        .And(KcbLuotkham.Columns.TrangThai).IsGreaterThanOrEqualTo(1);

                        //    if (sqlQuery.GetRecordCount() > 0)
                        //    {
                        //        new Update(KcbLuotkham.Schema)
                        //            .Set(KcbLuotkham.Columns.SoBenhAn).EqualTo(THU_VIEN_CHUNG.LaySoBenhAn())
                        //            .Where(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(objLuotkham.MaLuotkham).
                        //            Execute();
                        //    }

                        //}
                        if (objRegExam != null)//Đôi lúc người dùng không chọn phòng khám
                        {
                            objRegExam.MaLuotkham = Utility.sDbnull(objLuotkham.MaLuotkham);
                            objRegExam.IdBenhnhan = Utility.Int32Dbnull(objLuotkham.IdBenhnhan);
                            id_kham = AddRegExam(objRegExam, objLuotkham, false, KieuKham);
                        }

                        scope.Complete();
                        return ActionResult.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("loi trong qua trinh cap nhap thong tin them moi thong tin benh nhan tiep don {0}", ex);
                return ActionResult.Error;
            }
        }
        public ActionResult UpdateLanKham(KcbDanhsachBenhnhan objPatientInfo, KcbLuotkham objLuotkham, KcbDangkyKcb objRegExam, int KieuKham, decimal PtramBhytCu, decimal PtramBhytgoc )
        {
            ActionResult _ActionResult = ActionResult.Success;
            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var dbscope = new SharedDbConnectionScope())
                    {
                        SqlQuery query =
                            new Select().From(KcbLuotkham.Schema).Where(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(
                                objLuotkham.MaLuotkham).And(KcbLuotkham.Columns.IdBenhnhan).IsEqualTo(
                                    objLuotkham.IdBenhnhan);
                        KcbLuotkham objExam = query.ExecuteSingle<KcbLuotkham>();
                        UpdatePatientInfo(objPatientInfo);
                        //decimal PtramBHYT = THU_VIEN_CHUNG.TinhPtramBHYT(objLuotkham);
                        //if (PtramBHYT != Utility.DecimaltoDbnull(objLuotkham.PtramBhyt))
                        //{
                        //    objLuotkham.PtramBhyt = PtramBHYT;
                        //}
                        objLuotkham.MarkOld();
                        objLuotkham.IsNew = false;
                        objLuotkham.Save();
                        //int recordExam = new Update(KcbLuotkham.Schema)
                        //    .Set(KcbLuotkham.Columns.NguoiLienhe).EqualTo(objLuotkham.NguoiLienhe)
                        //    .Set(KcbLuotkham.Columns.TrangthaiCapcuu).EqualTo(objLuotkham.TrangthaiCapcuu)
                        //    .Set(KcbLuotkham.Columns.LuongCoban).EqualTo(objLuotkham.LuongCoban)
                        //    .Set(KcbLuotkham.Columns.TthaiChuyendi).EqualTo(objLuotkham.TthaiChuyendi)
                        //    .Set(KcbLuotkham.Columns.DienthoaiLienhe).EqualTo(objLuotkham.DienthoaiLienhe)
                        //    .Set(KcbLuotkham.Columns.DiachiLienhe).EqualTo(objLuotkham.DiachiLienhe)
                        //    .Set(KcbLuotkham.Columns.TrieuChung).EqualTo(objLuotkham.TrieuChung)
                        //    .Set(KcbLuotkham.Columns.MatheBhyt).EqualTo(objLuotkham.MatheBhyt)
                        //    .Set(KcbLuotkham.Columns.MaNoicapBhyt).EqualTo(objLuotkham.MaNoicapBhyt)
                        //    .Set(KcbLuotkham.Columns.MaQuyenloi).EqualTo(objLuotkham.MaQuyenloi)
                        //    .Set(KcbLuotkham.Columns.NgaybatdauBhyt).EqualTo(objLuotkham.NgaybatdauBhyt)
                        //    .Set(KcbLuotkham.Columns.NgayketthucBhyt).EqualTo(objLuotkham.NgayketthucBhyt)
                        //    .Set(KcbLuotkham.Columns.NoicapBhyt).EqualTo(objLuotkham.NoicapBhyt)
                        //    .Set(KcbLuotkham.Columns.IdDoituongKcb).EqualTo(objLuotkham.IdDoituongKcb)
                        //    .Set(KcbLuotkham.Columns.IdLoaidoituongKcb).EqualTo(objLuotkham.IdLoaidoituongKcb)
                        //    .Set(KcbLuotkham.Columns.TrangthaiNgoaitru).EqualTo(objLuotkham.TrangthaiNgoaitru)
                        //    .Set(KcbLuotkham.Columns.MaKcbbd).EqualTo(objLuotkham.MaKcbbd)
                        //    .Set(KcbLuotkham.Columns.NoiDongtrusoKcbbd).EqualTo(objLuotkham.NoiDongtrusoKcbbd)
                        //    .Set(KcbLuotkham.Columns.MaDoituongBhyt).EqualTo(objLuotkham.MaDoituongBhyt)
                        //    .Set(KcbLuotkham.Columns.IdKhoatiepnhan).EqualTo(objLuotkham.IdKhoatiepnhan)
                        //    .Set(KcbLuotkham.Columns.DungTuyen).EqualTo(objLuotkham.DungTuyen)
                        //    .Set(KcbLuotkham.Columns.NgayTiepdon).EqualTo(objLuotkham.NgayTiepdon)
                        //    .Set(KcbLuotkham.Columns.MaDoituongKcb).EqualTo(objLuotkham.MaDoituongKcb)
                        //    .Set(KcbLuotkham.Columns.MaKhoaThuchien).EqualTo(objLuotkham.MaKhoaThuchien)
                        //    .Set(KcbLuotkham.Columns.NguoiSua).EqualTo(globalVariables.UserName)
                        //    .Set(KcbLuotkham.Columns.NgaySua).EqualTo(globalVariables.SysDate)
                        //    .Set(KcbLuotkham.Columns.PtramBhyt).EqualTo(objLuotkham.PtramBhyt)
                        //    .Set(KcbLuotkham.Columns.SoBenhAn).EqualTo(objLuotkham.SoBenhAn)
                        //    .Set(KcbLuotkham.Columns.DiaChi).EqualTo(objLuotkham.DiaChi)
                        //    .Set(KcbLuotkham.Columns.DiachiBhyt).EqualTo(objLuotkham.DiachiBhyt)
                        //    .Set(KcbLuotkham.Columns.Cmt).EqualTo(objLuotkham.Cmt)
                        //    .Where(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(objLuotkham.MaLuotkham)
                        //    .And(KcbLuotkham.Columns.IdBenhnhan).IsEqualTo(objLuotkham.IdBenhnhan)
                        //    .Execute();
                        //Kiểm tra nếu % bị thay đổi thì cập nhật lại tất cả các bảng
                        if (PtramBhytCu != Utility.DecimaltoDbnull(objLuotkham.PtramBhyt, 0) || PtramBhytgoc != Utility.DecimaltoDbnull(objLuotkham.PtramBhytGoc, 0))
                           _ActionResult= THU_VIEN_CHUNG.UpdatePtramBHYT(objLuotkham, -1);
                        if (_ActionResult == ActionResult.Cancel)//Báo không cho phép thay đổi phần trăm BHYT do đã có dịch vụ đã thanh toán
                        {
                            return _ActionResult;
                        }

                        if (objRegExam != null)
                        {
                            objRegExam.MaLuotkham = Utility.sDbnull(objLuotkham.MaLuotkham);
                            objRegExam.IdBenhnhan = Utility.Int32Dbnull(objLuotkham.IdBenhnhan);
                            AddRegExam(objRegExam,objLuotkham, false, KieuKham);
                        }
                        scope.Complete();
                        return ActionResult.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Loi trong qua trinh update thong tin benh nhan {0}", ex);
                return ActionResult.Error;
            }
        }
        public  DataTable GetClinicCode(string ClinicCode)
        {
            return SPs.KcbLaythongtinNoikcbbd(ClinicCode).GetDataSet().Tables[0];
        }
    }
}
