using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Vietbait.Lablink.TestInformation.UI.Forms;

namespace Vietbait.Lablink.TestInformation.UI
{
    public partial class frmQuickInputResult : Form
    {
        public frmQuickInputResult()
        {
            InitializeComponent();
            var x = new Uc_QuickInputResult {Dock = DockStyle.Fill};
            this.Controls.Add(x);
        }
    }
}
