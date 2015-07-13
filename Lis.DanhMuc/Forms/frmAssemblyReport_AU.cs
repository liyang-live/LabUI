using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmAssemblyReport_AU : Form
    {
        public DataTable dtList;

        public frmAssemblyReport_AU()
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
            LAssemblyReport objManufacture = LAssemblyReport.FetchByID(txtID.Text);
            if(objManufacture!=null)
            {
                txtName.Text = Utility.sDbnull(objManufacture.ReportName);
                txtDll.Text = Utility.sDbnull(objManufacture.SDLLname);
                LoadCrptListToComboBox(txtDll.Text);
                cboASM.SelectedValue = Utility.sDbnull(objManufacture.SAssemblyName);
                txtDesc.Text = Utility.sDbnull(objManufacture.Desc);
                txtID.Enabled = false;
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
                txtID.Text = txtID.Text.ToUpper().Replace(" ", "");
                txtName.Text = txtName.Text.Trim();
                LAssemblyReport obj;
                if (ValidData())
                    if (txtID.Enabled)
                    {
                        obj = new LAssemblyReport();
                        obj.AssemblyReportId = Utility.sDbnull(txtID.Text);
                        obj.ReportName = Utility.sDbnull(txtName.Text);
                        obj.SDLLname = Utility.sDbnull(txtDll.Text);
                        obj.SAssemblyName = Utility.sDbnull(cboASM.SelectedValue);
                        obj.Desc = Utility.sDbnull(txtDesc.Text);
                        obj.IsNew = true;
                        obj.Save();

                        obj = LAssemblyReport.FetchByID(Utility.sDbnull(txtID.Text));
                        if (obj != null)
                        {
                            DataRow newDr = dtList.NewRow();
                            Utility.FromObjectToDatarow(obj, ref newDr);
                            dtList.Rows.Add(newDr);
                            txtID.Enabled = false;
                        }
                    }
                    else
                    {
                            new Update(LAssemblyReport.Schema.Name).Set(LAssemblyReport.Columns.ReportName).EqualTo(txtName.Text).
                                Set(LAssemblyReport.Columns.Desc).EqualTo(txtDesc.Text).
                                Set(LAssemblyReport.Columns.SAssemblyName).EqualTo(Utility.sDbnull(cboASM.SelectedValue)).
                                Set(LAssemblyReport.Columns.SDLLname).EqualTo(txtDll.Text).
                                Where(LAssemblyReport.Columns.AssemblyReportId).IsEqualTo(Utility.sDbnull(txtID.Text)).
                                Execute();
                            obj = LAssemblyReport.FetchByID(Utility.sDbnull(txtID.Text));
                            if(obj!=null)
                            {
                                DataRow newDr = Utility.GetDataRow(dtList, LAssemblyReport.Columns.AssemblyReportId,
                                                                   Utility.sDbnull(txtID.Text));
                                Utility.FromObjectToDatarow(obj, ref newDr);
                                newDr.AcceptChanges();
                            }
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
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    Utility.ShowMsg("ID không hợp lệ");
                    txtName.Focus();
                    return false;
                }
                else if (txtID.Enabled)
                {
                    int count =
                        new Select().From(LAssemblyReport.Schema.Name).
                            Where(LAssemblyReport.Columns.AssemblyReportId).IsEqualTo(txtID.Text).
                            ExecuteDataSet().Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        Utility.ShowMsg(txtID.Text + " đã tồn tại");
                        txtID.Focus();
                        txtID.SelectAll();
                        return false;
                    }
                }
                

                if (string.IsNullOrEmpty(txtName.Text))
                {
                    Utility.ShowMsg("Tên không hợp lệ");
                    txtName.Focus();
                    return false;
                }
                else if (txtID.Enabled)
                {
                    int count =
                        new Select().From(LAssemblyReport.Schema.Name).
                            Where(LAssemblyReport.Columns.ReportName).IsEqualTo(txtName.Text).
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
            txtID.Enabled = true;
            txtID.Clear();
            txtName.Clear();
            txtDesc.Clear();
            txtID.Focus();
        }

        private void txtDll_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                Stream myStream = null;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                //openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.InitialDirectory = Application.StartupPath;
                openFileDialog1.Filter = "dll files (*.dll)|*.dll";

                //openFileDialog1.FilterIndex = 2;
                //openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        myStream = openFileDialog1.OpenFile();
                        if (myStream != null)
                        {
                            //Utility.ShowMsg(openFileDialog1.FileName);
                            txtDll.Text = Path.GetFileName(openFileDialog1.FileName);
                            LoadCrptListToComboBox(openFileDialog1.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (myStream != null)
                        {
                            myStream.Flush();
                            myStream.Close();
                            myStream.Dispose();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.ToString(), "Lỗi !!!");
            }
        }

        private void LoadCrptListToComboBox(string sFileName)
        {
            try
            {
                Assembly asm = Assembly.LoadFrom(sFileName);
                cboASM.Items.Clear();
                foreach (Type type in asm.GetTypes())
                {
                    //if (typeof(type) == typeof(CrystalDecisions.CrystalReports.Engine.ReportDocument))
                    //    cboASM.Items.Add(type.Name, type.FullName);
                    try
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rpt =
                            (CrystalDecisions.CrystalReports.Engine.ReportDocument)Activator.CreateInstance(type);
                        cboASM.Items.Add(type.Name, type.FullName);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}