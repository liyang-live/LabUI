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
    public partial class frm_InPhieuChiDinh : Form
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

        public frm_InPhieuChiDinh()
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
            //_bw.DoWork += BwPerformPrint;
            //_bw.RunWorkerCompleted += BwRunWorkerCompleted;

            grdTestType.DataSource = m_dtTestType;
            grdTestType.CheckAllRecords();
            txtTieuDeIn.Text = FrmDangKyTraCuuNew._myProperties.TieuDeInPhieuChiDinh;
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
                     InPhieuChiDinh(false,txtTieuDeIn.Text,dtpDatePrint.Value);
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
                    InPhieuChiDinh(true, txtTieuDeIn.Text, dtpDatePrint.Value);
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

   
       
        private void InPhieuChiDinh(bool IsQuick, string sTitleReport, DateTime NgayIn)
        {
            int strPatient_ID = -1;
            var DTPrint = new DataTable();
            string vTestTypeId = GetCheckTestType();
            string vTestID = GetcheckTestID();
            if (vTestTypeId == "-1")
            {
                Utility.ShowMsg("Chưa chọn loại xét nghiệm để in");
                return;
            }

            //if (grdList.GetCheckedRows().Length > 0)
            //{
            //    foreach (GridEXRow gridExRow in grdList.GetCheckedRows())
            //    {
            //        strPatient_ID += "," + Utility.Int32Dbnull(gridExRow.Cells["Patient_ID"].Value, -1);
            //    }
            //    strPatient_ID = strPatient_ID.Remove(0, 1);
            //}
            //else
            {
                strPatient_ID = Utility.Int32Dbnull(grdList.GetValue("Patient_ID"));
            }
            DTPrint =
                SPs.InPhieuChiDinhXetNghiem(strPatient_ID, vTestTypeId, vTestID).GetDataSet().Tables[0];
             if (DTPrint.Rows.Count <= 0)
            {
                Utility.ShowMsg("Không tìm thấy bản ghi nào", "Thông báo");
                return;
            }
            string tieude = "", reportname = "";
            var crpt = Utility.GetReport("crpt_InPhieuChiDinhXetNghiem", ref tieude, ref reportname);
            var objForm = new frmPrintPreview(sTitleReport, crpt, true, DTPrint.Rows.Count <= 0 ? false : true);
            Utility.UpdateLogotoDatatable(ref DTPrint);
            Utility.AddColumToDataTable(ref DTPrint, "BarcodeImg", typeof(byte[]));
            foreach (DataRow dr in DTPrint.Rows)
            {
                dr["BarcodeImg"] =
                    Utility.GenerateBarCode(
                        BarcodeInfo.CreateNewBarcode(Utility.sDbnull(dr["Barcode"], "0000000000")));
            }
          try
            {
                DTPrint.AcceptChanges();
                crpt.SetDataSource(DTPrint);
                objForm.crptViewer.ReportSource = crpt;
                objForm.crptTrinhKyName = Path.GetFileName(reportname);
                Utility.SetParameterValue(crpt, "ParentBranchName", globalVariables.ParentBranch_Name);
                Utility.SetParameterValue(crpt, "BranchName", globalVariables.Branch_Name);
                Utility.SetParameterValue(crpt, "sCurrentDate", Utility.FormatDateTimeWithThanhPho(NgayIn));
                Utility.SetParameterValue(crpt, "sTitleReport", sTitleReport);
                Utility.SetParameterValue(crpt, "BottomCondition", THU_VIEN_CHUNG.BottomCondition());
                if (!IsQuick)
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
                
                    Utility.ShowMsg(ex.ToString());
              
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