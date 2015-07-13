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
namespace VNS.HIS.BusRule.Classes
{
    public class KCB_CHIDINH_CANLAMSANG
    {
         private NLog.Logger log;
         public KCB_CHIDINH_CANLAMSANG()
        {
            log = LogManager.GetCurrentClassLogger();
        }
         public void XoaChiDinhCLSChitiet(long IdChitietchidinh)
         {
             SPs.ChidinhclsXoaChitiet(IdChitietchidinh).Execute();
         }
         public void GoidichvuXoachitiet(long IdChitietchidinh)
         {
             SPs.GoidichvuXoachitiet(IdChitietchidinh).Execute();
         }
         public DataTable LaythongtinCLS_Thuoc(int ID, string KieuMau)
         {
             return SPs.ChidinhclsLaythongtinChidinhclsTheoid(ID, KieuMau).GetDataSet().Tables[0];
         }
         public DataTable LaythongtininphieuchidinhCLS(string MaChidinh, string PatientCode, int PatientID)
         {
             return SPs.KcbThamkhamLaythongtinclsInphieuTach(MaChidinh, PatientCode,
                                                              PatientID).GetDataSet().
                     Tables[0];
         }
         public DataTable LaythongtininphieuchidinhCLS(KcbChidinhcl objAssignInfo)
         {
             return SPs.KcbThamkhamLaythongtinclsInphieuTach(objAssignInfo.MaChidinh, objAssignInfo.MaLuotkham,
                                                              Utility.Int32Dbnull(objAssignInfo.IdBenhnhan)).GetDataSet().
                     Tables[0];
         }
        
