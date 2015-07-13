using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Lis.Report.UI.Reports;
using SubSonic;
using VNS.Libs;




namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class Frm_LAOKHOA_SLMAU_THEOBARCODE : Form
    {
        public Frm_LAOKHOA_SLMAU_THEOBARCODE()
        {
            InitializeComponent();
        }

        private DataTable m_Report = new DataTable();
        private DataTable dt;
        private DataTable dtRawResult;

        public StoredProcedure LAOKHOA_SLMAU_THEOBARCODE(DateTime pTestDate, string pFromBarcode, string pToBarcode)
        {
            var sp = new StoredProcedure("LAOKHOA_BAOCAO_SLUONG_MAU", DataService.GetInstance("ORM"), "dbo");
            sp.Command.AddParameter("@TestDate", pTestDate, DbType.DateTime, null, null);
            sp.Command.AddParameter("@FromBarcode", pFromBarcode, DbType.String, null, null);
            sp.Command.AddParameter("@ToBarcode", pToBarcode, DbType.String, null, null);

            return sp;
        }

        public StoredProcedure LAOKHOA_DANHSACH_THEOBARCODE(DateTime pTestDate, string pFromBarcode, string pToBarcode)
        {
            var sp = new StoredProcedure("LAOKHOA_BAOCAO_SLUONG_MAU1", DataService.GetInstance("ORM"), "dbo");
            sp.Command.AddParameter("@TestDate", pTestDate, DbType.DateTime, null, null);
            sp.Command.AddParameter("@FromBarcode", pFromBarcode, DbType.String, null, null);
            sp.Command.AddParameter("@ToBarcode", pToBarcode, DbType.String, null, null);

            return sp;
        }

        private void SoLuongXetNghiem()
        {
            try
            {
                string pFromBarcode = dtpDatePrintFrom.Value.ToString("yyMMdd") +
                                      txtFromBarcode.Text.Trim().PadLeft(4, '0');
                string pToBarcode = dtpDatePrintFrom.Value.ToString("yyMMdd") + txtToBarcode.Text.Trim().PadLeft(4, '0');

                m_Report =
                    LAOKHOA_SLMAU_THEOBARCODE(dtpDatePrintFrom.Value, Utility.sDbnull(pFromBarcode),
                                              Utility.sDbnull(pToBarcode)).GetDataSet().Tables[0];
                if (m_Report.Rows.Count <= 0)
                {
                    Utility.ShowMsg("Không tìm thấy bản ghi nào", "Thông Báo", MessageBoxIcon.Information);
                }
                else
                {
                    string stringBarcode = string.Format("Từ Barcode {0} đến barcode {1}", pFromBarcode, pToBarcode);
                    var crpt = new crpt_SoLuongMauTheoBarcode();
                    var frm = new frmPrintPreview("Thống Kê Số Lượng Mẫu", crpt, true, true);
                    crpt.SetDataSource(m_Report);
                    crpt.DataDefinition.FormulaFields["Formula_1"].Text = "";
                    crpt.SetParameterValue("stringBarcode", stringBarcode);
                    crpt.SetParameterValue("ParentBranchName", globalVariables.ParentBranch_Name);
                    crpt.SetParameterValue("BranchName", globalVariables.Branch_Name);
                    frm.crptViewer.ReportSource = crpt;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.ToString(), "Lỗi xuất báo cáo!");
            }
        }

        public void DanhSachXetNghiem()
        {
            try
            {
                string pFromBarcode = dtpDatePrintFrom.Value.ToString("yyMMdd") +
                                      txtFromBarcode.Text.Trim().PadLeft(4, '0');

                string pToBarcode = dtpDatePrintFrom.Value.ToString("yyMMdd") +
                                    txtToBarcode.Text.Trim().PadLeft(4, '0');

                dt = new DataTable();
                dt.Columns.Add("Patient_ID");
                dt.Columns.Add("Barcode");
                dt.Columns.Add("Patient_Name");
                dt.Columns.Add("TestType_ID");
                dt.Columns.Add("TestType_Name");
                dt.Columns.Add("AllResult");
                dtRawResult =
                    LAOKHOA_DANHSACH_THEOBARCODE(dtpDatePrintFrom.Value, pFromBarcode, pToBarcode).GetDataSet().Tables[0
                        ];
                var patientResult = new StringBuilder();
                var patientResult2 = new StringBuilder();
                dtRawResult.Rows.InsertAt(dtRawResult.NewRow(), 0);
                dtRawResult.Rows[0]["Patient_ID"] = dtRawResult.Rows[1]["Patient_ID"];
                dtRawResult.Rows.Add(dtRawResult.NewRow());
                for (int i = 1; i <= dtRawResult.Rows.Count - 1; i++)
                {
                    if (Utility.sDbnull(dtRawResult.Rows[i]["Patient_ID"]) !=
                        Utility.sDbnull(dtRawResult.Rows[i - 1]["Patient_ID"]))
                    {
                        var newdr = dt.NewRow();
                        newdr["Patient_ID"] = dtRawResult.Rows[i - 1]["Patient_ID"];
                        newdr["Barcode"] = dtRawResult.Rows[i - 1]["Barcode"];
                        newdr["Patient_Name"] = dtRawResult.Rows[i - 1]["Patient_Name"];
                        newdr["AllResult"] = patientResult.ToString();
                        dt.Rows.Add(newdr);
                        patientResult2 = new StringBuilder();
                        patientResult = new StringBuilder();
                    }
                    if ((Utility.sDbnull(dtRawResult.Rows[i]["TestType_Name"]) !=
                         Utility.sDbnull(dtRawResult.Rows[i - 1]["TestType_Name"])) |
                        (Utility.sDbnull(dtRawResult.Rows[i]["Patient_ID"]) !=
                         Utility.sDbnull(dtRawResult.Rows[i - 1]["Patient_ID"])))
                    {
                        //patientResult2.Append(dtRawResult.Rows[i]["TestType_Name"] + ":");
                       // patientResult.Append("</p>");
                        patientResult.Append(string.Format("<font  color=\"red\"><b>{0}</b></font>: ",
                                                           Utility.sDbnull(dtRawResult.Rows[i]["TestType_Name"]).ToUpper
                                                               ()));
                        //   patientResult.Append("</p>");
                    }
                    string value;
                    if (Utility.sDbnull(dtRawResult.Rows[i]["TestType_ID"]) == "2" && Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]) =="")
                    {
                        value = string.Format("{0}; ", "Tổng phân tích huyết học");
                    }

                    else
                    {
                        if (Utility.sDbnull(dtRawResult.Rows[i]["TestType_ID"]) == "10" && Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]) =="")
                        {
                        value = string.Format("{0}; ", "Tổng phân tích nước tiểu");
                         }
                        else
                        {
                            value = string.Format("{0}; ", Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]));
                        }
                        
                    }
                    patientResult.Append(value);
                   // patientResult2.Append(value);
                }
                if (dt.Rows.Count <= 0)
                {
                    Utility.ShowMsg("Không tìm thấy bản ghi nào", "Thông Báo", MessageBoxIcon.Information);
                }
                else
                {
                    string stringBarcode = string.Format("Từ Barcode {0} đến barcode {1}", pFromBarcode, pToBarcode);
                    var crpt = new crpt_LaoKhoa_SLMau_TheoBarcode();
                    var objFrom = new frmPrintPreview("Danh Sách Bệnh Nhân Theo Barcode", crpt, true, true);
                    crpt.SetDataSource(dt);
                    crpt.DataDefinition.FormulaFields["Formula_1"].Text = "";
                    crpt.SetParameterValue("stringBarcode", stringBarcode);
                    crpt.SetParameterValue("ParentBranchName", globalVariables.ParentBranch_Name);
                    crpt.SetParameterValue("BranchName", globalVariables.Branch_Name);
                    objFrom.crptViewer.ReportSource = crpt;
                    objFrom.ShowDialog();
                }
            }
            catch (Exception)
            {
                Utility.ShowMsg("Bạn chưa chọn loại xét nghiệm", "Thông báo", MessageBoxIcon.Warning);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (chkSoLuong.Checked)
            {
                SoLuongXetNghiem();
            }
            else
            {
                DanhSachXetNghiem();
            }
        }

        private void Frm_LAOKHOA_SLMAU_THEOBARCODE_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    btnPrint.PerformClick();
                    break;
                case Keys.Escape:
                    btnCancel.PerformClick();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Frm_LAOKHOA_SLMAU_THEOBARCODE_Load(object sender, EventArgs e)
        {
        }

        private void chkSoLuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSoLuong.Checked) chkDanhSach.Checked = false;
            if (chkDanhSach.Checked) chkSoLuong.Checked = false;
        }

        private void chkDanhSach_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDanhSach.Checked) chkSoLuong.Checked = false;
            if (chkSoLuong.Checked) chkDanhSach.Checked = false;
        }
    }
}