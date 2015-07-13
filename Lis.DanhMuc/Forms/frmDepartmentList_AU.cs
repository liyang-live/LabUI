using System;
using System.Data;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmDepartmentList_AU : Form
    {
        public DataRow drList;
        public DataTable dtList;
        public action vAction;

        public frmDepartmentList_AU()
        {
            InitializeComponent();
        }

        private void frmTestTypeList_AU_Load(object sender, EventArgs e)
        {
            try
            {
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

        private void LoadData()
        {
            txtID.Text = Utility.sDbnull(drList[LDepartment.Columns.Id]);
            txtName.Text = Utility.sDbnull(drList[LDepartment.Columns.SName]);
            txtDesc.Text = Utility.sDbnull(drList[LDepartment.Columns.SDesc]);
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
                            var obj = new LDepartment();
                            obj.SName = Utility.sDbnull(txtName.Text);
                            obj.SDesc = Utility.sDbnull(txtDesc.Text);
                            obj.IsNew = true;
                            obj.Save();

                            drList = dtList.NewRow();
                            drList[LDepartment.Columns.Id] =LDepartment.CreateQuery().GetMax(LDepartment.Columns.Id);
                            ApplyData2Datarow();
                            dtList.Rows.InsertAt(drList, 0);
                            dtList.AcceptChanges();

                            txtID.Text = Utility.sDbnull(drList[LDepartment.Columns.Id]);
                            vAction = action.Update;
                            break;
                        case action.Update:
                            new Update(LDepartment.Schema.Name).Set(LDepartment.Columns.SName).EqualTo(txtName.Text).
                                Set(LDepartment.Columns.SDesc).EqualTo(txtDesc.Text).
                                Where(LDepartment.Columns.Id).IsEqualTo(Utility.Int32Dbnull(txtID.Text)).
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
            drList[LDepartment.Columns.SName] = Utility.sDbnull(txtName.Text);
            drList[LDepartment.Columns.SDesc] = Utility.sDbnull(txtDesc.Text);
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
                        new Select().From(LDepartment.Schema.Name).
                            Where(LDepartment.Columns.SName).IsEqualTo(txtName.Text).
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
            txtName.Focus();
        }
    }
}