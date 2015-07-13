using System;
using System.Data;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI
{
    public partial class frmAssemblyReport : Form
    {
        private DataTable dtList;

        public frmAssemblyReport()
        {
            InitializeComponent();
        }

        private void frmTestDataList_Load(object sender, EventArgs e)
        {
            try
            {
                LoadList();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void LoadList()
        {
            dtList =
                new Select().From(LAssemblyReport.Schema.Name).ExecuteDataSet().Tables[0];
            grdList.DataSource = dtList;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = new Forms.frmAssemblyReport_AU();
                obj.dtList = dtList;
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void frmTestDataList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.N:
                        cmdSave.PerformClick();
                        break;
                    case Keys.U:
                        cmdUpdate.PerformClick();
                        break;
                }
            else
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        cmdExit.PerformClick();
                        break;
                    case Keys.Delete:
                        cmdDelete.PerformClick();
                        break;
                }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdList.CurrentRow != null && grdList.CurrentRow.RowType == RowType.Record)
                    if (
                        Utility.AcceptQuestion(
                            string.Format("Xóa {0}",grdList.GetValue("Report_Name")), "Thông báo", true))
                    {
                        new Delete().From(LAssemblyReport.Schema.Name).Where(LAssemblyReport.Columns.AssemblyReportId).
                            IsEqualTo(Utility.sDbnull(grdList.GetValue("AssemblyReport_ID"))).Execute();
                        grdList.CurrentRow.Delete();
                        grdList.UpdateData();
                    }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdList.CurrentRow == null || grdList.CurrentRow.RowType != RowType.Record) return;
                var obj = new Forms.frmAssemblyReport_AU();
                obj.dtList = dtList;
                obj.txtID.Text = Utility.sDbnull(grdList.GetValue("AssemblyReport_ID"));
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdTestData_DoubleClick(object sender, EventArgs e)
        {
            cmdUpdate.PerformClick();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
           // Reports.ExcelReport.ExportGridEx(grdList);
        }
    }
}