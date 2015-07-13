using System;
using System.Data;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmTestGroupList : Form
    {
        private DataTable dtTestGroup, dtTestDataList, dtTestGroupDetail;

        public frmTestGroupList()
        {
            InitializeComponent();
        }

        private void frmTestGroupList_Load(object sender, EventArgs e)
        {
            try
            {
                dtTestGroup = new Select("*").From(TTestgroupList.Schema.Name).
                    LeftOuterJoin(TTestTypeList.TestTypeIdColumn, TTestgroupList.TestTypeIdColumn).
                    OrderAsc(TTestTypeList.Columns.IntOrder).ExecuteDataSet().Tables[0];
                dtTestDataList = new Select().From(LStandardTest.Schema.Name).Where(LStandardTest.Columns.DataView).
                        IsEqualTo(true).OrderAsc(LStandardTest.Columns.DataSequence).ExecuteDataSet().Tables[0];
                dtTestDataList.DefaultView.RowFilter = "1=2";
                grdTestGroup.DataSource = dtTestGroup;
                grdTestData.DataSource = dtTestDataList;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdTestGroup_SelectionChanged(object sender, EventArgs e)
        {
            grdTestData.UnCheckAllRecords();
            if (grdTestGroup.CurrentRow != null)
            {
                string rowFilter = "TestType_ID = " + Utility.sDbnull(grdTestGroup.GetValue("TestType_ID"), "-1");
                dtTestDataList.DefaultView.RowFilter = rowFilter;

                dtTestGroupDetail = new Select().From(TTestgroupDtl.Schema.Name).
                    Where(TTestgroupDtl.Columns.TestGroupId).IsEqualTo(Utility.Int32Dbnull(grdTestGroup.GetValue("TestGroup_ID"))).
                    ExecuteDataSet().Tables[0];
                foreach (GridEXRow exRow in grdTestData.GetRows())
                {
                    if (dtTestGroupDetail.Select(string.Format("TestGroup_ID = {0} And TestData_ID = '{1}'",
                        Utility.Int32Dbnull(grdTestGroup.GetValue("TestGroup_ID")),
                        Utility.sDbnull(exRow.Cells["TestData_ID"].Value))).Length > 0)
                    {
                        exRow.CheckState = RowCheckState.Checked;
                    }
                }
            }
            else
            {
                dtTestDataList.DefaultView.RowFilter = "1=2";
                dtTestDataList.AcceptChanges();
            }
        }

        private void PerformAction(action vAction)
        {
            try
            {
                if (grdTestGroup.CurrentRow == null && (vAction == action.Update || vAction == action.Delete))
                    return;

                switch (vAction)
                {
                    case action.Delete:
                        if (Utility.AcceptQuestion("Thực hiện xóa " + grdTestGroup.GetValue("TestGroup_Name"), "Thông báo",
                                                   true))
                        {
                            new Delete().From(TTestgroupList.Schema.Name).Where(TTestgroupList.Columns.TestGroupId).IsEqualTo(
                                Utility.Int32Dbnull(grdTestGroup.GetValue("TestGroup_ID"))).Execute();
                            new Delete().From(TTestgroupDtl.Schema.Name).Where(TTestgroupDtl.Columns.TestGroupId).IsEqualTo(
                                Utility.Int32Dbnull(grdTestGroup.GetValue("TestGroup_ID"))).Execute();
                            grdTestGroup.CurrentRow.Delete();
                            grdTestGroup.UpdateData();
                        }
                        break;
                    default:
                        var oForm = new frmTestGroupList_AU();
                        if (vAction == action.Update) oForm.txtID.Text = Utility.sDbnull(grdTestGroup.GetValue("TestGroup_ID"));
                        oForm.dtList = dtTestGroup;
                        oForm.grdList = grdTestGroup;
                        oForm.ShowDialog();
                        if (grdTestGroup.CurrentRow !=null)
                            grdTestGroup_SelectionChanged(new object(), new EventArgs());
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            PerformAction(action.Insert);
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            PerformAction(action.Update);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            PerformAction(action.Delete);
        }

        private void frmTestGroupList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        cmdSave.PerformClick();
                        break;
                    case Keys.U:
                        cmdUpdate.PerformClick();
                        break;
                }
            }
            else
            switch (e.KeyCode)
            {
                case Keys.Delete :
                    cmdDelete.PerformClick();
                    break;
                case Keys.Escape:
                    cmdExit.PerformClick();
                    break;
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void grdTestGroup_DoubleClick(object sender, EventArgs e)
        {
            cmdUpdate.PerformClick();
        }

        private void grdTestData_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        {
            try
            {
                if (grdTestData.CurrentRow.IsChecked)
                {
                    TTestgroupDtl obj = new TTestgroupDtl();
                    obj.TestGroupId = Utility.Int32Dbnull(grdTestGroup.GetValue("TestGroup_ID"));
                    obj.TestDataId = Utility.sDbnull(grdTestData.GetValue("TestData_ID"));
                    obj.IsNew = true;
                    obj.Save();
                }
                else
                {
                    new Delete().From(TTestgroupDtl.Schema.Name).Where(TTestgroupDtl.Columns.TestGroupId).
                        IsEqualTo(grdTestGroup.GetValue("TestGroup_ID")).And(TTestgroupDtl.Columns.TestDataId).
                        IsEqualTo(grdTestData.GetValue("TestData_ID")).Execute();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

    }
}