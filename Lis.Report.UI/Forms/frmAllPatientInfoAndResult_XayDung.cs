using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using LIS.DAL;
using Lis.Report.UI;
using SubSonic;
using newLib;
using Microsoft.VisualBasic;
using VNS.Libs;
using AggregateFunction = Janus.Windows.GridEX.AggregateFunction;

namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frmAllPatientInfoAndResult_XayDung : Form
    {
        private DataTable dtResult;

        public frmAllPatientInfoAndResult_XayDung()
        {
            InitializeComponent();

        }

        private void cmdINPHIEU_Click(object sender, EventArgs e)
        {
            try
            {
                grdAllPatientInfoAndResult.RootTable.Columns.Clear();

                dtResult =
                    SPs.SpRptAllPatientInfoAndResultXayDung(dtpFromDate.Value.Date,
                                                        dtpToDate.Value.Date.AddDays(1).AddMilliseconds(-5),
                                                        Utility.Int32Dbnull(cboTestType.SelectedValue),
                                                        Utility.Int16Dbnull(cboObjectType.SelectedValue),
                                                        Utility.Int16Dbnull(cboDepartment.SelectedValue),
                                                        Utility.sDbnull(cboAddress.Text),
                                                        Utility.Int16Dbnull(cboDevices.SelectedValue)).
                        GetDataSet().Tables[0];
                

                if (dtResult.Rows.Count <= 0 | dtResult.Columns.Count <= 1)
                {
                    Utility.ShowMsg("Không tìm thấy kết quả !");
                    return;
                }

                for (int i = 0; i < dtResult.Columns.Count; i++)
                {
                    GridEXColumn grdCol = new GridEXColumn(dtResult.Columns[i].ColumnName);
                    grdAllPatientInfoAndResult.RootTable.Columns.Add(grdCol);
                    grdAllPatientInfoAndResult.RootTable.Columns[grdCol.Key].AggregateFunction = AggregateFunction.ValueCount;
                }
                grdAllPatientInfoAndResult.RootTable.Columns["Patient_ID"].Visible = false;

                SetPropertiesCol("Barcode", "Barcode");
                SetPropertiesCol("Patient_Name", "Tên BN");
                SetPropertiesCol("SexName", "Giới Tính");
                SetPropertiesCol("Year_Birth", "Năm Sinh");
                SetPropertiesCol("PID", "PID");
                SetPropertiesCol("Address", "Địa Chỉ");
                SetPropertiesCol("Year_Birth", "Năm sinh");
                SetPropertiesCol("Insurance_Num", "Số thẻ BHYT");
                SetPropertiesCol("Baroce", "Barcode");
                SetPropertiesCol("ObjectType_Name", "Đối tượng");
                SetPropertiesCol("Department_Name", "Khoa");
                SetPropertiesCol("Age", "Tuổi");

                grdAllPatientInfoAndResult.DataSource = dtResult;
                grdAllPatientInfoAndResult.AutoSizeColumns();


            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void SetPropertiesCol(string colName, string colCaption)
        {
            if (!dtResult.Columns.Contains(colName))
                return;
            grdAllPatientInfoAndResult.RootTable.Columns[colName].Caption = colCaption;
            grdAllPatientInfoAndResult.RootTable.Columns[colName].AutoSizeMode = ColumnAutoSizeMode.AllCellsAndHeader;
            grdAllPatientInfoAndResult.RootTable.Columns[colName].FilterRowComparison = ConditionOperator.Contains;
            grdAllPatientInfoAndResult.RootTable.Columns[colName].AggregateFunction = AggregateFunction.None;

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmArchiverReport_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    cmdINPHIEU.PerformClick();
                    break;
                case Keys.F5:
                    btnExportExcel.PerformClick();
                    break;
                case Keys.Escape:
                    cmdExit.PerformClick();
                    break;
            }
        }

        private void frmArchiverReport_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTestType = new Select("*").From(TTestTypeList.Schema.Name).OrderAsc(TTestTypeList.Columns.IntOrder).
                    ExecuteDataSet().Tables[0];
                DataBinding.BindDataCombobox_Basic(cboTestType, dtTestType, TTestTypeList.Columns.TestTypeId, TTestTypeList.Columns.TestTypeName);

                DataTable dtObjectType = new Select("*").From(LObjectType.Schema.Name).ExecuteDataSet().Tables[0];
                DataBinding.BindDataCombobox_Basic(cboObjectType, dtObjectType, LObjectType.Columns.Id, LObjectType.Columns.SName);

                DataTable dtDepartment = new Select("*").From(LDepartment.Schema.Name).ExecuteDataSet().Tables[0];
                DataBinding.BindDataCombobox_Basic(cboDepartment, dtDepartment, LDepartment.Columns.Id, LDepartment.Columns.SName);

                DataTable dtDevices = new Select("*").From(DDeviceList.Schema.Name).ExecuteDataSet().Tables[0];
                DataBinding.BindDataCombobox_Basic(cboDevices, dtDevices, DDeviceList.Columns.DeviceId, DDeviceList.Columns.DeviceName);

                DataTable dtAddress = new Select(Aggregate.GroupBy(LPatientInfo.Columns.Address,"Address"),Aggregate.Max(LPatientInfo.Columns.PatientId,"Patient_ID")).From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.Address).IsNotEqualTo(string.Empty).ExecuteDataSet().Tables[0];
                DataBinding.BindDataCombox(cboAddress, dtAddress, LPatientInfo.Columns.PatientId, LPatientInfo.Columns.Address);
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                Dispose();
            }
        }


        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExcelReport.ExportGridEx(grdAllPatientInfoAndResult);
        }

        private void grdAllPatientInfoAndResult_LoadingRow(object sender, RowLoadEventArgs e)
        {

        }

        private void grdAllPatientInfoAndResult_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.RowType == RowType.TotalRow)
            {

                e.Row.Cells["Department_Name"].Value = "Tổng Số Xét Nghiệm:";
                e.Row.Cells["Patient_Name"].Value = "Tổng Sô BN:  " + dtResult.Rows.Count.ToString();
            }
        }
    }
}