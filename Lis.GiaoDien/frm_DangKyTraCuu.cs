using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevComponents.AdvTree;
using Janus.Windows.GridEX;
using Janus.Windows.UI.Tab;
using SubSonic;
using SubSonic.Sugar;
using VNS.Libs;
using LIS.DAL;
using SortOrder = Janus.Windows.GridEX.SortOrder;
//using globalModule = LabLink.globalModule;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class frm_DangKyTraCuu : Form
    {
        /// <summary>
        ///     Đường dẫn chạy chương trình
        /// </summary>
        public static string AppPath = AppDomain.CurrentDomain.BaseDirectory;

        private readonly BackgroundWorker _bw = new BackgroundWorker();
        private string btnExpandPanelText;
        private DataTable dtDepartment;
        private DataTable dtObjectType;
        private DataTable dtTestType;
        private DataTable dtTestTypeandTRegList = new DataTable();
        private DataTable m_dtResultDetail = new DataTable();
        private DataTable m_dtTestInfo = new DataTable();
        private DataTable mv_DTPatientInfor = new DataTable();

        private Color colorNoEditResult = Color.FromArgb(255, 224, 192);
        private Color colorAllowEditResult = Color.FromArgb(192, 255, 192);

        private Color colorRowHeaderActive = Color.Red;
        private Color colorRowHeaderIntactive = Color.Black;

        private string _autoLoadRegListFile = "_Auto Load Reg List.txt";
        private bool _autoLoadRegList = false;

      //  private BarcodeInfo bInfo = new BarcodeInfo();

        /// <summary>
        /// Biến cho phép in chỉ sử dụng cho Việt Đức
        /// </summary>
        private int _readyToPrint = 0;

        #region Search BackGround Worker

        private void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {


                {

                    {
                        txtMessageDisplay.Text = string.Format("Tìm thấy {0} bệnh nhân !", mv_DTPatientInfor.Rows.Count);
                        rbtPrint_Checked_Changed(sender, new EventArgs());
                        grdPatients.DataSource = mv_DTPatientInfor;
                        ckbHasResult_CheckedChanged(sender, new EventArgs());
                        grdPatients_SelectionChanged(sender, new EventArgs());
                        grdPatients.SelectionChanged += grdPatients_SelectionChanged;

                        progressBar.Style = ProgressBarStyle.Blocks;
                        progressBar.Visible = false;

                        if (mv_DTPatientInfor.Columns.Contains("AutoGeneratePatient"))
                        {
                            int count = (from dr in mv_DTPatientInfor.AsEnumerable()
                                         where (dr.Field<string>("AutoGeneratePatient") == ("Auto Generate"))
                                         select dr).Count();
                            if (count == 0)
                                grdPatients.RootTable.Groups.Clear();
                            else if (grdPatients.RootTable.Groups.Count == 0)
                            {
                                GridEXGroup exGroup = new GridEXGroup();
                                exGroup.Column = grdPatients.RootTable.Columns["AutoGeneratePatient"];
                                exGroup.GroupPrefix = "";
                                exGroup.SortOrder = SortOrder.Descending;
                                grdPatients.RootTable.Groups.Add(exGroup);
                            }
                        }
                        grdPatients.Focus();
                        grdPatients.MoveFirst();
                    }
                }
            }


            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void BwPerformSearch(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            try
            {
                //Thread.Sleep(5000);
            Utility.SetControlProperty(progressBar, "Visible", true);
                Utility.SetPropertyValue(progressBar, "Style", ProgressBarStyle.Marquee);
                //progressBar.Visible = true;
                //progressBar.Style = ProgressBarStyle.Marquee;
                int vAge = 0;
                if (ckbHasResult.Checked)
                {
                    if (txtAge.Text.Trim() != "")
                    {
                        if (Numbers.IsNumber(txtAge.Text.Trim())) vAge = Utility.Int32Dbnull(txtAge.Text, -1);
                        else
                        {
                            Utility.ShowMsg("Tuổi không hợp lệ");
                            txtAge.Focus();
                            return;
                        }
                    }
                    string vBarcode = txtBarcode.Text.Trim() == "" ? "NOTHING" : txtBarcode.Text.Trim();
                    string vPid = "";//txtPID.Text.Trim() == "" ? "NOTHING" : txtPID.Text.Trim();
                    string vName = txtName.Text.Trim() == "" ? "NOTHING" : txtName.Text.Trim();
                    string vMaHis = txtMaHis.Text.Trim() == "" ? "NOTHING" : txtMaHis.Text.Trim();
                    string strTestTypeId = GetIdString(dtTestType, grdTestType, "TestType_ID", "-3");
                    if (strTestTypeId == "-1")
                    {
                        Utility.ShowMsg("Bạn chưa chọn loại xét nghiệm");
                        grdTestType.Focus();
                        return;
                    }

                    int sex = Utility.Int32Dbnull(Utility.GetPropertyValue(cboSex, "SelectedValue"), -1);
                    int objectTypeId = Utility.Int32Dbnull(
                        Utility.GetPropertyValue(cboObjectType, "SelectedValue"), -1);
                    int departmentId = Utility.Int32Dbnull(
                        Utility.GetPropertyValue(cboDepartment, "SelectedValue"), -1);
                    grdPatients.SelectionChanged -= grdPatients_SelectionChanged;

                    mv_DTPatientInfor = SPs.SpGetPatientInfoAllNoResult(dtpTestDateFrom.Value.ToShortDateString(),
                                                                        dtpTestDateTo.Value.ToShortDateString(),
                                                                        strTestTypeId,
                                                                        vBarcode, vPid, vName, vAge, sex, objectTypeId,
                                                                        departmentId, vMaHis)
                        .GetDataSet().Tables[0];
                    if (!mv_DTPatientInfor.Columns.Contains("CLSID"))
                        mv_DTPatientInfor.Columns.Add("CLSID", typeof (Int32));
                    foreach (DataRow row in mv_DTPatientInfor.Rows)
                    {
                        try
                        {
                            row["CLSID"] = Utility.Int32Dbnull(row[LPatientInfo.Columns.CanLamSangId], 0);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    int vIsFinal;
                    if (chkIsFinal.Checked) vIsFinal = 1;
                    else vIsFinal = -1;
                    if (txtAge.Text.Trim() != "")
                    {
                        if (Numbers.IsNumber(txtAge.Text.Trim())) vAge = Utility.Int32Dbnull(txtAge.Text, -1);
                        else
                        {
                            Utility.ShowMsg("Tuổi không hợp lệ");
                            txtAge.Focus();
                            return;
                        }
                    }
                    string vBarcode = txtBarcode.Text.Trim() == "" ? "NOTHING" : txtBarcode.Text.Trim();
                    string vPid = "";// txtPID.Text.Trim() == "" ? "NOTHING" : txtPID.Text.Trim();
                    string vName = txtName.Text.Trim() == "" ? "NOTHING" : txtName.Text.Trim();
                    string vMaHis = txtMaHis.Text.Trim() == "" ? "NOTHING" : txtMaHis.Text.Trim();
                    string strTestTypeId = GetIdString(dtTestType, grdTestType, "TestType_ID", "-3");

                    if (strTestTypeId == "-1")
                    {
                        Utility.ShowMsg("Bạn chưa chọn loại xét nghiệm");
                        grdTestType.Focus();
                        return;
                    }
                    
                    int sex = Utility.Int32Dbnull(Utility.GetPropertyValue(cboSex, "SelectedValue"), -1);
                    int objectTypeId = Utility.Int32Dbnull(
                        Utility.GetPropertyValue(cboObjectType, "SelectedValue"), -1);
                    int departmentId = Utility.Int32Dbnull(
                        Utility.GetPropertyValue(cboDepartment, "SelectedValue"), -1);
                    grdPatients.SelectionChanged -= grdPatients_SelectionChanged;

                    mv_DTPatientInfor = SPs.SpGetPatientInfoAll(dtpTestDateFrom.Value.ToShortDateString(),
                                                                dtpTestDateTo.Value.ToShortDateString(), strTestTypeId,
                                                                vBarcode, vPid, vName, vAge, sex, objectTypeId,
                                                                departmentId, vMaHis, vIsFinal, globalVariables.UserName)
                        .GetDataSet().Tables[0];
                    if (!mv_DTPatientInfor.Columns.Contains("CLSID"))
                        mv_DTPatientInfor.Columns.Add("CLSID", typeof (Int32));
                    foreach (DataRow row in mv_DTPatientInfor.Rows)
                    {
                        try
                        {
                            row["CLSID"] = Utility.Int32Dbnull(row[LPatientInfo.Columns.CanLamSangId], 0);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi trong quá trình lấy thông tin:" + ex.ToString());
            }
        }

        private FrmAllMainProperties _myProperties;

        #endregion

        public frm_DangKyTraCuu()
        {
            InitializeComponent();
            _myProperties = GetFrmAllManConfig();
            SetFormatCondition();
        }

        private void SetFormatCondition()
        {
            //var conditionName = new List<string>(){"HightCondition","LowCondition"};
            var gridExFormatConditionCollection = grdResultDetail.RootTable.FormatConditions;

            var highCondition = (from c in gridExFormatConditionCollection.Cast<GridEXFormatCondition>()
                                 where c.Key.Equals("HightCondition")
                                 select c).FirstOrDefault();
            if (highCondition != null)
                highCondition.FormatStyle.BackColor = ColorTranslator.FromHtml(_myProperties.HighColor);

            var lowCondition = (from c in gridExFormatConditionCollection.Cast<GridEXFormatCondition>()
                                where c.Key.Equals("LowCondition")
                                select c).FirstOrDefault();
            if (lowCondition != null)
                lowCondition.FormatStyle.BackColor = ColorTranslator.FromHtml(_myProperties.LowColor);
            var normalCodition = (from c in gridExFormatConditionCollection.Cast<GridEXFormatCondition>()
                                  where c.Key.Equals("NormalCodition")
                                  select c).FirstOrDefault();
            if (normalCodition != null)
                normalCodition.FormatStyle.BackColor = ColorTranslator.FromHtml(_myProperties.NormalColor);
            try
            {
                if (_myProperties.ResultDateColumn == false)
                {
                    grdResultDetail.RootTable.Columns["Test_Date"].Visible = false;
                }
                else
                {
                    grdResultDetail.RootTable.Columns["Test_Date"].Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
            //gridExFormatConditionCollection.Clear();

            //var fc = new GridEXFormatCondition(grdResultDetail.RootTable.Columns["binhthuong"], ConditionOperator.Equal,"High")
            //{
            //    FormatStyle = {BackColor = ColorTranslator.FromHtml(_myProperties.NormalColor)}
            //};
            //gridExFormatConditionCollection.Add(fc);
        }

        /// <summary>
        ///     Nạp cấu hình của service
        /// </summary>
        /// <returns></returns>
        private FrmAllMainProperties GetFrmAllManConfig()
        {
            try
            {
                var myProperties = new FrmAllMainProperties();
                string filePath = string.Format("{0}{1}.xml", AppPath, myProperties.GetType().Name);
                var myFileStream = new FileStream(filePath, FileMode.Open);
                var mySerializer = new XmlSerializer(myProperties.GetType());
                myProperties = (FrmAllMainProperties) mySerializer.Deserialize(myFileStream);
                myFileStream.Close();
                return myProperties;
            }
            catch (Exception ex)
            {
                return new FrmAllMainProperties();
            }
        }

        /// <summary>mal_Level
        ///     Lưu lại cấu hình
        /// </summary>
        private void SaveFrmMainConfig()
        {
            var myWriter = new StreamWriter(string.Format("{0}{1}.xml", AppPath, _myProperties.GetType().Name));
            try
            {
                var mySerializer = new XmlSerializer(_myProperties.GetType());
                mySerializer.Serialize(myWriter, _myProperties);
            }
            catch (Exception)
            {
            }
            finally
            {
                myWriter.Flush();
                myWriter.Close();
            }
        }

        private void frm_AllMain_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    var asm = Assembly.LoadFrom("VIETBAIT.LIS.HISConnectivity.dll");
                    var obj = (UserControl)asm.CreateInstance("VIETBAIT.LIS.HISConnectivity.Usc_KetNoi_XetNghiem");
                    if (obj != null)
                    {
                        obj.Dock = DockStyle.Fill;
                        obj.Visible = true;
                        tabHISLIS.TabVisible = true;
                        tabHISLIS.Controls.Add(obj);
                        //obj.BringToFront();
                    }
                }
                catch (Exception ex)
                {
                    
                }
                try
                {
                    var asm = Assembly.LoadFrom("VIETBAIT.LIS.HISConnectivity.dll");
                    var obj = (UserControl)asm.CreateInstance("VIETBAIT.LIS.HISConnectivity.Usc_HisLis_Gtvt");
                    if (obj != null)
                    {
                        obj.Dock = DockStyle.Fill;
                        obj.Visible = true;
                        tabHISLIS.TabVisible = true;
                        tabHISLIS.Controls.Add(obj);
                        //obj.BringToFront();
                    }
                }
                catch (Exception ex)
                {
                    // Utility.ShowMsg("Lỗi ko load form HISConnectivity" + ex.ToString());
                }
                // Load tab HIS-LIS
                try
                {
                    var asm = Assembly.LoadFrom("VIETBAIT.LIS.HISConnectivity2.dll");
                    var obj = (UserControl) asm.CreateInstance("VIETBAIT.LIS.HISConnectivity.Uc_HisLis_NoiTiet");
                    if (obj != null)
                    {
                        obj.Dock = DockStyle.Fill;
                        obj.Visible = true;
                        tabHISLIS.TabVisible = true;
                        tabHISLIS.Controls.Add(obj);
                        //obj.BringToFront();
                    }
                }
                catch (Exception ex)
                {
                    //   Utility.ShowMsg("Lỗi ko load form HISConnectivity" + ex.ToString());
                }

                try
                {
                    if(_myProperties.TabCapNhapKetQua ==false)
                    {
                         var x = new Uc_QuickInputResult();
                    x.Dock = DockStyle.Fill;
                    x.Visible = true;
                    tabQuickInput.TabVisible = true;
                    tabQuickInput.Controls.Add(x);
                    }
                   
                }
                catch (Exception ex)
                {
                    //  Utility.ShowMsg("Lỗi ko load form Uc_QuickInputResult" + ex.ToString());
                }
                try
                {
                    if (_myProperties.TabXulyDL == false)
                    {
                        tabDataMonitor.TabVisible = true;
                    }

                }
                catch (Exception ex)
                {
                    //  Utility.ShowMsg("Lỗi ko load form Uc_QuickInputResult" + ex.ToString());
                }

                
                SetEventColumnHeaderColor();

                if (!File.Exists(_autoLoadRegListFile))
                {
                    _autoLoadRegList = false;
                    File.WriteAllText(_autoLoadRegListFile, "0");
                }
                else
                {
                    var tempStr = File.ReadAllText(_autoLoadRegListFile);
                    _autoLoadRegList = tempStr.Contains("1");
                }

                ControlUtilities controlUtilities = new ControlUtilities();
                controlUtilities.FormName = this.Name;
                controlUtilities.Control = this;
                controlUtilities.SetChildWindowsFormProperties();

                ResetTabKey resetTabKey = new ResetTabKey();
                resetTabKey.ArrControl = new Control[] {grdTestInfoModification, grdResultModification};
                resetTabKey.Implement();

                _bw.DoWork += BwPerformSearch;
                _bw.RunWorkerCompleted += BwRunWorkerCompleted;

              //  btnExpandPanelText = btnExpandPanel.Text;
                LoadTestType();
                LoadDepartment();
                LoadObjectType();
                LoadSexCombo();
                LoadDevice();
                //cboDate.SelectedIndex = 0;
                grdPatients.CheckAllRecords();
                if (cmsResultDetail.Items["tsmEditResult"].Enabled == false)
                {
                    grdResultDetail.RootTable.Columns["Test_Result"].EditType = EditType.NoEdit;
                    grdResultDetail.RootTable.Columns["Test_Result"].CellStyle.BackColor = colorNoEditResult;
                }

                // Gán sự kiện cho các nút lọc đã in và chưa in
                rbtTatCa.CheckedChanged += rbtPrint_Checked_Changed;
                rbtChuaIn.CheckedChanged += rbtPrint_Checked_Changed;
                rbtDaIn.CheckedChanged += rbtPrint_Checked_Changed;
                tabTestInfo.SelectedIndex = 1;
                cmdSearch.PerformClick();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi:" + ex.Message);
                Dispose();
            }
        }

        private void rbtPrint_Checked_Changed(object sender, EventArgs e)
        {
            try
            {
                if (rbtDaIn.Checked)
                    mv_DTPatientInfor.DefaultView.RowFilter = "Print_Status = 1";

                else if (rbtChuaIn.Checked)
                {
                    mv_DTPatientInfor.DefaultView.RowFilter = "Print_Status = 0";
                    
                }
                else
                    mv_DTPatientInfor.DefaultView.RowFilter = "1 = 1";
            }
            catch (Exception)
            {
            }
        }

        private void LoadDevice()
        {
            try
            {
                DataTable dt = PreloadedLists.Device.Copy();
                DataBinding.BindDataCombobox_Basic(cboDevice, dt, "Device_ID", "Device_Name");
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void LoadSexCombo()
        {
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof (int));
            dt.Columns.Add("Sex_Name", typeof (string));
            DataRow dr = dt.NewRow();
            dr["ID"] = -1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["ID"] = 1;
            dr["Sex_Name"] = "Nam";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["ID"] = 0;
            dr["Sex_Name"] = "Nữ";
            dt.Rows.Add(dr);
            DataBinding.BindData(cboSex, dt, "ID", "Sex_Name");
        }

        private void LoadObjectType()
        {
            dtObjectType = new Select().From(LObjectType.Schema.Name).OrderAsc(LObjectType.Columns.SName).
                ExecuteDataSet().Tables[0];
            DataBinding.BindDataCombox(cboObjectType, dtObjectType, LObjectType.Columns.Id, LObjectType.Columns.SName);
        }

        private void LoadDepartment()
        {
            dtDepartment =
                new Select().From(LDepartment.Schema.Name).OrderAsc(LDepartment.Columns.IntOrder).ExecuteDataSet().
                    Tables[0];
            DataBinding.BindDataCombox(cboDepartment, dtDepartment, LDepartment.Columns.Id, LDepartment.Columns.SName);
        }

        private void LoadTestType()
        {
            try
            {
                // Đặt check mặc định cho NHTD
                const string sFileName = "defaultTestTypechecked.txt";
                string[] allTestTypeId = new string[] {};

                if (File.Exists(sFileName))
                {
                    string[] tempstring = File.ReadAllLines(sFileName);
                    if (tempstring.Length > 0)
                    {
                        allTestTypeId = tempstring[0].Split(',');
                    }
                }
                else
                {
                    File.WriteAllText(sFileName, "-1");
                }

                dtTestType =
                    new Select(LUserTestType.Columns.UserName, TTestTypeList.Schema.Name + ".*").From(
                        LUserTestType.Schema.Name).
                        LeftOuterJoin(TTestTypeList.TestTypeIdColumn, LUserTestType.TestTypeIdColumn).
                        Where(LUserTestType.Columns.UserName).IsEqualTo(globalVariables.UserName).
                        OrderAsc(TTestTypeList.Columns.IntOrder).ExecuteDataSet().Tables[0];
                if (dtTestType.Rows.Count <= 0)
                    dtTestType = new Select().From(TTestTypeList.Schema.Name).OrderAsc(TTestTypeList.Columns.IntOrder).
                        ExecuteDataSet().Tables[0];
                grdTestType.DataSource = dtTestType;

                if (allTestTypeId.Contains("-1"))
                    grdTestType.CheckAllRecords();
                else
                {
                    foreach (GridEXRow row in grdTestType.GetRows())
                    {
                        row.IsChecked = allTestTypeId.Contains(row.Cells["TestType_ID"].Value.ToString().Trim());
                    }
                }

                cboTestType.Items.Add("--- Tất cả ---", -1);
                foreach (DataRow dataRow in dtTestType.Rows)
                {
                    cboTestType.Items.Add(Utility.sDbnull(dataRow["TestType_Name"]),
                                          Utility.Int32Dbnull(dataRow["TestType_ID"]));
                }
                cboTestType.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi load Loại XN:" + ex.ToString());
            }
        }

        private void cboDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //switch (cboDate.SelectedIndex)
            //{
            //    case 0:
            //        dtpTestDateFrom.Value = DateTime.Now;
            //        dtpTestDateTo.Value = DateTime.Now;
            //        pnlDate.Enabled = false;
            //        break;
            //    case 1:
            //        dtpTestDateFrom.Value = DateTime.Now.Date.AddDays(-1);
            //        dtpTestDateTo.Value = DateTime.Now.Date.AddDays(-1);
            //        pnlDate.Enabled = false;
            //        break;
            //    case 2:
            //        pnlDate.Enabled = true;
            //        break;
            //}
            //dtpTestDateFrom.Focus();
        }

        private void frm_AllMain_KeyDown(object sender, KeyEventArgs e)
        {
            //    if (globalVariables.UserName == "ADMIN" || globalVariables.UserName == "LIS_ADMIN")


            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.T:
                        cmdTestTypeReg.PerformClick();
                        break;
                    case Keys.Tab:
                        if (tabAll.SelectedIndex == tabAll.TabPages.Count - 1) tabAll.SelectedIndex = 0;
                        else tabAll.SelectedIndex += 1;
                        break;
                    case Keys.N:
                        cmdAddPatient.PerformClick();
                        break;
                    case Keys.U:
                        cmdUpdatePatient.PerformClick();
                        break;
                    case Keys.K:
                        tsmAddDetail.PerformClick();
                        break;
                    case Keys.E:
                      //  btnExpandPanel.PerformClick();
                        break;
                    case Keys.Space:
                        txtBarcode.Focus();
                        txtBarcode.SelectAll();
                        break;
                    case Keys.H:
                        tsmShowHideTabDetail.PerformClick();
                        break;
                    case Keys.Y:
                        tsmResultView.PerformClick();
                        break;
                    case Keys.X:
                        cmdDeletePatient.PerformClick();
                        break;
                    case Keys.F:
                        tsmEditResult.PerformClick();
                        break;
                    case Keys.R:
                        tsmRefresh.PerformClick();
                        break;
                    case Keys.M:
                        tsmManualAddDetail.PerformClick();
                        break;
                    case Keys.L:
                        tsmLoadRegData.PerformClick();
                        break;
                    case Keys.J:
                        tsmAddAllStandardDetail.PerformClick();
                        break;
                    case Keys.D:
                        tsmDuyetChiDinh.PerformClick();
                        break;
                    case Keys.W:
                        tsmHuyDuyet.PerformClick();
                        break;
                }
            }

            //else if (e.Alt)
            //    switch (e.KeyCode)
            //    {
            //        case Keys.F:
            //            btnPrintBarcode.PerformClick();
            //            break;
            //    }


            switch (e.KeyCode)
            {
                case Keys.F1:
                    try
                    {
                        tabTestInfo.SelectedTab = tabTestInfo.TabPages["tabReg"];
                    }
                    catch (Exception)
                    {
                    }

                    break;
                case Keys.F2:
                    //tabTestInfo.SelectedIndex = 1;
                    try
                    {
                        tabTestInfo.SelectedTab = tabTestInfo.TabPages["tabResult"];
                        grdPatients_SelectionChanged(sender, e);
                    }
                    catch (Exception)
                    {
                    }
                    break;
                case Keys.F3:
                    switch (tabAll.SelectedTab.Name)
                    {
                        case "tabPatientInfo":
                            cmdSearch.PerformClick();
                            break;
                        case "tabDataMonitor":
                            btnSearchModification.PerformClick();
                            break;
                    }
                    //cmdSearch.PerformClick();
                    break;
                case Keys.F4:
                    switch (tabTestInfo.SelectedTab.Name)
                    {
                        case "tabReg":
                            cmd_InPhieu_ChiDinh.PerformClick();
                            break;
                 

                        case "tabResult":
                            if (globalVariables.UserName == "ADMIN" || globalVariables.UserName == "LIS_ADMIN") 
                                cmd_InPhieu_XetNghiem_TongHop.PerformClick();
                            
                            break;
                            
                    }
                    break;
                case Keys.F5:
                    //cmdPrintResultByTestType_Click(sender,e);
                    break;
                case Keys.F9:
                    cmdValidate.PerformClick();
                    break;
                case Keys.F10:
                    cmdUnValidate.PerformClick();
                    break;
                    //case Keys.F:
                    //    btnPrintBarcode.PerformClick();
                    //    break;
                case Keys.Escape:
                    cmdEscape.PerformClick();
                    break;
                    //case Keys.F11:
                    //    tsmDuyetChiDinh.PerformClick();
                    //    break;
            }
        }

        private void cmdEscape_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tabTestInfo_SelectedTabChanged(object sender, TabEventArgs e)
        {
            try
            {
                ResetTabKey resetTabKey;
                switch (tabTestInfo.SelectedTab.Name)
                {
                    case "tabReg":
                        //PerformTabKeyAdjustment(grdPatients,grdTestTypeRegList);
                        //new ResetTabKey().Implement(new Control[] {grdPatients,grdTestTypeRegList});
                        resetTabKey = new ResetTabKey();
                        resetTabKey.ArrControl = new Control[] {grdPatients, grdTestTypeRegList};
                        resetTabKey.Implement();
                        break;
                    case "tabResult":
                        //new ResetTabKey().Implement(new Control[] {grdPatients,grdTestInfo,grdResultDetail});
                        //PerformTabKeyAdjustment(grdPatients, grdTestInfo);
                        //PerformTabKeyAdjustment(grdTestInfo,grdResultDetail);
                        resetTabKey = new ResetTabKey();
                        resetTabKey.ArrControl = new Control[] {grdPatients, grdTestInfo, grdResultDetail};
                        resetTabKey.Implement();
                        break;
                }
                ModifyCommand();
                grdPatients_SelectionChanged(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void ModifyCommand()
        {
            //cmdAddPatient.Visible = tabTestInfo.SelectedTab.Name == "tabReg";
            //btnPrintBarcode.Visible = tabTestInfo.SelectedTab.Name == "tabReg";
            //cmdRegList.Visible = tabTestInfo.SelectedTab.Name == "tabReg";
            cmd_InPhieu_ChiDinh.Visible = tabTestInfo.SelectedTab.Name == "tabReg";
            //cmdDeletePatient.Visible = tabTestInfo.SelectedTab.Name == "tabReg";
            //btnEditResult.Visible = tabTestInfo.SelectedTab.Name == "tabResult";
            // cmdInPhieuChiDinh.Visible = tabTestInfo.SelectedTab.Name == "tabReg";
            cmd_InPhieu_XetNghiem_TongHop.Visible = tabTestInfo.SelectedTab.Name == "tabResult";
            //btnParaEntry.Visible = tabTestInfo.SelectedTab.Name == "tabResult";
            //btnRegData.Visible = tabTestInfo.SelectedTab.Name == "tabResult";
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            //progressBar.Visible = true;
            //progressBar.Style = ProgressBarStyle.Marquee;
            if (!_bw.IsBusy)
            {
                _bw.RunWorkerAsync();
            }
            else
            {
                txtMessageDisplay.Text = string.Format("Tìm thấy {0} bệnh nhân !", mv_DTPatientInfor.Rows.Count);
            }

            ModifyCommand();
        }

        private string GetIdString(DataTable dt, GridEX grd, string colName, string errResult)
        {
            try
            {
                string vResult = errResult;
                int count = 0;
                foreach (GridEXRow grdRow in grd.GetCheckedRows())
                {
                    if (grdRow.IsChecked)
                    {
                        vResult += "," + grdRow.Cells[colName].Value;
                        count += 1;
                    }
                }
                if (count == PreloadedLists.TestType.Rows.Count) vResult = errResult;
                return vResult;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                return "-1";
            }
        }

        private void btnExpandPanel_Click(object sender, EventArgs e)
        {
          
        }

        private void grdPatients_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (splitContainer2.Panel2Collapsed) return;
                if (grdPatients.CurrentRow == null)
                {
                    NoPatientSelected();
                    return;
                }
                if (grdPatients.CurrentRow.RowType != RowType.Record)
                {
                    NoPatientSelected();
                    return;
                }
                ///Check trường hợp ADMIN dc sửa KQ
                ///
                cmdValidate.Enabled = Utility.Int32Dbnull(grdPatients.GetValue("IsFinal")) != 1;
                cmdUnValidate.Enabled = !cmdValidate.Enabled;
                   grdResultDetail.AllowEdit = Utility.Int32Dbnull(grdPatients.GetValue("IsFinal")) != 1
                                                    ? InheritableBoolean.True
                                                    : InheritableBoolean.False;
                    cmsResultDetail.Enabled = Utility.Int32Dbnull(grdPatients.GetValue("IsFinal")) != 1;
               

                switch (tabTestInfo.SelectedTab.Name)
                {
                    case "tabReg":
                        LoadTestTypeAndTRegList();
                        break;
                    case "tabResult":
                        LoadTestInfoResult();
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void NoPatientSelected()
        {
            try
            {
                m_dtResultDetail.Clear();
                m_dtResultDetail.AcceptChanges();
                m_dtTestInfo.Clear();
                m_dtTestInfo.AcceptChanges();
                dtTestTypeandTRegList.Clear();
                dtTestTypeandTRegList.AcceptChanges();
                cmdValidate.Enabled = false;
                cmdUnValidate.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }

        private void LoadTestTypeAndTRegList()
        {
            try
            {
                int v_PatientId = Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"), -1);
                dtTestTypeandTRegList = SPs.SpGetTestTypeandTReglistV2(v_PatientId, dtpTestDateFrom.Value.Date,
                                                                       dtpTestDateTo.Value.Date.AddDays(1).
                                                                           AddMilliseconds(-2)).GetDataSet().Tables[0];

                grdTestTypeRegList.DataSource = dtTestTypeandTRegList;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void LoadTestInfoResult()
        {
            try
            {
                string strTestTypeID = GetIdString(dtTestType, grdTestType, "TestType_ID", "-3");
                int patientId = Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"), -1);
                DataSet ds =
                    SPs.SpGetTestInfoByPatientIDV3(patientId, strTestTypeID, dtpTestDateFrom.Value.Date,
                                                   dtpTestDateTo.Value.Date.Date.AddDays(1).AddMilliseconds(-2)).
                        GetDataSet();

                m_dtTestInfo = ds.Tables[0];
                m_dtResultDetail = ds.Tables[1];

                ProcessNormalResult(ref m_dtResultDetail);

                grdTestInfo.DataSource = m_dtTestInfo;


                grdResultDetail.DataSource = m_dtResultDetail;

                ModifyCommand();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdTestInfo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string _rowFilter = "1=2";
                //Barcode2.Visible =
                //    !string.IsNullOrEmpty(Utility.sDbnull(grdTestInfo.GetValue(TTestInfo.Columns.Barcode), ""));

                if (grdTestInfo.CurrentRow != null)
                {
                    _rowFilter = "Test_ID=" + Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"), -1);

                    //Barcode2.Data = Utility.sDbnull(grdTestInfo.GetValue(TTestInfo.Columns.Barcode), "");
                }
                m_dtResultDetail.DefaultView.RowFilter = _rowFilter;
                if (globalVariables.UserName == "ADMIN" || globalVariables.UserName == "LIS_ADMIN")
                {
                    grdResultDetail.AllowEdit = InheritableBoolean.True;

                    cmsResultDetail.Enabled = true;
                }
                else
                {
                    grdResultDetail.AllowEdit = Utility.Int32Dbnull(grdTestInfo.GetValue("SentStatus")) != 1
                                                   ? InheritableBoolean.True
                                                   : InheritableBoolean.False;
                    cmsResultDetail.Enabled = Utility.Int32Dbnull(grdTestInfo.GetValue("SentStatus")) != 1;
           
                }
                //IsNormalResult(m_dtResultDetail)

                m_dtResultDetail.AcceptChanges();
                ModifyCommand();
                if (_autoLoadRegList) tsmLoadRegData.PerformClick();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void ckbHasResult_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (ckbHasResult.Checked) 
                //{
                //mv_DTPatientInfor.DefaultView.RowFilter = "substring(NumberOfTest,1,1) <> 0";
                //mv_DTPatientInfor.AcceptChanges();
                //}
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdUpdatePatient_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFormPatientInfo(action.Update);
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void LoadFormPatientInfo(action vAction)
        {
            try
            {
                if (vAction == action.Update)
                {
                    if (grdPatients.CurrentRow == null) return;
                    if (grdPatients.CurrentRow.RowType != RowType.Record) return;
                }

                if (vAction == action.Insert | mv_DTPatientInfor.Rows.Count > 0)
                {
                    //if (SysPara.BarcodeType.ToUpper().Equals("VIETDUC"))
                    //{
                    //    var oForm = new frmNewPatientReg_VietDuc();
                    //    oForm.m_iAction = vAction;
                    //    if (vAction != action.Insert)
                    //        oForm.mv_DR = mv_DTPatientInfor.Rows[grdPatients.CurrentRow.RowIndex];
                    //    oForm.mv_ParentTable = mv_DTPatientInfor;
                    //    oForm.grdList = grdPatients;
                    //    oForm.dtDepartment = dtDepartment;
                    //    oForm.dtObjectType = dtObjectType;
                    //    oForm.ShowDialog();
                    //    if (oForm.AutoLoadRegForm) cmdTestTypeReg.PerformClick();
                    //    ModifyCommand();
                    //}
                    //else
                    //{
                    //var oForm = new frmNewPatientReg_VietDuc();
                    //oForm.m_iAction = vAction;
                    //if (vAction != action.Insert)
                    //    oForm.mv_DR = mv_DTPatientInfor.Rows[grdPatients.CurrentRow.RowIndex];
                    //oForm.mv_ParentTable = mv_DTPatientInfor;
                    //oForm.grdList = grdPatients;
                    //oForm.dtDepartment = dtDepartment;
                    //oForm.dtObjectType = dtObjectType;
                    //oForm.ShowDialog();
                    //if (oForm.AutoLoadRegForm) LoadTestTypeRegForm(Utility.Int32Dbnull(oForm.txtPatient_ID.Text));//cmdTestTypeReg.PerformClick();
                    //ModifyCommand();
                    //}

                    var oForm = new frmInsertUpdatePatient();
                    oForm.m_iAction = vAction;
                    if (vAction != action.Insert)
                    {
                        var tempPatientId = grdPatients.GetValue("Patient_ID");
                        var tempPatient = (from dr in mv_DTPatientInfor.AsEnumerable()
                                           where dr["Patient_ID"].Equals(tempPatientId)
                                           select dr).FirstOrDefault();
                        oForm.mv_DR = tempPatient;
                    }
                    oForm.mv_ParentTable = mv_DTPatientInfor;
                    oForm.grdList = grdPatients;
                    oForm.dtDepartment = dtDepartment;
                    oForm.dtObjectType = dtObjectType;
                    oForm.ShowDialog();
                    if (oForm.AutoLoadRegForm && !string.IsNullOrEmpty(oForm.txtPatient_ID.Text))
                        LoadTestTypeRegForm(Utility.Int32Dbnull(oForm.txtPatient_ID.Text));
                    //cmdTestTypeReg.PerformClick();
                    ModifyCommand();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdPatients_DoubleClick(object sender, EventArgs e)
        {
            cmdUpdatePatient.PerformClick();
        }

        private void ProcessNormalResult(ref DataTable dt)
        {
            try
            {
                double min = 0;
                double max = 0;
                string normal = null;
                const string low = "Low";
                const string hight = "High";
                const string binhthuong = "binhthuong";
                const string testResult = "Test_result";
                var normalLevel = "Normal_Level";
                //var arrResultWithLetters = new ArrayList();
                //arrResultWithLetters.Add("NE");
                //arrResultWithLetters.Add("POS");

                if (!dt.Columns.Contains(binhthuong)) dt.Columns.Add(binhthuong, typeof (string));

                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        //'truong hop nam trong khonang co can tren va can duoi
                        normalLevel = Utility.Int32Dbnull(dr["Sex"], 1) == 1 ? "Normal_Level" : "Normal_LevelW";
                        normal = dr[normalLevel].ToString().Trim();
                        if (string.IsNullOrEmpty(dr[testResult].ToString()) | string.IsNullOrEmpty(normal))
                        {
                            dr[binhthuong] = DBNull.Value;
                            continue;
                        }
                        normal = normal.Replace("≤", "<=");
                        normal = normal.Replace("≥", ">=");
                        normal = normal.Replace(" ", "");
                        normal = normal.Replace(",", ".");
                        if (Utility.IsNumeric(dr[testResult]))
                        {
                            dr[binhthuong] = DBNull.Value;
                            double tempResult = Utility.DoubletoDbnull(dr[testResult]);
                            if (normal.IndexOf("-") > 0)
                            {
                                string[] arrstr = null;
                                arrstr = normal.Split('-');
                                min = Utility.DoubletoDbnull(arrstr[0]);
                                max = Utility.DoubletoDbnull(arrstr[1]);
                                bool b1 = tempResult >= min;
                                bool b2 = tempResult <= max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                            }
                            else if (normal.IndexOf("<=") >= 0)
                            {
                                min = double.MinValue;
                                max = Utility.DoubletoDbnull(normal.Substring(2));
                                bool b1 = tempResult >= min;
                                bool b2 = tempResult <= max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                            }
                            else if (normal.IndexOf(">=") >= 0)
                            {
                                max = double.MaxValue;
                                min = Utility.DoubletoDbnull(normal.Substring(2));
                                bool b1 = tempResult >= min;
                                bool b2 = tempResult <= max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                                //'Truong hop chi co can tren
                            }
                            else if (normal.IndexOf("<") >= 0)
                            {
                                min = double.MinValue;
                                max = Utility.DoubletoDbnull(normal.Substring(1));
                                bool b1 = tempResult > min;
                                bool b2 = tempResult < max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                                //'Truong hop chi co can tren
                            }
                            else if (normal.IndexOf(">") >= 0)
                            {
                                max = double.MaxValue;
                                min = Utility.DoubletoDbnull(normal.Substring(1));
                                bool b1 = tempResult > min;
                                bool b2 = tempResult < max;
                                if (!b1)
                                    dr[binhthuong] = low;
                                if (!b2)
                                    dr[binhthuong] = hight;
                            }
                            else if (dr[testResult].ToString().Trim().ToUpper() != dr[normalLevel].ToString())
                            {
                                dr[binhthuong] = hight;
                            }
                        }
                        else
                        {
                            //'Truong hop cua Negative va positive
                            //'Dim b As Boolean = (dr(testResult).ToString.Trim.ToUpper.IndexOf(arrResultWithLetters(0)) >= 0)
                            bool b1 = dr[testResult].ToString().Trim().ToUpper().IndexOf("DƯƠ") >= 0;
                            bool b2 = dr[testResult].ToString().Trim().ToUpper().IndexOf("DUO") >= 0;
                            bool b3 = dr[testResult].ToString().Trim().ToUpper().IndexOf("POS") >= 0;
                            if (b1 | b2 | b3) dr[binhthuong] = hight;
                            else dr[binhthuong] = DBNull.Value;
                        }
                    }
                    catch (Exception ex)
                    {
                        dr[binhthuong] = DBNull.Value;
                    }
                }
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdAddPatient_Click(object sender, EventArgs e)
        {
            LoadFormPatientInfo(action.Insert);
        }

        private void cmdRegList_Click(object sender, EventArgs e)
        {
            LoadTestTypeRegForm(Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID")));
        }

        private void LoadTestTypeRegForm(int patient_ID)
        {
            try
            {
                if (grdPatients.CurrentRow == null) return;
                var obj = new frmTiepDonDangKy();
                if (grdTestTypeRegList.GetValue("Test_ID") != null)
                {
                    obj.currentTest_ID = Utility.Int32Dbnull(grdTestTypeRegList.GetValue("Test_ID"));
                }
                
                obj.patientId = patient_ID;
                obj.dtTestTypeList = dtTestType;
                obj.grdPatients = grdPatients;
               // obj.PrintbarcodeInstance = PrintBarcode;
                obj.ShowDialog();
                tsmRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnPrintBarcode_ButtonClick(Object sender, EventArgs e)
        {
          //  PrintBarcode();
        }

        /// <summary>
        /// Hàm xử lý sự kiện in barcode được click
        /// </summary>
        //private void PrintBarcode()
        //{
        //    try
        //    {
        //        // In theo luồng của Việt Đức
        //        if (SysPara.BarcodeType.ToUpper() == "VIETDUC")
        //        {
        //            if ((grdPatients.CurrentRow != null))
        //            {
        //                //Nếu readytoPrint = 0 gán barcode và thêm mới
        //                if (_readyToPrint == 0)
        //                {
        //                    var barcodeData = Utility.sDbnull(grdPatients.GetValue("Barcode"));
        //                    if (string.IsNullOrEmpty(barcodeData))
        //                    {
        //                        Utility.ShowMsg("Chưa có Barcode. Đề nghị đăng ký loại xét nghiệm");
        //                        return;
        //                    }

        //                    //barcodeData = barcodeData.Length >= 4 ? barcodeData.Substring(barcodeData.Length - 4) : barcodeData.PadLeft(4, '0');
        //                    bInfo.BarcodeData = barcodeData;
        //                    bInfo.PatientName = Utility.sDbnull(grdPatients.GetValue("Patient_Name"), "");
        //                    bInfo.InsuranceNum = Utility.sDbnull(grdPatients.GetValue("Insurance_Num"), "");
        //                    var yearOfBirth = Utility.sDbnull(grdPatients.GetValue("Year_Birth"));
        //                    var dob = string.IsNullOrEmpty(Utility.sDbnull(grdPatients.GetValue("DOB"), ""))
        //                                  ? yearOfBirth
        //                                  : Utility.GetFormatDateTime(Convert.ToDateTime(grdPatients.GetValue("DOB")),
        //                                                              "dd/MM/yyyy");
        //                    bInfo.Dob = dob;
        //                    bInfo.Sex = Utility.Int32Dbnull(grdPatients.GetValue("SexId"), -1);
        //                    bInfo.DisplayData = true;
        //                    bInfo.Department = Utility.sDbnull(grdPatients.GetValue("Department_Name"), "");
        //                    bInfo.Room = Utility.sDbnull(grdPatients.GetValue("Room"), "");
        //                    //Chuyển trạng thái Readyto Print = 1
        //                    _readyToPrint = 1;
        //                }
        //                else if (_readyToPrint == 1)
        //                {
        //                    try
        //                    {
        //                        var barcodeData = Utility.sDbnull(grdPatients.GetValue("Barcode"));
        //                        if (string.IsNullOrEmpty(barcodeData))
        //                        {
        //                            Utility.ShowMsg("Chưa có Barcode. Đề nghị đăng ký loại xét nghiệm");
        //                            return;
        //                        }
        //                        //barcodeData = barcodeData.Length >= 4 ? barcodeData.Substring(barcodeData.Length - 4) : barcodeData.PadLeft(4, '0');
        //                        bInfo.BarcodeData2 = barcodeData;
        //                        new PrintBarcode().PrintBarCode(bInfo);
        //                    }
        //                    finally
        //                    {
        //                        _readyToPrint = 0;
        //                    }
        //                }
        //            }
        //        }
        //        else //In thông thường
        //        {
        //            if ((grdPatients.CurrentRow != null))
        //            {
        //                var barcodeData = Utility.sDbnull(grdPatients.GetValue("Barcode"));
        //                if (string.IsNullOrEmpty(barcodeData))
        //                {
        //                    Utility.ShowMsg("Chưa có Barcode. Đề nghị đăng ký loại xét nghiệm");
        //                    return;
        //                }

        //                //barcodeData = barcodeData.Length >= 4 ? barcodeData.Substring(barcodeData.Length - 4) : barcodeData.PadLeft(4, '0');
        //                bInfo.BarcodeData = barcodeData;
        //                bInfo.PatientName = Utility.sDbnull(grdPatients.GetValue("Patient_Name"), "");
        //                bInfo.InsuranceNum = Utility.sDbnull(grdPatients.GetValue("Insurance_Num"), "");
        //                var yearOfBirth = Utility.sDbnull(grdPatients.GetValue("Year_Birth"));
        //                var dob = string.IsNullOrEmpty(Utility.sDbnull(grdPatients.GetValue("DOB"), ""))
        //                              ? yearOfBirth
        //                              : Utility.GetFormatDateTime(Convert.ToDateTime(grdPatients.GetValue("DOB")),
        //                                                          "dd/MM/yyyy");
        //                bInfo.Dob = dob;
        //                bInfo.Sex = Utility.Int32Dbnull(grdPatients.GetValue("SexId"), -1);
        //                bInfo.DisplayData = true;
        //                bInfo.Department = Utility.sDbnull(grdPatients.GetValue("Department_Name"), "");
        //                bInfo.Room = Utility.sDbnull(grdPatients.GetValue("Room"), "");
        //                new PrintBarcode().PrintBarCode(bInfo);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Utility.ShowMsg(ex.Message);
        //    }
        //}

        private void tsmRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPatients.CurrentRow == null) return;

                grdPatients_SelectionChanged(sender, e);
                grdPatients.CurrentRow.Cells["Barcode"].Value = Utility.sDbnull(TTestInfo.CreateQuery().
                                                                                    WHERE(TTestInfo.Columns.PatientId,
                                                                                          Utility.Int32Dbnull(
                                                                                              grdPatients.GetValue(
                                                                                                  "Patient_ID"), -1)).
                                                                                    GetMax("Barcode"));
                int testCount = TTestInfo.CreateQuery().WHERE(TTestInfo.Columns.PatientId,
                                                              Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"), -1))
                    .
                    GetRecordCount();
                string strNumberOfTest = grdPatients.CurrentRow.Cells["NumberOfTest"].Value.ToString();
                if (string.IsNullOrEmpty(strNumberOfTest))
                {
                    grdPatients.CurrentRow.Cells["NumberOfTest"].Value = "0/" + testCount;
                    grdPatients.CurrentRow.Cells["Print_Status"].Value = 0;
                }
                else
                {
                    grdPatients.CurrentRow.Cells["NumberOfTest"].Value = strNumberOfTest.Split('/')[0] + "/" + testCount;
                }
                grdPatients.UpdateData();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void dtpTestDateTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpTestDateTo.Value < dtpTestDateFrom.Value) dtpTestDateFrom.Value = dtpTestDateTo.Value;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void dtpTestDateFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTestDateFrom.Value > dtpTestDateTo.Value) dtpTestDateTo.Value = dtpTestDateFrom.Value;
        }

        private void grdTestTypeRegList_DoubleClick(object sender, EventArgs e)
        {
            cmdTestTypeReg.PerformClick();
        }

        private void grdTestInfo_DoubleClick(object sender, EventArgs e)
        {
            if (globalVariables.UserName == "ADMIN" || globalVariables.UserName == "LIS_ADMIN")
            {
                cmdTestTypeReg.PerformClick();
            }
        }

        private void tsmShowHideTabDetail_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
            grdPatients_SelectionChanged(sender, e);
            //tabTestInfo.Visible = tabTestInfo.Visible != true;
        }

        private void tsmResultView_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPatients.CurrentRow == null | tabTestInfo.SelectedTab.Name != "tabResult") return;
                frmTestResultInfo frm = new frmTestResultInfo();
                frm.grwPatient = grdPatients.CurrentRow;
                frm.ShowDialog();
                tsmRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void tsmRegView_Click(object sender, EventArgs e)
        {
            if (globalVariables.UserName == "ADMIN" || globalVariables.UserName == "LIS_ADMIN")
            {
                cmdTestTypeReg.PerformClick();
            }
        }

        private void tsmTestRegistration_Click(object sender, EventArgs e)
        {
            grdTestInfo_DoubleClick(sender, e);
        }

        private void tsmMoveTestToPatient_Click(object sender, EventArgs e)
        {
            try
            {
                GridEXRow[] arrGridRow = grdTestInfo.GetCheckedRows();
                if (arrGridRow.Length <= 0)
                {
                    Utility.ShowMsg("Chưa đăng ký hoặc chưa chọn test xét nghiệm");
                    return;
                }
                var oForm = new frmSearchPatient();
                oForm.ShowDialog();
                if (oForm.vSelectedID != -1)
                    if (Utility.AcceptQuestion("Thực hiện chuyển kết quả được chọn sang bệnh nhân khác", "Thông báo",
                                               true))
                    {
                        Int32 vPatientID = oForm.vSelectedID;
                        foreach (var gridExRow in arrGridRow)
                        {
                            Int32 vTestID = Utility.Int32Dbnull(gridExRow.Cells["Test_ID"].Value);
                            new Update(TTestInfo.Schema.Name).Set(TTestInfo.Columns.PatientId).EqualTo(vPatientID).
                                Where(TTestInfo.Columns.TestId).IsEqualTo(vTestID).
                                Execute();
                            new Update(TResultDetail.Schema.Name).Set(TResultDetail.Columns.PatientId).EqualTo(
                                vPatientID).
                                Where(TTestInfo.Columns.TestId).IsEqualTo(vTestID).
                                Execute();
                            gridExRow.Delete();
                        }
                        grdTestInfo.UpdateData();
                    }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdDelelePatient_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdPatients.CurrentRow == null) return;
                if (
                    TTestInfo.CreateQuery().WHERE(TTestInfo.Columns.PatientId,
                                                  Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"), -1)).
                        GetRecordCount() > 0)
                {
                    Utility.ShowMsg("Bệnh nhận đã có đăng ký xét nghiệm.\nKhông được xóa.");
                    return;
                }
                if (
                    TResultDetail.CreateQuery().WHERE(TResultDetail.Columns.PatientId,
                                                      Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"), -1)).
                        GetRecordCount() > 0)
                {
                    Utility.ShowMsg("Bệnh nhận đã có kết quả.\nKhông được xóa.");
                    return;
                }
                if (
                    Utility.AcceptQuestion(
                        string.Format("Thực hiện xóa bệnh nhận {0}",
                                      Utility.sDbnull(grdPatients.GetValue("Patient_Name"))), "Thông báo", true))
                {
                    new Delete().From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.PatientId).IsEqualTo(
                        Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"))).Execute();
                    grdPatients.CurrentRow.Delete();
                    grdPatients.UpdateData();
                    mv_DTPatientInfor.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdTestTypeRegList_CellValueChanged(object sender, ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "Status")
                {
                    int vStatus = Utility.Int32Dbnull(grdTestTypeRegList.GetValue("Status"));
                    new Update(TRegList.Schema.Name).Set(TRegList.Columns.Status).
                        EqualTo(vStatus).Where(TRegList.Columns.TestRegDetailId).
                        IsEqualTo(Utility.Int32Dbnull(grdTestTypeRegList.GetValue("TestRegDetail_ID"))).
                        Execute();
                    grdTestTypeRegList.UpdateData();
                    dtTestTypeandTRegList.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmd_InPhieu_ChiDinh_Click(object sender, EventArgs e)
        {
            try
            {
                //if (grdPatients.CurrentRow == null) return;
                //frm_JCLV_InPhieuYeuCau_XETNGHIEM frm = new frm_JCLV_InPhieuYeuCau_XETNGHIEM();
                //frm.p_Patient_ID = Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"), -1);
                //frm.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmd_InPhieu_XetNghiem_TongHop_Click(object sender, EventArgs e)
        {
            if (grdPatients.CurrentRow == null)
            {
                Utility.ShowMsg("Bạn chưa chọn bệnh nhân để in");
                return;
            }
            frm_ChoosePrint frm = new frm_ChoosePrint();
            if (grdPatients.GetCheckedRows().Count() > 0)
                frm.m_dtTestType = (DataTable) grdTestType.DataSource;
            else frm.m_dtTestType = (DataTable) grdTestInfo.DataSource;
            frm.grdList = grdPatients;
            frm.ShowDialog();
        }

        #region Xử lý update Barcode

        private DataTable dtResultModification;
        private string CurrentRowBarcode;

        private void btnSearchModification_Click(object sender, EventArgs e)
        {
            try
            {
                string strTestTypeID = "";
                if (Utility.Int32Dbnull(cboTestType.SelectedValue) > 0)
                    strTestTypeID = Utility.sDbnull(cboTestType.SelectedValue);
                else
                {
                    foreach (DataRow row in dtTestType.Rows)
                    {
                        strTestTypeID += Utility.sDbnull(row["TestType_ID"]) + ",";
                    }
                    if (strTestTypeID.EndsWith(",")) strTestTypeID = strTestTypeID.Remove(strTestTypeID.Length - 1);
                }

                dtResultModification =
                    SPs.SpGetResultForUpdatePatientInfo(dtpDateFrom.Value.Date,
                                                        dtpDateTo.Value.Date.AddDays(1).AddSeconds(-1),
                                                        strTestTypeID, Utility.Int32Dbnull(cboDevice.SelectedValue)).
                        GetDataSet().Tables[0];

                if (dtResultModification.Columns.Contains("Patient_InPut_Method"))
                {
                    int count = (from dr in dtResultModification.AsEnumerable()
                                 where (dr.Field<string>("Patient_InPut_Method") == ("Auto Generate"))
                                 select dr).Count();
                    grdTestInfoModification.RootTable.Groups.Clear();
                    if (count > 0)
                    {
                        GridEXGroup exGroup = new GridEXGroup();
                        exGroup.Column = grdTestInfoModification.RootTable.Columns["Patient_InPut_Method"];
                        exGroup.GroupPrefix = "";
                        exGroup.SortOrder = SortOrder.Descending;
                        grdTestInfoModification.RootTable.Groups.Add(exGroup);
                    }
                }

                grdTestInfoModification.DataSource = dtResultModification;
                grdTestInfoModification.Focus();
                grdTestInfoModification.MoveFirst();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdTestInfoModification_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdTestInfoModification.CurrentRow == null ||
                    grdTestInfoModification.CurrentRow.RowType != RowType.Record)
                {
                    grdResultModification.BoundMode = BoundMode.Unbound;
                    grdResultModification.ClearItems();
                }
                else
                {
                    grdResultModification.BoundMode = BoundMode.Bound;
                    DataTable dt = new Select(TResultDetail.Schema.Name + ".*",
                                              "(Select Top 1 ddl.Device_Name From D_Device_List ddl where ddl.Device_ID = T_Result_Detail.Device_ID) AS Device_Name")
                        .
                        From(TResultDetail.Schema.Name).
                        Where(TResultDetail.Columns.TestId).IsEqualTo(
                            Utility.Int32Dbnull(grdTestInfoModification.GetValue("Test_ID"))).
                        OrderAsc(TResultDetail.Columns.DataSequence).
                        ExecuteDataSet().Tables[0];
                    grdResultModification.DataSource = dt;
                    CurrentRowBarcode = Utility.sDbnull(grdTestInfoModification.CurrentRow.Cells["Barcode"].Value);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdTestInfoModification_CellUpdated(object sender, ColumnActionEventArgs e)
        {
            if (grdTestInfoModification.CurrentColumn.Key == "Barcode")
            {
                bool bSuccess = false;
                string vBarcode = Utility.sDbnull(grdTestInfoModification.GetValue("Barcode"));
                try
                {
                    //Tim Patient_ID moi cho test_ID dang dc chon
                    if (vBarcode.Length <= 4) vBarcode = DateTime.Now.ToString("yyMMdd") + vBarcode.PadLeft(4, '0');

                    DataTable dtPatientModified =
                        TTestInfo.CreateQuery().WHERE(TTestInfo.Columns.Barcode, vBarcode).AND(
                            TTestInfo.Columns.PatientId, Comparison.GreaterThan, 0).ExecuteDataSet().Tables[0];

                    //Neu ko tim thay
                    if (
                        (from drCount in dtPatientModified.AsEnumerable() select drCount["Patient_ID"]).Distinct().Count
                            () != 1)
                    {
                        Utility.ShowMsg(
                            string.Format(
                                "Không tìm thấy bệnh nhân có barcode {0} hoặc tìm thấy nhiều hơn 1 bệnh nhân. Đề nghị thực hiện lại.",
                                vBarcode));
                        grdTestInfoModification.CurrentRow.Cells["Barcode"].Value = CurrentRowBarcode;
                        return;
                    }
                    //Neu tim thay
                    int newPatientID = Utility.Int32Dbnull(dtPatientModified.Rows[0]["Patient_ID"]);
                    int oldPatientID = Utility.Int32Dbnull(grdTestInfoModification.GetValue("Patient_ID"));
                    int oldTestID = Utility.Int32Dbnull(grdTestInfoModification.GetValue("Test_ID"));

                    int vTestType_ID = Utility.Int32Dbnull(grdTestInfoModification.GetValue("TestType_ID"));

                    LPatientInfo obj = LPatientInfo.FetchByID(newPatientID);
                    if (obj == null)
                    {
                        Utility.ShowMsg("Không tồn tại bệnh nhân !");
                        return;
                    }

                    if (
                        !Utility.AcceptQuestion(
                            string.Format("Thực hiện chuyển sang bệnh nhận {0} có barcode {1} ?", obj.PatientName,
                                          vBarcode), "Thông báo", true))
                        return;

                    DataRow dr = Utility.GetDataRow(dtPatientModified, "TestType_ID", vTestType_ID);
                    DataRow drPatient = Utility.GetDataRow(dtResultModification,
                                                           new[] {"Patient_ID", "Test_ID"},
                                                           new object[] {oldPatientID, oldTestID});
                    if (drPatient == null)
                    {
                        Utility.ShowMsg("Không tìm thấy thông tin trên lưới");
                        return;
                    }

                    int newTest_ID = oldTestID;
                    if (oldTestID > 0)
                    {
                        if (dr == null)
                        {
                            newTest_ID = oldTestID;
                            new Update(TTestInfo.Schema.Name). //Set(TTestInfo.Columns.Barcode).EqualTo(vBarcode).
                                Set(TTestInfo.Columns.PatientId).EqualTo(newPatientID).
                                Set(TTestInfo.Columns.Barcode).EqualTo(vBarcode).
                                Where(TTestInfo.Columns.TestId).IsEqualTo(oldTestID).
                                Execute();
                            //Utility.ShowMsg(string.Format("Tìm thấy bệnh nhân {0}, chưa đăng ký {1}. Đề nghị thực hiện lại.",
                            //    obj.PatientName, grdResultModification.GetValue("TestType_Name")));
                            //return;
                        }
                        else if (oldPatientID > 0)
                        {
                            if (
                                !Utility.AcceptQuestion(
                                    string.Format(
                                        "Giữ đăng ký của bệnh nhân cũ và chỉ thực hiện chuyển kết quả sang bệnh nhận {0} có barcode {1} ?",
                                        obj.PatientName, dr["Barcode"]), "Thông báo", true))
                            {
                                //Update PatientID cho T_Test_Info
                                new Update(TTestInfo.Schema.Name). //Set(TTestInfo.Columns.Barcode).EqualTo(vBarcode).
                                    Set(TTestInfo.Columns.PatientId).EqualTo(newPatientID).
                                    Set(TTestInfo.Columns.Barcode).EqualTo(vBarcode).
                                    Where(TTestInfo.Columns.TestId).IsEqualTo(oldTestID).
                                    Execute();
                            }
                            else newTest_ID = Utility.Int32Dbnull(dr["Test_ID"]);
                        }
                        else newTest_ID = Utility.Int32Dbnull(dr["Test_ID"]);
                    }
                    else
                    {
                        //Utility.ShowMsg(string.Format("Tìm thấy bệnh nhân {0}, chưa đăng ký {1}. Đề nghị thực hiện lại.",
                        //        obj.PatientName, grdResultModification.GetValue("TestType_Name")));
                        //return;
                        TTestInfo objTestInfo = new TTestInfo();
                        objTestInfo.DeviceId = -1;
                        objTestInfo.PatientId = newPatientID;
                        objTestInfo.Barcode = vBarcode;
                        objTestInfo.TestDate = DateTime.Now;
                        objTestInfo.RequireDate = DateTime.Now;
                        objTestInfo.TestTypeId = Utility.Int32Dbnull(grdTestInfoModification.GetValue("TestType_ID"));
                        objTestInfo.TestStatus = 0;
                        objTestInfo.PrintStatus = 0;
                        objTestInfo.IsNew = true;
                        objTestInfo.Save();
                        newTest_ID = Utility.Int32Dbnull(objTestInfo.TestId);
                    }
                    
                    //Update PatientID,TestID,Barcode cho T_Result_Detail
                    new Update(TResultDetail.Schema.Name).Set(TResultDetail.Columns.PatientId).EqualTo(newPatientID).
                        Set(TResultDetail.Columns.Barcode).EqualTo(vBarcode).
                        Set(TResultDetail.Columns.TestId).EqualTo(newTest_ID).
                        Set(TResultDetail.Columns.TestDate).EqualTo(DateTime.Now.ToString()).
                        Where(TResultDetail.Columns.TestId).IsEqualTo(oldTestID).
                        And(TResultDetail.Columns.PatientId).IsEqualTo(oldPatientID).
                        And(TResultDetail.Columns.Barcode).IsEqualTo(CurrentRowBarcode).
                        Execute();

                    //Sửa trạng thái Has_Result của những test có kết quả
                    var dtTestHasResult =
                        new Select(TResultDetail.Columns.TestDataId).From(TResultDetail.Schema.Name).Where(
                            TResultDetail.Columns.Barcode).IsEqualTo(vBarcode).And(TResultDetail.Columns.TestId).
                            IsEqualTo(newTest_ID).ExecuteDataSet().Tables[0];
                    var listTestHasResult = (from d in dtTestHasResult.AsEnumerable() select d["TestData_ID"]).ToList();
                    new Update(TRegList.Schema.Name).Set(TRegList.Columns.HasResult).EqualTo(1).Where(
                        TRegList.Columns.Barcode).IsEqualTo(vBarcode).And(TResultDetail.Columns.TestDataId).In(listTestHasResult).Execute();

                    if (oldTestID > 0 & oldPatientID <= 0 & dr != null)
                        new Delete().From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.TestId).IsEqualTo(oldTestID).
                            Execute();
                    else if (
                        TResultDetail.CreateQuery().WHERE(TResultDetail.Columns.TestId, oldTestID).GetRecordCount() <=
                        0)
                    {
                        if (
                            Utility.AcceptQuestion(
                                string.Format("Đăng ký {0} của bệnh nhân {1} không còn kết quả. Thực hiện xóa ?",
                                              drPatient["TestType_Name"], drPatient["Patient_Name"]), "Thông báo",
                                true))
                        {
                            new Delete().From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.TestId).IsEqualTo(
                                oldTestID).Execute();
                        }
                    }
                    if (oldPatientID > 0 &
                        TTestInfo.CreateQuery().WHERE(TTestInfo.Columns.PatientId, oldPatientID).GetRecordCount() <= 0)
                        if (
                            Utility.AcceptQuestion(
                                string.Format("Bệnh nhận {0} không còn đăng ký. Thực hiện xóa ?",
                                              grdTestInfoModification.GetValue("Patient_Name")), "Thông báo", true))
                        {
                            new Delete().From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.PatientId).IsEqualTo(
                                oldPatientID).Execute();
                        }

                    //Cap nhan thong tin BN tren luoi
                    if (newTest_ID == oldTestID)
                    {
                        Utility.FromObjectToDatarow(obj, ref drPatient);
                        if (obj.YearBirth != null) drPatient["Age"] = DateTime.Now.Year - obj.YearBirth;
                        drPatient["SexName"] = obj.Sex == true ? "Nam" : "Nữ";
                        dtResultModification.AcceptChanges();
                    }
                    else
                    {
                        //grdTestInfoModification.CurrentRow.Delete();
                        //grdTestInfoModification.Refresh();
                        grdTestInfoModification.UpdateData();
                        dtResultModification.AcceptChanges();
                        btnSearchModification.PerformClick();
                    }
                    bSuccess = true;
                }
                catch (Exception ex)
                {
                    Utility.ShowMsg(ex.Message);
                }
                finally
                {
                    if (!bSuccess)
                    {
                        grdTestInfoModification.CurrentRow.Cells["Barcode"].Value = CurrentRowBarcode;
                        grdTestInfoModification.UpdateData();
                        dtResultModification.AcceptChanges();
                    }
                }
            }
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpDateFrom.Value > dtpDateTo.Value) dtpDateTo.Value = dtpDateFrom.Value;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpDateFrom.Value > dtpDateTo.Value) dtpDateFrom.Value = dtpDateTo.Value;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        #endregion

        #region grdResultDetail Event

        private void tsmLoadRegData_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabTestInfo.SelectedTab.Name != "tabResult" | grdTestInfo.CurrentRow == null) return;
                DataTable dt =
                    new Select(TRegList.Columns.TestId, LStandardTest.Schema.Name + ".*").From(TRegList.Schema.Name).
                        LeftOuterJoin(LStandardTest.TestDataIdColumn,
                                      TRegList.TestDataIdColumn).
                        Where(TRegList.Columns.TestId).IsEqualTo(grdTestInfo.GetValue("Test_ID")).ExecuteDataSet().
                        Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    //if (Utility.GetDataRow(m_dtResultDetail, TResultDetail.Columns.TestDataId,dr[TRegList.Columns.TestDataId]) == null)
                    DataRow loz = (from d in m_dtResultDetail.AsEnumerable()
                                   where ((d[TResultDetail.Columns.TestDataId].ToString().Trim().ToUpper() ==
                                           dr[TResultDetail.Columns.TestDataId].ToString().Trim().ToUpper())
                                          &&
                                          (d[TResultDetail.Columns.TestId].ToString().Trim() ==
                                           grdTestInfo.GetValue("Test_ID").ToString().Trim()))
                                   select d).FirstOrDefault();
                    if (loz == null) PerformAddRowTableResult(dr);
                }

                FocusColumnResult();
            }

            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SourceTable"></param>
        /// <param name="fieldName"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        private DataRow GetDataRow(DataTable SourceTable, string[] fieldName, object[] Value)
        {
            try
            {
                foreach (DataRow dr in SourceTable.Rows)
                {
                    bool found = true;
                    for (int i = 0; i <= fieldName.Length - 1; i++)
                    {
                        found = found && dr[fieldName[i]].ToString() == Value[i].ToString();
                    }
                    if (found)
                        return dr;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        private void tsmAddAllStandardDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabTestInfo.SelectedTab.Name != "tabResult" | grdTestInfo.CurrentRow == null) return;
                foreach (
                    DataRow row in
                        PreloadedLists.StandardTest.Select("TestType_ID = " +
                                                           Utility.Int32Dbnull(grdTestInfo.GetValue("TestType_ID"))))
                {
                    if (Utility.GetDataRow(m_dtResultDetail,
                                           new string[] {TResultDetail.Columns.TestDataId, "TestType_ID"},
                                           new object[] {row[TRegList.Columns.TestDataId], row["TestType_ID"]}) == null)
                    {
                        PerformAddRowTableResult(row);
                    }
                }
                FocusColumnResult();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void PerformAddRowTableResult(DataRow row)
        {
            DataRow newDr = m_dtResultDetail.NewRow();
            newDr[TResultDetail.Columns.TestDetailId] = -1;
            newDr[TResultDetail.Columns.ParaName] = row[LStandardTest.Columns.DataName];
            newDr[TResultDetail.Columns.NormalLevel] = row[LStandardTest.Columns.NormalLevel];
            newDr[TResultDetail.Columns.NormalLevelW] = row[LStandardTest.Columns.NormalLevelW];
            newDr[TResultDetail.Columns.DataSequence] = row[LStandardTest.Columns.DataSequence];
            newDr[TResultDetail.Columns.PrintData] = row[LStandardTest.Columns.DataPrint];
            newDr[TResultDetail.Columns.MeasureUnit] = row[LStandardTest.Columns.MeasureUnit];
            newDr[TResultDetail.Columns.TestDataId] = row[LStandardTest.Columns.TestDataId];
            newDr[TResultDetail.Columns.PatientId] = Utility.Int32Dbnull(
                grdTestInfo.GetValue("Patient_ID"), -1);
            newDr[TResultDetail.Columns.TestTypeId] =
                Utility.Int32Dbnull(grdTestInfo.GetValue("TestType_ID"), -1);
            newDr[TResultDetail.Columns.TestId] = Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"), -1);
            m_dtResultDetail.Rows.Add(newDr);
            m_dtResultDetail.AcceptChanges();
        }

        private void tsmAddDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdTestInfo.CurrentRow == null | tabTestInfo.SelectedTab.Name != "tabResult") return;
                var obj = new frmTestTypeRegistration();
                obj.LoadType = "ForResultDetail";
                obj.currentTest_ID = Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"));
                obj.currentTestType_ID = Utility.Int32Dbnull(grdTestInfo.GetValue("TestType_ID"));
                if (Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID")) <= 0)
                {
                    Utility.ShowMsg("Mã loại xét nghiệm không đúng !");
                    obj.Dispose();
                    return;
                }
                obj.patientId = Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"));
                obj.dtResultDetail = m_dtResultDetail;
                obj.ShowDialog();
                FocusColumnResult();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
            //btnParaEntry.PerformClick();
        }

        private void FocusColumnResult()
        {
            //grdResultDetail.Focus();
            //grdResultDetail.CurrentColumn = grdResultDetail.RootTable.Columns["Test_Result"];
        }

        private void tsmManualAddDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabTestInfo.SelectedTab.Name != "tabResult" | grdTestInfo.CurrentRow == null) return;
                var frm = new frmResultDetailInfo();
                frm.vAction = action.Insert;
                frm.m_dtResultDetail = m_dtResultDetail;
                frm.grdResultDetail = grdResultDetail;
                frm.vTestID = Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"));
                frm.ShowDialog();
                //Khi ResultDetail đã được thêm thì add row vào grd KQ
                if (frm.vAction == action.ConfirmData)
                {
                    //grdResultDetail.CurrentRow.Cells[TResultDetail.Columns.TestId].Value = Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"));
                    grdResultDetail.CurrentRow.Cells[TResultDetail.Columns.PatientId].Value =
                        Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"));
                    grdResultDetail.CurrentRow.Cells[TResultDetail.Columns.TestTypeId].Value =
                        Utility.Int32Dbnull(grdTestInfo.GetValue("TestType_ID"));
                    grdResultDetail.CurrentRow.Cells[TResultDetail.Columns.Barcode].Value =
                        Utility.sDbnull(grdTestInfo.GetValue("Barcode"));
                    Insert_Update_Result();
                    FocusColumnResult();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void tsmUpdateResultDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdResultDetail.CurrentRow == null) return;
                var frm = new frmResultDetailInfo();
                frm.grdResultDetail = grdResultDetail;
                frm.ShowDialog();
                if (frm.vAction == action.ConfirmData)
                {
                    Insert_Update_Result();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdXoaCheck_Click(object sender, EventArgs e)
        {
            try
            {
                GridEXRow[] rowCollection = grdResultDetail.GetCheckedRows();


                if (globalVariables.UserName == "ADMIN" || globalVariables.UserName == "LIS_ADMIN" || Utility.Int32Dbnull(grdPatients.GetValue("Print_Status")) == 0)
              {
                //    //Insert_Update_Result();
              
                if (rowCollection.Length <= 0)
                {
                    Utility.ShowMsg("Chưa chọn chi tiết để xóa");
                    return;
                }
                if (!Utility.AcceptQuestion("Thực hiện xóa " + rowCollection.Length + " bản ghi", "Thông báo", true))
                    return;


                  foreach (GridEXRow grdRow in rowCollection)
                  {
                      //if (SysPara.ReportDelete == 1 &&
                      //    !string.IsNullOrEmpty(Utility.sDbnull(grdRow.Cells["Test_Result"].Value)))
                      //{
                      //    //Thêm vào bảng Delete Log để thực hiện in
                      //    var deleteLog = new TDeleteLog();
                      //    deleteLog.TestDetailId = Utility.Int32Dbnull(grdRow.Cells["TestDetail_ID"].Value, -1);
                      //    deleteLog.TestId = Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"), -1);
                      //    deleteLog.Barcode = Utility.sDbnull(grdPatients.GetValue("Barcode"), "");
                      //    deleteLog.PatientId = Utility.Int32Dbnull(grdTestInfo.GetValue("Patient_ID"), -1);
                      //    deleteLog.TestTypeId = Utility.Int32Dbnull(grdTestInfo.GetValue("TestType_ID"), -1);
                      //    deleteLog.ParaName = Utility.sDbnull(grdRow.Cells["Para_Name"].Value, -1);
                      //    deleteLog.ParaStatus = Utility.Int16Dbnull(grdRow.Cells["Para_Status"].Value, -1);
                      //    deleteLog.TestResult = Utility.sDbnull(grdRow.Cells["Test_Result"].Value, -1);
                      //    deleteLog.TestTypeName = Utility.sDbnull(grdTestInfo.GetValue("TestType_Name"));
                      //    deleteLog.TestDate = Convert.ToDateTime(grdTestInfo.GetValue("Test_Date"));
                      //    deleteLog.UserName = globalVariables.UserName;
                      //    deleteLog.DeleteDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                      //    deleteLog.Save();
                      //}

                      new Delete().From(TResultDetail.Schema.Name).Where(TResultDetail.Columns.TestDetailId).IsEqualTo(
                          Utility.Int32Dbnull(grdRow.Cells["TestDetail_ID"].Value, -1)).Execute();
                      grdRow.Delete();


                  }
              }
                else
                {
                    Utility.ShowMsg("Bạn không có quyền xóa két quả, Liên hệ với ADMIN!");
                 
                }
                grdResultDetail.UpdateData();
                m_dtResultDetail.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdResultDetail_CellUpdated(object sender, ColumnActionEventArgs e)
        {
            Insert_Update_Result();
        }

        private void Insert_Update_Result()
        {
            try
            {
                if (grdResultDetail.CurrentRow == null) return;
                if (Utility.Int32Dbnull(grdResultDetail.GetValue("TestDetail_ID"), -1) > 0)
                {
                    new Update(TResultDetail.Schema.Name).Set(TResultDetail.Columns.ParaName).EqualTo(
                        Utility.sDbnull(grdResultDetail.GetValue("Para_Name"))).
                        Set(TResultDetail.Columns.NormalLevel).EqualTo(
                            Utility.sDbnull(grdResultDetail.GetValue("Normal_Level"))).
                        Set(TResultDetail.Columns.NormalLevelW).EqualTo(
                            Utility.sDbnull(grdResultDetail.GetValue("Normal_LevelW"))).
                        Set(TResultDetail.Columns.MeasureUnit).EqualTo(
                            Utility.sDbnull(grdResultDetail.GetValue("Measure_Unit"))).
                        Set(TResultDetail.Columns.TestResult).EqualTo(
                            Utility.sDbnull(grdResultDetail.GetValue("Test_Result"))).
                        Set(TResultDetail.Columns.Note).EqualTo(Utility.sDbnull(grdResultDetail.GetValue("Note"))).
                        Set(TResultDetail.Columns.DataSequence).EqualTo(
                            Utility.sDbnull(grdResultDetail.GetValue("Data_Sequence"))).
                               Set(TResultDetail.Columns.TestDate).EqualTo(
                            DateTime.Now.ToString("yyyy-MM-dd")).
                        Where(TResultDetail.Columns.TestDetailId).IsEqualTo(
                            Utility.Int32Dbnull(grdResultDetail.GetValue("TestDetail_ID"), -1)).
                        Execute();
                }
                else
                {
                    var obj = new TResultDetail();
                    obj.TestId = Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"), -1);
                    obj.PatientId = Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"), -1);
                    obj.TestTypeId = Utility.Int32Dbnull(grdTestInfo.GetValue("TestType_ID"), -1);
                    obj.TestDate = DateTime.Now;
                    obj.DataSequence = Utility.Int32Dbnull(grdResultDetail.GetValue("Data_Sequence"));
                    obj.TestResult = Utility.sDbnull(grdResultDetail.GetValue("Test_Result"));
                    obj.NormalLevel = Utility.sDbnull(grdResultDetail.GetValue("Normal_Level"));
                    obj.NormalLevelW = Utility.sDbnull(grdResultDetail.GetValue("Normal_levelW"));
                    obj.MeasureUnit = Utility.sDbnull(grdResultDetail.GetValue("Measure_Unit"));
                    obj.ParaName = Utility.sDbnull(grdResultDetail.GetValue("Para_Name"));
                    obj.TestDataId = Utility.sDbnull(grdResultDetail.GetValue("TestData_ID"));
                    obj.ParaStatus = 0;
                    obj.PrintData = true;
                    obj.Barcode = Utility.sDbnull(grdTestInfo.GetValue("Barcode"));
                    obj.UpdateNum = 0;
                    obj.IsNew = true;
                    obj.Save();
                    grdResultDetail.CurrentRow.Cells["TestDetail_ID"].Value =
                        Utility.Int32Dbnull(TResultDetail.CreateQuery().
                                                WHERE(TResultDetail.Columns.PatientId, obj.PatientId).
                                                WHERE(TResultDetail.Columns.TestTypeId, obj.TestTypeId).
                                                GetMax(TResultDetail.Columns.TestDetailId), -1);
                    grdResultDetail.UpdateData();
                    m_dtResultDetail.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdResultDetail_DoubleClick(object sender, EventArgs e)
        {
            tsmUpdateResultDetail.PerformClick();
        }

        private void tsmEditResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabTestInfo.SelectedTab.Name != "tabResult") return;
                if (grdResultDetail.RootTable.Columns["Test_Result"].EditType != EditType.NoEdit)
                {
                    grdResultDetail.RootTable.Columns["Test_Result"].EditType = EditType.NoEdit;
                    grdResultDetail.RootTable.Columns["Test_Result"].CellStyle.BackColor = colorNoEditResult;
                }
                else
                {
                    grdResultDetail.RootTable.Columns["Test_Result"].EditType = EditType.TextBox;
                    grdResultDetail.RootTable.Columns["Test_Result"].CellStyle.BackColor = colorAllowEditResult;
                    FocusColumnResult();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        #endregion

        private void tsmReRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdTestTypeRegList.CurrentRow == null) return;
                if (grdTestTypeRegList.CurrentRow.RowType != RowType.Record) return;
                if (!Utility.AcceptQuestion("Đăng ký chạy lại", "Thông báo", true)) return;
                new Update(TRegList.Schema.Name).Set(TRegList.Columns.Status).EqualTo(0).
                    Where(TRegList.Columns.TestRegDetailId).
                    IsEqualTo(Utility.Int32Dbnull(grdTestTypeRegList.GetValue("TestRegDetail_ID"))).Execute();
                grdTestTypeRegList.SetValue("Status", 0);
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdResultDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (grdResultDetail.CurrentRow == null) return;
                int vTestResult_Id = Utility.Int32Dbnull(grdResultDetail.GetValue("TestDetail_ID"));
                {
                    if (grdResultDetail.CurrentColumn.Key == "Test_Result" &
                        grdResultDetail.RootTable.Columns["Test_Result"].EditType != EditType.NoEdit &
                        vTestResult_Id > 0)
                    {
                        if (globalVariables.UserName == "ADMIN" || globalVariables.UserName == "LIS_ADMIN" || Utility.Int32Dbnull(grdPatients.GetValue("Print_Status")) ==0)
                        {
                            Insert_Update_Result();
                        }

                        else if (TResultDetail.CreateQuery().WHERE(TResultDetail.Columns.TestDetailId, vTestResult_Id).
                                AND(TResultDetail.Columns.ParaStatus, Comparison.GreaterThan, 0).GetRecordCount() > 0)
                        {
                            Utility.ShowMsg("Đã in kết quả. Không được sửa !");
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


        private void cmdValidate_Click(object sender, EventArgs e)
        {
            try
            {
                var sqlQuery =
                    new Select().From(TResultDetail.Schema).Where(TResultDetail.Columns.PatientId).IsEqualTo(
                        Utility.sDbnull(grdPatients.GetValue("Patient_ID")));

                var testInfo = sqlQuery.ExecuteSingle<TTestInfo>();
                if (testInfo != null)
                {
                    if (Utility.AcceptQuestion(string.Format("Hoàn tất xét nghiệm của bệnh nhân {0} ",
                                                             Utility.sDbnull(grdPatients.GetValue("Patient_Name"))),
                                               "Thông báo", true))
                    {
                        new Update(LPatientInfo.Schema.Name).Set(LPatientInfo.Columns.IsFinal).EqualTo(1).
                            Where(LPatientInfo.Columns.PatientId).IsEqualTo(
                                Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"))).Execute();
                        grdPatients.SetValue("IsFinal", 1);
                        grdPatients.UpdateData();
                        mv_DTPatientInfor.AcceptChanges();
                        grdResultDetail.AllowEdit = InheritableBoolean.True;
                    }
                }
                else
                {
                    Utility.ShowMsg("Bệnh nhân chưa có kết quả nên chưa được hoàn thành", "Thông Báo",
                                    MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdUnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Utility.AcceptQuestion(string.Format("Cho phép tiếp tục xử lý kết quả của bệnh nhân {0} ",
                                                         Utility.sDbnull(grdPatients.GetValue("Patient_Name"))),
                                           "Thông báo", true))
                {
                    new Update(LPatientInfo.Schema.Name).Set(LPatientInfo.Columns.IsFinal).EqualTo(0).
                        Where(LPatientInfo.Columns.PatientId).IsEqualTo(
                            Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"))).Execute();
                    grdPatients.SetValue("IsFinal", 0);
                    grdPatients.UpdateData();
                    mv_DTPatientInfor.AcceptChanges();
                    grdResultDetail.AllowEdit = InheritableBoolean.True;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void SetEventColumnHeaderColor()
        {
            try
            {
                Control[] arrControls = new Control[]
                                            {
                                                grdPatients, grdTestInfo, grdResultDetail, grdTestInfoModification,
                                                grdResultModification, grdTestTypeRegList, grdTestType
                                            };
                foreach (Control control in arrControls)
                {
                    control.Enter += gridEx_Enter;
                    control.Leave += gridEx_Leave;
                }
            }
            catch (Exception)
            {
            }
        }

        private void gridEx_Enter(object sender, EventArgs e)
        {
            try
            {
                GridEX gridEx = (GridEX) sender;
                gridEx.HeaderFormatStyle.ForeColor = colorRowHeaderActive;
            }
            catch (Exception)
            {
            }
        }

        private void gridEx_Leave(object sender, EventArgs e)
        {
            try
            {
                GridEX gridEx = (GridEX) sender;
                gridEx.HeaderFormatStyle.ForeColor = colorRowHeaderIntactive;
            }
            catch (Exception)
            {
            }
        }

        private void txtBarcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) cmdSearch.PerformClick();
        }

        private void HoanTatBenhNhan()
        {
            SqlQuery sql =
                new Select().From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.SentStatus).IsEqualTo(1).And(
                    TTestInfo.Columns.PatientId).IsEqualTo(
                        Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID")));
            DataTable dataTable = sql.ExecuteDataSet().Tables[0];
            SqlQuery sql1 =
                new Select().From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.PatientId).
                    IsEqualTo(Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID")));
            DataTable dataTable1 = sql1.ExecuteDataSet().Tables[0];
            int countTestID = dataTable1.Rows.Count;
            int countSentStatus = dataTable.Rows.Count;
            if (countSentStatus == countTestID)
            {
                new Update(LPatientInfo.Schema.Name).Set(LPatientInfo.Columns.IsFinal).EqualTo(1).Where(
                    LPatientInfo.Columns.PatientId).IsEqualTo(
                        Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"))).Execute();
                grdPatients.SetValue("IsFinal", 1);
                grdPatients.UpdateData();
                mv_DTPatientInfor.AcceptChanges();
                grdResultDetail.AllowEdit = InheritableBoolean.True;
            }
            else
            {
                new Update(LPatientInfo.Schema.Name).Set(LPatientInfo.Columns.IsFinal).EqualTo(0).Where(
                    LPatientInfo.Columns.PatientId).IsEqualTo(
                        Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"))).Execute();
                grdPatients.SetValue("IsFinal", 0);
                grdPatients.UpdateData();
                mv_DTPatientInfor.AcceptChanges();
                grdResultDetail.AllowEdit = InheritableBoolean.True;
            }
        }

        private void tsmDuyetChiDinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdTestInfo.CurrentRow.Cells["SentStatus"].Value.ToString() == "1")
                {
                    var printStatus = Utility.sDbnull(grdPatients.GetValue("Print_Status"));
                    if (printStatus == "1")
                    {
                        if (globalVariables.UserName == "ADMIN" || globalVariables.UserName == "TRUC" ||
                            globalVariables.UserName == "TRUONGKHOA" || globalVariables.UserName == "PHOKHOA")
                        {
                            if (Utility.AcceptQuestion(
                                string.Format("Cho phép xử lý kết quả xét nghiệm {0} của bệnh nhân {1}",
                                              Utility.sDbnull(grdTestInfo.GetValue("TestType_Name")),
                                              Utility.sDbnull(grdPatients.GetValue("Patient_Name"))), "Thông Báo", true))
                            {
                                new Update(TTestInfo.Schema.Name).Set(TTestInfo.Columns.SentStatus).EqualTo(0).Where(
                                    TTestInfo.Columns.TestId).IsEqualTo(
                                        Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID")))
                                    .And(
                                        TTestInfo.Columns.PatientId).IsEqualTo(
                                            Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"))).Execute();
                                grdTestInfo.SetValue("SentStatus", 0);
                                grdTestInfo.UpdateData();
                                m_dtTestInfo.AcceptChanges();
                                grdResultDetail.AllowEdit = InheritableBoolean.True;
                            }
                            HoanTatBenhNhan();
                        }
                        else
                        {
                            Utility.ShowMsg(
                                "Bệnh nhân này đã được in nên không hủy duyệt được" + "\n" +
                                "Vui lòng liên hệ với ADMIN để được hủy duyệt! Thanks", "Thông Báo",
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (Utility.AcceptQuestion(
                            string.Format("Cho phép xử lý kết quả xét nghiệm {0} của bệnh nhân {1}",
                                          Utility.sDbnull(grdTestInfo.GetValue("TestType_Name")),
                                          Utility.sDbnull(grdPatients.GetValue("Patient_Name"))), "Thông Báo", true))
                        {
                            new Update(TTestInfo.Schema.Name).Set(TTestInfo.Columns.SentStatus).EqualTo(0).Where(
                                TTestInfo.Columns.TestId).IsEqualTo(Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID")))
                                .
                                And(
                                    TTestInfo.Columns.PatientId).IsEqualTo(
                                        Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"))).Execute();
                            grdTestInfo.SetValue("SentStatus", 0);
                            grdTestInfo.UpdateData();
                            m_dtTestInfo.AcceptChanges();
                            grdResultDetail.AllowEdit = InheritableBoolean.True;
                        }
                        HoanTatBenhNhan();
                    }
                }
                else
                {
                    SqlQuery sqlQuery =
                        new Select().From(TResultDetail.Schema).Where(TResultDetail.Columns.TestId).IsEqualTo(
                            Utility.sDbnull(grdTestInfo.GetValue("Test_ID")));
                    var testInfo = sqlQuery.ExecuteSingle<TTestInfo>();
                    if (testInfo != null)
                    {
                        if (Utility.AcceptQuestion(string.Format("Hoàn tất xét nghiệm {0} của bện nhân {1} ",
                                                                 Utility.sDbnull(grdTestInfo.GetValue("TestType_Name")),
                                                                 Utility.sDbnull(grdPatients.GetValue("Patient_Name"))),
                                                   "Thông Báo", true))
                        {
                            new Update(TTestInfo.Schema.Name).Set(TTestInfo.Columns.SentStatus).EqualTo(1).Where(
                                TTestInfo.Columns.PatientId).IsEqualTo(
                                    Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"))).And(
                                        TTestInfo.Columns.TestId).
                                IsEqualTo(Utility.sDbnull(grdTestInfo.GetValue("Test_ID"))).Execute();
                            grdTestInfo.SetValue("SentStatus", 1);
                            grdTestInfo.UpdateData();
                            m_dtTestInfo.AcceptChanges();
                            grdResultDetail.AllowEdit = InheritableBoolean.True;
                        }
                        HoanTatBenhNhan();
                    }
                    else
                    {
                        Utility.ShowMsg(
                            string.Format(" Xét nghiệm {0} của bệnh nhân {1} chưa có kết quả",
                                          Utility.sDbnull(grdTestInfo.GetValue("TestType_Name")),
                                          Utility.sDbnull(grdPatients.GetValue("Patient_Name"))), "Thông Báo",
                            MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Duyệt kết quả thất bại" + "\n" + ex, "Thông Báo", MessageBoxIcon.Error);
            }
        }

        private void tsmHuyDuyet_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string printStatus = Utility.sDbnull(grdPatients.GetValue("Print_Status"));
            //    if (printStatus == "1")
            //    {
            //        if (globalVariables.UserName == "ADMIN" || globalVariables.UserName == "TRUC" || globalVariables.UserName =="TRUONGKHOA"|| globalVariables.UserName =="PHOKHOA")
            //        {
            //            if (Utility.AcceptQuestion(
            //                string.Format("Cho phép xử lý kết quả xét nghiệm {0} của bệnh nhân {1}",
            //                              Utility.sDbnull(grdTestInfo.GetValue("TestType_Name")),
            //                              Utility.sDbnull(grdPatients.GetValue("Patient_Name"))), "Thông Báo", true))
            //            {
            //                new Update(TTestInfo.Schema.Name).Set(TTestInfo.Columns.SentStatus).EqualTo(0).Where(
            //                    TTestInfo.Columns.TestId).IsEqualTo(Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID")))
            //                    .And(
            //                        TTestInfo.Columns.PatientId).IsEqualTo(
            //                            Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"))).Execute();
            //                grdTestInfo.SetValue("SentStatus", 0);
            //                grdTestInfo.UpdateData();
            //                m_dtTestInfo.AcceptChanges();
            //                grdResultDetail.AllowEdit = InheritableBoolean.True;
            //            }
            //            HoanTatBenhNhan();
            //        }
            //        else
            //        {
            //            Utility.ShowMsg(
            //                "Bệnh nhân này đã được in nên không hủy duyệt được" + "\n" +
            //                "Vui lòng liên hệ với ADMIN để được hủy duyệt! Thanks", "Thông Báo",
            //                MessageBoxIcon.Error);
            //        }
            //    }
            //    else
            //    {
            //        if (Utility.AcceptQuestion(
            //            string.Format("Cho phép xử lý kết quả xét nghiệm {0} của bệnh nhân {1}",
            //                          Utility.sDbnull(grdTestInfo.GetValue("TestType_Name")),
            //                          Utility.sDbnull(grdPatients.GetValue("Patient_Name"))), "Thông Báo", true))
            //        {
            //            new Update(TTestInfo.Schema.Name).Set(TTestInfo.Columns.SentStatus).EqualTo(0).Where(
            //                TTestInfo.Columns.TestId).IsEqualTo(Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"))).
            //                And(
            //                    TTestInfo.Columns.PatientId).IsEqualTo(
            //                        Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"))).Execute();
            //            grdTestInfo.SetValue("SentStatus", 0);
            //            grdTestInfo.UpdateData();
            //            m_dtTestInfo.AcceptChanges();
            //            grdResultDetail.AllowEdit = InheritableBoolean.True;
            //        }
            //        HoanTatBenhNhan();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Utility.ShowMsg("Hủy duyệt kết quả thất bại" + "\n" + ex, "Thông Báo", MessageBoxIcon.Error);
            //}
        }

        private void cboObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void grdTestInfo_CellValueChanged(object sender, ColumnActionEventArgs e)
        {
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            var x = new Frm_Config();
            x.Text = "Cấu hình chức năng";
            x.Object = _myProperties;
            x.ShowDialog();
            SaveFrmMainConfig();
            SetFormatCondition();
        }

    }
}