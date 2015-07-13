using System;
using System.Data;
using System.Windows.Forms;
using Janus.Windows.UI.Tab;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI.Forms
{
    public partial class frmDanhMucChung : Form
    {
        private DataTable dtDepartment;
        private DataTable dtDevice;
        private DataTable dtDoctor;
        private DataTable dtManufacturer, dtObject;
        private DataTable dtTestType;

        public frmDanhMucChung()
        {
            InitializeComponent();
        }

        private void tabGeneralList_SelectedTabChanged(object sender, TabEventArgs e)
        {
            PerformAction(action.Normal);
        }

        private void frmGeneralList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.N:
                        cmdSave.PerformClick();
                        break;
                    case Keys.U:
                        cmdUpdate.PerformClick();
                        break;
                    case Keys.E:
                        btnExportToExcel.PerformClick();
                        break;
                    case Keys.Tab:
                        tabGeneralList.SelectedIndex = tabGeneralList.SelectedIndex == tabGeneralList.TabPages.Count - 1
                                                           ? 0
                                                           : tabGeneralList.SelectedIndex + 1;
                        break;
                }
            else
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        cmdExit.PerformClick();
                        break;
                    case Keys.Delete:
                        cmdDelete.PerformClick();
                        break;
                }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            PerformAction(action.Insert);
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            PerformAction(action.Update);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            PerformAction(action.Delete);
        }

        private void PerformAction(action vAction)
        {
            try
            {
                UITabPage selectedTab = tabGeneralList.SelectedTab;
                switch (selectedTab.Name)
                {
                    case "tabTestType":
                        LoadFormTestTypeAU(vAction);
                        break;
                    case "tabManufacturer":
                        ActionManufacturer(vAction);
                        break;
                    case "tabDevice":
                        ActionDevice(vAction);
                        break;
                    case "tabObject":
                        ActionObject(vAction);
                        break;
                    case "tabDepartment":
                        ActionDepartment(vAction);
                        break;
                    case "tabDoctor":
                        ActionDoctor(vAction);
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void LoadFormTestTypeAU(action vAction)
        {
            try
            {
                if (grdTestType.CurrentRow == null && (vAction == action.Update || vAction == action.Delete)) return;

                switch (vAction)
                {
                    case action.Normal:
                        dtTestType =
                            new Select().From(TTestTypeList.Schema.Name).OrderAsc(TTestTypeList.Columns.IntOrder).
                                ExecuteDataSet().Tables[0];
                        grdTestType.DataSource = dtTestType;
                        break;
                    case action.Delete:
                        if (
                            DDeviceList.CreateQuery().WHERE(DDeviceList.Columns.TestTypeId,
                                                            Utility.Int32Dbnull(grdTestType.GetValue("TestType_ID"))).
                                GetRecordCount() > 0)
                        {
                            Utility.ShowMsg("Danh mục đang được sử dụng. Không được xóa");
                            return;
                        }
                        if (Utility.AcceptQuestion("Thực hiện xóa " + grdTestType.GetValue("TestType_Name"), "Thông báo", true))
                        {
                            new Delete().From(TTestTypeList.Schema.Name).Where(TTestTypeList.Columns.TestTypeId).
                                IsEqualTo(
                                    Utility.Int32Dbnull(grdTestType.GetValue("TestType_ID"))).Execute();
                            grdTestType.CurrentRow.Delete();
                            grdTestType.UpdateData();
                        }
                        break;
                    default:
                        var oForm = new frmTestTypeList_AU();
                        oForm.vAction = vAction;
                        oForm.drList = Utility.GetDataRow(dtTestType, TTestTypeList.Columns.TestTypeId,
                                                          grdTestType.GetValue("TestType_ID"));
                        oForm.dtList = dtTestType;
                        oForm.ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void ActionManufacturer(action vAction)
        {
            try
            {
                if (grdManufacturer.CurrentRow == null && (vAction == action.Update || vAction == action.Delete))
                    return;

                switch (vAction)
                {
                    case action.Normal:
                        dtManufacturer = new Select().From(LManufacture.Schema.Name).ExecuteDataSet().Tables[0];
                        grdManufacturer.DataSource = dtManufacturer;
                        break;
                    case action.Delete:
                        if (
                            DDeviceList.CreateQuery().WHERE(DDeviceList.Columns.ManufactureId,
                                                            Utility.Int32Dbnull(grdManufacturer.GetValue("ID"))).
                                GetRecordCount() > 0)
                        {
                            Utility.ShowMsg("Danh mục đang được sử dụng. Không được xóa");
                            return;
                        }
                        if (Utility.AcceptQuestion("Thực hiện xóa " + grdManufacturer.GetValue("sName"), "Thông báo",
                                                   true))
                        {
                            new Delete().From(LManufacture.Schema.Name).Where(LManufacture.Columns.Id).IsEqualTo(
                                Utility.Int32Dbnull(grdManufacturer.GetValue("ID"))).Execute();
                            grdManufacturer.CurrentRow.Delete();
                            grdManufacturer.UpdateData();
                        }
                        break;
                    default:
                        var oForm = new frmManufacturerList_AU();
                        if(vAction==action.Update) oForm.txtID.Text = Utility.sDbnull(grdManufacturer.GetValue("ID"));
                        oForm.dtList = dtManufacturer;
                        oForm.grdList = grdManufacturer;
                        oForm.ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void ActionDevice(action vAction)
        {
            try
            {
                if (grdDevice.CurrentRow == null && (vAction == action.Update || vAction == action.Delete)) return;

                switch (vAction)
                {
                    case action.Normal:
                        dtDevice =
                            new Select(DDeviceList.Schema.Name + ".*", TTestTypeList.Columns.TestTypeName,
                                       LManufacture.Columns.SName)
                                .From(DDeviceList.Schema.Name).
                                LeftOuterJoin(TTestTypeList.TestTypeIdColumn, DDeviceList.TestTypeIdColumn).
                                LeftOuterJoin(LManufacture.IdColumn, DDeviceList.ManufactureIdColumn).
                                ExecuteDataSet().Tables[0];
                        grdDevice.DataSource = dtDevice;
                        break;
                    case action.Delete:
                        if (
                            DDataControl.CreateQuery().WHERE(DDataControl.Columns.DeviceId,Utility.Int32Dbnull(grdDevice.GetValue("Device_ID"))).
                                GetRecordCount() > 0)
                        {
                            Utility.ShowMsg("Danh mục đang được sử dụng. Không được xóa");
                            return;
                        }
                        if (Utility.AcceptQuestion("Thực hiện xóa " + grdDevice.GetValue("Device_Name"), "Thông báo",
                                                   true))
                        {
                            new Delete().From(DDeviceList.Schema.Name).Where(DDeviceList.Columns.DeviceId).IsEqualTo(
                                Utility.Int32Dbnull(grdDevice.GetValue("Device_ID"))).Execute();
                            grdDevice.CurrentRow.Delete();
                            grdDevice.UpdateData();
                        }
                        dtDevice.AcceptChanges();
                        break;
                    default:
                        var oForm = new frmDeviceList_AU();
                        oForm.vAction = vAction;
                        oForm.drList = Utility.GetDataRow(dtDevice, DDeviceList.Columns.DeviceId,
                                                          grdDevice.GetValue("Device_ID"));
                        oForm.dtList = dtDevice;
                        oForm.ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void ActionObject(action vAction)
        {
            try
            {
                if (grdObject.CurrentRow == null && (vAction == action.Update || vAction == action.Delete)) return;

                switch (vAction)
                {
                    case action.Normal:
                        dtObject = new Select().From(LObjectType.Schema.Name).ExecuteDataSet().Tables[0];
                        grdObject.DataSource = dtObject;
                        break;
                    case action.Delete:
                        if (
                            LPatientInfo.CreateQuery().WHERE(LPatientInfo.Columns.ObjectType,
                                                             Utility.Int32Dbnull(grdObject.GetValue("ID"))).
                                GetRecordCount() > 0)
                        {
                            Utility.ShowMsg("Danh mục đang được sử dụng. Không được xóa");
                            return;
                        }
                        if (Utility.AcceptQuestion("Thực hiện xóa " + grdObject.GetValue("sName"), "Thông báo", true))
                        {
                            new Delete().From(LObjectType.Schema.Name).Where(LObjectType.Columns.Id).IsEqualTo(
                                Utility.Int32Dbnull(grdObject.GetValue("ID"))).Execute();
                            grdObject.CurrentRow.Delete();
                            grdObject.UpdateData();
                        }
                        dtObject.AcceptChanges();
                        break;
                    default:
                        var oForm = new frmObjectTypeList_AU();
                        oForm.vAction = vAction;
                        oForm.drList = Utility.GetDataRow(dtObject, LObjectType.Columns.Id, grdObject.GetValue("ID"));
                        oForm.dtList = dtObject;
                        oForm.ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void ActionDepartment(action vAction)
        {
            try
            {
                if (grdDepartment.CurrentRow == null && (vAction == action.Update || vAction == action.Delete)) return;

                switch (vAction)
                {
                    case action.Normal:
                        dtDepartment = new Select().From(LDepartment.Schema.Name).ExecuteDataSet().Tables[0];
                        grdDepartment.DataSource = dtDepartment;
                        break;
                    case action.Delete:
                        if (
                            LPatientInfo.CreateQuery().WHERE(LPatientInfo.Columns.DepartmentID,
                                                             Utility.Int32Dbnull(grdDepartment.GetValue("ID"))).
                                GetRecordCount() > 0)
                        {
                            Utility.ShowMsg("Danh mục đang được sử dụng. Không được xóa");
                            return;
                        }
                        if (Utility.AcceptQuestion("Thực hiện xóa " + grdDepartment.GetValue("sName"), "Thông báo", true))
                        {
                            new Delete().From(LDepartment.Schema.Name).Where(LDepartment.Columns.Id).IsEqualTo(
                                Utility.Int32Dbnull(grdDepartment.GetValue("ID"))).Execute();
                            grdDepartment.CurrentRow.Delete();
                            grdDepartment.UpdateData();
                        }
                        dtDepartment.AcceptChanges();
                        break;
                    default:
                        var oForm = new frmDepartmentList_AU();
                        oForm.vAction = vAction;
                        oForm.drList = Utility.GetDataRow(dtDepartment, LDepartment.Columns.Id,
                                                          grdDepartment.GetValue("ID"));
                        oForm.dtList = dtDepartment;
                        oForm.ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void ActionDoctor(action vAction)
        {
            try
            {
                if (grdDoctor.CurrentRow == null && (vAction == action.Update || vAction == action.Delete)) return;

                switch (vAction)
                {
                    case action.Normal:
                        dtDoctor = new Select().From(LUser.Schema.Name).ExecuteDataSet().Tables[0];
                            grdDoctor.DataSource = dtDoctor;
                        break;
                    case action.Delete:
                        if (TTestInfo.CreateQuery().WHERE(TTestInfo.Columns.DiagnosticianId,Utility.Int32Dbnull(grdDoctor.GetValue("User_ID"))).
                            OR(TTestInfo.Columns.AssignId,Utility.Int32Dbnull(grdDoctor.GetValue("User_ID"))).GetRecordCount() > 0)
                        {
                            Utility.ShowMsg("Danh mục đang được sử dụng. Không được xóa");
                            return;
                        }
                        if (Utility.AcceptQuestion("Thực hiện xóa " + grdDoctor.GetValue("User_Name"), "Thông báo", true))
                        {
                            new Delete().From(LUser.Schema.Name).Where(LUser.Columns.UserId).
                                IsEqualTo(Utility.Int32Dbnull(grdDoctor.GetValue("User_ID"))).
                                Execute();
                            grdDoctor.CurrentRow.Delete();
                            grdDoctor.UpdateData();
                            dtDoctor.AcceptChanges();
                        }

                        break;
                    default:
                        var oForm = new frmDoctorList_AU();
                        oForm.vAction = vAction;
                        oForm.drList = Utility.GetDataRow(dtDoctor, LUser.Columns.UserId,grdDoctor.GetValue("User_ID"));
                        oForm.dtList = dtDoctor;
                        oForm.ShowDialog();
                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //Reports.ExcelReport.ExportGridEx((Janus.Windows.GridEX.GridEX)tabGeneralList.SelectedTab.Controls[0]);
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
            
        }
    }
}