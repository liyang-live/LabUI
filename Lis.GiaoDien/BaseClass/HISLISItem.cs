using System;
using System.Drawing;
using VietBaIT.CommonLibrary;
using NLog;
using System.Data;
using VietBaIT.HISLink.DataAccessLayer;



namespace VietBaIT.HISLink.UI.ControlUtility.BaseClass
{
    public class HISLISItem
    {
            Logger log;
            public bool Result = false;
            public bool isSending = false;
            public delegate void OnAction(int result,string MA_CHIDINH, int vAssign_Id, string PATIENT_CODE, string sLogText, Color resultColor);
            public event OnAction _OnAction;

            public delegate void OnDoing(string sLogText, Color resultColor);
            public event OnDoing _OnDoing;

            private VietBaIT.HISLink.UI.ControlUtility.HLW.HLW _HWL = new VietBaIT.HISLink.UI.ControlUtility.HLW.HLW();
            private string MA_CHIDINH = "-1";
           private int Assign_Id = -1;
            string PATIENT_CODE = "";
            public HISLISItem(string MA_CHIDINH, int vAssign_Id, string PATIENT_CODE, Logger log)
            {
               
                
                this.Assign_Id = vAssign_Id;
                this.MA_CHIDINH = MA_CHIDINH;
                this.PATIENT_CODE = PATIENT_CODE;
                this.log = log;
               //_HWL.DeletePatient()
            }

            public DataTable KetQuaXetNghiem(string sophieu)
            {
                return _HWL.GetLisResult(sophieu).Tables[0];
            }
            //public  DataSet GetHisInfo(string soPhieu)
            //{
            //    DataSet dataSet = null;
            //    try
            //    {


            //        //dataSet = SPs.KetnoiLayChiDinhXetNgiem(soPhieu).GetDataSet();
            //        dataSet = SPs.KetnoiLayChiDinhXetNgiemNew(soPhieu).GetDataSet();
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Trace(soPhieu + "-->Lỗi khi lấy thông tin chỉ định từ HIS:\n"+ex.Message);
            //    }
            //    return dataSet;
            //}
            public DataSet GetHisInfo(int  soPhieu)
            {
                DataSet dataSet = null;
                try
                {


                    //dataSet = SPs.KetnoiLayChiDinhXetNgiem(soPhieu).GetDataSet();
                    dataSet = SPs.KetnoiLayChiDinhXetNgiemNew(soPhieu).GetDataSet();
                }
                catch (Exception ex)
                {
                    log.Trace(soPhieu + "-->Lỗi khi lấy thông tin chỉ định từ HIS:\n" + ex.Message);
                }
                return dataSet;
            }
            public void DoSend()
            {
                int result = -1;
                try
                {

                    isSending = true;
                    string ErrMsg="";
                    _HWL.Url = globalVariables.WebPath;
                    _HWL.Timeout = 30000;
                    _OnDoing("Đang đẩy-->" + PATIENT_CODE + "....", Color.Blue);
                     result = _HWL.InsertPatient(GetHisInfo(Utility.Int32Dbnull(Assign_Id)), MA_CHIDINH, BusinessHelper.GetSysDateTime(), ref ErrMsg);
                    if (result != 0) log.Error(PATIENT_CODE + "-->"+ErrMsg);
                   else log.Trace(PATIENT_CODE + "-->Đẩy dữ liệu vào Lablink thành công");
                    log.Trace("==============================================END=============================================");
                    switch (result)
                    {
                        case -1:
                            _OnAction(result,MA_CHIDINH, Assign_Id, PATIENT_CODE, PATIENT_CODE + "-->Lỗi không xác định", Color.Red);
                           
                            break;
                        case 0:
                            _OnAction(result, MA_CHIDINH, Assign_Id, PATIENT_CODE, PATIENT_CODE + "-->Đẩy dữ liệu vào Lablink thành công", Color.Blue);
                            break;
                        case 1:
                            _OnAction(result, MA_CHIDINH, Assign_Id, PATIENT_CODE, PATIENT_CODE + "-->Không tìm thấy bệnh nhân", Color.Red);
                            break;
                        case 2:
                            _OnAction(result, MA_CHIDINH, Assign_Id, PATIENT_CODE, PATIENT_CODE + "-->Lỗi khi thêm bệnh nhân vào Lablink", Color.Red);
                            break;
                        case 3:
                            _OnAction(result, MA_CHIDINH, Assign_Id, PATIENT_CODE, PATIENT_CODE + "-->Lỗi khi thêm chỉ định Lablink", Color.Red);
                            break;
                        case 4:
                            _OnAction(result, MA_CHIDINH, Assign_Id, PATIENT_CODE, PATIENT_CODE + "-->Barcode đã được sử dụng cho bệnh nhân khác", Color.Red);
                            break;
                        default:
                            _OnAction(result, MA_CHIDINH, Assign_Id, PATIENT_CODE, PATIENT_CODE + "-->Không xác định", Color.Red);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    log.Error(PATIENT_CODE + "-->Lỗi ngoại lệ:\n" + ex.Message);
                    _OnAction(result,MA_CHIDINH, Assign_Id, PATIENT_CODE, PATIENT_CODE + "-->Lỗi ngoại lệ:\n" + ex.Message, Color.Red);
                    
                }
                finally
                {
                    isSending = false;
                }
            }
            
           
    }
}
