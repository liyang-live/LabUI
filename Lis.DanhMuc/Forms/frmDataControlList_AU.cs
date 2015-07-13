using System;
using System.Data;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI
{
    public partial class frmDataControlList_AU : Form
    {
        public DataRow drData;
        public DataTable dtDataControl;
        private DataTable dtDevice;
        public action vAction;

        public frmDataControlList_AU()
        {
            InitializeComponent();
        }

        private void frmTestDataList_Load(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = "-1";
                LoaDDataControl();
                switch (vAction)
                {
                    case action.Insert:
                        txtAlias.Focus();
                        break;
                    case action.Update:
                        LoadTestData();
                        txtAlias.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void LoaDDataControl()
        {
            dtDevice = new Select().From(DDeviceList.Schema.Name).Where(DDeviceList.Columns.Valid).IsEqualTo(true).
                ExecuteDataSet().Tables[0];
            DataBinding.BindData(cboDevice, dtDevice, DDeviceList.Columns.DeviceId, DDeviceList.Columns.DeviceName);
        }

        private void LoadTestData()
        {
            txtID.Text = Utility.sDbnull(drData[DDataControl.Columns.DataControlId], "NONE");
            txtAlias.Text = Utility.sDbnull(drData[DDataControl.Columns.AliasName], "NONE");
            cboDevice.SelectedValue = Utility.Int32Dbnull(drData[DDataControl.Columns.DeviceId] ,- 1);
            txtDesc.Text = Utility.sDbnull(drData[DDataControl.Columns.Description]);
        }

        private bool ValidData()
        {
            try
            {
                if (string.IsNullOrEmpty(txtAlias.Text))
                {
                    Utility.ShowMsg("Alias không hợp lệ");
                    txtAlias.Focus();
                    return false;
                }
                else
                {
                    int count =
                        new Select().From(DDataControl.Schema.Name).
                        Where(DDataControl.Columns.DeviceId).IsEqualTo(Utility.Int32Dbnull(cboDevice.SelectedValue, -1)).
                        And(DDataControl.Columns.AliasName).IsEqualTo(txtAlias.Text).
                        And(DDataControl.Columns.DataControlId).IsNotEqualTo(txtID.Text).
                            ExecuteDataSet().Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        Utility.ShowMsg(cboDevice.Text + " đã có " + txtAlias.Text);
                        txtAlias.Focus();
                        txtAlias.SelectAll();
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                return false;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = txtID.Text.ToUpper();
                if (ValidData())
                    switch (vAction)
                    {
                        case action.Insert:
                            var obj = new DDataControl();
                            obj.DataName = "";
                            obj.DeviceId = Utility.Int32Dbnull(cboDevice.SelectedValue, -1);
                            obj.DataTypeId = 0;
                            obj.ControlType = true;
                            obj.AliasName = Utility.sDbnull(txtAlias.Text);
                            obj.Description = Utility.sDbnull(txtDesc.Text);
                            obj.IsNew = true;
                            obj.Save();

                            drData = dtDataControl.NewRow();
                            drData[DDataControl.Columns.DataControlId] =
                                DDataControl.CreateQuery().WHERE(DDataControl.Columns.DeviceId,Utility.Int32Dbnull(cboDevice.SelectedValue, -1)).
                                WHERE(DDataControl.Columns.AliasName, txtAlias.Text).GetMax(DDataControl.Columns.DataControlId);
                            txtID.Text = drData[DDataControl.Columns.DataControlId].ToString();
                            ApplyData2Datarow();
                            dtDataControl.Rows.InsertAt(drData, 0);
                            dtDataControl.AcceptChanges();
                            vAction=action.Update;
                            break;
                        case action.Update:
                            new Update(DDataControl.Schema.Name).Set(DDataControl.Columns.AliasName).EqualTo(txtAlias.Text).
                                Set(DDataControl.Columns.Description).EqualTo(txtDesc.Text).
                                Set(DDataControl.Columns.DeviceId).EqualTo(Utility.Int32Dbnull(cboDevice.SelectedValue,-1)).
                                Where(DDataControl.Columns.DataControlId).IsEqualTo(Utility.Int32Dbnull(txtID.Text,-1)).Execute();
                            ApplyData2Datarow();
                            drData.AcceptChanges();
                            break;
                    }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void ApplyData2Datarow()
        {
            drData[DDataControl.Columns.DataControlId] = Utility.sDbnull(txtID.Text, "NONE");
            drData[DDataControl.Columns.AliasName] = Utility.sDbnull(txtAlias.Text, "NONE");
            drData[DDataControl.Columns.Description] = Utility.sDbnull(txtDesc.Text);
            drData[DDataControl.Columns.DeviceId] = Utility.Int32Dbnull(cboDevice.SelectedValue,-1);
            drData[DDeviceList.Columns.DeviceName] = Utility.sDbnull(cboDevice.Text);
            drData[DDataControl.Columns.ControlType] = true;
        }

        private void frmTestDataList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.S:
                        btnSave.PerformClick();
                        break;
                    case Keys.R:
                        btnReset.PerformClick();
                        break;
                }
            else
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        btnExit.PerformClick();
                        break;
                }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            vAction = action.Insert;
            txtID.Text = "-1";
            txtAlias.Focus();
            txtAlias.Clear();
            txtDesc.Clear();
        }
    }
}