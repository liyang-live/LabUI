using System;
using System.Data;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmTestGroupList_AU : Form
    {
        public DataTable dtList;
        public Janus.Windows.GridEX.GridEX grdList;

        public frmTestGroupList_AU()
        {
            InitializeComponent();
        }

        private void frmTestTypeList_AU_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTestType = new Select().From(TTestTypeList.Schema.Name).
                    OrderAsc(TTestTypeList.Columns.IntOrder).ExecuteDataSet().Tables[0];

                DataBinding.BindData(cboTestType,dtTestType,"TestType_ID","TestType_Name");
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
            cboTestType.Enabled = TTestgroupDtl.CreateQuery().WHERE(TTestgroupDtl.Columns.TestGroupId, Utility.Int32Dbnull(txtID.Text)).
                GetRecordCount() <= 0;
            TTestgroupList obj = TTestgroupList.FetchByID(Utility.Int32Dbnull(txtID.Text));
            if(obj!=null)
            {
                txtName.Text = Utility.sDbnull(obj.TestGroupName,"");
                cboTestType.SelectedValue= Utility.Int32Dbnull(obj.TestTypeId,-1);
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
                TTestgroupList obj = new TTestgroupList();
                if (ValidData())
                    switch (txtID.Text)
                    {
                        case "-1":
                            //var obj = new LManufacture();
                            obj.TestGroupName = Utility.sDbnull(txtName.Text);
                            obj.TestTypeId = Utility.Int32Dbnull(cboTestType.SelectedValue);
                            obj.IsNew = true;
                            obj.Save();

                            txtID.Text = Utility.sDbnull(TTestgroupList.CreateQuery().GetMax(TTestgroupList.Columns.TestGroupId));
                            obj = TTestgroupList.FetchByID(Utility.Int32Dbnull(txtID.Text, -1));
                            if (obj != null)
                            {
                                DataRow newDr = dtList.NewRow();
                                Utility.FromObjectToDatarow(obj, ref newDr);
                                newDr["TestType_Name"] = cboTestType.Text;
                                dtList.Rows.Add(newDr);
                            }
                            break;
                        default:
                            new Update(TTestgroupList.Schema.Name).Set(TTestgroupList.Columns.TestGroupName).EqualTo(txtName.Text).
                                Set(TTestgroupList.Columns.TestTypeId).EqualTo(Utility.Int32Dbnull(cboTestType.SelectedValue, -1)).
                                Where(TTestgroupList.Columns.TestGroupId).IsEqualTo(Utility.Int32Dbnull(txtID.Text)).
                                Execute();
                            obj = TTestgroupList.FetchByID(Utility.Int32Dbnull(txtID.Text, -1));
                            if(obj!=null)
                            {
                                DataRow newDr = Utility.GetDataRow(dtList, TTestgroupList.Columns.TestGroupId, obj.TestGroupId);
                                Utility.FromObjectToDatarow(obj,ref newDr);
                                newDr["TestType_Name"] = cboTestType.Text;
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
                    Utility.ShowMsg("Tên nhóm xét nhiệm không hợp lệ");
                    txtName.Focus();
                    return false;
                }
                else if (txtID.Text == "-1")
                {
                    int count =
                        new Select().From(TTestgroupList.Schema.Name).
                            Where(TTestgroupList.Columns.TestGroupName).IsEqualTo(txtName.Text).
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
            txtName.Focus();
            cboTestType.Enabled = true;
        }
    }
}