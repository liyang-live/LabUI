using System;
using System.Data;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmManufacturerList_AU : Form
    {
        public DataTable dtList;
        public Janus.Windows.GridEX.GridEX grdList;

        public frmManufacturerList_AU()
        {
            InitializeComponent();
        }

        private void frmTestTypeList_AU_Load(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txtID.Text)) LoadData();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                Close();
            }
        }

        private void LoadData()
        {
            LManufacture objManufacture = LManufacture.FetchByID(txtID.Text);
            if(objManufacture!=null)
            {
                txtName.Text = Utility.sDbnull(objManufacture.SName,"");
                txtDesc.Text = Utility.sDbnull(objManufacture.SDesc,"");
            }
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
                LManufacture objManufacture;
                if (ValidData())
                    switch (txtID.Text)
                    {
                        case "-1":
                            var obj = new LManufacture();
                            obj.SName = Utility.sDbnull(txtName.Text);
                            obj.SDesc = Utility.sDbnull(txtDesc.Text);
                            obj.IsNew = true;
                            obj.Save();

                            txtID.Text = Utility.sDbnull(LManufacture.CreateQuery().GetMax(LManufacture.Columns.Id));
                            objManufacture = LManufacture.FetchByID(Utility.Int32Dbnull(txtID.Text, -1));
                            if (objManufacture != null)
                            {
                                DataRow newDr = dtList.NewRow();
                                Utility.FromObjectToDatarow(objManufacture, ref newDr);
                                dtList.Rows.Add(newDr);
                            }
                            break;
                        default:
                            new Update(LManufacture.Schema.Name).Set(LManufacture.Columns.SName).EqualTo(txtName.Text).
                                Set(LManufacture.Columns.SDesc).EqualTo(txtDesc.Text).
                                Where(LManufacture.Columns.Id).IsEqualTo(Utility.Int32Dbnull(txtID.Text)).
                                Execute();
                            objManufacture = LManufacture.FetchByID(Utility.Int32Dbnull(txtID.Text, -1));
                            if(objManufacture!=null)
                            {
                                DataRow newDr = Utility.GetDataRow(dtList, LManufacture.Columns.Id, objManufacture.Id);
                                Utility.FromObjectToDatarow(objManufacture,ref newDr);
                                newDr.AcceptChanges();
                            }
                                 
                            break;
                    }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
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
                else if (txtID.Text == "-1")
                {
                    int count =
                        new Select().From(LManufacture.Schema.Name).
                            Where(LManufacture.Columns.SName).IsEqualTo(txtName.Text).
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
            txtID.Text = "-1";
            txtName.Clear();
            txtDesc.Clear();
            txtName.Focus();
        }
    }
}