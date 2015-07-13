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
    public partial class frm_InPhieuKetQua : Form
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
        private bool IsQuick=false;
        public PrintDocument printDocument = new PrintDocument();
        /// <summary>
        /// Khởi tạo biến kết nối
        /// </summary>
       // private PgSQL pgSql = new PgSQL();

        public static HisLisProperties HisLisConfig = GetServiceConfig();

        public frm_InPhieuKetQua()
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
     
        private void frm_ChoosePrint_Load(object sender, EventArgs e)
        {
            dtpDatePrint.Value = DateTime.Now;
           grdTestType.DataSource = m_dtTestType;
            grdTestType.CheckAllRecords();
            txtTieuDeIn.Text = FrmDangKyTraCuuNew._myProperties.TieuDeInPhieuKq;
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
               {
                   INPHIEU_XETNGHIEM(false, txtTieuDeIn.Text, dtpDatePrint.Value);
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
                {
                    INPHIEU_XETNGHIEM(true, txtTieuDeIn.Text, dtpDatePrint.Value);
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
        private void ProcessData(ref DataTable DT)
        {
            try
            {
                foreach (DataRow drv in DT.Rows)
                {
                    if (Utility.sDbnull(drv["PID"], "-1") == "-1") drv["PID"] = Utility.sDbnull(drv["Barcode"], "");
                }
                DT.AcceptChanges();

                Utility.AddColumToDataTable(ref DT, "BarcodeImg", typeof(byte[]));
                Utility.AddColumToDataTable(ref DT, "sTitleReport", typeof(string));
                Utility.AddColumToDataTable(ref DT, "sSex", typeof(string));
                Utility.AddColumToDataTable(ref DT, "Nguoidung", typeof(string));
                Utility.AddColumToDataTable(ref DT, "logo", typeof(byte[]));
                string path = "";
                if (System.IO.File.Exists(@"logo\logo.bmp")) path = @"logo\logo.bmp";
                if (System.IO.File.Exists(@"logo\logo.jpg")) path = @"logo\logo.jpg";
                if (System.IO.File.Exists(@"logo\logo.png")) path = @"logo\logo.png";
                byte[] logoBytes = new byte[] { };
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
        private void ProcessNormalResult(ref DataTable dt)
        {
            try
            {
                double min = 0;
                double max = 0;
                string normal = null;
                const string low = "Low";
                const string hight = "High";
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
            string vTestTypeId; //= GetCheckTestType();
            string vTestID;//= GetcheckTestID();
            string Test_ID = "-1";
            string TestType = "-1";
            foreach (GridEXRow gridExRow in grdTestType.GetCheckedRows())
            {
                TestType += "," + Utility.sDbnull(gridExRow.Cells[TTestTypeList.Columns.TestTypeId].Value, "-1");
                Test_ID += "," + Utility.sDbnull(gridExRow.Cells[TTestInfo.Columns.TestId].Value, "-1");
            }
            vTestTypeId = TestType;
            vTestID = Test_ID;
            if (vTestTypeId == "-1")
            {
                Utility.ShowMsg("Chưa chọn loại xét nghiệm để in");
                return;
            }


            strPatient_ID = Utility.sDbnull(grdTestType.GetValue("Patient_ID"));

            DTPrint =
                SPs.GtvtGetTestResultForPrintV2FromDateToDate(strPatient_ID, vTestTypeId, vTestID, dtFromDate.ToShortDateString(),
                                                              dtToDate.ToShortDateString()).GetDataSet().Tables[0];
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
            //try
            //{
            //    reporttype = File.ReadAllText(filereporttype);
            //    if (chkA5.Checked)
            //    {
            //        StrCode = reporttype;
            //    }
            //    else if (chkA4.Checked)
            //    {
            //        StrCode = reporttype;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Loz" + ex, "Thông báo");
            //}

            string tieude = "", reportname = "";
            var crpt = Utility.GetReport("crpt_InPhieuKetQuaXetNghiem", ref tieude, ref reportname);
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
                //Utility.SetParameterValue(crpt, "sCurrentDate", dtpDatePrint(NgayIn));
                Utility.SetParameterValue(crpt, "sTitleReport", tieude);
                Utility.SetParameterValue(crpt, "BottomCondition", THU_VIEN_CHUNG.BottomCondition());
                if (IsQuick)
                {
                    objForm.ShowDialog();
                    // Utility.DefaultNow(this);
                }
                else
                {
                    objForm.addTrinhKy_OnFormLoad();
                    crpt.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
                    crpt.PrintToPrinter(0, true, 0, 0);
                    crpt.Dispose();
                    CleanTemporaryFolders();
                }
            }
            catch (Exception ex)
            {
                if (globalVariables.IsAdmin)
                {
                    Utility.ShowMsg(ex.ToString());
                }
            }

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