using System;
using System.Data;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmDoctorList_AU : Form
    {
        public DataRow drList;
        public DataTable dtList;
        public action vAction;
        private DataTable dtDoctor;

        public frmDoctorList_AU()
        {
            InitializeComponent();
        }

        private void frmTestTypeList_AU_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDoctorList();
                switch (vAction)
                {
                    case action.Insert:
                        txtID.Text = "-1";
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

        private void LoadDoctorList()
        {
            dtDoctor = new Select().From(SysUser.Schema.Name).ExecuteDataSet().Tables[0];
            dtDoctor.Columns.Add("DisplayUser");
            foreach (DataRow dr in dtDoctor.Rows)
            {
                dr["DisplayUser"] = dr[SysUser.Columns.PkSuid];
            }
            DataRow dataRow = dtDoctor.NewRow();
            dataRow["DisplayUser"] = "";
            dataRow[SysUser.Columns.PkSuid] = "-1";
            dtDoctor.Rows.InsertAt(dataRow,0);
            DataBinding.BindData(cboUserName, dtDoctor, SysUser.Columns.PkSuid, "DisplayUser");
        }

        private void LoadData()
        {
            txtID.Text = Utility.sDbnull(drList[LUser.Columns.UserId]);
            txtName.Text = Utility.sDbnull(drList[LUser.Columns.UserName]);
            cboUserName.SelectedValue = Utility.sDbnull(drList[LUser.Columns.UserCode]);
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
                            var obj = new LUser();
                            obj.UserName = Utility.sDbnull(txtName.Text);
                            obj.UserCode = Utility.sDbnull(cboUserName.Text);
                            obj.IsNew = true;
                            obj.Save();

                            drList = dtList.NewRow();
                            drList[LUser.Columns.UserId] = LUser.CreateQuery().GetMax(LUser.Columns.UserId);
                            ApplyData2Datarow();
                            dtList.Rows.InsertAt(drList, 0);
                            dtList.AcceptChanges();

                            txtID.Text = Utility.sDbnull(drList[LUser.Columns.UserId]);
                            vAction = action.Update;
                            break;
                        case action.Update:
                            new Update(LUser.Schema.Name).Set(LUser.Columns.UserName).EqualTo(txtName.Text).
                                Set(LUser.Columns.UserCode).EqualTo(Utility.sDbnull(cboUserName.Text)).
                                Where(LUser.Columns.UserId).IsEqualTo(Utility.Int32Dbnull(txtID.Text)).
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
            drList[LUser.Columns.UserName] = Utility.sDbnull(txtName.Text);
            drList[LUser.Columns.UserCode] = Utility.sDbnull(cboUserName.Text);
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
                        new Select().From(LUser.Schema.Name).Where(LUser.Columns.UserName).IsEqualTo(txtName.Text).
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
            txtName.Focus();
        }
    }
}