using System;
using System.Data;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI
{
    public partial class frmDataControlList : Form
    {
        private DataTable dtDataControl, dtTestDataList;

        public frmDataControlList()
        {
            InitializeComponent();
        }

        private void frmTestDataList_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (GridEXColumn column in grdDataControl.RootTable.Columns)
                {
                    column.EditType = EditType.NoEdit;
                    column.FilterRowComparison = ConditionOperator.Contains;
                    column.FilterEditType = (column.ColumnType == ColumnType.CheckBox
                                                 ? FilterEditType.CheckBox
                                                 : FilterEditType.TextBox);
                }
                grdDataControl.RootTable.Columns["Control_Type"].EditType = EditType.CheckBox;
                grdDataControl.RootTable.Columns["Force_Run"].EditType = EditType.CheckBox;

                LoadDataControl();
                LoadTestData();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void LoadTestData()
        {
            dtTestDataList =
                new Select(LStandardTest.Schema.Name + ".*", TTestTypeList.Columns.TestTypeName).From(
                    LStandardTest.Schema.Name).LeftOuterJoin(TTestTypeList.TestTypeIdColumn,
                    LStandardTest.TestTypeIdColumn).OrderAsc(TTestTypeList.Columns.IntOrder,
                    LStandardTest.Columns.DataSequence).ExecuteDataSet().Tables[0];
            grdTestData.DataSource = dtTestDataList;
            grdTestData.MoveFirst();
        }

        private void LoadDataControl()
        {
            dtDataControl = new Select(DDataControl.Columns.DataControlId, DDataControl.Columns.DeviceId, DDataControl.Columns.AliasName, DDataControl.Columns.Description,
                DDataControl.TestDataIdColumn.QualifiedName, DDataControl.ControlTypeColumn.QualifiedName, DDataControl.ForceRunColumn.QualifiedName,
                LStandardTest.DataNameColumn.QualifiedName,LStandardTest.DataPointColumn.QualifiedName, LStandardTest.DataPrintColumn.QualifiedName, 
                LStandardTest.DataSequenceColumn.QualifiedName,LStandardTest.DataViewColumn.QualifiedName, LStandardTest.MeasureUnitColumn.QualifiedName, 
                LStandardTest.NormalLevelColumn.QualifiedName, LStandardTest.NormalLevelWColumn.QualifiedName,LStandardTest.TestTypeIdColumn.QualifiedName,
                TTestTypeList.Columns.TestTypeName,
                DDeviceList.Columns.DeviceName).
                From(DDataControl.Schema.Name).LeftOuterJoin(DDeviceList.DeviceIdColumn,DDataControl.DeviceIdColumn).
                LeftOuterJoin(LStandardTest.TestDataIdColumn,DDataControl.TestDataIdColumn).
                LeftOuterJoin(TTestTypeList.TestTypeIdColumn,LStandardTest.TestTypeIdColumn).
                OrderAsc(TTestTypeList.IntOrderColumn.QualifiedName, LStandardTest.DataSequenceColumn.QualifiedName).ExecuteDataSet().Tables[0];
            grdDataControl.DataSource = dtDataControl;
            grdDataControl.MoveFirst();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = new frmDataControlList_AU();
                obj.dtDataControl= dtDataControl;
                obj.vAction = action.Insert;
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
                    case Keys.E:
                        if (grdTestData.Focused)
                        {
                            grdTestData.GroupMode = GroupMode.Expanded;
                            grdTestData.Refetch();
                        }
                        else
                        {
                            grdDataControl.GroupMode = GroupMode.Expanded;
                            grdDataControl.Refetch();    
                        }
                        break;
                    case Keys.C:
                        if (grdTestData.Focused)
                        {
                            grdTestData.GroupMode = GroupMode.Collapsed;
                            grdTestData.Refetch();
                        }
                        else
                        {
                            grdDataControl.GroupMode = GroupMode.Collapsed;
                            grdDataControl.Refetch();
                        }
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
                if (grdDataControl.CurrentRow != null && grdDataControl.CurrentRow.RowType == RowType.Record)
                    if (
                        Utility.AcceptQuestion(
                            string.Format("Xóa {0} của {1}", grdDataControl.GetValue("Alias_Name"),
                                          grdDataControl.GetValue("Device_Name")), "Thông báo", true))
                    {
                        new Delete().From(DDataControl.Schema.Name).Where(DDataControl.Columns.DataControlId).IsEqualTo(
                            grdDataControl.GetValue("DataControl_ID")).Execute();
                        grdDataControl.CurrentRow.Delete();
                        grdDataControl.UpdateData();
                        dtDataControl.AcceptChanges();
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
                if (grdDataControl.CurrentRow == null || grdDataControl.CurrentRow.RowType != RowType.Record) return;
                else
                {
                    var obj = new frmDataControlList_AU();
                    obj.dtDataControl = dtDataControl;
                    obj.vAction = action.Update;
                    obj.drData = Utility.GetDataRow(dtDataControl, DDataControl.Columns.DataControlId, grdDataControl.GetValue("DataControl_ID"));
                    obj.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnUpdateStandardData_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdTestData.CurrentRow != null && grdDataControl.CurrentRow != null && 
                    grdTestData.CurrentRow.RowType == RowType.Record && grdDataControl.CurrentRow.RowType == RowType.Record)
                {
                    new Update(DDataControl.Schema.Name).Set(DDataControl.Columns.DataSequence).EqualTo(grdTestData.GetValue("Data_Sequence")).
                        Set(DDataControl.Columns.DataName).EqualTo(grdTestData.GetValue("Data_Name")).
                        Set(DDataControl.Columns.MeasureUnit).EqualTo(grdTestData.GetValue("Measure_Unit")).
                        Set(DDataControl.Columns.DataPoint).EqualTo(grdTestData.GetValue("Data_Point")).
                        Set(DDataControl.Columns.NormalLevel).EqualTo(grdTestData.GetValue("Normal_Level")).
                        Set(DDataControl.Columns.NormalLevelW).EqualTo(grdTestData.GetValue("Normal_LevelW")).
                        Set(DDataControl.Columns.DataView).EqualTo(grdTestData.GetValue("Data_View")).
                        Set(DDataControl.Columns.DataPrint).EqualTo(grdTestData.GetValue("Data_Print")).
                        Set(DDataControl.Columns.TestDataId).EqualTo(grdTestData.GetValue("TestData_ID")).
                        Where(DDataControl.Columns.DataControlId).IsEqualTo(Utility.Int32Dbnull(grdDataControl.GetValue("DataControl_ID"),-1)).
                        Execute();

                    grdDataControl.CurrentRow.Cells["Data_Sequence"].Value = grdTestData.CurrentRow.Cells["Data_Sequence"].Value;
                    grdDataControl.CurrentRow.Cells["Data_Name"].Value = grdTestData.CurrentRow.Cells["Data_Name"].Value;
                    grdDataControl.CurrentRow.Cells["Measure_Unit"].Value = grdTestData.CurrentRow.Cells["Measure_Unit"].Value;
                    grdDataControl.CurrentRow.Cells["Data_Point"].Value = grdTestData.CurrentRow.Cells["Data_Point"].Value;
                    grdDataControl.CurrentRow.Cells["Normal_Level"].Value = grdTestData.CurrentRow.Cells["Normal_Level"].Value;
                    grdDataControl.CurrentRow.Cells["Normal_LevelW"].Value = grdTestData.CurrentRow.Cells["Normal_LevelW"].Value;
                    grdDataControl.CurrentRow.Cells["Data_View"].Value = grdTestData.CurrentRow.Cells["Data_View"].Value;
                    grdDataControl.CurrentRow.Cells["Data_Print"].Value = grdTestData.CurrentRow.Cells["Data_Print"].Value;
                    grdDataControl.CurrentRow.Cells["TestData_ID"].Value = grdTestData.CurrentRow.Cells["TestData_ID"].Value;
                    grdDataControl.CurrentRow.Cells["TestType_Name"].Value = grdTestData.CurrentRow.Cells["TestType_Name"].Value;
                    grdDataControl.UpdateData();
                    Utility.ShowMsg("Cập nhật thành công");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdDataControl_DoubleClick(object sender, EventArgs e)
        {
            cmdUpdate.PerformClick();
        }

        private void grdDataControl_CellValueChanged(object sender, ColumnActionEventArgs e)
        {
            try
            {
                switch (e.Column.Key)
                {
                    case "Control_Type":
                        new Update(DDataControl.Schema.Name).Set(e.Column.Key).
                            EqualTo(Utility.ByteDbnull(grdDataControl.GetValue(e.Column.Key))).Where(DDataControl.Columns.DataControlId).
                            IsEqualTo(Utility.Int32Dbnull(grdDataControl.GetValue("DataControl_ID"))).Execute();
                        grdDataControl.UpdateData();
                        dtDataControl.AcceptChanges();
                        break;
                    case "Force_Run":
                        new Update(DDataControl.Schema.Name).Set(e.Column.Key).
                            EqualTo(Utility.Int16Dbnull(grdDataControl.GetValue(e.Column.Key))).Where(DDataControl.Columns.DataControlId).
                            IsEqualTo(Utility.Int32Dbnull(grdDataControl.GetValue("DataControl_ID"))).Execute();
                        grdDataControl.UpdateData();
                        dtDataControl.AcceptChanges();
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
    }
}