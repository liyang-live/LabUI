using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmUser_FormControl_AU : Form
    {
        public DataTable dtList;
        public Janus.Windows.GridEX.GridEX grdList;

        public frmUser_FormControl_AU()
        {
            InitializeComponent();
        }

        private void frmTestTypeList_AU_Load(object sender, EventArgs e)
        {
            try
            {
                LoadControlTypeList();
                if(!string.IsNullOrEmpty(txtID.Text)) LoadData();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                Close();
            }
        }

        private void LoadControlTypeList()
        {
            ArrayList arr = new ArrayList();
            arr.Add("");
            arr.Add("Win.ToolStrip");
            arr.Add("Win.ContextMenuStrip");
            for (int i = 0; i < arr.Count; i++)
            {
                cboType.Items.Add(arr[i]);
            }
            cboType.SelectedIndex = 0;
        }

        private void LoadData()
        {
            LFormControl obj = LFormControl.FetchByID(txtID.Text);
            if(obj!=null)
            {
                txtFormName.Text = Utility.sDbnull(obj.FormName);
                txtControlName.Text = Utility.sDbnull(obj.ControlName);
                cboProperty.Text = Utility.sDbnull(obj.PropertyName);
                cboType.Text = Utility.sDbnull(obj.ControlTypeName);
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
                LFormControl obj;
                if (ValidData())
                    switch (txtID.Text)
                    {
                        case "-1":
                            obj = new LFormControl();
                            obj.FormName = Utility.sDbnull(txtFormName.Text);
                            obj.ControlName = Utility.sDbnull(txtControlName.Text);
                            obj.PropertyName = Utility.sDbnull(cboProperty.Text);
                            obj.ControlTypeName = Utility.sDbnull(cboType.Text);
                            obj.IsNew = true;
                            obj.Save();

                            txtID.Text = Utility.sDbnull(LFormControl.CreateQuery().GetMax(LFormControl.Columns.ControlId));
                            obj = LFormControl.FetchByID(Utility.Int32Dbnull(txtID.Text, -1));
                            if (obj != null)
                            {
                                DataRow newDr = dtList.NewRow();
                                Utility.FromObjectToDatarow(obj, ref newDr);
                                dtList.Rows.Add(newDr);
                            }
                            break;
                        default:
                            new Update(LFormControl.Schema.Name).Set(LFormControl.Columns.FormName).EqualTo(txtFormName.Text).
                                Set(LFormControl.Columns.ControlName).EqualTo(txtControlName.Text).
                                Set(LFormControl.Columns.PropertyName).EqualTo(cboProperty.Text).
                                Set(LFormControl.Columns.ControlTypeName).EqualTo(cboType.Text).
                                Where(LFormControl.Columns.ControlId).IsEqualTo(Utility.Int32Dbnull(txtID.Text)).
                                Execute();
                            obj = LFormControl.FetchByID(Utility.Int32Dbnull(txtID.Text, -1));
                            if(obj!=null)
                            {
                                DataRow newDr = Utility.GetDataRow(dtList, LFormControl.Columns.ControlId, obj.ControlId);
                                Utility.FromObjectToDatarow(obj,ref newDr);
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
                if (string.IsNullOrEmpty(txtFormName.Text) | string.IsNullOrEmpty(txtControlName.Text))
                {
                    Utility.ShowMsg("Tên khai báo không hợp lệ");
                    //txtFormName.Focus();
                    return false;
                }
                else if (txtID.Text == "-1")
                {
                    int count =
                        new Select().From(LFormControl.Schema.Name).
                            Where(LFormControl.Columns.FormName).IsEqualTo(txtFormName.Text).
                            And(LFormControl.Columns.ControlName).IsEqualTo(txtControlName.Text).
                            And(LFormControl.Columns.PropertyName).IsEqualTo(cboProperty.Text).
                            And(LFormControl.Columns.ControlTypeName).IsEqualTo(cboType.Text).
                            ExecuteDataSet().Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        Utility.ShowMsg(cboProperty.Text + " đã tồn tại");
                        cboProperty.Focus();
                        //txtPropertyName.SelectAll();
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
            txtFormName.Clear();
            txtControlName.Clear();
            //txtPropertyName.Clear();
            txtFormName.Focus();
        }
    }
}