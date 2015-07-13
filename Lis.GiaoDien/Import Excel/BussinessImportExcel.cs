using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SubSonic;
using System.Transactions;
using System.Data;
using NLog;
using SubSonic;
using VNS.Libs;
namespace Lis.GiaoDien
{
    public class BussinessImportExcel
    {
        public BussinessImportExcel() 
        { }
        public delegate void OnDoing(int value);
        public event OnDoing _OnDoing;
        public ActionResult SaveInfos1(List<KskTPatientInfo> lstPatientInfo, List<KskTPatientExam> lstPatientExam, List<KskTAssignInfo> lstAssignInfo, List<KskTAssignDetail> lstAssignDetail, DateTime dtNgayNgayThucHien,string sMaDonVi)
        {
            Logger log = LogManager.GetCurrentClassLogger();            
            string PatientID = "";
            string PatientCode = "";
            string Barcode = "";
            try
            {                
                KskTPatientExam objPatietnExam = null;
                KskTAssignInfo objAssignInfo = null;                
                //PatientCode = this.GetPatientCode();                
                //Barcode = this.GetBarcode();
                using (TransactionScope trans = new TransactionScope())
                {
                    using (SharedDbConnectionScope shs = new SharedDbConnectionScope())
                    {
                        for(int i=0;i<lstPatientInfo.Count;i++)
                        {                                         
                            objPatietnExam = lstPatientExam.Where(e => e.PatientCode.Equals(lstPatientInfo[i].IdentifyNum)).FirstOrDefault();
                            objAssignInfo = lstAssignInfo.Where(e => e.PatientCode.Equals(lstPatientInfo[i].IdentifyNum)).FirstOrDefault();
                            if (objPatietnExam == null || objAssignInfo == null) return ActionResult.Error;
                            if (lstPatientInfo[i].IdentifyNum.Contains("@")) lstPatientInfo[i].IdentifyNum = string.Empty;

                            #region Save PatientInfo
                            lstPatientInfo[i].IsNew = true;
                            lstPatientInfo[i].Save();
                            PatientID = this.GeneratePatientID(lstPatientInfo[i].Id, sMaDonVi, dtNgayNgayThucHien.ToString("yyyyMMdd"));
                            new Update(KskTPatientInfo.Schema)
                                .Set(KskTPatientInfo.Columns.PatientId).EqualTo(PatientID)
                                .Where(KskTPatientInfo.Columns.Id)
                                .IsEqualTo(lstPatientInfo[i].Id).Execute();
                            #endregion

                            #region Save PatientExam
                            PatientCode = GetPatientCode(lstPatientInfo[i].Id);
                            objPatietnExam.PatientCode = PatientCode;
                            objPatietnExam.PatientId = PatientID;
                            objPatietnExam.IsNew = true;
                            objPatietnExam.Save();
                            #endregion

                            #region Save AssignInfo
                            objAssignInfo.AssignCode = Barcode;
                            objAssignInfo.PatientCode = PatientCode;
                            objAssignInfo.PatientId = PatientID;
                            objAssignInfo.IsNew = true;
                            objAssignInfo.Save();
                            #endregion

                            #region Save Assign Detail
                            for (int m = 0; m < lstAssignDetail.Count; m++)
                            {
                                lstAssignDetail[m].AssignId = objAssignInfo.AssignId;
                                lstAssignDetail[m].IsNew = true;
                                lstAssignDetail[m].Save();
                            }
                            #endregion
                            
                            //PatientCode = this.IncreasePatientCode(PatientCode);
                            //Barcode = this.IncreaseBarcode(Barcode);                            
                        }
                        trans.Complete();
                    }                    
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);                
                return ActionResult.Error;
            }
            return ActionResult.Success;
        }

        #region Generate PatientId, PatientCode, Barcode from Database
        public string GetPatientID(string sNgayThucHien, string MaDonVi)
        {
            string PatientID = "";
            StoredProcedure sp = SPs.SpGeneratePatientID(sNgayThucHien, MaDonVi, PatientID);
            sp.Execute();
            sp.OutputValues.ForEach(delegate(object objOutput)
            {
                PatientID = (String)objOutput;
            });
            return PatientID;
        }

