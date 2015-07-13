using System;
using System.Data;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmDeviceList_AU : Form
    {
        public DataRow drList;
        public DataTable dtList;
        public action vAction;
        private DataTable dtTestTypeList, dtManufacturerList;

        public frmDeviceList_AU()
        {
            InitializeComponent();
        }

        private void frmTestTypeList_AU_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTestTypeList();
                LoadManufacturerList();

                switch (vAction)
                {
                    case action.Insert:
                        txtID.Text = "-1";
                        txtName.Focus();
                        break;
                    case action.Update:
                        LoadData();
                        txtName.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                Close();
            }
        }

        private void LoadTestTypeList()
        {
            dtTestTypeList = new Select().From(TTestTypeList.Schema.Name).OrderAsc(TTestTypeList.Columns.IntOrder).
                ExecuteDataSet().Tables[0];
            DataBinding.BindData(cboTestType,dtTestTypeList,TTestTypeList.Columns.TestTypeId,TTestTypeList.Columns.TestTypeName);
        }

        private void LoadManufacturerList()
        {
            dtManufacturerList = new Select().From(LManufacture.Schema.Name).ExecuteDataSet().Tables[0];
            DataBinding.BindData(cboManufacturer, dtManufacturerList, LManufacture.Columns.Id, LManufacture.Columns.SName);
        }

        private void LoadData()
        {
            txtID.Text = Utility.sDbnull(drList[DDeviceList.Columns.DeviceId]);
            txtName.Text = Utility.sDbnull(drList[DDeviceList.Columns.DeviceName]);
            cboTestType.SelectedValue= Utility.Int32Dbnull(drList[DDeviceList.Columns.TestTypeId], -1);
            cboManufacturer.SelectedValue = Utility.Int32Dbnull(drList[DDeviceList.Columns.ManufactureId], -1);
            ckbValid.Checked = Utility.Int32Dbnull(drList[DDeviceList.Columns.Valid], 0) == 1;
            txtDesc.Text = Utility.sDbnull(drList[DDeviceList.Columns.Description]);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTestTypeList_AU_KeyDown(object sender, KeyEventArgs e)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = txtID.Text.ToUpper();
                if (ValidData())
                    switch (vAction)
                    {
                        case action.Insert:
                            var obj = new DDeviceList();
                            obj.DeviceName = Utility.sDbnull(txtName.Text);
                            obj.TestTypeId = Utility.Int32Dbnull(cboTestType.SelectedValue);
                            obj.ManufactureId = Utility.ByteDbnull(cboManufacturer.SelectedValue);
                            obj.Description = Utility.sDbnull(txtDesc.Text);
                            obj.Valid = ckbValid.Checked;
                            obj.IsNew = true;
                            obj.Save();

                            drList = dtList.NewRow();
                            drList[DDeviceList.Columns.DeviceId] = DDeviceList.CreateQuery().GetMax(DDeviceList.Columns.DeviceId);
                            ApplyData2Datarow();
                            dtList.Rows.InsertAt(drList, 0);
                            dtList.AcceptChanges();

                            txtID.Text = Utility.sDbnull(drList[DDeviceList.Columns.DeviceId]);
                            vAction = action.Update;
                            break;
                        case action.Update:
                            new Update(DDeviceList.Schema.Name).Set(DDeviceList.Columns.DeviceName).EqualTo(txtName.Text).
                                Set(DDeviceList.Columns.TestTypeId).EqualTo(Utility.Int32Dbnull(cboTestType.SelectedValue)).
                                Set(DDeviceList.Columns.ManufactureId).EqualTo(Utility.Int32Dbnull(cboManufacturer.SelectedValue)).
                                Set(DDeviceList.Columns.Description).EqualTo(txtDesc.Text).
                                Set(DDeviceList.Columns.Valid).EqualTo(ckbValid.Checked).
                                Where(DDeviceList.Columns.DeviceId).IsEqualTo(Utility.Int32Dbnull(txtID.Text)).
                                Execute();
                            ApplyData2Datarow();
                            drList.AcceptChanges();
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
            drList[DDeviceList.Columns.DeviceName] = Utility.sDbnull(txtName.Text);
            drList[DDeviceList.Columns.TestTypeId] = Utility.Int32Dbnull(cboTestType.SelectedValue);
            drList[DDeviceList.Columns.ManufactureId] = Utility.Int32Dbnull(cboManufacturer.SelectedValue);
            drList[TTestTypeList.Columns.TestTypeName
                ] = Utility.sDbnull(cboTestType.Text);
            drList[LManufacture.Columns.SName] = Utility.sDbnull(cboManufacturer.Text);
            drList[DDeviceList.Columns.Description] = Utility.sDbnull(txtDesc.Text);
            drList[DDeviceList.Columns.Valid] = ckbValid.Checked;
        }

        private bool ValidData()
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    Utility.ShowMsg("Tên loại xét nghiệm không hợp lệ");
                    txtName.Focus();
                    return false;
                }
                else if (vAction == action.Insert)
                {
                    int count =
                        new Select().From(DDeviceList.Schema.Name).
                            Where(DDeviceList.Columns.DeviceName).IsEqualTo(txtName.Text).
                            ExecuteDataSet().Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        Utility.ShowMsg(txtName.Text + " đã tồn tại");
                        txtName.Focus();
                        txtName.SelectAll();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            vAction = action.Insert;
            txtID.Text = "-1";
            txtName.Clear();
            txtDesc.Clear();
            ckbValid.Checked = true;
            txtName.Focus();
        }

    }
}