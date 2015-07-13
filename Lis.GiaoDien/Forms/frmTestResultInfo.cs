using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using SubSonic;
using VNS.Libs;
using LIS.DAL;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class frmTestResultInfo : Form
    {
        private DataTable dtTestResult;
        public GridEXRow grwPatient;
        public bool LoadAllTest = false;

        public frmTestResultInfo()
        {
            InitializeComponent();
        }

        private void frmTestResultInfo_Load(object sender, EventArgs e)
        {
            try
            {
                txtPatientName.Text = grwPatient.Cells["Patient_Name"].Value.ToString();
                txtAge.Text = grwPatient.Cells["Age"].Value.ToString();
                txtSex.Text = grwPatient.Cells["SexName"].Value.ToString();
                LoadTestResult();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                Dispose();
            }
        }

        private void LoadTestResult()
        {
            try
            {
                dtTestResult = new Select(TResultDetail.Schema.Name + ".*, " +
                                          "(Select ddl.Device_Name From D_Device_List ddl where ddl.Device_ID = T_Result_Detail.Device_ID) as Device_Name", TTestTypeList.Columns.TestTypeName).
                    From(TTestInfo.Schema.Name).
                    InnerJoin(TResultDetail.TestIdColumn, TTestInfo.TestIdColumn).
                    LeftOuterJoin(TTestTypeList.TestTypeIdColumn, TTestInfo.TestTypeIdColumn).
                    Where(TTestInfo.Columns.PatientId).IsEqualTo(
                        Utility.Int32Dbnull(grwPatient.Cells["Patient_ID"].Value)).
                    OrderAsc(TTestTypeList.Columns.IntOrder, TResultDetail.Columns.TestId,
                             TResultDetail.Columns.DataSequence).
                    ExecuteDataSet().Tables[0];
                dtTestResult = ProcessData.NormalResult(dtTestResult, "IsNormal",
                                                        grwPatient.Cells["SexName"].Value.ToString());
                
                if(LoadAllTest)
                {
                    var dt = new Select("*", TTestTypeList.Columns.TestTypeName).
                        From(TTestInfo.Schema.Name).
                        LeftOuterJoin(TRegList.TestIdColumn, TTestInfo.TestIdColumn).
                        LeftOuterJoin(TTestTypeList.TestTypeIdColumn, TTestInfo.TestTypeIdColumn).
                        Where(TTestInfo.Columns.PatientId).IsEqualTo(Utility.Int32Dbnull(grwPatient.Cells["Patient_ID"].Value)).
                        And(TTestInfo.Columns.TestTypeId).NotIn(new Select(TResultDetail.Columns.TestTypeId).From(TResultDetail.Schema.Name).Where(TResultDetail.Columns.PatientId).IsEqualTo(Utility.Int32Dbnull(grwPatient.Cells["Patient_ID"].Value))).
                        ExecuteDataSet().Tables[0];
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        var newRow = dtTestResult.NewRow();
                        newRow["Para_Name"] = row["Para_Name"];
                        //newRow["Data_Sequence"] = row["Data_Sequence"];
                        //newRow["Normal_levelW"] = row["Normal_levelW"];
                        //newRow["Normal_level"] = row["Normal_level"];
                        //newRow["Measure_Unit"] = row["Measure_Unit"];
                        //newRow["Patient_ID"] = Utility.sDbnull(grwPatient.Cells["Patient_ID"].Value);
                        //newRow["TestType_ID"] = row["TestType_ID"];
                        newRow["TestType_Name"] = row["TestType_Name"];
                        newRow["Barcode"] = Utility.sDbnull(grwPatient.Cells["Barcode"].Value);
                        dtTestResult.Rows.Add(newRow);
                    }
                    
                }


                grdTestResult.DataSource = dtTestResult;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                throw;
            }
        }

        private void frmTestResultInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    //case Keys.E:
                    //    btnEditResult.PerformClick();
                    //    break;
                    case Keys.C :
                        grdTestResult.CollapseGroups();
                        break;
                    case Keys.E:
                        grdTestResult.ExpandGroups();
                        break;
                }   
            }
            else
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Dispose();
                    break;
            }
        }

        private void grdTestResult_CellUpdated(object sender, ColumnActionEventArgs e)
        {
            try
            {
                if (grdTestResult.CurrentRow == null) return;
                if (Utility.Int32Dbnull(grdTestResult.GetValue("TestDetail_ID"), -1) > 0)
                {
                    new Update(TResultDetail.Schema.Name).Set(TResultDetail.Columns.TestResult).EqualTo(
                        grdTestResult.GetValue("Test_Result")).Where(TResultDetail.Columns.TestDetailId).IsEqualTo(
                            Utility.Int32Dbnull(grdTestResult.GetValue("TestDetail_ID"), -1)).Execute();
                }
                else
                {
                    var obj = new TResultDetail();
                    if (string.IsNullOrEmpty(Utility.sDbnull(grdTestResult.GetValue("Para_Name"))))
                    {
                        Utility.ShowMsg("Tên thông số không được để trống");
                        return;
                    }
                    obj.TestId = Utility.Int32Dbnull(grdTestResult.GetValue("Test_ID"), -1);
                    obj.PatientId = Utility.Int32Dbnull(grdTestResult.GetValue("Patient_ID"), -1);
                    obj.TestTypeId = Utility.Int32Dbnull(grdTestResult.GetValue("TestType_ID"), -1);
                    obj.TestDate = Utility.getSysDate();
                    obj.DataSequence = Utility.Int32Dbnull(grdTestResult.GetValue("Data_Sequence"));
                    obj.TestResult = Utility.sDbnull(grdTestResult.GetValue("Test_Result"));
                    obj.NormalLevel = Utility.sDbnull(grdTestResult.GetValue("Normal_Level"));
                    obj.NormalLevelW = Utility.sDbnull(grdTestResult.GetValue("Normal_levelW"));
                    obj.MeasureUnit = Utility.sDbnull(grdTestResult.GetValue("Measure_Unit"));
                    obj.ParaName = Utility.sDbnull(grdTestResult.GetValue("Para_Name"));
                    obj.TestDataId = Utility.sDbnull(grdTestResult.GetValue("TestData_ID"));
                    obj.ParaStatus = 0;
                    obj.PrintData = true;
                    obj.Barcode = Utility.sDbnull(grdTestResult.GetValue("Barcode"));
                    obj.UpdateNum = 0;
                    obj.IsNew = true;
                    obj.Save();

                    grdTestResult.CurrentRow.Cells["TestDetail_ID"].Value =
                        Utility.Int32Dbnull(TResultDetail.CreateQuery().
                                                WHERE(TResultDetail.Columns.PatientId, obj.PatientId).
                                                WHERE(TResultDetail.Columns.TestTypeId, obj.TestTypeId).
                                                GetMax(TResultDetail.Columns.TestDetailId), -1);
                }

                grdTestResult.UpdateData();
                dtTestResult.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnEditResult_Click(object sender, EventArgs e)
        {
            if (grdTestResult.RootTable.Columns["Test_Result"].Selectable)
            {
                grdTestResult.RootTable.Columns["Test_Result"].Selectable = false;
                grdTestResult.RootTable.Columns["Test_Result"].CellStyle.BackColor = Color.FromArgb(255, 224, 192);
            }
            else
            {
                grdTestResult.RootTable.Columns["Test_Result"].Selectable = true;
                grdTestResult.RootTable.Columns["Test_Result"].CellStyle.BackColor = Color.FromArgb(192, 255, 192);
            }
        }
    }
}