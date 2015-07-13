using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using VNS.Libs;
using LIS.DAL;
using SubSonic;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class Uc_QuickInputResult : UserControl
    {
        #region KeyDown Handler
        private struct MSG
        {
            public IntPtr hwnd;
            public int message;
            public IntPtr wParam;
            public IntPtr lParam;
            public int time;
            public int pt_x;
            public int pt_y;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool PeekMessage([In, Out] ref MSG msg,
            HandleRef hwnd, int msgMin, int msgMax, int remove);

        //----------------------------------------------

        /// <summary> 
        /// Trap any keypress before child controls get hold of them
        /// </summary>
        /// <param name="m">Windows message</param>
        /// <returns>True if the keypress is handled</returns>
        protected override bool ProcessKeyPreview(ref Message m)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_KEYUP = 0x101;
            const int WM_CHAR = 0x102;
            const int WM_SYSCHAR = 0x106;
            const int WM_SYSKEYDOWN = 0x104;
            const int WM_SYSKEYUP = 0x105;
            const int WM_IME_CHAR = 0x286;

            KeyEventArgs e = null;

            if ((m.Msg != WM_CHAR) && (m.Msg != WM_SYSCHAR) && (m.Msg != WM_IME_CHAR))
            {
                e = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys);
                if ((m.Msg == WM_KEYDOWN) || (m.Msg == WM_SYSKEYDOWN))
                {
                    TrappedKeyDown(e);
                }
                //else
                //{
                //    TrappedKeyUp(e);
                //}

                // Remove any WM_CHAR type messages if supresskeypress is true.
                if (e.SuppressKeyPress)
                {
                    this.RemovePendingMessages(WM_CHAR, WM_CHAR);
                    this.RemovePendingMessages(WM_SYSCHAR, WM_SYSCHAR);
                    this.RemovePendingMessages(WM_IME_CHAR, WM_IME_CHAR);
                }

                if (e.Handled)
                {
                    return e.Handled;
                }
            }
            return base.ProcessKeyPreview(ref m);
        }

        private void RemovePendingMessages(int msgMin, int msgMax)
        {
            if (!this.IsDisposed)
            {
                MSG msg = new MSG();
                IntPtr handle = this.Handle;
                while (PeekMessage(ref msg,
                new HandleRef(this, handle), msgMin, msgMax, 1))
                {
                }
            }
        }

        /// <summary>
        /// This routine gets called if a keydown has been trapped 
        /// before a child control can get it.
        /// </summary>
        /// <param name="e"></param>
        private void TrappedKeyDown(KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        txtBarcode.Focus();
                        txtBarcode.SelectAll();
                        break;
                    case Keys.F2:
                        txtCanLamSangID.Focus();
                        txtCanLamSangID.SelectAll();
                        break;
                    case Keys.F3:
                        btnSearch.PerformClick();
                        break;
                    case Keys.Escape:
                        Dispose();
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion


        private DataTable dtPatientInfo;

        public Uc_QuickInputResult()
        {
            InitializeComponent();
        }

        private void frmQuickInputResult_Load(object sender, EventArgs e)
        {
            DataTable dtTestType = new Select().From(TTestTypeList.Schema.Name).OrderAsc(TTestTypeList.Columns.IntOrder).
                ExecuteDataSet().Tables[0];
            DataBinding.BindDataCombobox_Basic(cboTestType, dtTestType,TTestTypeList.Columns.TestTypeId, TTestTypeList.Columns.TestTypeName);
            ActiveControl = txtBarcode;
            //btnSearch.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBarcode.Text.Trim()) & string.IsNullOrEmpty(txtCanLamSangID.Text.Trim()))
                {
                    Utility.ShowMsg("Bạn cần nhập thông tin barcode hoặc số CMT");
                    txtBarcode.Focus();
                    return;
                }

                dtPatientInfo =
                    SPs.SpGetPatientForQuickInputResult(dtpDateFrom.Value.Date,
                                                        dtpDateFrom.Value.Date.AddDays(1).AddMilliseconds(-1),
                                                        Utility.Int32Dbnull(cboTestType.SelectedValue), txtBarcode.Text, txtCanLamSangID.Text)
                        .GetDataSet().Tables[0];
                grdPatientInfo.DataSource = dtPatientInfo;
                grdPatientInfo.Focus();
                grdPatientInfo.CurrentColumn = grdPatientInfo.RootTable.Columns["Test_Result"];
                grdPatientInfo.MoveFirst();
                if (globalVariables.UserName == "ADMIN" || globalVariables.UserName == "LIS_ADMIN")
                {
                    grdPatientInfo.AllowEdit = InheritableBoolean.True;

                }
                else
                {
                    grdPatientInfo.AllowEdit = Utility.Int32Dbnull(grdPatientInfo.GetValue("SentStatus")) != 1
                                                   ? InheritableBoolean.True
                                                   : InheritableBoolean.False;
                }
            }
            catch (Exception ex) 
            {
                Utility.ShowMsg(ex.Message);   
            }
        }

        private void grdPatientInfo_CellUpdated(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (grdPatientInfo.CurrentRow.RowType != RowType.Record |
                    grdPatientInfo.CurrentColumn.Key != "Test_Result") return;
                if (string.IsNullOrEmpty(Utility.sDbnull(grdPatientInfo.GetValue("TestData_ID")))) return;
                if (grdPatientInfo.CurrentRow == null) return;
                if (Utility.Int32Dbnull(grdPatientInfo.GetValue("TestDetail_ID"), -1) > 0)
                {
                    new Update(TResultDetail.Schema.Name).Set(TResultDetail.Columns.ParaName)
                        .EqualTo(Utility.sDbnull(grdPatientInfo.GetValue("Para_Name"))).
                        Set(TResultDetail.Columns.TestResult).EqualTo(Utility.sDbnull(grdPatientInfo.GetValue("Test_Result"))).
                        Where(TResultDetail.Columns.TestDetailId).IsEqualTo(Utility.Int32Dbnull(grdPatientInfo.GetValue("TestDetail_ID"), -1)).
                        Execute();
                }

                else
                {
                    var obj = new TResultDetail();
                    obj.TestId = Utility.Int32Dbnull(grdPatientInfo.GetValue("Test_ID"), -1);
                    obj.PatientId = Utility.Int32Dbnull(grdPatientInfo.GetValue("Patient_ID"), -1);
                    obj.TestTypeId = Utility.Int32Dbnull(grdPatientInfo.GetValue("TestType_ID"), -1);
                    obj.TestDate = DateTime.Now;
                    obj.DataSequence = Utility.Int32Dbnull(grdPatientInfo.GetValue("Data_Sequence"));
                    obj.TestResult = Utility.sDbnull(grdPatientInfo.GetValue("Test_Result"));
                    obj.NormalLevel = Utility.sDbnull(grdPatientInfo.GetValue("Normal_Level"));
                    obj.NormalLevelW = Utility.sDbnull(grdPatientInfo.GetValue("Normal_levelW"));
                    obj.MeasureUnit = Utility.sDbnull(grdPatientInfo.GetValue("Measure_Unit"));
                    obj.ParaName = Utility.sDbnull(grdPatientInfo.GetValue("Para_Name"));
                    obj.TestDataId = Utility.sDbnull(grdPatientInfo.GetValue("TestData_ID"));
                    obj.ParaStatus = 0;
                    obj.PrintData = true;
                    obj.Barcode = Utility.sDbnull(grdPatientInfo.GetValue("Barcode"));
                    obj.UpdateNum = 0;
                    obj.IsNew = true;
                    obj.Save();
                    //grdPatientInfo.CurrentRow.Cells["TestDetail_ID"].Value = obj.TestDetailId;
                    grdPatientInfo.CurrentRow.Cells["TestDetail_ID"].Value =
                        Utility.Int32Dbnull(TResultDetail.CreateQuery().
                            WHERE(TResultDetail.Columns.PatientId, obj.PatientId).
                            WHERE(TResultDetail.Columns.TestTypeId, obj.TestTypeId).
                            GetMax(TResultDetail.Columns.TestDetailId), -1);
                    grdPatientInfo.UpdateData();
                    dtPatientInfo.AcceptChanges();
                }

            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch.PerformClick();
        }

        private void txtCanLamSangID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch.PerformClick();
        }

        private void grdPatientInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (grdPatientInfo.CurrentRow == null) return;
                int vTestResult_Id = Utility.Int32Dbnull(grdPatientInfo.GetValue("TestDetail_ID"));
                if (globalVariables.UserName == "ADMIN" || globalVariables.UserName == "LIS_ADMIN")
                {
                    //Insert_Update_Result();
                }
                else
                {

                    if (grdPatientInfo.CurrentColumn.Key == "Test_Result" &
                        grdPatientInfo.RootTable.Columns["Test_Result"].EditType != EditType.NoEdit &
                        vTestResult_Id > 0)
                    {
                        if (TResultDetail.CreateQuery().WHERE(TResultDetail.Columns.TestDetailId, vTestResult_Id).
                                AND(TResultDetail.Columns.ParaStatus, Comparison.GreaterThan, 0).GetRecordCount() > 0)
                        {
                            Utility.ShowMsg("Đã in kết quả. Không được sửa, Bạn hãy liên hệ với ADMIN để được trợ giúp!", "Thông Báo", MessageBoxIcon.Warning);
                            e.Handled = true;
                        }
                    }
                }
               

            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
    }
}
