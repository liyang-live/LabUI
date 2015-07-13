using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Lis.LoadData;
using SubSonic;
using System.Xml.Serialization;
using VietBaIT.LABLink.Reports;
using VNS.Libs;

using LIS.DAL;
using System.Drawing.Printing;

using SortOrder = Janus.Windows.GridEX.SortOrder;


namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class frm_ChoosePrint : Form
    {
        public int Patient_ID = -1;
        public DateTime dtFromDate;
        public DateTime dtToDate;
        public GridEX grdList;
        public DataTable m_dtTestType = new DataTable();
        public string filereporttype = "_ReportType.txt";
        public string SentResult = "SentResult.txt";
        public static string reporttype;
        public static string Sent;
        public string StrCode;
        public static DateTime PrintDate;
        public static string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        private readonly BackgroundWorker _bw = new BackgroundWorker();
        private bool IsQuick;
        public PrintDocument printDocument = new PrintDocument();
        /// <summary>
        /// Khởi tạo biến kết nối
        /// </summary>
       // private PgSQL pgSql = new PgSQL();

        public static HisLisProperties HisLisConfig = GetServiceConfig();

        public frm_ChoosePrint()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        /// <summary>
        ///Các sự kiện của Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #region Event 
        private void cmdExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BwPerformPrint(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            try
            {
                CrptBusiness.printDateTime = dtpDatePrint.Value;
                    INPHIEU_XETNGHIEM_GTVT();
            }
            catch(Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
        private void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
        private void frm_ChoosePrint_Load(object sender, EventArgs e)
        {
            dtpDatePrint.Value = DateTime.Now;
            _bw.DoWork += BwPerformPrint;
            _bw.RunWorkerCompleted += BwRunWorkerCompleted;
            grdTestType.DataSource = m_dtTestType;
            grdTestType.CheckAllRecords();
            if (!File.Exists(filereporttype))
            {
                File.WriteAllText(filereporttype, "");
            }
            else
            {
                reporttype = File.ReadAllText(filereporttype);
            }
            if (reporttype.Trim() == "A4")
            {
                chkA4.Checked = true;
            }
            else if (reporttype.Trim() == "A5")
            {
                chkA5.Checked = true;
            }
        }

        private void frm_ChoosePrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        grdTestType.CheckAllRecords();
                        break;
                    case Keys.U:
                        grdTestType.UnCheckAllRecords();
                        break;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Escape) cmdExit.PerformClick();
                if (e.KeyCode == Keys.F4) cmdPrintPhieu.PerformClick();
                if (e.KeyCode == Keys.F5) btnQuickPrint.PerformClick();
            }
        }

        /// <summary>
        /// hàm thực hiện việc in phiếu xét nghiệm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPrintPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                 string send = SysPara.SendResult;
                CrptBusiness.printDateTime = dtpDatePrint.Value;
                
                 IsQuick = false;
                 if (send == "GTVT")
                 {
                     
                     if (!_bw.IsBusy)
                     {
                         _bw.RunWorkerAsync();
                         SendResult();
                     }
                 }
                 else
                 {
                     INPHIEU_XETNGHIEM(false,"In baos cao XN",DateTime.Now);
                 }
            }
            catch (Exception ex )
            {
                Utility.ShowMsg("Lỗi: " + ex);
         //       return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnQuickPrint_Click(object sender, EventArgs e)
        {
            try
            {
                CrptBusiness.printDateTime = dtpDatePrint.Value;
                string send = SysPara.SendResult;
                
                IsQuick = true;
                if (send == "GTVT")
                {

                    if (!_bw.IsBusy)
                    {
                        _bw.RunWorkerAsync();
                        SendResult();
                    }
                }
                else
                {
                    INPHIEU_XETNGHIEM(false, "In baos cao XN", DateTime.Now);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void chkA5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkA5.Checked)
            {
                chkA4.Checked = false;
                File.WriteAllText(filereporttype, "A5");
            }
            else
            {
                File.WriteAllText(filereporttype, "");
            }
        }

        private void chkA4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkA4.Checked)
            {
                chkA5.Checked = false;
                File.WriteAllText(filereporttype, "A4");
            }
            else
            {
                File.WriteAllText(filereporttype, "");
            }
        }

        #endregion

        /// <summary>
        /// Các Hàm sử dụng trong Form
        /// </summary>
        /// <returns></returns>

        #region Function
        public static HisLisProperties GetServiceConfig()
        {
            try
            {
                var myProperties = new HisLisProperties();
                string filePath = string.Format("{0}{1}.xml", AppPath, myProperties.GetType().Name);
                var myFileStream = new FileStream(filePath, FileMode.Open);
                var mySerializer = new XmlSerializer(myProperties.GetType());
                myProperties = (HisLisProperties) mySerializer.Deserialize(myFileStream);
                myFileStream.Close();
                return myProperties;
            }
            catch (Exception ex)
            {
                return new HisLisProperties();
            }
        }

        private void SendResult()
        {
            var listSoPhieu = GetCheck_SoPhieu();
           
            foreach (string vsophieu in listSoPhieu)
            {
                var resultDataSet = SPs.GtvtGetLabPatientInfo(vsophieu).GetDataSet();
                //  _tblResult = resultDataSet.Tables[0];
                var _tblResultDetail = resultDataSet.Tables[1];
                if (_tblResultDetail.Rows.Count > 0)
                {
                    //var n = new OrderLine();
                    //var order = new List<OrderLine>();
                    //int idChiDinh = 0;
                    //foreach (DataRow dr in _tblResultDetail.Rows)
                    //{
                    //    idChiDinh = Utility.Int32Dbnull(dr["CanLamSang_ID"].ToString());
                    //    n.OrderID = idChiDinh;
                    //    n.ItemID = Utility.sDbnull(dr["Item_ID"].ToString());
                    //    n.Result = Utility.sDbnull(dr["Test_Result"].ToString());
                    //    n.Note = Utility.sDbnull(dr["Note"].ToString());
                    //    order.Add(n);
                    //    n = new OrderLine();
                    //}
                    var rDuyetKetQua = _tblResultDetail.Rows[0];
                    string perDept = Utility.sDbnull(rDuyetKetQua["MaKhoa"]);
                    string perDoctor = Utility.sDbnull(rDuyetKetQua["User_Code"]);
                    var perDate = Convert.ToDateTime(Utility.sDbnull(rDuyetKetQua["Test_Date"]));
                    int kt = -1;
                  //  pgSql.ServerName = HisLisConfig.HisServer;
                    //pgSql.DBName = HisLisConfig.HisDataBase;
                   // SentResult_GTVT(pgSql, idChiDinh, order.ToArray(), ref kt);
                    //DuyetKetQua_GTVT(pgSql, idChiDinh, perDept, perDate, perDoctor);
                }
            }
        }


        //public static bool SentResult_GTVT(PgSQL pgSql, int idChiDinh, OrderLine[] orderLine, ref int kt)
        //{
        //    try
        //    {
        //        kt = pgSql.UpdateResult(Convert.ToInt32(idChiDinh), orderLine);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        Utility.ShowMsg("Gửi dữ liệu không thành công sang His");
        //        return false;
        //    }
        //}

        //public static bool DuyetKetQua_GTVT(PgSQL pgSql, int idChiDinh, string perDept, DateTime perDate,
        //                                    string perDoctor)
        //{
        //    try
        //    {
        //      //  pgSql.OrderApproved(Convert.ToInt32(idChiDinh), perDept, perDate, perDoctor);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        Utility.ShowMsg("Duyệt kết quả thất bại");
        //        return false;
        //    }
        //}

        //  private  DataTable m_dtResultDetail=new DataTable();

        public static void ProcessNormalResult(ref DataTable dt)
        {
            try
            {
                double min = 0;
                double max = 0;
                string normal = null;
                const string low = "-1";
                const string hight = "1";
                const string binhthuong = "binhthuong";
                const string testResult = "Test_result";
                var normalLevel = "Normal_Level";
                //var arrResultWithLetters = new ArrayList();
                //arrResultWithLetters.Add("NE");
                //arrResultWithLetters.Add("POS");

                if (!dt.Columns.Contains(binhthuong)) dt.Columns.Add(binhthuong, typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        //'truong hop nam trong khonang co can tren va can duoi
                        normalLevel = Utility.Int32Dbnull(dr["Sex"], 1) == 1 ? "Normal_Level" : "Normal_LevelW";
                        normal = dr[normalLevel].ToString().Trim();
                        if (string.IsNullOrEmpty(dr[testResult].ToString()) | string.IsNullOrEmpty(normal))
                        {
                            dr[binhthuong] = DBNull.Value;
                            continue;
                        }
                        normal = normal.Replace("≤", "<=");
                        normal = normal.Replace("≥", ">=");
                        normal = normal.Replace(" ", "");
                        normal = normal.Replace(",", ".");
                        if (Utility.IsNumeric(dr[testResult]))
                        {
                            dr[binhthuong] = DBNull.Value;
                            double tempResult = Utility.DoubletoDbnull(dr[testResult]);
                            if (normal.IndexOf("-") > 0)
                            {
                                string[] arrstr = null;
                                arrstr = normal.Split('-');
                                min = Utility.DoubletoDbnull(arrstr[0]);
                                max = Utility.DoubletoDbnull(arrstr[1]);
                                bool b1 = tempResult >= min;
                                bool b2 = tempResult <= max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                            }
                            else if (normal.IndexOf("<=") >= 0)
                            {
                                min = double.MinValue;
                                max = Utility.DoubletoDbnull(normal.Substring(2));
                                bool b1 = tempResult >= min;
                                bool b2 = tempResult <= max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                            }
                            else if (normal.IndexOf(">=") >= 0)
                            {
                                max = double.MaxValue;
                                min = Utility.DoubletoDbnull(normal.Substring(2));
                                bool b1 = tempResult >= min;
                                bool b2 = tempResult <= max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                                //'Truong hop chi co can tren
                            }
                            else if (normal.IndexOf("<") >= 0)
                            {
                                min = double.MinValue;
                                max = Utility.DoubletoDbnull(normal.Substring(1));
                                bool b1 = tempResult > min;
                                bool b2 = tempResult < max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                                //'Truong hop chi co can tren
                            }
                            else if (normal.IndexOf(">") >= 0)
                            {
                                max = double.MaxValue;
                                min = Utility.DoubletoDbnull(normal.Substring(1));
                                bool b1 = tempResult > min;
                                bool b2 = tempResult < max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                            }
                            else if (dr[testResult].ToString().Trim().ToUpper() != dr[normalLevel].ToString())
                            {
                                dr[binhthuong] = hight;
                            }
                        }
                        else
                        {
                            //'Truong hop cua Negative va positive
                            //'Dim b As Boolean = (dr(testResult).ToString.Trim.ToUpper.IndexOf(arrResultWithLetters(0)) >= 0)
                            bool b1 = dr[testResult].ToString().Trim().ToUpper().IndexOf("DƯƠ") >= 0;
                            bool b2 = dr[testResult].ToString().Trim().ToUpper().IndexOf("DUO") >= 0;
                            bool b3 = dr[testResult].ToString().Trim().ToUpper().IndexOf("POS") >= 0;
                            if (b1 | b2 | b3) dr[binhthuong] = hight;
                            else dr[binhthuong] = DBNull.Value;
                        }
                    }
                    catch (Exception ex)
                    {
                        dr[binhthuong] = DBNull.Value;
                    }
                }
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
        private void INPHIEU_XETNGHIEM(bool IsQuick, string sTitleReport, DateTime NgayIn)
        {
            string strPatient_ID = string.Empty;
            var DTPrint = new DataTable();
            string vTestTypeId = GetCheckTestType();
            string vTestID = GetcheckTestID();
            if (vTestTypeId == "-1")
            {
                Utility.ShowMsg("Chưa chọn loại xét nghiệm để in");
                return;
            }

            if (grdList.GetCheckedRows().Length > 0)
            {
                foreach (GridEXRow gridExRow in grdList.GetCheckedRows())
                {
                    strPatient_ID += "," + Utility.Int32Dbnull(gridExRow.Cells["Patient_ID"].Value, -1);
                }
                strPatient_ID = strPatient_ID.Remove(0, 1);
            }
            else
            {
                strPatient_ID = Utility.sDbnull(grdList.GetValue("Patient_ID"));
            }
            DTPrint =
                SPs.GtvtGetTestResultForPrintV2FromDateToDate(strPatient_ID, vTestTypeId, vTestID,
                                                              dtFromDate.Date.ToShortDateString(),
                                                              dtToDate.Date.ToShortDateString()).GetDataSet().Tables[0];
            if (DTPrint.Rows.Count <= 0)
            {
                Utility.ShowMsg("Không tìm thấy bản ghi nào", "Thông báo");
                return;
            }
            ProcessData(ref DTPrint);
            if (SysPara.IsNormalResult == 1)
            {
                string normalLevel = Utility.Int32Dbnull(DTPrint.Rows[0]["Sex"], 1) == 1
                                         ? "Normal_Level"
                                         : "Normal_LevelW";
                ProcessNormalResult(ref DTPrint);
                //ProcessNormalResult(ref DTPrint, "Test_result", normalLevel, -1, 1, 0,
                //                                            "binhthuong", false);
                foreach (DataRow row in DTPrint.Rows)
                {
                    if (
                        (row["Test_result"].ToString().Trim().ToUpper().StartsWith("ÂM"))
                        || (row["Test_result"].ToString().Trim().ToUpper().Contains("AM"))
                        )
                    {
                        row["binhthuong"] = -1;
                    }
                    else if (
                        (row["Test_result"].ToString().Trim().ToUpper().StartsWith("DƯƠ"))
                        || (row["Test_result"].ToString().Trim().ToUpper().Contains("DUO"))
                        )
                    {
                        row["binhthuong"] = 1;
                    }
                }
            }
            try
            {
                reporttype = File.ReadAllText(filereporttype);
                if (chkA5.Checked)
                {
                    StrCode = reporttype;
                }
                else if (chkA4.Checked)
                {
                    StrCode = reporttype;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loz" + ex, "Thông báo");
            }

            //Tạo list loại xét nghiệm được tick chọn
            //CrptBusiness.testTypeList.Clear();
            //foreach (var row in grdTestType.GetCheckedRows())
            //{
            //    var a = row.Cells["TestType_ID"].Value;
            //    CrptBusiness.testTypeList.Add(Utility.Int32Dbnull(row.Cells["TestType_ID"].Value));
            //}
            string tieude = "", reportname = "";
            var crpt = Utility.GetReport("LAOKHOA_crpt_DetailTestReport_TESTTYPE", ref tieude, ref reportname);
            var objForm = new frmPrintPreview(sTitleReport, crpt, true, DTPrint.Rows.Count <= 0 ? false : true);
            Utility.UpdateLogotoDatatable(ref DTPrint);
            try
            {

                DTPrint.AcceptChanges();
                crpt.SetDataSource(DTPrint);
                objForm.crptViewer.ReportSource = crpt;
                ////crpt.DataDefinition.FormulaFields["Formula_1"].Text = Strings.Chr(34) + "  PHÒNG TIẾP ĐÓN   ".Replace("#$X$#", Strings.Chr(34) + "&Chr(13)&" + Strings.Chr(34)) + Strings.Chr(34);
                objForm.crptTrinhKyName = Path.GetFileName(reportname);
                Utility.SetParameterValue(crpt, "ParentBranchName", globalVariables.ParentBranch_Name);
                Utility.SetParameterValue(crpt, "BranchName", globalVariables.Branch_Name);
                Utility.SetParameterValue(crpt, "sCurrentDate", Utility.FormatDateTimeWithThanhPho(NgayIn));
                Utility.SetParameterValue(crpt, "sTitleReport", tieude);
                Utility.SetParameterValue(crpt, "BottomCondition", THU_VIEN_CHUNG.BottomCondition());

                objForm.ShowDialog();
                // Utility.DefaultNow(this);
            }
            catch (Exception ex)
            {
                if (globalVariables.IsAdmin)
                {
                    Utility.ShowMsg(ex.ToString());
                }
            }
            //StrCode = reporttype.Trim();
            //// neu rpt A4 hoac A5 ma chua khai bao thi lay me no cai mac dinh(.)
            //if (StrCode == "")
            //{
            //    crptBusiness.StrCode = rdoNoheader.Checked ? "LABNOHEADER" : "LABREPORT";
            //}
            //else
            //{
            //    crptBusiness.StrCode = StrCode;
            //}
            //crptBusiness.FormPreviewTitle = "In kết quả xét nghiệm";
            //crptBusiness.Print(IsQuick, printDocument.PrinterSettings.PrinterName);
        }
        
        private void INPHIEU_XETNGHIEM_GTVT()
        {
            string strPatient_ID = string.Empty;
            var DTPrint = new DataTable();
            string vTestTypeId = GetCheckTestType();
            string vTestID = GetcheckTestID();
            if (vTestTypeId == "-1")
            {
                Utility.ShowMsg("Chưa chọn loại xét nghiệm để in");
                return;
            }

            if (grdList.GetCheckedRows().Length > 0)
            {
                foreach (GridEXRow gridExRow in grdList.GetCheckedRows())
                {
                    strPatient_ID += "," + Utility.Int32Dbnull(gridExRow.Cells["Patient_ID"].Value, -1);
                }
                strPatient_ID = strPatient_ID.Remove(0, 1);
            }
            else
            {
                strPatient_ID = Utility.sDbnull(grdList.GetValue("Patient_ID"));
            }
            DTPrint =
                SPs.GtvtGetTestResultForPrintV2FromDateToDate(strPatient_ID, vTestTypeId, vTestID,
                                                              dtFromDate.Date.ToShortDateString(),
                                                              dtToDate.Date.ToShortDateString()).GetDataSet().Tables[0];
            if (DTPrint.Rows.Count <= 0)
            {
                Utility.ShowMsg("Không tìm thấy bản ghi nào", "Thông báo");
                return;
            }
            ProcessData(ref DTPrint);
            if (SysPara.IsNormalResult == 1)
            {
                string normalLevel = Utility.Int32Dbnull(DTPrint.Rows[0]["Sex"], 1) == 1
                                         ? "Normal_Level"
                                         : "Normal_LevelW";
                //ProcessNormalResult(ref DTPrint);
               //ProcessNormalResult(ref DTPrint, "Test_result", normalLevel, -1, 1, 0,
               //                                             "binhthuong", false);
                foreach (DataRow row in DTPrint.Rows)
                {
                    if (
                        (row["Test_result"].ToString().Trim().ToUpper().StartsWith("ÂM"))
                        || (row["Test_result"].ToString().Trim().ToUpper().Contains("AM"))
                        )
                    {
                        row["binhthuong"] = -1;
                    }
                    else if (
                        (row["Test_result"].ToString().Trim().ToUpper().StartsWith("DƯƠ"))
                        || (row["Test_result"].ToString().Trim().ToUpper().Contains("DUO"))
                        )
                    {
                        row["binhthuong"] = 1;
                    }
                }
            }

            var crptBusiness = new CrptBusiness();
            crptBusiness.ReportSourceTable = DTPrint;

            //thang nao thich in A4 hay A5 thì khai bao trong rpt(.)

            try
            {
                reporttype = File.ReadAllText(filereporttype);
                if (chkA5.Checked)
                {
                    StrCode = reporttype;
                }
                else if (chkA4.Checked)
                {
                    StrCode = reporttype;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loz" + ex, "Thông báo");
            }

            StrCode = reporttype.Trim();
            // neu rpt A4 hoac A5 ma chua khai bao thi lay me no cai mac dinh(.)
            if (StrCode == "")
            {
                crptBusiness.StrCode = rdoNoheader.Checked ? "LABNOHEADER" : "LABREPORT";
            }
            else
            {
                crptBusiness.StrCode = StrCode;
            }
            crptBusiness.FormPreviewTitle = "In kết quả xét nghiệm";
            crptBusiness.Print(IsQuick, printDocument.PrinterSettings.PrinterName);
        }


        /// <summary>
        /// hàm thực hiện việc xử lý thông tin in phiếu
        /// </summary>
        /// <param name="DT"></param>
        private void ProcessData(ref DataTable DT)
        {
            try
            {
                foreach (DataRow drv in DT.Rows)
                {
                    if (Utility.sDbnull(drv["PID"], "-1") == "-1") drv["PID"] = Utility.sDbnull(drv["Barcode"], "");
                }
                DT.AcceptChanges();

                Utility.AddColumToDataTable(ref DT, "BarcodeImg", typeof (byte[]));
                Utility.AddColumToDataTable(ref DT, "sTitleReport", typeof (string));
                Utility.AddColumToDataTable(ref DT, "sSex", typeof (string));
                Utility.AddColumToDataTable(ref DT, "Nguoidung", typeof (string));
                Utility.AddColumToDataTable(ref DT, "logo", typeof (byte[]));
                string path = "";
                if (System.IO.File.Exists(@"logo\logo.bmp")) path = @"logo\logo.bmp";
                if (System.IO.File.Exists(@"logo\logo.jpg")) path = @"logo\logo.jpg";
                if (System.IO.File.Exists(@"logo\logo.png")) path = @"logo\logo.png";
                byte[] logoBytes = new byte[] {};
                if (path != "") logoBytes = Utility.bytGetImage(path);
                var arrayList = new ArrayList();
                string sTitleReport = "";
                foreach (DataRow dr in DT.Rows)
                {
                    dr["BarcodeImg"] =
                        Utility.GenerateBarCode(
                            BarcodeInfo.CreateNewBarcode(Utility.sDbnull(dr["Barcode"], "0000000000")));
                    dr["logo"] = logoBytes;
                    dr["TESTTYPE_NAME"] = Utility.sDbnull(dr["TESTTYPE_NAME"], "").ToUpper();

                    if (dr["Sex"] == DBNull.Value)
                    {
                        dr["sSex"] = ""; 
                    }
                    else if (Utility.Int32Dbnull(dr["Sex"]) == 1)
                    {
                        //  dr["Normal_Level"] = dr["Normal_Level"];
                        dr["sSex"] = "Nam";
                    }
                    else
                    {
                        //dr["Normal_Level"] = dr["Normal_LevelW"];
                        dr["sSex"] = "Nữ";
                    }

                    arrayList.Add(dr[TResultDetail.Columns.TestDetailId].ToString());
                    string sql = string.Format("SELECT Sys_Users.sFullName \n"
        + "FROM   Sys_Users  WITH (NOLOCK)  \n"
        + "WHERE  Sys_Users.PK_sUID = '{0}'", globalVariables.UserName);

                    var userName = new InlineQuery().ExecuteScalar<string>(sql);

                    if (radGopChung.Checked)
                    {
                        //if (Utility.sDbnull(drv["PID"], "-1") == "-1") drv["PID"] = Utility.sDbnull(drv["Barcode"], "");
                        if (grdTestType.GetCheckedRows().Length == 1)
                        {
                            GridEXRow[] gridExRows = grdTestType.GetCheckedRows();
                            sTitleReport =
                                gridExRows[0].Cells[TTestTypeList.Columns.TestTypeName].Value.ToString().ToUpper();
                            sTitleReport = sTitleReport.Replace("XÉT NGHIỆM", "");
                            dr["sTitleReport"] = sTitleReport;
                            dr["Nguoidung"] = userName;
                        }
                    }
                    else
                    {
                        dr["PID"] = Utility.sDbnull(dr["PID"]) + Utility.sDbnull(dr[TTestInfo.Columns.TestTypeId], "-1");
                        sTitleReport = dr[TTestTypeList.Columns.TestTypeName].ToString().ToUpper();
                        sTitleReport = sTitleReport.Replace("XÉT NGHIỆM", "");
                        dr["sTitleReport"] = sTitleReport;
                        dr["Nguoidung"] = userName;
                    }
                }
                DT.AcceptChanges();

                new Update(TResultDetail.Schema)
                    .Set(TResultDetail.Columns.ParaStatus).EqualTo(1)
                    .Where(TResultDetail.Columns.TestDetailId).In(arrayList).Execute();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private string GetCheckTestType()
        {
            string TestType = "-1";
            foreach (GridEXRow gridExRow in grdTestType.GetCheckedRows())
            {
                TestType += "," + Utility.sDbnull(gridExRow.Cells[TTestTypeList.Columns.TestTypeId].Value, "-1");
            }
            return TestType;
        }

        private string GetcheckTestID()
        {
            string Test_ID = "-1";
            foreach (GridEXRow gridExRow in grdTestType.GetCheckedRows())
            {
                Test_ID += "," + Utility.sDbnull(gridExRow.Cells[TTestInfo.Columns.TestId].Value, "-1");
            }
            return Test_ID;
        }

        private void EmptyFolderContents(string folderName)
        {
            foreach (var folder in Directory.GetDirectories(folderName))
            {
                try
                {
                    Directory.Delete(folder, true);
                }
                catch (Exception excep)
                {
                    System.Diagnostics.Debug.WriteLine(excep);
                }
            }
            foreach (var file in Directory.GetFiles(folderName))
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception excep)
                {
                    System.Diagnostics.Debug.WriteLine(excep);
                }
            }
        }

        private void CleanTemporaryFolders()
        {
            try
            {
                String tempFolder = Environment.ExpandEnvironmentVariables("%TEMP%");
                // String recent = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + "\\Recent";
                // String prefetch = Environment.ExpandEnvironmentVariables("%SYSTEMROOT%") + "\\Prefetch";
                EmptyFolderContents(tempFolder);
                // EmptyFolderContents(recent);
                // EmptyFolderContents(prefetch);
            }
            catch (Exception)
            {
            }
        }

        private List<string> GetCheck_SoPhieu()
        {
            return
                grdTestType.GetCheckedRows().Select(
                    gridExRow => Utility.sDbnull(gridExRow.Cells[TTestInfo.Columns.CanLamSangId].Value, "-1")).Distinct()
                    .ToList();
        }
    }

    #endregion
}