using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Management;
namespace CIS2008
{
    public partial class frm_Register : Form
    {
        public frm_Register()
        {
            InitializeComponent();
        }
        // CARSOFT_V2.GetMachineInfoModule
        /// <summary>
        ///           ''' return Volume Serial Number from hard drive
        ///           ''' </summary>
        /// <param name="strDriveLetter">[optional] Drive letter</param>
        /// <returns>[string] VolumeSerialNumber</returns>
        private string GetHWID()
        {
            string seri_hdd = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                // get the hardware serial no.
                if (wmi_HD["SerialNumber"] != null)
                    seri_hdd = wmi_HD["SerialNumber"].ToString();
            }
            return seri_hdd;
        }

        private void frm_Register_Load(object sender, EventArgs e)
        {

            // Set all the fields to the appropriate values
            //TxtCPUCode.Text = GetHWID();
            //TxtHDDCode.Text = 

        }
    }
}
