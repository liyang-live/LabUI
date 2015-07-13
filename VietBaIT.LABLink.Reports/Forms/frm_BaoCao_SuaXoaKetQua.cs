using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CrystalDecisions.CrystalReports.Engine;
using Janus.Windows.GridEX;
using SubSonic;
using VietBaIT.LABLink.LoadEnvironments;
using VietBaIT.LABLink.Reports.Reports;
using Vietbait.Lablink.Model;
using VietBaIT.CommonLibrary;
using lablinkhelper;
using System.Windows.Forms;

namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frm_BaoCao_SuaXoaKetQua : Form
    {
        public DataTable dt;
        public frm_BaoCao_SuaXoaKetQua()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDocument crpt;
                
                string s;
                if (cboTestType.SelectedValue.ToString() == "-1")
                {
                    s = "TẤT CẢ CÁC LOẠI XÉT NGHIỆM";
                }
                else
                {
                    s = string.Format("XÉT NGHIỆM {0}", cboTestType.SelectedText.ToUpper());
                }
                var ds =
                        SPs.SpBaoCaoXoaKetQua(dtpFromDate.Value.ToString("yyyy/MM/dd"),
                                              dtpToDate.Value.ToString("yyyy/MM/dd"),
                                              Utility.Int32Dbnull(cboTestType.SelectedValue, -1),
                                              Utility.sDbnull(cboUserName.SelectedValue, "")).GetDataSet();
                if (cboReportType.SelectedIndex == 1)
                {
                    crpt = new crpt_BAOCAO_XOA_KETQUA_TONGHOP();
                    dt = ds.Tables[0];
                }
                else
                {
                    crpt = new crpt_BAOCAO_SUAXOA_KETQUA_CHITIET();
                    dt = ds.Tables[1];
                }
                if (dt.Rows.Count <= 0)
                {
                    Utility.ShowMsg("Không có dữ liệu để báo cáo");
                }
                else
                {
                    var oForm = new frmPrintPreview("In báo cáo sửa xóa", crpt, true, true);
                    crpt.SetDataSource(dt);
                    crpt.DataDefinition.FormulaFields["Formula_1"].Text = "";
                    //crpt.SetParameterValue("TongBenhNhan", dt.Rows.Count);
                    crpt.SetParameterValue("TestType_Name", s);
                    crpt.SetParameterValue("ParentBranchName", ManagementUnit.gv_sParentBranchName);
                    crpt.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                    //crpt.SetParameterValue("sCurrentDate", dtpDatePrintFrom.Value);
                    oForm.crptViewer.ReportSource = crpt;
                    oForm.ShowDialog();
                    oForm.Dispose();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        

        private void frm_BaoCao_XoaKetQua_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }
        
        private void LoadComboBox()
        {
            DataTable testType = new Select(TTestTypeList.Columns.TestTypeId, TTestTypeList.Columns.TestTypeName).From(
                      TTestTypeList.Schema).ExecuteDataSet().Tables[0];
            DataBinding.BindDataCombox(cboTestType, testType, TTestTypeList.Columns.TestTypeId,
                                       TTestTypeList.Columns.TestTypeName, "-----Chọn loại xét nghiệm-----");


            DataTable userName = new Select(TblUser.Columns.PkSuid, TblUser.Columns.SFullName).From(
                      TblUser.Schema).ExecuteDataSet().Tables[0];
            var row = userName.NewRow();
            row["PK_sUID"] = "ADMIN";
            row["sFullName"] = "ADMIN";
            userName.Rows.Add(row);
            DataBinding.BindDataCombox(cboUserName, userName, TblUser.Columns.SFullName,
                                       TblUser.Columns.PkSuid, "-----Chọn tài khoản-----");
            //cboUserName.DataSource = userName;
            //cboUserName.ValueMember = TblUser.Columns.PkSuid;
            //cboUserName.DisplayMember = TblUser.Columns.PkSuid;
            


            DataTable reportType = new DataTable();
            reportType.Columns.Add("reportTypeId");
            reportType.Columns.Add("reportType");
            for (int i = 0; i < 2; i++)
            {
                var rows = reportType.NewRow();
                switch (i)
                {
                    case 0:
                        rows["reportTypeId"] = 0;
                        rows["reportType"] = "Chi tiết";
                        break;
                    case 1:
                        rows["reportTypeId"] = 1;
                        rows["reportType"] = "Tổng hợp";
                        break;
                }
                reportType.Rows.Add(rows);
            }
            DataBinding.BindData(cboReportType, reportType, "reportTypeId", "reportType");
            cboReportType.SelectedIndex = 0;
        }

        private void frm_BaoCao_XoaKetQua_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) cmdExit.PerformClick();
            if (e.KeyCode == Keys.F4) btnPrint.PerformClick();
            if (e.KeyCode == Keys.F5) cmdExportExcel.PerformClick();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdExportExcel_Click(object sender, EventArgs e)
        {
            var ds =
                        SPs.SpBaoCaoXoaKetQua(dtpFromDate.Value.ToString("yyyy/MM/dd"),
                                              dtpToDate.Value.ToString("yyyy/MM/dd"),
                                              Utility.Int32Dbnull(cboTestType.SelectedValue, -1),
                                              Utility.sDbnull(cboUserName.SelectedValue, "")).GetDataSet();
            var dataTable = new DataTable();
            //Tổng hợp
            if (cboReportType.SelectedIndex == 1)
            {
                dt = ds.Tables[0];
                //dataTable = Utilities.GetInversedDataTable(dt, "Para_Name", "Barcode", "Test_Result", "", false);
            }
            //Chi tiết
            else
            {
                dt = ds.Tables[1];
                dataTable = Utilities.GetInversedDataTable(dt, "TestType_Name", "Barcode", "Delete_Date", "", false);
            }
            
            
            if (dataTable.Rows.Count <= 0)
            {
                Utility.ShowMsg("Không có dữ liệu để báo cáo");
                return;
            }

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                GridEXColumn grdCol = new GridEXColumn(dataTable.Columns[i].ColumnName);
                grdAllPatientInfoAndResult.RootTable.Columns.Add(grdCol);
                //grdAllPatientInfoAndResult.RootTable.Columns[grdCol.Key].AggregateFunction = AggregateFunction.Count;
            }
            // grdAllPatientInfoAndResult.RootTable.Columns["Patient_ID"].Visible = false;
            //SetPropertiesCol("Barcode", "Barcode");
            // SetPropertiesCol("Test_Date", "Ngày Xét Nghiệm");
            // SetPropertiesCol("TestType_Name", "Loại XN");
            grdAllPatientInfoAndResult.DataSource = dataTable;
            grdAllPatientInfoAndResult.AutoSizeColumns();
            ExcelReport.ExportGridEx(grdAllPatientInfoAndResult);
        }
    }
}