         public ActionResult InsertDataChiDinhCLS(KcbChidinhcl objAssignInfo, KcbLuotkham objPatientExam, KcbChidinhclsChitiet[] arrAssignDetails)
         {
             try
             {
                 using (var scope = new TransactionScope())
                 {
                     using (var sh = new SharedDbConnectionScope())
                     {
                         if (objAssignInfo != null)
                         {
                             if (objPatientExam == null)
                             {
                                 objPatientExam = new Select().From(KcbLuotkham.Schema)
                                     .Where(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(objAssignInfo.MaLuotkham)
                                     .And(KcbLuotkham.Columns.IdBenhnhan).IsEqualTo(
                                         Utility.Int32Dbnull(objAssignInfo.IdBenhnhan)).ExecuteSingle<KcbLuotkham>();
                             }
                             if (objPatientExam != null)
                             {
                                 objAssignInfo.MaChidinh = THU_VIEN_CHUNG.SinhMaChidinhCLS();
                                 objAssignInfo.IsNew = true;
                                 objAssignInfo.Save();
                                 InsertAssignDetail(objAssignInfo, objPatientExam, arrAssignDetails);
                             }
                             else
                             {
                                 return ActionResult.Error;
                             }
                         }
                     }
                     scope.Complete();
                     return ActionResult.Success;
                 }
             }
             catch (Exception exception)
             {
                 log.InfoException("Loi thong tin {0}", exception);
                 return ActionResult.Error;
             }
         }
         public void InsertAssignDetail(KcbChidinhcl objAssignInfo, KcbLuotkham objPatientExam, KcbChidinhclsChitiet[] assignDetail)
         {

             if (objPatientExam == null) return;
             foreach (KcbChidinhclsChitiet objAssignDetail in assignDetail)
             {
                 log.Info("Them moi thong tin cua phieu chi dinh chi tiet voi ma phieu Assign_ID=" +
                          objAssignInfo.IdChidinh);
                 TinhCLS.TinhGiaChiDinhCLS(objPatientExam, objAssignDetail);
                 objAssignDetail.IdDoituongKcb = Utility.Int16Dbnull(objPatientExam.IdDoituongKcb);
                 objAssignDetail.IdChidinh = Utility.Int32Dbnull(objAssignInfo.IdChidinh);
                 objAssignDetail.IdKham = Utility.Int32Dbnull(objAssignInfo.IdKham, -1);
                 decimal PtramBHYT = Utility.DecimaltoDbnull(objPatientExam.PtramBhyt, 0);
                 TinhCLS.GB_TinhPhtramBHYT(objAssignDetail, objPatientExam, PtramBHYT);
                 objAssignDetail.MaLuotkham = objAssignInfo.MaLuotkham;
                 objAssignDetail.IdBenhnhan = objAssignInfo.IdBenhnhan;
                 if (Utility.Int32Dbnull(objAssignDetail.SoLuong) <= 0) objAssignDetail.SoLuong = 1;
                 if (objAssignDetail.IdChitietchidinh <= 0)
                 {
                    
                     objAssignDetail.IsNew = true;
                     objAssignDetail.Save();
                 }
                 else
                 {
                     objAssignDetail.MarkOld();
                     objAssignDetail.IsNew = false;
                     objAssignDetail.Save();
                 }
             }
         }
        
         public ActionResult UpdateDataChiDinhCLS(KcbChidinhcl objAssignInfo, KcbLuotkham objPatientExam, KcbChidinhclsChitiet[] arrAssignDetails)
         {
             try
             {
                 using (var scope = new TransactionScope())
                 {
                     using (var sh = new SharedDbConnectionScope())
                     {
                         if (objPatientExam == null)
                         {
                             objPatientExam = new Select().From(KcbLuotkham.Schema)
                                 .Where(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(objAssignInfo.MaLuotkham)
                                 .And(KcbLuotkham.Columns.IdBenhnhan).IsEqualTo(
                                     Utility.Int32Dbnull(objAssignInfo.IdBenhnhan)).ExecuteSingle<KcbLuotkham>();
                         }
                         new Update(KcbChidinhcl.Schema)
                             .Set(KcbChidinhcl.Columns.IdBacsiChidinh).EqualTo(globalVariables.gv_intIDNhanvien)
                             .Set(KcbChidinhcl.Columns.NgaySua).EqualTo(globalVariables.SysDate)
                             .Set(KcbChidinhcl.Columns.NguoiSua).EqualTo(globalVariables.UserName)
                             .Where(KcbChidinhcl.Columns.IdChidinh).IsEqualTo(Utility.Int32Dbnull(objAssignInfo.IdChidinh)).Execute();
                         if (Utility.Int32Dbnull(objAssignInfo.IdKham) > 0)
                         {
                             new Update(KcbDangkyKcb.Schema)
                                 .Set(KcbDangkyKcb.Columns.IdBacsikham).EqualTo(globalVariables.gv_intIDNhanvien)
                                 .Where(KcbDangkyKcb.IdKhamColumn).IsEqualTo(objAssignInfo.IdKham).Execute();
                         }
                         log.Info("Cap nhap lai thong tin cua phieu chi dinh voi Assign_ID=" + objAssignInfo.IdChidinh);
                         InsertAssignDetail(objAssignInfo, objPatientExam, arrAssignDetails);
                     }
                     scope.Complete();
                     return ActionResult.Success;
                 }
             }
             catch (Exception exception)
             {
                 log.InfoException("Loi thong tin ", exception);
                 return ActionResult.Error;
             }
         }
         public DataTable LaydanhsachCLS_chidinh(string MaDoiTuong, byte Noitru, byte cogiayBHYT, int ID_GoiDV, int dungtuyen, string MA_KHOA_THIEN, string nhomchidinh)
         {
             DataTable dataTable = new DataTable();
             try
             {
                 dataTable = SPs.ChidinhclsLaydanhsachCLSChidinh(MaDoiTuong, Noitru, cogiayBHYT,ID_GoiDV, dungtuyen, MA_KHOA_THIEN, nhomchidinh).GetDataSet().Tables[0];
                 if (!dataTable.Columns.Contains("TenDichvu_khongdau"))
                     dataTable.Columns.Add("TenDichvu_khongdau", typeof(string));
                 if (!dataTable.Columns.Contains("TenChitietDichvu_khongdau"))
                     dataTable.Columns.Add("TenChitietDichvu_khongdau", typeof(string));
                 foreach (DataRow drv in dataTable.Rows)
                 {
                     drv["TenDichvu_khongdau"] = Utility.UnSignedCharacter(drv[DmucDichvucl.Columns.TenDichvu].ToString());
                     drv["TenChitietDichvu_khongdau"] = Utility.UnSignedCharacter(drv[DmucDichvuclsChitiet.Columns.TenChitietdichvu].ToString());
                 }
                 dataTable.AcceptChanges();
             }
             catch (Exception)
             {
                 return null;
             }
             return dataTable;
         }
    }
}
