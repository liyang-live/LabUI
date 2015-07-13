using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Janus.Windows.GridEX.Export;

using LIS.DAL;
using Lis.Report.UI.Reports;
using SubSonic;
using VNS.Libs;


namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class Frm_PatientNoBarcode : Form
    {
        #region Fields

        private DataTable _tblPatients;
        private DataTable _tblResult;
        private readonly BackgroundWorker _bw = new BackgroundWorker();

        #endregion

        #region Private Method

        /// <summary>
        /// Hàm không đồng bộ sử dụng để lấy dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BwDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var pFromDate = (DateTime) Utility.GetPropertyValue(dtpFromDate,"Value");
                var pToDate = (DateTime) Utility.GetPropertyValue(dtpToDate, "Value");
                var selectedValue = (int)Utility.GetPropertyValue(cboStatus, "SelectedValue");
                var pTestTypeList = (int)Utility.GetPropertyValue(cboTestTypeList, "SelectedValue");
                var ds = SPs.GetPatientByStatusAndTestTypeId(pFromDate, pToDate,selectedValue,pTestTypeList).GetDataSet();

                _tblPatients = ds.Tables[0];
                _tblResult = ds.Tables[1];
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Có lỗi trong quá trình lấy thông tin", "Thông Báo Lỗi !", MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hàm xử lý sau khi đã lấy xong dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Gán hàm xử lý sự kiện
            if (_tblPatients != null) grdPatient.DataSource = _tblPatients;
            if (_tblResult != null) grdTestResult.DataSource = _tblResult.DefaultView;

            grdPatient_SelectionChanged(grdPatient, new EventArgs());
            grdPatient.AutoSizeColumns();
            pgbStatus.Visible = false;
        }

        #endregion

        #region Constructor

        public Frm_PatientNoBarcode()
        {
            InitializeComponent();
        }

        private void Frm_PatientNoBarcode_Load(object sender, EventArgs e)
        {
            // Gán dữ liệu khi Debug
            if (Debugger.IsAttached)
            {
                dtpFromDate.Value = new DateTime(2013, 06, 01);
                dtpToDate.Value = new DateTime(2013, 06, 15);
            }

            // Gán trạng thái về ô Tất cả
            cboStatus.SelectedIndex = 0;

            // Nạp dữ liệu vào combobox TestType
            FillTestTypeList();

            // Gán hàm xử lý sự kiện cho BackgroundWorker
            _bw.DoWork += BwDoWork;
            _bw.RunWorkerCompleted += BwRunWorkerCompleted;
            
        }

        private void FillTestTypeList()
        {
            try
            {
                var dt =
                    new Select(TTestTypeList.Columns.TestTypeId, TTestTypeList.Columns.TestTypeName).From(
                        TTestTypeList.Schema.Name).ExecuteDataSet().Tables[0];
                var dr = dt.NewRow();
                dr[TTestTypeList.Columns.TestTypeId] = -1;
                dr[TTestTypeList.Columns.TestTypeName] = "Tất Cả";
                dt.Rows.InsertAt(dr,0);
                cboTestTypeList.DataSource = dt;
                cboTestTypeList.DisplayMember = TTestTypeList.Columns.TestTypeName;
                cboTestTypeList.ValueMember = TTestTypeList.Columns.TestTypeId;
                cboTestTypeList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi khi nạp danh sách các loại xét nghiệm", "Thông báo", MessageBoxIcon.Error);
            }
        }

        private void LoadDataPrint()
        {

            if (_tblPatients.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu để báo cáo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int soXN = _tblPatients.Rows.Count;
            //int TongLoaiXN = (from r in _tblPatients.AsEnumerable()
            //                  where r[TTestInfo.Columns.TestTypeId].ToString().Equals(TTestTypeList.Columns.TestTypeId)
            //                  select r).Count();

            int bNchuaDk = (from r in _tblPatients.AsEnumerable()
                            where r[TTestInfo.Columns.TestStatus].ToString().Equals("20")
                            select r).Count();
            int xNchuaDk = (from r in _tblPatients.AsEnumerable()
                            where r[TTestInfo.Columns.TestStatus].ToString().Equals("30")
                            select r).Count();
            int xNdaDk = soXN - (xNchuaDk + bNchuaDk);
            var crpt = new Crpt_BaoCaoMau();
            var objForm = new frmPrintPreview("Báo cáo số lượng mẫu", crpt, true, true);
            crpt.SetDataSource(_tblPatients);
            crpt.SetParameterValue("ParentBranchName", globalVariables.ParentBranch_Name);
            crpt.SetParameterValue("BranchName", globalVariables.Branch_Name);
            crpt.SetParameterValue("TongSN", soXN);
            crpt.SetParameterValue("XNdaDK", xNdaDk);
            crpt.SetParameterValue("XNchuaDK", xNchuaDk);
            crpt.SetParameterValue("BNchuaDK", bNchuaDk);
           // crpt.SetParameterValue("TongSoLoaiXN",TongLoaiXN);

            string strFromDateToDate = dtpFromDate.Value == dtpToDate.Value
                    ? string.Format("Ngày {0}", dtpFromDate.Value.ToString("dd/MM/yyyy"))
                    : string.Format("Từ ngày {0} đến ngày {1}", dtpFromDate.Value.ToString("dd/MM/yyyy"),
                                    dtpToDate.Value.ToString("dd/MM/yyyy"));
            crpt.SetParameterValue("Date", strFromDateToDate);

            objForm.ShowDialog();
            // MessageBox.Show(soXN.ToString());
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Hàm tìm kiếm dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_bw.IsBusy)
                {
                    pgbStatus.Visible = true;
                    if (grdPatient.RowCount > 0) _tblPatients.Clear();
                    if (grdTestResult.RowCount > 0) _tblResult.Clear();
                    _bw.RunWorkerAsync();
                }
                else
                {
                    Utility.ShowMsg("Đang tìm kiếm", "Thông báo", MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lỗi trong quá trình tìm kiếm dữ liệu \r\n{0}", ex));
            }
        }

        private void grdPatient_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //var xxx = (from row in grdPatient.SelectedItems.Cast<GridEXRow>()
                //           select row.Cells["Test_ID"].ToString()).ToArray();
                //var allTestId = string.Join(",", xxx);
                _tblResult.DefaultView.RowFilter = string.Format("Test_ID = {0}", grdPatient.GetValue("Test_ID"));
                //_tblResult.DefaultView.RowFilter = string.Format("Test_ID In ({0})", allTestId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void grdTestResult_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e == null) return;
            var gf = new GridEXFormatStyle();
            GridEXCell gridExCell = e.Row.Cells[TResultDetail.Columns.TestResult];
            gf.TextAlignment = Utility.IsNumeric(gridExCell.Value) ? TextAlignment.Far : TextAlignment.Center;
            gridExCell.FormatStyle = gf;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //VietBaIT.LABLink.Reports.ExcelReport.ExportGridEx(grdPatient);
            Stream sw = null;
            try
            {
                var sd = new SaveFileDialog {Filter = "Excel File (*.xls)|*.xls|All Files (*.*)|*.*"};
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    //sw = new FileStream(sd.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    sw = new FileStream(sd.FileName, FileMode.Create);
                    var grdListExporter = new GridEXExporter();
                    grdListExporter.IncludeExcelProcessingInstruction = true;
                    grdListExporter.IncludeFormatStyle = true;
                    grdListExporter.IncludeHeaders = true;
                    grdListExporter.GridEX = grdPatient;
                    grdListExporter.Export(sw);
                    Utility.ShowMsg("Xuất dữ liệu thành công");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            LoadDataPrint();
        }

        #endregion
    }
}