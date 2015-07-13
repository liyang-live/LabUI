using System;
using System.Data;
using System.Windows.Forms;
using SubSonic;
using VietBaIT.CommonLibrary;
using Vietbait.Lablink.Model;

namespace VietBaIT.LABLink.List.UI
{
    public partial class frmPort_AU : Form
    {
        public DataTable dtList;

        public frmPort_AU()
        {
            InitializeComponent();
            cboBaudRate.Text = "9600";
            cboDataBits.Text = "8";
            cboParity.Text = "None";
            cboStopBits.Text = "1";
        }

        private void frmTestDataList_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtID.Text))
                    txtID.Focus();
                else
                    LoadObject();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                Dispose();
            }
        }

        private void LoadObject()
        {
            LPort obj = LPort.FetchByID(Utility.Int32Dbnull(txtID.Text));
            txtID.Enabled = false;
            txtID.Text = Utility.sDbnull(obj.PortId);
            cboBaudRate.Text = obj.BaudRate;
            cboDataBits.Text = Utility.sDbnull(obj.DataBits);
            cboParity.Text = obj.Parity;
            cboStopBits.Text = obj.StopBits;
            txtPcName.Text = obj.LocalAlias;
            txtDesc.Text = obj.Description;
        }

        //private bool ValidData()
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(txtID.Text)) 
        //        {
        //            Utility.ShowMsg("Tên không hợp lệ");
        //            txtName.Focus();
        //            return false;
        //        }
        //        else if (vAction != action.Update && LStandardTest.FetchByID(txtID.Text) != null)
        //        {
        //            Utility.ShowMsg(string.Format("Đã tồn tại mã {0}", txtID.Text));
        //            txtID.Focus();
        //            txtID.SelectAll();
        //            return false;
        //        }

        //        if (string.IsNullOrEmpty(txtName.Text))
        //        {
        //            Utility.ShowMsg("Tên không hợp lệ");
        //            txtName.Focus();
        //            return false;
        //        }
        //        else
        //        {
        //            int count =
        //                new Select().From(LStandardTest.Schema.Name).
        //                Where(LStandardTest.Columns.TestTypeId).IsEqualTo(Utility.Int32Dbnull(cboTestType.SelectedValue, -1)).
        //                And(LStandardTest.Columns.DataName).IsEqualTo(txtName.Text).
        //                And(LStandardTest.Columns.TestDataId).IsNotEqualTo(txtID.Text).
        //                    ExecuteDataSet().Tables[0].Rows.Count;
        //            if (count > 0)
        //            {
        //                Utility.ShowMsg(cboTestType.Text + " đã có " + txtName.Text);
        //                txtName.Focus();
        //                txtName.SelectAll();
        //                return false;
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.ShowMsg(ex.Message);
        //        return false;
        //    }
        //}

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = txtID.Text.ToUpper();
                    switch (string.IsNullOrEmpty(txtID.Text))
                    {
                        case true:
                            //var obj = new LStandardTest();
                            //obj.TestDataId = Utility.sDbnull(txtID.Text, "NONE");
                            //obj.DataName = Utility.sDbnull(txtName.Text, "NONE");
                            //obj.DataSequence = Utility.Int32Dbnull(txtSequence.Value, 0);
                            //obj.TestTypeId = Utility.Int32Dbnull(cboTestType.SelectedValue, -1);
                            //obj.MeasureUnit = Utility.sDbnull(txtMeasureUnit.Text);
                            //obj.NormalLevel = Utility.sDbnull(txtNormalLevel.Text);
                            //obj.NormalLevelW = Utility.sDbnull(txtNormalLevelW.Text);
                            //obj.DataPoint = (short)Utility.Int32Dbnull(txtDataPoint.Value,0);
                            //obj.DataView = ckbDataView.Checked;
                            //obj.DataPrint = ckbDataPrint.Checked;
                            //obj.Description = Utility.sDbnull(txtDesc.Text);
                            //obj.IsNew = true;
                            //obj.Save();

                            //drData = dtTestDataList.NewRow();
                            //ApplyData2Datarow();
                            //dtTestDataList.Rows.InsertAt(drData, 0);
                            //dtTestDataList.AcceptChanges();
                            //txtID.Enabled = false;
                            //vAction=action.Update;
                            break;
                        case false:
                            //new Update(LStandardTest.Schema.Name).Set(LStandardTest.Columns.TestDataId).EqualTo(txtID.Text).
                            //    Set(LStandardTest.Columns.DataName).EqualTo(txtName.Text).
                            //    Set(LStandardTest.Columns.DataSequence).EqualTo(txtSequence.Text).
                            //    Set(LStandardTest.Columns.TestTypeId).EqualTo(Utility.Int32Dbnull(cboTestType.SelectedValue, -1)).
                            //    Set(LStandardTest.Columns.MeasureUnit).EqualTo(txtMeasureUnit.Text).
                            //    Set(LStandardTest.Columns.NormalLevel).EqualTo(txtNormalLevel.Text).
                            //    Set(LStandardTest.Columns.NormalLevelW).EqualTo(txtNormalLevelW.Text).
                            //    Set(LStandardTest.Columns.DataPoint).EqualTo(txtDataPoint.Text).
                            //    Set(LStandardTest.Columns.DataView).EqualTo(ckbDataView.Checked).
                            //    Set(LStandardTest.Columns.DataPrint).EqualTo(ckbDataPrint.Checked).
                            //    Set(LStandardTest.Columns.Description).EqualTo(txtDesc.Text).
                            //    Where(LStandardTest.Columns.TestDataId).IsEqualTo(txtID.Text).Execute();
                            //ApplyData2Datarow();
                            //drData.AcceptChanges();
                            break;
                    }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        //private void ApplyData2Datarow()
        //{
        //    drData[LStandardTest.Columns.TestDataId] = Utility.sDbnull(txtID.Text, "NONE");
        //    drData[LStandardTest.Columns.DataName] = Utility.sDbnull(txtName.Text, "NONE");
        //    drData[LStandardTest.Columns.DataSequence] = Utility.Int32Dbnull(txtSequence.Value, 0);
        //    drData[LStandardTest.Columns.TestTypeId] = Utility.Int32Dbnull(cboTestType.SelectedValue, -1);
        //    drData[TTestTypeList.Columns.TestTypeName] = Utility.sDbnull(cboTestType.Text, "NONE");
        //    drData[LStandardTest.Columns.MeasureUnit] = Utility.sDbnull(txtMeasureUnit.Text);
        //    drData[LStandardTest.Columns.NormalLevel] = Utility.sDbnull(txtNormalLevel.Text);
        //    drData[LStandardTest.Columns.NormalLevelW] = Utility.sDbnull(txtNormalLevelW.Text);
        //    drData[LStandardTest.Columns.DataPoint] = Utility.ByteDbnull(txtDataPoint.Value);
        //    drData[LStandardTest.Columns.DataView] = ckbDataView.Checked;
        //    drData[LStandardTest.Columns.DataPrint] = ckbDataPrint.Checked;
        //    drData[LStandardTest.Columns.Description] = Utility.sDbnull(txtDesc.Text);
        //}

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
            //vAction = action.Insert;
            //txtID.Enabled = true;
            //txtName.Clear();
            //txtMeasureUnit.Clear();
            //txtNormalLevel.Clear();
            //txtNormalLevelW.Clear();
            //txtDesc.Clear();
            //txtSequence.Value = 0;
            //txtDataPoint.Value = 0;
            //ckbDataPrint.Checked = true;
            //ckbDataView.Checked = true;
            //txtID.Focus();
            //txtID.Clear();
        }
    }
}