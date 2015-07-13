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
using VNS.Libs;
using SubSonic;

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmUserRelation : Form
    {
        private DataTable dtUserTestType, dtUserFormControl, dtFormControl;

        public frmUserRelation()
        {
            InitializeComponent();
        }

        private void frmUserRelation_Load(object sender, EventArgs e)
        {
            LoadRelationUserTestType();
            LoadRelationUserFormControl();
            LoadUser();
        }

        private void LoadRelationUserTestType()
        {
            try
            {
                grdTestType.DataSource = new Select().From(TTestTypeList.Schema.Name).OrderAsc(TTestTypeList.Columns.IntOrder).
                                            ExecuteDataSet().Tables[0];
                dtUserTestType = new Select(LUserTestType.Columns.UserName,TTestTypeList.Schema.Name+".*").
                                            From(LUserTestType.Schema.Name).
                                            InnerJoin(TTestTypeList.TestTypeIdColumn,LUserTestType.TestTypeIdColumn).
                                            ExecuteDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void LoadRelationUserFormControl()
        {
            try
            {
                dtFormControl = new Select().From(LFormControl.Schema.Name).OrderAsc(LFormControl.Columns.ControlName).
                                            ExecuteDataSet().Tables[0];
                grdControl.DataSource = dtFormControl;
                dtUserFormControl = new Select(LUserFormControl.Columns.UserName, LFormControl.Schema.Name + ".*").
                                            From(LUserFormControl.Schema.Name).
                                            InnerJoin(LFormControl.ControlIdColumn, LUserFormControl.ControlIdColumn).
                                            ExecuteDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void LoadUser()
        {
            try
            {
                grdUser.DataSource = new Select().From(SysUser.Schema.Name).ExecuteDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdUser_SelectionChanged(object sender, EventArgs e)
        {
            switch (uiTab1.SelectedTab.Name)
            {
                case "tabTestType":
                    SelectorTestType();
                    break;
                case "tabControl":
                    SelectorControl();
                    break;
            }
        }

        private void SelectorControl()
        {
            try
            {
                grdControl.UnCheckAllRecords();
                string sUserName = Utility.sDbnull(grdUser.GetValue("PK_sUID"));
                foreach (Janus.Windows.GridEX.GridEXRow gridEx in grdControl.GetRows())
                {
                    DataRow[] dr = dtUserFormControl.Select(string.Format("UserName = '{0}' And Control_ID = {1}", sUserName,
                                                            Utility.Int32Dbnull(gridEx.Cells["Control_ID"].Value)));
                    if (dr.Length > 0) gridEx.CheckState = RowCheckState.Checked;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void SelectorTestType()
        {
            try
            {
                grdTestType.UnCheckAllRecords();
                string sUserName = Utility.sDbnull(grdUser.GetValue("PK_sUID"));
                foreach (Janus.Windows.GridEX.GridEXRow gridEx in grdTestType.GetRows())
                {
                    DataRow[] dr =
                        dtUserTestType.Select(string.Format("UserName = '{0}' And TestType_ID = {1}", sUserName,
                                                            Utility.Int32Dbnull(gridEx.Cells["TestType_ID"].Value)));
                    if (dr.Length > 0) gridEx.CheckState = RowCheckState.Checked;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

    

        private void frmUserRelation_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape :
                    Dispose();
                    break;
            }
        }

        private void grdTestType_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        {
            try
            {
                if (grdTestType.CurrentRow.IsChecked)
                {
                    LUserTestType obj = new LUserTestType();
                    obj.UserName = Utility.sDbnull(grdUser.GetValue("PK_sUID"));
                    obj.TestTypeId = Utility.Int32Dbnull(grdTestType.GetValue("TestType_ID"));
                    obj.IsNew = true;
                    obj.Save();
                }
                else
                {
                    new Delete().From(LUserTestType.Schema.Name).Where(LUserTestType.Columns.UserName).
                        IsEqualTo(grdUser.GetValue("PK_sUID")).And(LUserTestType.Columns.TestTypeId).
                        IsEqualTo(grdTestType.GetValue("TestType_ID")).Execute();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdControl_RowCheckStateChanged(object sender, RowCheckStateChangeEventArgs e)
        {
            try
            {
                if (grdControl.CurrentRow.IsChecked)
                {
                    LUserFormControl obj = new LUserFormControl();
                    obj.UserName = Utility.sDbnull(grdUser.GetValue("PK_sUID"));
                    obj.ControlId = Utility.Int32Dbnull(grdControl.GetValue("Control_ID"));
                    obj.IsNew = true;
                    obj.Save();
                }
                else
                {
                    new Delete().From(LUserFormControl.Schema.Name).Where(LUserFormControl.Columns.UserName).
                        IsEqualTo(grdUser.GetValue("PK_sUID")).And(LUserFormControl.Columns.ControlId).
                        IsEqualTo(grdControl.GetValue("Control_ID")).Execute();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void uiTab1_SelectedTabChanged(object sender, Janus.Windows.UI.Tab.TabEventArgs e)
        {
            grdUser_SelectionChanged(sender, new EventArgs());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmUser_FormControl_AU oForm = new frmUser_FormControl_AU();
                oForm.grdList = grdControl;
                oForm.dtList = dtFormControl;
                oForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                frmUser_FormControl_AU oForm = new frmUser_FormControl_AU();
                oForm.grdList = grdControl;
                oForm.dtList = dtFormControl;
                oForm.txtID.Text = Utility.sDbnull(grdControl.GetValue("Control_ID"));
                oForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utility.AcceptQuestion(string.Format("Thực hiện xóa Control_ID: {0}", Utility.sDbnull(grdControl.GetValue("Control_ID"))),"Thông báo",true))
                {
                    new Delete().From(LFormControl.Schema.Name).Where(LFormControl.Columns.ControlId).IsEqualTo(
                        Utility.Int32Dbnull(grdControl.GetValue("Control_ID"))).Execute();
                    new Delete().From(LUserFormControl.Schema.Name).Where(LUserFormControl.Columns.ControlId).IsEqualTo(
                        Utility.Int32Dbnull(grdControl.GetValue("Control_ID"))).Execute();
                    grdControl.CurrentRow.Delete();
                    grdControl.UpdateData();
                }
                    
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
    }
}
