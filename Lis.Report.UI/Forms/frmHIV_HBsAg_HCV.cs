using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using LIS.DAL;
using Lis.Report.UI;
using SubSonic;
using VNS.Libs;
namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frmHIV_HBsAg_HCV : Form
    {
        private DataTable dtResult;
        private DataTable dtStatistics;
        private string strTestData;

        public frmHIV_HBsAg_HCV()
        {
            InitializeComponent();
        }

        private void frmHIV_HBsAg_HCV_Load(object sender, EventArgs e)
        {
            try
            {
                cboSex.SelectedIndex = 0;
                InitializeData();
                grdStatistics.CheckAllRecords();
                btnSearch.PerformClick();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void InitializeData()
        {
            try
            {
                dtStatistics= new DataTable();
                dtStatistics.Columns.Add("Test_Name", typeof (string));
                dtStatistics.Columns.Add("TestData_Name", typeof(string));
                dtStatistics.Columns.Add("Negative", typeof(int));
                dtStatistics.Columns.Add("Positive", typeof(int));
                dtStatistics.Columns.Add("Total", typeof(int));
                DataRow dr;
                dr = dtStatistics.NewRow(); dr["Test_Name"] = "HIV"; dr["TestData_Name"] = "HIV"; dtStatistics.Rows.Add(dr);
                dr = dtStatistics.NewRow(); dr["Test_Name"] = "HCV"; dr["TestData_Name"] = "HCV"; dtStatistics.Rows.Add(dr);
                dr = dtStatistics.NewRow(); dr["Test_Name"] = "HBsAg"; dr["TestData_Name"] = "HBSII"; dtStatistics.Rows.Add(dr);
                grdStatistics.DataSource = dtStatistics;
                
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                strTestData = "";
                foreach (GridEXRow row in grdStatistics.GetCheckedRows())
                {
                    strTestData += Utility.sDbnull(row.Cells["TestData_Name"].Value) + ",";
                }

                dtResult = SPs.SpGetHivHbsiiHcv(dtpFromDate.Value.Date, dtpToDate.Value.Date.AddDays(1).AddMilliseconds(-1),
                                         Utility.Int16Dbnull(cboSex.SelectedValue),strTestData).GetDataSet().Tables[0];
                if (dtResult.Rows.Count <= 0)
                {
                    Utility.ShowMsg("Không tìm thấy dữ liệu. Chọn lại điều kiện tìm kiếm !");
                    dtResult.Clear();
                    dtResult.AcceptChanges();
                    return;
                }
                grdResult.DataSource = dtResult;

                string sTestName;
                for (int i = 0; i < dtStatistics.Rows.Count; i++)
                {
                    sTestName = Utility.sDbnull(dtStatistics.Rows[i]["TestData_Name"]);
                    dtStatistics.Rows[i]["Negative"] = (from dr in dtResult.AsEnumerable()
                                                        where(dr.Field<object>(sTestName+"_Diagnose") != null) &&
                                                            (dr.Field<string>(sTestName +"_Diagnose") == "Âm tính")
                                                        select dr).Count();
                    dtStatistics.Rows[i]["Positive"] = (from dr in dtResult.AsEnumerable()
                                                        where (dr.Field<object>(sTestName + "_Diagnose") != null) &&
                                                            (dr.Field<string>(sTestName + "_Diagnose") == "Dương tính")
                                                        select dr).Count();
                    dtStatistics.Rows[i]["Total"] = Utility.Int32Dbnull(dtStatistics.Rows[i]["Negative"]) + Utility.Int32Dbnull(dtStatistics.Rows[i]["Positive"]);
                }

                foreach (GridEXRow row in grdStatistics.GetRows())
                {
                    sTestName = Utility.sDbnull(row.Cells["TestData_Name"].Value);
                    grdResult.RootTable.Columns[sTestName].Visible = row.IsChecked;
                    grdResult.RootTable.Columns[sTestName + "_Diagnose"].Visible = row.IsChecked;
                }

                dtStatistics.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnResultToExcel_Click(object sender, EventArgs e)
        {
            ExcelReport.ExportGridEx(grdResult);
        }

        private void btnStatisticsToExcel_Click(object sender, EventArgs e)
        {
            ExcelReport.ExportGridEx(grdStatistics);
        }

        private void frmHIV_HBsAg_HCV_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F3:
                        btnSearch.PerformClick();
                        break;
                    case Keys.F4:
                        btnResultToExcel.PerformClick();
                        break;
                    case Keys.F5:
                        btnStatisticsToExcel.PerformClick();
                        break;
                    case Keys.Escape:
                        btnExit.PerformClick();
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFromDate.Value > dtpToDate.Value)
                dtpToDate.Value = dtpFromDate.Value;
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFromDate.Value > dtpToDate.Value)
                dtpFromDate.Value = dtpToDate.Value;
        }
    }
}
