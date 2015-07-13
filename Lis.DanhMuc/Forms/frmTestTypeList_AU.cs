using System;
using System.Data;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmTestTypeList_AU : Form
    {
        public DataRow drList;
        public DataTable dtList;
        public action vAction;

        public frmTestTypeList_AU()
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
                        txtSequence.Focus();
                        break;
                    case action.Update:
                        LoadData();
                        txtSequence.Focus();
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
            txtID.Text = Utility.sDbnull(drList[TTestTypeList.Columns.TestTypeId]);
            txtName.Text = Utility.sDbnull(drList[TTestTypeList.Columns.TestTypeName]);
            txtSequence.Value = Utility.Int32Dbnull(drList[TTestTypeList.Columns.IntOrder], 0);
            txtAbbreviation.Text = Utility.sDbnull(drList[TTestTypeList.Columns.Abbreviation]);
            txtPrice.Value = Utility.DecimaltoDbnull(drList[TTestTypeList.Columns.Price]);
            ckbPrintDetail.Checked = Utility.Int32Dbnull(drList[TTestTypeList.Columns.PrintDetail], 0) == 1;
            txtDesc.Text = Utility.sDbnull(drList[TTestTypeList.Columns.Note]);
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
                            var obj = new TTestTypeList();
                            obj.TestTypeName = Utility.sDbnull(txtName.Text);
                            obj.IntOrder = Utility.ByteDbnull(txtSequence.Value);
                            obj.Abbreviation = Utility.sDbnull(txtAbbreviation.Text);
                            obj.Note = Utility.sDbnull(txtDesc.Text);
                            obj.Price = Utility.DecimaltoDbnull(txtPrice.Value);
                            obj.PrintDetail = Utility.ByteDbnull(ckbPrintDetail.Checked ? 1 : 0);
                            obj.IsNew = true;
                            obj.Save();

                            drList = dtList.NewRow();
                            drList[TTestTypeList.Columns.TestTypeId] =
                                TTestTypeList.CreateQuery().GetMax(TTestTypeList.Columns.TestTypeId);
                            ApplyData2Datarow();
                            dtList.Rows.InsertAt(drList, 0);
                            dtList.AcceptChanges();

                            txtID.Text = Utility.sDbnull(drList[TTestTypeList.Columns.TestTypeId]);
                            vAction = action.Update;
                            break;
                        case action.Update:
                            new Update(TTestTypeList.Schema.Name).Set(TTestTypeList.Columns.TestTypeName).EqualTo(
                                txtName.Text).
                                Set(TTestTypeList.Columns.IntOrder).EqualTo(txtSequence.Value).
                                Set(TTestTypeList.Columns.Abbreviation).EqualTo(txtAbbreviation.Text).
                                Set(TTestTypeList.Columns.Note).EqualTo(txtDesc.Text).
                                Set(TTestTypeList.Columns.Price).EqualTo(txtPrice.Value).
                                Set(TTestTypeList.Columns.PrintDetail).EqualTo(
                                    Utility.ByteDbnull(ckbPrintDetail.Checked ? 1 : 0)).
                                Where(TTestTypeList.Columns.TestTypeId).IsEqualTo(Utility.Int32Dbnull(txtID.Text)).
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
            drList[TTestTypeList.Columns.TestTypeName] = Utility.sDbnull(txtName.Text);
            drList[TTestTypeList.Columns.IntOrder] = Utility.Int32Dbnull(txtSequence.Value, 0);
            drList[TTestTypeList.Columns.Abbreviation] = Utility.sDbnull(txtAbbreviation.Text);
            drList[TTestTypeList.Columns.Note] = Utility.sDbnull(txtDesc.Text);
            drList[TTestTypeList.Columns.PrintDetail] = Utility.ByteDbnull(ckbPrintDetail.Checked ? 1 : 0);
            drList[TTestTypeList.Columns.Price] = Utility.DecimaltoDbnull(txtPrice.Value);
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
                        new Select().From(TTestTypeList.Schema.Name).
                            Where(TTestTypeList.Columns.TestTypeName).IsEqualTo(txtName.Text).
                            ExecuteDataSet().Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        Utility.ShowMsg(txtName.Text + " đã tồn tại");
                        txtName.Focus();
                        txtName.SelectAll();
                        return false;
                    }
                }

                if (string.IsNullOrEmpty(txtAbbreviation.Text))
                {
                    Utility.ShowMsg("Tên viết tắt không hợp lệ");
                    txtName.Focus();
                    return false;
                }
                else if (vAction == action.Insert)
                {
                    int count =
                        new Select().From(TTestTypeList.Schema.Name).
                            Where(TTestTypeList.Columns.Abbreviation).IsEqualTo(txtAbbreviation.Text).
                            ExecuteDataSet().Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        Utility.ShowMsg(txtAbbreviation.Text + " đã tồn tại");
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
            txtAbbreviation.Clear();
            txtPrice.Value = 0;
            txtDesc.Clear();
            txtSequence.Value = 0;
            ckbPrintDetail.Checked = true;
            txtSequence.Focus();
        }
    }
}