        public string GetPatientCode()
        {
            string MaxPatientCode = "";
            StoredProcedure sp = SPs.SpGetPatientCode(MaxPatientCode);
            sp.Execute();
            sp.OutputValues.ForEach(delegate(object objOutput)
            {
                MaxPatientCode = (String)objOutput;
            });
            return MaxPatientCode;
        }

        public string GetBarcode()
        {
            string BarCode = "";
            DataTable dataTable = new DataTable();
            dataTable = SPs.SpKskSinhmachidinhCls(BusinessHelper.GetSysDateTime(), globalVariables.MA_KHOA_THIEN, globalVariables.MIN_STT, globalVariables.MAX_STT).GetDataSet().Tables[0];
            if (dataTable.Rows.Count > 0)
            {
                BarCode = Utility.sDbnull(dataTable.Rows[0]["BARCODE"], "");
            }
            return BarCode;
        }
        #endregion        

        private string GeneratePatientID(long ID,string MaDonVi,string NgayNhap)
        {
            string sPatientID = "";
            string sPrefix = string.Format("{0}{1}", MaDonVi, NgayNhap);
            string sEnd = ID.ToString();
            sEnd = sEnd.PadLeft(5, '0');
            sPatientID = string.Format("{0}{1}", sPrefix, sEnd);
            return sPatientID;
        }

        private string GetPatientCode(long PID)
        {
            string sPatientCode = "";
            DateTime dateTime = new SubSonic.InlineQuery().ExecuteScalar<DateTime>("select getdate()");
            string Year = dateTime.Year.ToString().Substring(2, 2);
            string sEnd = PID.ToString();
            sEnd = sEnd.PadLeft(6, '0');
            sPatientCode = Year + sEnd;
            return sPatientCode;
        }        

        #region Increase ID
        public string IncreasePatientID(string PatientID)
        {
            string sPatientID = "";
            try
            {
                string Prefix = PatientID.Substring(0, PatientID.Length - 5);
                string sEnd = "";
                Int32 iMaxPatientID = Convert.ToInt32(PatientID.Substring(PatientID.Length - 5, 5));
                iMaxPatientID = iMaxPatientID + 1;
                sEnd = iMaxPatientID.ToString();
                sEnd = sEnd.PadLeft(5, '0');
                sPatientID = Prefix + sEnd;
            }
            catch (Exception ex)
            {
                sPatientID = "";
            }
            return sPatientID;
        }
        public string IncreasePatientCode(string PatientCode)
        {
            string sPatientCode = "";
            try
            {
                string sEnd = "";
                string Prefix = PatientCode.Substring(0, PatientCode.Length - 6);
                Int32 iMaxPatientCode = Convert.ToInt32(PatientCode.Substring(PatientCode.Length - 6, 6));
                iMaxPatientCode = iMaxPatientCode + 1;
                sEnd = iMaxPatientCode.ToString();
                sEnd = sEnd.PadLeft(6, '0');
                sPatientCode = Prefix + sEnd;
            }
            catch (Exception ex)
            {
                sPatientCode = "";
            }
            return sPatientCode;
        }

        public string IncreaseBarcode(string Barcode)
        {
            string sBarcode = "";
            try
            {
                string sEnd = "";
                string Prefix = Barcode.Substring(0, Barcode.Length - 4);
                Int32 iMaxBarcode = Convert.ToInt32(Barcode.Substring(Barcode.Length - 4, 4));
                iMaxBarcode = iMaxBarcode + 1;
                sEnd = iMaxBarcode.ToString();
                sEnd = sEnd.PadLeft(4, '0');
                sBarcode = Prefix + sEnd;
            }
            catch (Exception ex)
            {
                sBarcode = "";
            }
            return sBarcode;
        }
        #endregion

