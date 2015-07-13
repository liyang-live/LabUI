using System;
using System.Data;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmObjectTypeList_AU : Form
    {
        public DataRow drList;
        public DataTable dtList;
        public action vAction;

        public frmObjectTypeList_AU()
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
            txtID.Text = Utility.sDbnull(drList[LObjectType.Columns.Id]);
            txtName.Text = Utility.sDbnull(drList[LObjectType.Columns.SName]);
            txtDesc.Text = Utility.sDbnull(drList[LObjectType.Columns.SDesc]);
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
                            var obj = new LObjectType();
                            obj.SName = Utility.sDbnull(txtName.Text);
                            obj.SDesc = Utility.sDbnull(txtDesc.Text);
                            obj.IsNew = true;
                            obj.Save();

                            drList = dtList.NewRow();
                            drList[LObjectType.Columns.Id] =
                                LObjectType.CreateQuery().GetMax(LObjectType.Columns.Id);
                            ApplyData2Datarow();
                            dtList.Rows.InsertAt(drList, 0);
                            dtList.AcceptChanges();

                            txtID.Text = Utility.sDbnull(drList[LObjectType.Columns.Id]);
                            vAction = action.Update;
                            break;
                        case action.Update:
                            new Update(LObjectType.Schema.Name).Set(LObjectType.Columns.SName).EqualTo(txtName.Text).
                                Set(LObjectType.Columns.SDesc).EqualTo(txtDesc.Text).
                                Where(LObjectType.Columns.Id).IsEqualTo(Utility.Int32Dbnull(txtID.Text)).
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
            drList[LObjectType.Columns.SName] = Utility.sDbnull(txtName.Text);
            drList[LObjectType.Columns.SDesc] = Utility.sDbnull(txtDesc.Text);
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
                        new Select().From(LObjectType.Schema.Name).
                            Where(LObjectType.Columns.SName).IsEqualTo(txtName.Text).
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