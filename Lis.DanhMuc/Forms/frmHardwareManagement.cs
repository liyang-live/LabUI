using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using VietBaIT.CommonLibrary;
using SubSonic;
using Vietbait.Lablink.Model;

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmHardwareManagement : Form
    {
        private DataTable dtDevice;
        private DataTable dtPort;

        public frmHardwareManagement()
        {
            InitializeComponent();
        }

        private void frmHardwareManagement_Load(object sender, EventArgs e)
        {
            try
            {
                dtPort = new Select().From(LPort.Schema).ExecuteDataSet().Tables[0];
                grdPort.DataSource = dtPort;

                dtDevice = new Select(DDeviceList.Schema.Name + ".*", TTestTypeList.Columns.TestTypeName,
                                       LManufacture.Columns.SName,LPort.Columns.LocalAlias)
                                .From(DDeviceList.Schema.Name).
                                LeftOuterJoin(TTestTypeList.TestTypeIdColumn, DDeviceList.TestTypeIdColumn).
                                LeftOuterJoin(LManufacture.IdColumn, DDeviceList.ManufactureIdColumn).
                                LeftOuterJoin(LPort.PortIdColumn, DDeviceList.PortIdColumn).
                                ExecuteDataSet().Tables[0];
                grdDevice.DataSource = dtDevice;
                cboList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                cmdExit.PerformClick();
            }
        }

        private List<string> GetMacArdress()
        {
            var result = new List<string>();
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface nic in nics)
                {
                    string mac = nic.GetPhysicalAddress().ToString();
                    if (!string.IsNullOrEmpty(mac)) result.Add(mac);
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        private void PerfromUpdatePortId(bool UpdateOrClear)
        {
            try
            {
                if (grdDevice.CurrentRow == null | grdPort.CurrentRow == null) return;
                if (grdDevice.CurrentRow.RowType != RowType.Record | grdPort.CurrentRow.RowType != RowType.Record)
                {
                    Utility.ShowMsg("Lựa chọn không đúng !");
                    return;
                }
                int portID = UpdateOrClear ? Utility.Int32Dbnull(grdPort.GetValue("Port_ID")) : -1;
                int deviceID = Utility.Int32Dbnull(grdDevice.GetValue("Device_ID"));
                if (UpdateOrClear)
                    if (DDeviceList.CreateQuery().WHERE(DDeviceList.Columns.PortId,portID).GetRecordCount() > 0)
                    {
                        Utility.ShowMsg(string.Format("Cổng {0} đã được sử dụng !",portID));
                        return;
                    }
                new Update(DDeviceList.Schema).Set(DDeviceList.Columns.PortId).EqualTo(UpdateOrClear ? portID : SqlInt32.Null).
                    Where(DDeviceList.Columns.DeviceId).IsEqualTo(deviceID).Execute();
                grdPort.RootTable.FormatConditions[0].Value1 = portID;
                if (UpdateOrClear)
                {
                    grdDevice.SetValue("Port_ID", portID);
                    grdDevice.SetValue("LocalAlias", Utility.sDbnull(grdPort.GetValue("LocalAlias")));
                }
                else
                {
                    grdDevice.SetValue("Port_ID", DBNull.Value);
                    grdDevice.SetValue("LocalAlias", DBNull.Value);
                }
                grdDevice.UpdateData();
                dtDevice.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PerfromUpdatePortId(true);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PerfromUpdatePortId(false);
        }

        private void grdDevice_CellValueChanged(object sender, ColumnActionEventArgs e)
        {
            try
            {
                if (grdDevice.CurrentColumn.Key == "Valid")
                {
                    new Update(DDeviceList.Schema).Set(DDeviceList.Columns.Valid).EqualTo(grdDevice.GetValue("Valid")).
                    Where(DDeviceList.Columns.DeviceId).IsEqualTo(Utility.Int32Dbnull(grdDevice.GetValue("Device_ID"))).Execute();
                }
                grdDevice.UpdateData();
                dtDevice.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdDevice_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                grdPort.RootTable.FormatConditions[0].Value1 = Utility.Int32Dbnull(grdDevice.GetValue("Port_ID"),-1);
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmHardwareManagement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.N :
                        cmdSave.PerformClick();
                        break;
                    case Keys.U:
                        cmdUpdate.PerformClick();
                        break;
                }
            else
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    cmdDelete.PerformClick();
                    break;
                case Keys.Escape :
                    cmdExit.PerformClick();
                    break;
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPort.CurrentRow == null) return;
                if (grdPort.CurrentRow.RowType != RowType.Record) return;
                frmPort_AU oForm = new frmPort_AU();
                oForm.txtID.Text = Utility.sDbnull(grdPort.GetValue("Port_ID"));
                oForm.dtList = dtPort;
                oForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            frmPort_AU oForm = new frmPort_AU();
            oForm.ShowDialog();
        }

        private void grdPort_DoubleClick(object sender, EventArgs e)
        {
            cmdUpdate.PerformClick();
        }
    }
}