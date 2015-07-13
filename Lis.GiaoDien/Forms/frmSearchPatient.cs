using System;
using System.Data;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class frmSearchPatient : Form
    {
        private DataTable dtPatient;
        public Int32 vSelectedID = -1;

        public frmSearchPatient()
        {
            InitializeComponent();
        }

        private void frmSearchPatient_Load(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            cmdSearch.PerformClick();
        }

        private void grdPatients_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grdPatients.CurrentRow != null)
                {
                    vSelectedID = Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"));
                    Close();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dtPatient = SPs.SpGetPatientInforByBarcodeAndName("NOTHING", "NOTHING", -1, -1,
                                                          dtpDate.Value, dtpDate.Value,
                                                          txtBarcode.Text == "" ? "NOTHING" : txtBarcode.Text).GetDataSet().Tables[0];
                grdPatients.DataSource = dtPatient;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void frmSearchPatient_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                    case Keys.Escape:
                    btnExit.PerformClick();
                    break;
                    case Keys.F3:
                    cmdSearch.PerformClick();
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
            vSelectedID = -1;
        }
    }
}