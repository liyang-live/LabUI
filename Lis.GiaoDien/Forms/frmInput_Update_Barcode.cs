using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class frmInput_Update_Barcode : Form
    {
        private bool _cancel = true;
        public string intOrder = "";
        public int vPatient_ID = -1;
        public int vTestType_ID = -1;
        public action VAction = action.Insert;

        public frmInput_Update_Barcode()
        {
            InitializeComponent();
        }

        private void frmInput_Update_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        Close();
                        break;
                    case Keys.Enter:
                        btnAccept.PerformClick();
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private bool BarcodeExist()
        {
            try
            {
                int count = 1;
                switch (SysPara.AutoGenerateBarcode)
                {
                    case 0:
                    case 1:
                        count = new Select().From(TTestInfo.Schema).Where(TTestInfo.Columns.Barcode).IsEqualTo(txtBarcode.Text.Trim()).
                            And(TTestInfo.Columns.PatientId).IsNotEqualTo(vPatient_ID).GetRecordCount();
                        break;
                    case 2:
                        count = new Select().From(TTestInfo.Schema).Where(TTestInfo.Columns.TestTypeId).IsEqualTo(vTestType_ID).
                        And(TTestInfo.Columns.Barcode).IsEqualTo(txtBarcode.Text.Trim()).GetRecordCount();
                        break;
                }
                if (count > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        private void BarcodeFinalize()
        {
            if (txtBarcode.Text.Length <= 4)
            {
                txtBarcode.Text = dtpDate.Value.Date.ToString("yyMMdd") + intOrder + txtBarcode.Text.PadLeft(4, '0');
            }
        }

        private void shakeMe()
        {
            Point myLoc;
            Point myLocDef;
            myLocDef = Location;
            myLoc = Location;
            for (int i = 0; i <= 15; i++)
            {
                for (int x = 0; x <= 4; x++)
                {
                    switch (x)
                    {
                        case 0:
                            myLoc.X = myLocDef.X + 10;
                            break;
                        case 1:
                            myLoc.X = myLocDef.X - 10;
                            break;
                        case 2:
                            myLoc.Y = myLocDef.Y - 10;
                            break;
                        case 3:
                            myLoc.Y = myLocDef.Y + 10;
                            break;
                        case 4:
                            myLoc = myLocDef;
                            break;
                    }
                    Location = myLoc;
                    Refresh();
                }
            }
            Location = myLocDef;
            Refresh();
        }

        private void frmInput_Update_Barcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cancel) txtBarcode.Text = "";
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBarcode.Text)) return;
                BarcodeFinalize();
                if (BarcodeExist())
                {
                    Text = "Barcode tồn tại. Mời nhập lại.";
                    shakeMe();
                    txtBarcode.Focus();
                    txtBarcode.SelectAll();
                    _cancel = true;
                }
                else
                {
                    _cancel = false;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void frmInput_Update_Barcode_Load(object sender, EventArgs e)
        {

        }
    }
}