        //public void SaveInfos(List<TPatientInfo> lstPatientInfo, List<TPatientExam> lstPatientExam, List<TAssignInfo> lstAssignInfo, List<TAssignDetail> lstAssignDetail, DateTime dtNgayNgayThucHien, string sMaDonVi,ref decimal decFailed)
        //{
        //    TPatientExam objPatietnExam = null;
        //    TAssignInfo objAssignInfo = null;
        //    Logger log = LogManager.GetCurrentClassLogger();
        //    string errMsg = "";
        //    try
        //    {
        //        for (int i = 0; i < lstPatientInfo.Count; i++)
        //        {
        //            objPatietnExam = lstPatientExam.Where(e => e.PatientCode.Equals(lstPatientInfo[i].IdentifyNum)).FirstOrDefault();
        //            objAssignInfo = lstAssignInfo.Where(e => e.PatientCode.Equals(lstPatientInfo[i].IdentifyNum)).FirstOrDefault();
        //            if (objPatietnExam == null || objAssignInfo == null) decFailed = decFailed + 1;
        //            else
        //            {
        //                if (!Save(lstPatientInfo[i], objPatietnExam, objAssignInfo, lstAssignDetail, dtNgayNgayThucHien, sMaDonVi, ref errMsg)) decFailed = decFailed + 1;
        //            }                    
        //        }
        //    }
        //    catch (Exception ex) { }
        //}
        public bool DeleteData(List<int> lstID,bool checkassignstatus)
        {
            Logger log = LogManager.GetCurrentClassLogger();
            string PatientID = "";
            string PatientCode = "";
            string _AssignCode = "";
            SqlQuery query = null;
            try
            {
                int value=0;
                using (TransactionScope trans = new TransactionScope())
                {
                    using (SharedDbConnectionScope shs = new SubSonic.SharedDbConnectionScope())
                    {
                        foreach (int _id in lstID)
                        {
                            bool allowdeleted = true;
                            if (checkassignstatus)
                            {
                                TAssignDetailCollection lst = new Select().From(TAssignDetail.Schema).Where(TAssignDetail.Columns.AssignDetailStatus).IsGreaterThan(1).And(TAssignDetail.Columns.AssignId).In(new Select(TAssignInfo.Columns.AssignId).From(TAssignInfo.Schema).Where(TAssignInfo.Columns.PatientId).IsEqualTo(_id)).ExecuteAsCollection<TAssignDetailCollection>();
                                allowdeleted = lst.Count <= 0;
                            }
                            if (allowdeleted)
                            {
                            //    new Delete().From(TAssignDetail.Schema).Where(TAssignDetail.Columns.AssignId).In(new Select(TAssignInfo.Columns.AssignId).From(TAssignInfo.Schema).Where(TAssignInfo.Columns.PatientId).IsEqualTo(_id)).Execute();
                            //    new Delete().From(TAssignInfo.Schema).Where(TAssignInfo.Columns.PatientId).IsEqualTo(_id).Execute();
                            //    new Delete().From(TPatientExam.Schema).Where(TPatientExam.Columns.PatientId).IsEqualTo(_id).Execute();
                            //    new Delete().From(TPatientInfo.Schema).Where(TPatientInfo.Columns.PatientId).IsEqualTo(_id).Execute();
                            //}
                            value+=1;
                            _OnDoing(value);
                        }
                    }
                    trans.Complete();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }
            return true;
        }
        public bool Save(TPatientInfo objPatientInfo, TPatientExam objPatientExam, TAssignInfo objAssignInfo, List<TAssignDetail> lstAssignDetail, DateTime dtNgayNhap, string MaDonVi,ref string errMsg)
        {
            Logger log = LogManager.GetCurrentClassLogger();    
            string PatientID = "";
            string PatientCode = "";
            string _AssignCode = "";
            SqlQuery query = null;
            try
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    using (SharedDbConnectionScope shs = new SubSonic.SharedDbConnectionScope())
                    {
                        TAssignInfoCollection _lstAssign=new Select().From(TAssignInfo.Schema)
                            .Where(TAssignInfo.Columns.Barcode).IsEqualTo(objAssignInfo.Barcode)
                            .And(TAssignInfo.Columns.RegDate).IsEqualTo(objAssignInfo.RegDate.Date)
                            .ExecuteAsCollection<TAssignInfoCollection>();
                        if (_lstAssign.Count > 0)
                        {
                            Utility.ShowMsg("Barcode " + objAssignInfo.Barcode + " đã được một bệnh nhân khác sử dụng trong ngày " + objAssignInfo.RegDate.Date.ToString("dd/MM/yyyy") + "\nĐề nghị bạn kiểm tra lại");
                            return false;
                        }
                        //PatientID = this.GetPatientID(dtNgayNhap.ToString("yyyyMMdd"), MaDonVi);
                        //PatientCode = this.GetPatientCode();
                        //Barcode = this.GetBarcode();
                        PatientCode = BusinessHelper.GeneratePatientCode();
                        _AssignCode = BusinessHelper.NOITIET_KetNoi_SinhMaBarCode_CD(objPatientExam.MaKhoaThien);
                        #region Save PatientInfo
                        //query = new Select().From(KskTPatientInfo.Schema).Where(KskTPatientInfo.Columns.PatientId).IsEqualTo(PatientID);
                        //if (query.GetRecordCount() > 0)
                        //{
                        //    PatientID = this.GetPatientID(dtNgayNhap.ToString("yyyyMMdd"), MaDonVi);
                        //}
                        //objPatientInfo.PatientId = PatientID;
                        if (objPatientInfo.IdentifyNum.Contains("@")) objPatientInfo.IdentifyNum = "";
                        objPatientInfo.IsNew = true;                        
                        objPatientInfo.Save();
                        #endregion

                        #region Save PatientExam
                        objPatientExam.IsNew = true;
                        objPatientExam.PatientId = objPatientInfo.PatientId;
                        objPatientExam.PatientCode = PatientCode;
                        objPatientExam.Save();
                        query = new Select().From(TPatientExam.Schema)
                                    .Where(TPatientExam.Columns.PatientCode).IsEqualTo(PatientCode)
                                    .And(TPatientExam.Columns.PatientId).IsNotEqualTo(objPatientInfo.PatientId);
                        if (query.GetRecordCount() > 0)
                        {
                            //PatientCode = this.GetPatientCode();
                            PatientCode = BusinessHelper.GeneratePatientCode();
                            new Update(TPatientExam.Schema)
                                .Set(TPatientExam.Columns.PatientCode).EqualTo(PatientCode)
                                .Where(TPatientExam.Columns.PatientId).IsEqualTo(objPatientInfo.PatientId)
                                .And(TPatientExam.Columns.PatientCode).IsEqualTo(objPatientExam.PatientCode)
                                .Execute();
                        }
                        #endregion

                        #region Save AssignInfo
                        objAssignInfo.IsNew = true;
                        objAssignInfo.PatientCode = PatientCode;
                        objAssignInfo.PatientId = objPatientInfo.PatientId;
                        objAssignInfo.AssignCode = _AssignCode;
                        objAssignInfo.MaChidinh = _AssignCode;
                        objAssignInfo.Save();
                        query = new Select().From(TAssignInfo.Schema).Where(TAssignInfo.Columns.AssignCode).IsEqualTo(_AssignCode).And(TAssignInfo.Columns.PatientId).IsNotEqualTo(objPatientInfo.PatientId).And(TAssignInfo.Columns.PatientCode).IsNotEqualTo(PatientCode);
                        if (query.GetRecordCount() > 0)
                        {
                            //Barcode = this.GetBarcode();
                            _AssignCode = BusinessHelper.NOITIET_KetNoi_SinhMaBarCode_CD(objPatientExam.MaKhoaThien);
                            new Update(TAssignInfo.Schema)
                                .Set(TAssignInfo.Columns.AssignCode).EqualTo(_AssignCode)
                                .Set(TAssignInfo.Columns.MaChidinh).EqualTo(_AssignCode)
                                .Where(TAssignInfo.Columns.PatientCode).IsEqualTo(PatientCode)
                                .And(TAssignInfo.Columns.PatientId).IsNotEqualTo(objPatientInfo.PatientId)
                                .Execute();
                        }
                        #endregion

                        #region Save AssignDetail
                        for (int i = 0; i < lstAssignDetail.Count; i++)
                        {
                           
                            lstAssignDetail[i].IsNew = true;
                            lstAssignDetail[i].DaGuiCls=1;
                            lstAssignDetail[i].ModifyDate = BusinessHelper.GetSysDateTime();
                            lstAssignDetail[i].ModifyBy = globalVariables.UserName;
                            lstAssignDetail[i].NguoiGuiCls = globalVariables.UserName;
                            lstAssignDetail[i].NgayGuiCls = BusinessHelper.GetSysDateTime();
                            lstAssignDetail[i].AssignId = objAssignInfo.AssignId;
                            lstAssignDetail[i].Save();
                        }
                        #endregion
                    }
                    trans.Complete();
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                log.Error(ex.Message);                    
                return false;
            }
            return true;
        }
    }         
}
