using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Printing;
using System.Threading;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using SubSonic;
using VNS.Libs;

using LIS.DAL;

using NLog;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class frm_PrintMany : Form
    {
        #region Attributes

        public int CountDataTable = 0;
        public string CurrentPrinterName;
        public DataTable DtPatientInfo;
        public DataTable DtTestType;
        public string StrCode;
        public string StrTestTypeId;
        public string filereporttype = "_ReportType.txt";
        public static string reporttype;
        public BackgroundWorker Worker = new BackgroundWorker();
        public BackgroundWorker WorkerPrint = new BackgroundWorker();
        public DataSet dsPrinting = new DataSet();
        public DataTable dtPatientInfoForPrinting = new DataTable();
        public DataTable dtPrintingStatus = new DataTable();
        public DataTable dtTestInfo;
        public PrintDocument printDocument = new PrintDocument();
        public Logger log;
        #endregion

        public frm_PrintMany()
        {
            InitializeComponent();
            log = LogManager.GetCurrentClassLogger();
            dtPrintingStatus.Columns.Add("Barcode");
            dtPrintingStatus.Columns.Add("Patient_Name");
            dtPrintingStatus.Columns.Add("Patient_ID");
            dtPrintingStatus.Columns.Add("PrinterName");
            dtPrintingStatus.Columns.Add("RowCount");
            dtPrintingStatus.Columns.Add("PrintData", typeof (List<DataRow>));
        }

        private void frm_PrintMany_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPrinter();

                LoadTestType();

                Worker.DoWork += BwPerformSearch;
                Worker.RunWorkerCompleted += BwRunWorkerCompleted;

                WorkerPrint.DoWork += BwPerformPrint;
                WorkerPrint.RunWorkerCompleted += BwRunWorkerPrintCompleted;

                cbDuKQ.CheckedChanged += cbFilter_Checked_Changed;
                cbNotPrint.CheckedChanged += cbFilter_Checked_Changed;

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
                    rboA4.Checked = true;
                }
                else if (reporttype.Trim() == "A5")
                {
                    rboA5.Checked = true;
                }

                cboDate.SelectedIndex = 0;
                grdPatients.CheckAllRecords();

                cmdSearch.PerformClick();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi:" + ex.Message);
                Dispose();
            }
        }

        /// <summary>
        /// Lấy danh sách máy in có trong máy 
        /// </summary>
        private void LoadPrinter()
        {
            try
            {
                if(!File.Exists(@"Config\Printer.txt"))
                {
                    using (StreamWriter sw = File.CreateText(@"Config\Printer.txt"))
                    {
                        sw.Write(printDocument.PrinterSettings.PrinterName);
                    }
                }
                    CurrentPrinterName = File.ReadAllText(@"Config\Printer.txt");
                
                PrinterSettings.StringCollection allPrinters = PrinterSettings.InstalledPrinters;

                var lstPriters = new DataTable();
                lstPriters.Columns.Add("PrinterName");
                foreach (string allPrinter in allPrinters)
                {
                    DataRow row = lstPriters.NewRow();
                    row["PrinterName"] = allPrinter;
                    lstPriters.Rows.Add(row);
                }
                cboPrinter.DataSource = lstPriters;
                cboPrinter.DisplayMember = "PrinterName";
                cboPrinter.ValueMember = "PrinterName";
                cboPrinter.SelectedValue = CurrentPrinterName;

                cboPrinter.SelectedValueChanged += cboPrinter_SelectedValueChanged;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        /// <summary>
        /// Hàm lọc dữ liệu theo checkbox
        /// </summary>
        private void FilterData()
        {
            try
            {
                if (cbDuKQ.Checked)
                {
                    DtPatientInfo.DefaultView.RowFilter = cbNotPrint.Checked
                                                              ? "Has_All_Result_Status = 1 AND Print_Status = 0"
                                                              : "Has_All_Result_Status = 1";
                }
                else if (cbNotPrint.Checked)
                {
                    DtPatientInfo.DefaultView.RowFilter = cbDuKQ.Checked
                                                              ? "Print_Status = 0 AND Has_All_Result_Status = 1"
                                                              : "Print_Status = 0";
                }
                else
                {
                    DtPatientInfo.DefaultView.RowFilter = "1=1";
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cbFilter_Checked_Changed(object sender, EventArgs e)
        {
            try
            {
                FilterData();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void BwPerformSearch(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            try
            {
                StrTestTypeId = GetIdString(DtTestType, grdTestType, "TestType_ID", "-3");
                if (StrTestTypeId == "-1")
                {
                    Utility.ShowMsg("Bạn chưa chọn loại xét nghiệm");
                    grdTestType.Focus();
                    return;
                }
                DtPatientInfo = SPs.SpGetPatientInfoAllForPrintingMany(dtpFromDate.Value.ToShortDateString(),
                                                                       dtpToDate.Value.ToShortDateString(),
                                                                       StrTestTypeId)
                    .GetDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        /// <summary>
        /// Lấy id của các loại xét nghiệm
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="grd"></param>
        /// <param name="colName"></param>
        /// <param name="errResult"></param>
        /// <returns></returns>
        private string GetIdString(DataTable dt, GridEX grd, string colName, string errResult)
        {
            try
            {
                string vResult = errResult;
                int count = 0;
                foreach (GridEXRow grdRow in grd.GetCheckedRows())
                {
                    if (grdRow.IsChecked)
                    {
                        vResult += "," + grdRow.Cells[colName].Value;
                        count += 1;
                    }
                }
                if (count == PreloadedLists.TestType.Rows.Count) vResult = errResult;
                return vResult;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                return "-1";
            }
        }

        private void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            grdPatients.DataSource = DtPatientInfo;
            FilterData();
        }

        /// <summary>
        /// Lấy các loại xét nghiệm
        /// </summary>
        private void LoadTestType()
        {
            try
            {
                DtTestType =
                    new Select(LUserTestType.Columns.UserName, TTestTypeList.Schema.Name + ".*").From(
                        LUserTestType.Schema.Name).
                        LeftOuterJoin(TTestTypeList.TestTypeIdColumn, LUserTestType.TestTypeIdColumn).
                        Where(LUserTestType.Columns.UserName).IsEqualTo(globalModule.gv_sUID).
                        OrderAsc(TTestTypeList.Columns.IntOrder).ExecuteDataSet().Tables[0];
                if (DtTestType.Rows.Count <= 0)
                    DtTestType = new Select().From(TTestTypeList.Schema.Name).OrderAsc(TTestTypeList.Columns.IntOrder).
                        ExecuteDataSet().Tables[0];
                grdTestType.DataSource = DtTestType;
                grdTestType.CheckAllRecords();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (!Worker.IsBusy)
            {
                Worker.RunWorkerAsync();
            }
        }

        private void cboDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboDate.SelectedIndex)
                {
                    case 0:
                        dtpFromDate.Value = DateTime.Now;
                        dtpToDate.Value = DateTime.Now;
                        gbDate.Enabled = false;
                        break;
                    case 1:
                        dtpFromDate.Value = DateTime.Now.AddDays(-1);
                        dtpToDate.Value = DateTime.Now.AddDays(-1);
                        gbDate.Enabled = false;
                        break;
                    case 2:
                        gbDate.Enabled = true;
                        break;
                }
                dtpFromDate.Focus();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        /// <summary>
        /// Kiểm tra tình trạng máy in.
        /// Nếu không có tài liệu chờ in trả về tình trạng sẵn sàng
        /// </summary>
        /// <param name="printer"></param>
        /// <returns></returns>
        private bool CheckPrinterStatus(PrintQueue printer)
        {
            try
            {
                if (printer == null) return false;
                printer.Refresh();
                //Nếu không có tài liệu chờ in trả về tình trạng sẵn sàng
                if (printer.NumberOfJobs <= 0) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Hàm thực hiện in.
        /// Nếu bệnh nhân không có kết quả thì bỏ qua.
        /// </summary>
        /// <param name="patientId"></param>
        private void PerformPrint()
        {
            try
            {
                if (((List<DataRow>) dtPrintingStatus.Rows[0]["PrintData"]).Count <= 0)
                {
                    dtPrintingStatus.Rows.RemoveAt(0);
                    dtPrintingStatus.AcceptChanges();
                    Utility.ShowMsg(Utility.sDbnull(dtPrintingStatus.Rows[0]["Patient_ID"]) + "đã bị xóa");
                    return;
                }
                DataTable dtPrint = ((List<DataRow>) dtPrintingStatus.Rows[0]["PrintData"]).CopyToDataTable();


                ProcessData(ref dtPrint);
                if (SysPara.IsNormalResult == 1)
                {
                    string normalLevel = Utility.Int32Dbnull(dtPrint.Rows[0]["Sex"], 1) == 1
                                             ? "Normal_Level"
                                             : "Normal_LevelW";
                    //ProcessNormalResult(ref DTPrint);
                    Utilities.ProcessNormalResult(ref dtPrint, "Test_result", normalLevel, -1, 1,
                                                  0,
                                                  "binhthuong", false);
                    foreach (DataRow printRow in dtPrint.Rows)
                    {
                        if (
                            (printRow["Test_result"].ToString().Trim().ToUpper().StartsWith("ÂM"))
                            || (printRow["Test_result"].ToString().Trim().ToUpper().Contains("AM"))
                            )
                        {
                            printRow["binhthuong"] = -1;
                        }
                        else if (
                            (printRow["Test_result"].ToString().Trim().ToUpper().StartsWith("DƯƠ"))
                            || (printRow["Test_result"].ToString().Trim().ToUpper().Contains("DUO"))
                            )
                        {
                            printRow["binhthuong"] = 1;
                        }
                    }
                }
                

                var crptBusiness = new CrptBusiness();
                crptBusiness.ReportSourceTable = dtPrint;
                crptBusiness.StrCode = rboA4.Checked ? "A4" : "A5";
                if(rboA4.Checked)
                {
                    crptBusiness.StrCode = "A4";
                }
                else if(rboA5.Checked)
                {
                    crptBusiness.StrCode = "A5";
                }
                else
                {
                    crptBusiness.StrCode = "LABREPORT";
                }
                crptBusiness.FormPreviewTitle = "In kết quả xét nghiệm";
                CrptBusiness.printDateTime = dtpPrintDate.Value.Date;
                CrptBusiness.testTypeList.Clear();
                foreach (var row in grdTestType.GetCheckedRows())
                {
                    var a = row.Cells["TestType_ID"].Value;
                    CrptBusiness.testTypeList.Add(Utility.Int32Dbnull(row.Cells["TestType_ID"].Value));
                }
                crptBusiness.Print(true, dtPrintingStatus.Rows[0]["PrinterName"].ToString());
                
                if (dtPrintingStatus.Rows.Count > 0)
                {
                    dtPrintingStatus.Rows.RemoveAt(0);
                    //log.Debug(Utility.sDbnull(dtPrintingStatus.Rows[0]["Patient_ID"]));
                    dtPrintingStatus.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void BwPerformPrint(object sender, DoWorkEventArgs e)
        {
            var ps = new PrintServer();
            PrintQueueCollection myPrintQueues = ps.GetPrintQueues();
            //Lấy máy in để xử lý trạng thái

            try
            {
                while (dtPrintingStatus.Rows.Count > 0)
                {
                    PrintQueue printer =
                        (from m in myPrintQueues
                         where m.Name.Equals(dtPrintingStatus.Rows[0]["PrinterName"].ToString())
                         select m).FirstOrDefault();
                    if (CheckPrinterStatus(printer))
                    {
                        PerformPrint();
                    }
                    else
                    {
                        //Dừng 4s rồi tiếp tục kiểm tra việc in
                        Thread.Sleep(4000);
                    }
                }
                dsPrinting.Clear();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void BwRunWorkerPrintCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            //Utility.ShowMsg("Bạn đã in thành công", "Thông báo");
        }

        /// <summary>
        /// Hàm lấy dữ liệu và bắt đầu Dowork Print
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strPatientId"></param>
        private void PrintAction(GridEXRow[] arrCheckedRow)
        {
            try
            {
                string strPatientId = string.Join(",", (from grdEx in arrCheckedRow
                                                        select Utility.sDbnull(grdEx.Cells["Patient_ID"].Value)).ToArray
                                                           ());

                StrTestTypeId = GetIdString(DtTestType, grdTestType, "TestType_ID", "-3");

                ////Lấy danh sách các test
                //dtTestInfo =
                //    SPs.SpGetTestInfoByPatientForPrintingManyIDV3(strPatientId, StrTestTypeId, dtpFromDate.Value.Date,
                //                                                  dtpToDate.Value.Date.Date.AddDays(1).
                //                                                      AddMilliseconds(
                //                                                          -2)).GetDataSet().Tables[0];

                ////Lấy danh sách bệnh nhân và các kết quả
                //string vTestId = string.Join(",",
                //                             (from dr in dtTestInfo.AsEnumerable() select Utility.sDbnull(dr.Field<object>("Test_ID")))
                //                                 .ToArray());
                DataTable dtPatientInfo =
                    SPs.GtvtGetTestResultForPrintingManyV2FromDateToDate(strPatientId, StrTestTypeId,
                                                                         dtpFromDate.Value.Date.ToString("yyyy/MM/dd"),
                                                                         dtpToDate.Value.Date.ToString("yyyy/MM/dd")).
                        GetDataSet().Tables[0];

                foreach (GridEXRow row in arrCheckedRow)
                {
                    DataRow dataRow = dtPrintingStatus.NewRow();
                    dataRow["Barcode"] = Utility.sDbnull(row.Cells["Barcode"].Value);
                    dataRow["Patient_Name"] = Utility.sDbnull(row.Cells["Patient_Name"].Value);
                    dataRow["Patient_ID"] = Utility.sDbnull(row.Cells["Patient_ID"].Value);
                    List<DataRow> dt = (from dr in dtPatientInfo.AsEnumerable()
                                        where
                                            Utility.Int32Dbnull(dr.Field<object>("Patient_ID")) ==
                                            Utility.Int32Dbnull(row.Cells["Patient_ID"].Value)
                                        select dr).ToList();
                    dataRow["PrinterName"] = Utility.sDbnull(cboPrinter.SelectedValue);
                    dataRow["PrintData"] = dt;
                    dataRow["RowCount"] = dt.Count;
                    dtPrintingStatus.Rows.Add(dataRow);
                }
                grdPrintingStatus.DataSource = dtPrintingStatus;


                if (!WorkerPrint.IsBusy)
                {
                    WorkerPrint.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi: " + ex);
            }
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
                if (File.Exists(@"logo\logo.bmp")) path = @"logo\logo.bmp";
                if (File.Exists(@"logo\logo.jpg")) path = @"logo\logo.jpg";
                if (File.Exists(@"logo\logo.png")) path = @"logo\logo.png";
                var logoBytes = new byte[] {};
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

                    
                    dr["PID"] = Utility.sDbnull(dr["PID"]) + Utility.sDbnull(dr[TTestInfo.Columns.TestTypeId], "-1");
                    sTitleReport = dr[TTestTypeList.Columns.TestTypeName].ToString().ToUpper();
                    sTitleReport = sTitleReport.Replace("XÉT NGHIỆM", "");
                    dr["sTitleReport"] = sTitleReport;
                    dr["Nguoidung"] = Utilities.gv_sUID;
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

        /// <summary>
        /// Hiển thị form kết quả
        /// </summary>
        private void LoadAllResult()
        {
            try
            {
                if (grdPatients.CurrentRow == null) return;
                var frm = new frmTestResultInfo();
                frm.grwPatient = grdPatients.CurrentRow;
                frm.LoadAllTest = true;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
            
        }

        private void frm_PrintMany_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control)
                {
                    switch (e.KeyCode)
                    {
                            //Tick hết bệnh nhân trên lưới
                        case Keys.A:
                            grdPatients.CheckAllRecords();
                            break;
                            //Bỏ tick hết bệnh nhân trên lưới
                        case Keys.U:
                            grdPatients.UnCheckAllRecords();
                            break;
                            //Xóa tất cả bệnh nhân trong hàng đợi in
                        case Keys.X:
                            RemovePrintQueue(true);
                            break;
                            //Xem tất cả kết quả
                        case Keys.Y:
                            LoadAllResult();
                            break;
                    }
                }
                else
                {
                    if (e.KeyCode == Keys.Escape) Close();
                    if (e.KeyCode == Keys.F4) cmdPrint.PerformClick();
                    if (e.KeyCode == Keys.F3) cmdSearch.PerformClick();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPatients.GetCheckedRows().Any())
                {
                    PrintAction(grdPatients.GetCheckedRows());
                }
                else
                {
                    Utility.ShowMsg("Bạn chưa chọn bản ghi nào để in", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        /// <summary>
        /// Hàm thực hiện xóa bệnh nhân trong hàng đợi in
        /// </summary>
        /// <param name="removeAll">Biến kiểm tra có muốn xóa tất cả không</param>
        private void RemovePrintQueue(bool removeAll)
        {
            try
            {
                if (removeAll)
                {
                    dtPrintingStatus.Clear();
                }
                else
                {
                    DataRow currentRow = (from ps in dtPrintingStatus.AsEnumerable()
                                          where
                                              ps["Patient_ID"].ToString().Equals(
                                                  grdPrintingStatus.CurrentRow.Cells["Patient_ID"].Value)
                                          select ps).FirstOrDefault();
                    dtPrintingStatus.Rows.Remove(currentRow);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdPatients_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            try
            {
                //Tick nút chọn để in từng bệnh nhân
                if (grdPatients.CurrentColumn.Key == "BtnChon")
                {
                    PrintAction(new[] {grdPatients.CurrentRow});
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cboPrinter_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Thay đổi tên máy in ở file cấu hình
                CurrentPrinterName = cboPrinter.SelectedValue.ToString();
                File.WriteAllText(@"Config\Printer.txt", CurrentPrinterName);
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdPrintingStatus_ColumnButtonClick(object sender, ColumnActionEventArgs e)
        {
            try
            {
                //Xóa 1 bệnh nhân trong hàng đợi in
                if (grdPrintingStatus.CurrentColumn.Key == "BtnCancel")
                {
                    RemovePrintQueue(false);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdPatients_RowDoubleClick(object sender, RowActionEventArgs e)
        {
            LoadAllResult();
        }

        private void rboA5_CheckedChanged(object sender, EventArgs e)
        {
            if (rboA5.Checked)
            {
                rboA4.Checked = false;
                File.WriteAllText(filereporttype, "A5");
            }
            else
            {
                File.WriteAllText(filereporttype, "");
            }
        }

        private void rboA4_CheckedChanged(object sender, EventArgs e)
        {
            if (rboA4.Checked)
            {
                rboA5.Checked = false;
                File.WriteAllText(filereporttype, "A4");
            }
            else
            {
                File.WriteAllText(filereporttype, "");
            }
        }
    }
}