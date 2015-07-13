using System;
using System.Data;

using System.Linq;
using SubSonic;
using VNS.Libs;
using LIS.DAL;

using System.Text;

using SubSonic;
using NLog;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Transactions;
using System.Windows.Forms;

namespace VNS.Libs
{
    public class THU_VIEN_CHUNG
    {
       
        
        public static string Laygiatrithamsohethong(string ParamName, bool fromDB)
        {
            try
            {
                string reval = null;
                if (fromDB)
                {
                    SqlQuery sqlQuery =
                        new Select().From(SysSystemParameter.Schema).Where(SysSystemParameter.Columns.SName).IsEqualTo(
                            ParamName);
                    SysSystemParameter objSystemParameter = sqlQuery.ExecuteSingle<SysSystemParameter>();
                    if (objSystemParameter != null) reval = objSystemParameter.SValue;
                }
                else
                {
                    DataRow[] arrDR = globalVariables.gv_dtSysparams.Select(SysSystemParameter.SNameColumn.ColumnName + " ='" + ParamName + "'");
                    if (arrDR.Length > 0) reval = Utility.sDbnull(arrDR[0][SysSystemParameter.SValueColumn.ColumnName]);
                }
                return reval;
            }
            catch
            {
                return null;
            }
        }
        public static SysSystemParameter Laythamsohethong(string ParamName)
        {
            try
            {

                SqlQuery sqlQuery =
                    new Select().From(SysSystemParameter.Schema).Where(SysSystemParameter.Columns.SName).IsEqualTo(
                        ParamName);
                SysSystemParameter objSystemParameter = sqlQuery.ExecuteSingle<SysSystemParameter>();

                return objSystemParameter;
            }
            catch
            {
                return null;
            }
        }
      
        
        public static void Capnhatgiatrithamsohethong(string ParamName, string _value)
        {
            try
            {
                if (Utility.DoTrim(ParamName) == "") return;
                DataRow[] arrDR = globalVariables.gv_dtSysparams.Select(SysSystemParameter.SNameColumn.ColumnName + " ='" + ParamName + "'");
                if (arrDR.Length > 0)
                {
                    arrDR[0][SysSystemParameter.SValueColumn.ColumnName] = _value;
                    globalVariables.gv_dtSysparams.AcceptChanges();
                    new Update(SysSystemParameter.Schema).Set(SysSystemParameter.SValueColumn).EqualTo(_value).Where(SysSystemParameter.SNameColumn).IsEqualTo(ParamName).Execute();
                }
                else
                {
                    SysSystemParameter newItem = new SysSystemParameter();
                    newItem.FpSBranchID = globalVariables.Branch_ID;
                    newItem.SName = ParamName;
                    newItem.SValue = _value;
                    newItem.IMonth = 0;
                    newItem.IYear = 0;
                    newItem.IStatus = 1;
                    newItem.IsNew = true;
                    newItem.Save();
                    DataRow newrow = globalVariables.gv_dtSysparams.NewRow();
                    newrow[SysSystemParameter.FpSBranchIDColumn.ColumnName] = globalVariables.Branch_ID;
                    newrow[SysSystemParameter.SNameColumn.ColumnName] = ParamName;
                    newrow[SysSystemParameter.SValueColumn.ColumnName] = _value;
                    newrow[SysSystemParameter.IYearColumn.ColumnName] = 0;
                    newrow[SysSystemParameter.IMonthColumn.ColumnName] = 0;
                    newrow[SysSystemParameter.IStatusColumn.ColumnName] = 1;
                    globalVariables.gv_dtSysparams.Rows.Add(newrow);
                    globalVariables.gv_dtSysparams.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi khi cập nhật giá trị tham số hệ thống:\n" + ex.Message);
            }
        }
        public static void Capnhatgiatrithamsohethong(string ParamName, string _value,string sdesc)
        {
            try
            {
                if (Utility.DoTrim(ParamName) == "") return;
                DataRow[] arrDR = globalVariables.gv_dtSysparams.Select(SysSystemParameter.SNameColumn.ColumnName + " ='" + ParamName + "'");
                if (arrDR.Length > 0)
                {
                    arrDR[0][SysSystemParameter.SValueColumn.ColumnName] = _value;
                    arrDR[0][SysSystemParameter.SDescColumn.ColumnName] = sdesc;
                    globalVariables.gv_dtSysparams.AcceptChanges();
                    new Update(SysSystemParameter.Schema).Set(SysSystemParameter.SValueColumn).EqualTo(_value).Set(SysSystemParameter.SDescColumn).EqualTo(sdesc).Where(SysSystemParameter.SNameColumn).IsEqualTo(ParamName).Execute();
                }
                else
                {
                    SysSystemParameter newItem = new SysSystemParameter();
                    newItem.FpSBranchID = globalVariables.Branch_ID;
                    newItem.SName = ParamName;
                    newItem.SDesc = sdesc;
                    newItem.SValue = _value;
                    newItem.IMonth = 0;
                    newItem.IYear = 0;
                    newItem.IStatus = 1;
                    newItem.IsNew = true;
                    newItem.Save();
                    DataRow newrow = globalVariables.gv_dtSysparams.NewRow();
                    newrow[SysSystemParameter.FpSBranchIDColumn.ColumnName] = globalVariables.Branch_ID;
                    newrow[SysSystemParameter.SNameColumn.ColumnName] = ParamName;
                    newrow[SysSystemParameter.SDescColumn.ColumnName] = sdesc;
                    newrow[SysSystemParameter.SValueColumn.ColumnName] = _value;
                    newrow[SysSystemParameter.IYearColumn.ColumnName] = 0;
                    newrow[SysSystemParameter.IMonthColumn.ColumnName] = 0;
                    newrow[SysSystemParameter.IStatusColumn.ColumnName] = 1;
                    globalVariables.gv_dtSysparams.Rows.Add(newrow);
                    globalVariables.gv_dtSysparams.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi khi cập nhật giá trị tham số hệ thống:\n" + ex.Message);
            }
        }
        public static string Laygiatrithamsohethong(string ParamName, string defaultval, bool fromDB)
        {
            try
            {
                string reval = defaultval;
                if (fromDB)
                {
                    SqlQuery sqlQuery =
                        new Select().From(SysSystemParameter.Schema).Where(SysSystemParameter.Columns.SName).IsEqualTo(
                            ParamName);
                    SysSystemParameter objSystemParameter = sqlQuery.ExecuteSingle<SysSystemParameter>();
                    if (objSystemParameter != null) reval = objSystemParameter.SValue;
                }
                else
                {
                    DataRow[] arrDR = globalVariables.gv_dtSysparams.Select(SysSystemParameter.SNameColumn.ColumnName + " ='" + ParamName + "'");
                    if (arrDR.Length > 0) reval = Utility.sDbnull(arrDR[0][SysSystemParameter.SValueColumn.ColumnName]);
                }
                return reval;
            }
            catch
            {
                return defaultval;
            }
        }
    
    
        
      
        public static DateTime GetSysDateTime()
        {
            try
            {
                DataTable dataTable = new DataTable();
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                DateTime dateTime = new SubSonic.InlineQuery().ExecuteScalar<DateTime>("select getdate()");

                return dateTime;
            }
            catch
            {
                return DateTime.Now;
            }
        }
    
        public static void LoadThamSoHeThong()
        {
            globalVariables.LUONGCOBAN = Utility.DecimaltoDbnull(THU_VIEN_CHUNG.Laygiatrithamsohethong("BHYT_LUONGCOBAN", "83000", false), 83000);
            globalVariables.gv_strNoiDKKCBBD = THU_VIEN_CHUNG.Laygiatrithamsohethong("BHYT_NOIDANGKY_KCBBD", "016", false);
            globalVariables.gv_strDiadiem = THU_VIEN_CHUNG.Laygiatrithamsohethong("DIA_DIEM", "Hà Nội", false);
            globalVariables.gv_strNoicapBHYT = THU_VIEN_CHUNG.Laygiatrithamsohethong("BHYT_NOICAP_BHYT", "01", false);

            globalVariables.gv_intChophepchongiathuoc =  Utility.Int32Dbnull(THU_VIEN_CHUNG.Laygiatrithamsohethong("CHONGIATHUOC", "0",false),0);
            globalVariables.gv_blnApdungChedoDuyetBHYT = THU_VIEN_CHUNG.Laygiatrithamsohethong("BHYT_TUDONGDUYET", "1", false) == "1";

            globalVariables.gv_GiathuoctheoGiatrongKho = THU_VIEN_CHUNG.Laygiatrithamsohethong("GIATHUOCKHO", "1", false) == "1";
            globalVariables.ChophepNhapkhoLe = Utility.Int32Dbnull(THU_VIEN_CHUNG.Laygiatrithamsohethong("ChophepNhapkhoLe", "0", false));
            globalVariables.gv_strTuyenBHYT = THU_VIEN_CHUNG.Laygiatrithamsohethong("BHYT_TUYEN", "TW", false);
            globalVariables.TrongGio = THU_VIEN_CHUNG.Laygiatrithamsohethong("KCB_TRONGGIO", "0:00-23:59", false);
            globalVariables.TrongNgay = THU_VIEN_CHUNG.Laygiatrithamsohethong("KCB_TRONGNGAY", "2,3,4,5,6,7,CN", false);
            globalVariables.gv_intKT_TT_ChuyenCLS_DV = Utility.Int32Dbnull(THU_VIEN_CHUNG.Laygiatrithamsohethong("KT_TT_ChuyenCLS_DV", "0", false), 0);
            globalVariables.gv_strBHYT_MAQUYENLOI_UUTIEN = THU_VIEN_CHUNG.Laygiatrithamsohethong("BHYT_MAQUYENLOI_UUTIEN", "", false);
            globalVariables.gv_intKT_TT_ChuyenCLS_BHYT = Utility.Int32Dbnull(THU_VIEN_CHUNG.Laygiatrithamsohethong("KT_TT_ChuyenCLS_BHYT", "0", false), 0);
            globalVariables.gv_strICD_BENH_AN_NGOAI_TRU = THU_VIEN_CHUNG.Laygiatrithamsohethong("KCB_ICD_BENH_AN_NGOAI_TRU", "", false);

            globalVariables.gv_intSO_BENH_AN_BATDAU = Utility.Int32Dbnull(THU_VIEN_CHUNG.Laygiatrithamsohethong("KCB_SO_BENH_AN", "-1", false), -1);
            globalVariables.gv_strMA_BHYT_KT = THU_VIEN_CHUNG.Laygiatrithamsohethong("MA_BHYT_KT", "", false);
            globalVariables.gv_strMaQuyenLoiHuongBHYT100Phantram = THU_VIEN_CHUNG.Laygiatrithamsohethong("BHYT_MAQUYENLOI_HUONG100PHANTRAM", "1,2", false);
            globalVariables.gv_intCHARACTERCASING = Utility.Int32Dbnull(THU_VIEN_CHUNG.Laygiatrithamsohethong("KCB_CHARACTERCASING", "0", false), 0);
            globalVariables.gv_intKIEMTRAMATHEBHYT = Utility.Int32Dbnull(THU_VIEN_CHUNG.Laygiatrithamsohethong("BHYT_KIEMTRAMATHE", "0", false), 0);
            globalVariables.gv_intBHYT_TUDONGCHECKTRAITUYEN = Utility.Int32Dbnull(THU_VIEN_CHUNG.Laygiatrithamsohethong("BHYT_TUDONGCHECKTRAITUYEN", "0", false), 0);
            globalVariables.gv_strBOTENDIACHINH = THU_VIEN_CHUNG.Laygiatrithamsohethong("BOTENDIACHINH", "", false);
           

        }
        public static string GetIP4Address()
        {
            try
            {
                if (string.IsNullOrEmpty(globalVariables.IpAddress))
                {
                    string IP4Address = String.Empty;

                    foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                    {
                        if (IPA.AddressFamily == AddressFamily.InterNetwork)
                        {
                            IP4Address = IPA.ToString();
                            break;
                        }
                    }
                    globalVariables.IpAddress = IP4Address;
                }


                return globalVariables.IpAddress;
            }
            catch
            { return "NO-IP"; }
        }
        /// <summary>
        /// hàm thực hiện việc lấy thông tin của địa chỉ mac cho máy tính
        /// </summary>
        /// <returns></returns>

        public static string GetMACAddress()
        {
            try
            {
                if (string.IsNullOrEmpty(globalVariables.IpMacAddress))
                {
                    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                    String sMacAddress = string.Empty;
                    foreach (NetworkInterface adapter in nics)
                    {
                        if (sMacAddress == String.Empty)// only return MAC Address from first card  
                        {
                            IPInterfaceProperties properties = adapter.GetIPProperties();
                            sMacAddress = adapter.GetPhysicalAddress().ToString();
                            globalVariables.IpMacAddress = sMacAddress;
                        }
                    }
                }
                //  Utility.sDbnull()
                return globalVariables.IpMacAddress;
            }
            catch
            { return "NO-ADDRESS"; }
        }
     
       
       
      
        public static string BottomCondition()
        {

            return string.Format("Hệ thống quản lý bệnh viện HIS, Phiếu in lúc : {0} in bởi : {1}",
                                 globalVariables.SysDate,
                                 !string.IsNullOrEmpty(globalVariables.gv_strTenNhanvien) ? globalVariables.gv_strTenNhanvien :
                                 globalVariables.UserName);

        }
     
        public static void CreateXML(DataTable dt)
        {
            try
            {
                if (!dt.Columns.Contains("Logo")) dt.Columns.Add(new DataColumn("Logo", typeof(byte[])));
                if (!dt.Columns.Contains("barcode")) dt.Columns.Add(new DataColumn("barcode", typeof(byte[])));
                bool _XML = Laygiatrithamsohethong("XML", "0", false) == "1";
                string _filePath = "newXML.xml";
                if (!_filePath.Contains(@"\")) _filePath = System.Windows.Forms.Application.StartupPath + @"\Xml4Reports\newXML.xml";
                if (_XML)
                {
                    DataTable newDT = dt.Copy();
                    if (newDT.DataSet != null)
                        newDT.DataSet.WriteXml(_filePath, XmlWriteMode.WriteSchema);
                    else
                    {
                        DataSet ds = new DataSet();
                        ds.Tables.Add(newDT);
                        ds.WriteXml(_filePath, XmlWriteMode.WriteSchema);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
        public static void CreateXML(DataSet ds)
        {
            try
            {
                if (!ds.Tables[0].Columns.Contains("Logo")) ds.Tables[0].Columns.Add(new DataColumn("Logo", typeof(byte[])));
                if (!ds.Tables[0].Columns.Contains("barcode")) ds.Tables[0].Columns.Add(new DataColumn("barcode", typeof(byte[])));
                bool _XML = Laygiatrithamsohethong("XML", "0", false) == "1";
                string _filePath = "newXML.xml";
                if (!_filePath.Contains(@"\")) _filePath = System.Windows.Forms.Application.StartupPath + @"\Xml4Reports\newXML.xml";
                if (_XML)
                {
                   
                        ds.WriteXml(_filePath, XmlWriteMode.WriteSchema);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
        public static void CreateXML(DataTable dt,string xmlfile)
        {
            try
            {
                if (!dt.Columns.Contains("Logo")) dt.Columns.Add(new DataColumn("Logo",typeof(byte[])));
                if (!dt.Columns.Contains("barcode")) dt.Columns.Add(new DataColumn("barcode", typeof(byte[])));
                bool _XML = Laygiatrithamsohethong("XML", "0", false) == "1";
                string _filePath = xmlfile;
                if (!_filePath.ToUpper().Contains(".XML")) _filePath += ".xml";

                if (!_filePath.Contains(@"\")) _filePath = System.Windows.Forms.Application.StartupPath + @"\Xml4Reports\" + xmlfile;
                Utility.CreateFolder(_filePath);
                if (_XML)
                {
                    DataTable newDT = dt.Copy();
                    if (newDT.DataSet != null)
                        newDT.DataSet.WriteXml(_filePath, XmlWriteMode.WriteSchema);
                    else
                    {
                        DataSet ds = new DataSet();
                        ds.Tables.Add(newDT);
                        ds.WriteXml(_filePath, XmlWriteMode.WriteSchema);
                    }
                }
            }
            catch(Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
        public static void CreateXML(DataSet ds, string xmlfile)
        {
            try
            {
                if (!ds.Tables[0].Columns.Contains("Logo")) ds.Tables[0].Columns.Add(new DataColumn("Logo", typeof(byte[])));
                if (!ds.Tables[0].Columns.Contains("barcode")) ds.Tables[0].Columns.Add(new DataColumn("barcode", typeof(byte[])));
                bool _XML = Laygiatrithamsohethong("XML", "0", false) == "1";
                string _filePath = xmlfile;
                if (!_filePath.ToUpper().Contains(".XML")) _filePath += ".xml";
                if (!_filePath.Contains(@"\")) _filePath = System.Windows.Forms.Application.StartupPath + @"\Xml4Reports\" + xmlfile;
                Utility.CreateFolder(_filePath);
                if (_XML)
                {

                    ds.WriteXml(_filePath, XmlWriteMode.WriteSchema);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
   
      
        /// <summary>
        /// hàm thực hiện việc tính phần trăm của bảo hiểm y tế
        /// </summary>
        /// <param name="objPatientExam"></param>
        /// <param name="objRegExam"></param>
       
        public static decimal TinhBhytChitra(decimal PhanTramBH, decimal Origin_Price)
        {
            return PhanTramBH * Origin_Price / 100;
        }
        public static decimal TinhBhytChitra(decimal PhanTramBH, decimal Origin_Price, int IsPayment)
        {
            if (IsPayment == 0)
                return PhanTramBH * Origin_Price / 100;
            else
            {
                return 0;
            }
        }
        public static decimal TinhBnhanChitra(decimal PhanTramBH, decimal Origin_Price)
        {
            return (100 - PhanTramBH) * Origin_Price / 100;
        }
        public static decimal TinhBnhanChitra(decimal PhanTramBH, decimal Origin_Price, int IsPayment)
        {
            if (IsPayment == 0)
                return (100 - PhanTramBH) * Origin_Price / 100;
            else
            {
                return Origin_Price;
            }
        }
      
        public static bool IsNgoaiGio()
        {
            try
            {
                GetTrongNgayTrongGio();
                //Kiểm tra ngày hiện tại có trong tham biến không
                if (KT_TRONGNGAY())
                {
                    // Nếu có trong ngày kiểm tra giờ hiện tại có trong giờ ko
                    if (!Utility.IsBetweenManyTimeranges(globalVariables.SysDate, globalVariables.TrongGio))
                    {
                        //Nếu giờ hiện tại không trong giờ tham biến trả về true. Ngoài giờ khám
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void GetTrongNgayTrongGio()
        {
            globalVariables.TrongGio = THU_VIEN_CHUNG.Laygiatrithamsohethong("KCB_TRONGGIO", "0:00-23:59", false);
            globalVariables.TrongNgay = THU_VIEN_CHUNG.Laygiatrithamsohethong("KCB_TRONGNGAY", "2,3,4,5,6,7,CN", false);
        }
        
        /// <summary>
        /// Kiểm tra so sánh ngày hiện tại với các ngày trong biến TRONGNGAY
        /// </summary>
        /// <returns></returns>
        static bool KT_TRONGNGAY()
        {
            try
            {
                string[] TrongNgay = globalVariables.TrongNgay.Split(',');
                if (TrongNgay.Length > 0)
                {
                    //So sánh giá trị từng ngày trong mảng.
                    foreach (string s in TrongNgay)
                    {
                        switch (s)
                        {
                            //Thứ 2 : giá trị so sánh = 1;
                            case "2":
                                //Nếu so sánh ngày bằng nhau thì trả về true
                                if (_SoSanhNgay(1))
                                {
                                    return true;
                                }
                                break;
                            //Thứ 3 : giá trị so sánh = 2;
                            case "3":
                                if (_SoSanhNgay(2))
                                {
                                    return true;
                                }
                                break;
                            //Thứ 4 : giá trị so sánh = 3;
                            case "4":
                                if (_SoSanhNgay(3))
                                {
                                    return true;
                                }
                                break;
                            //Thứ 5 : giá trị so sánh = 4;
                            case "5":
                                if (_SoSanhNgay(4))
                                {
                                    return true;
                                }
                                break;
                            //Thứ 6 : giá trị so sánh = 5;
                            case "6":
                                if (_SoSanhNgay(5))
                                {
                                    return true;
                                }
                                break;
                            //Thứ 7 : giá trị so sánh = 6;
                            case "7":
                                if (_SoSanhNgay(6))
                                {
                                    return true;
                                }
                                break;
                            //Thứ CN : giá trị so sánh = 0;
                            case "CN":
                                if (_SoSanhNgay(0))
                                {
                                    return true;
                                }
                                break;
                        }
                    }
                    //Nếu hết các giá trị trong mảng ko có giá trị nào bằng ngày hiện tại thì trả về false
                    return false;
                }
                //Nếu mảng giá trị nhỏ hơn không là ko có tham biến thì trả về true
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        /// <summary>
        /// KIểm tra so sánh ngày trong biến truyền vào với ngày hiện tại. Nếu bằng nhau thì trả về true else false
        /// </summary>
        /// <param name="Ngay"></param>
        /// <returns></returns>
        static bool _SoSanhNgay(int Ngay)
        {
            try
            {
                return (int)GetSysDateTime().DayOfWeek == Ngay;
            }
            catch (Exception)
            {
                return false;
            }
        }
     
        public static string GetThamSo_ThuTu()
        {
            string thamso = "THANG";
            SqlQuery sqlQuery =
                new Select().From(SysSystemParameter.Schema).Where(SysSystemParameter.Columns.SName).IsEqualTo(
                    "STT_KHAM");
            SysSystemParameter objSystemParameter = sqlQuery.ExecuteSingle<SysSystemParameter>();
            if (objSystemParameter != null) thamso = objSystemParameter.SValue;
            return thamso;
        }
    
       public static string  LayMaDviLamViec()
       {
           return "NO";
       }
       public static bool IsBaoHiem(byte IdLoaidoituongKcb)
       {
           return IdLoaidoituongKcb == (byte)0;
       }
       public static bool IsBaoHiem(byte? IdLoaidoituongKcb)
       {
           return Utility.ByteDbnull(IdLoaidoituongKcb, 1) == (byte)0;
       }
     
       public static string GetThanhToan_TraiTuyen()
       {
           string sPaymentFlow = "";
           SqlQuery sqlQuery = new Select().From(SysSystemParameter.Schema)
               .Where(SysSystemParameter.Columns.SName).IsEqualTo("TRAITUYEN");
           SysSystemParameter objSystemParameter = sqlQuery.ExecuteSingle<SysSystemParameter>();
           if (objSystemParameter != null) sPaymentFlow = objSystemParameter.SValue;
           return sPaymentFlow;
       }
    
       public static string MaKieuThanhToan(int PaymentType_ID)
       {
           string MaKieu = "";
           switch (PaymentType_ID)
           {
               case 0:
                   MaKieu = "KHAM";
                   break;
               case 1:
                   MaKieu = "KHAM";
                   break;
               case 2:
                   MaKieu = "CLS";
                   break;
               case 3:
                   MaKieu = "THUOC";
                   break;
               case 4:
                   MaKieu = "GIUONG";
                   break;
               case 5:
                   MaKieu = "VT";
                   break;
               case 6:
                   MaKieu = "TAMUNG";
                   break;
               case 7:
                   MaKieu = "AN";
                   break;
               case 8:
                   MaKieu = "GOIDV";
                   break;
           }
           return MaKieu;
       }
      
    }
   
}
