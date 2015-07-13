using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class Frm_Config : Form
    {
        public FrmAllMainProperties Object;

        public Frm_Config()
        {
            InitializeComponent();
        }

        private void Frm_HisLis_Config_Load(object sender, EventArgs e)
        {
            try
            {
                grdProperties.SelectedObject = Object;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong quá trình nạp form {0}", ex.ToString());
            }
        }
    }
}