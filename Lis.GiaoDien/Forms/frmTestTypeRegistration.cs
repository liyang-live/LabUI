using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Janus.Windows.EditControls;
using Janus.Windows.UI;
using LIS.DAL;
using Lis.LoadData;
using SubSonic;
using VNS.Libs;
using ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment;
using ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment;
using TextAlignment = Janus.Windows.EditControls.TextAlignment;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class frmTestTypeRegistration : Form
    {
        #region Attributes
        public Janus.Windows.GridEX.GridEX grdPatients;
        public DataTable dtResultDetail;
        public string LoadType;
        public int currentTest_ID = -1;
        public int currentTestType_ID = -1;
        private bool GroupButtonIsPressed = false;
        private DataTable dtRegList;

        private DataTable dtTestInfo;
        public DataTable dtTestTypeList;

        private Color myButtonBackColor;
        private Size myButtonSize, myImageSize;
        private Padding myPaddingSize;

        public int patientId;
        private LPatientInfo patientInfo;

        public delegate void PrintBarcodeDelegate();

        public PrintBarcodeDelegate PrintbarcodeInstance;

        #endregion

        public frmTestTypeRegistration()
        {
            InitializeComponent();
        }

        #region LoadForm

        private void frmTestTypeRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                myButtonSize = new Size(125, 40);
                myImageSize = new Size(24, 24);
                myPaddingSize = new Padding(1);
                myButtonBackColor = Color.WhiteSmoke;
                LoadPatientInfo();
                
                if (LoadType == "ForResultDetail")
                {
                    uiGroupBox1.Visible = false;
                    splitContainer1.Panel1Collapsed = true;
                    btnPrintBarcode.Visible = false;
                    btnPrint.Visible = false;
                    LoadStandardTestType(currentTestType_ID);
                    return;
                }

                LoadTestTypeButton();
                LoadRegisteredTestType();
                LoadAssignDoctor();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                Dispose();
            }
        }

        private void LoadAssignDoctor()
        {
            DataTable dtDoctor = new Select().From(LUser.Schema.Name).ExecuteDataSet().Tables[0];
            DataRow dr = dtDoctor.NewRow();
            dr[LUser.Columns.UserId] = -1;
            dr[LUser.Columns.UserName] = "-----Chọn Bác Sỹ-----";
            dtDoctor.Rows.InsertAt(dr,0);
            DataBinding.BindData(cboAssignDoctor,dtDoctor,LUser.Columns.UserId,LUser.Columns.UserName);
        }

        private void LoadPatientInfo()
        {
            patientInfo = LPatientInfo.FetchByID(patientId);
            txtPatientName.Text = patientInfo.PatientName;
            txtAge.Text = (DateTime.Now.Year - patientInfo.YearBirth).ToString();
            txtSex.Text = patientInfo.Sex == true ? "Nam" : "Nữ";
        }

        private void LoadRegisteredTestType()
        {
            try
            {
                dtTestInfo =
                new Select(TTestInfo.Schema.Name + ".*", TTestTypeList.Columns.TestTypeName,
                    LUser.Columns.UserName + " As AssignDoctor_Name",
                           "(Select Count(trl.Test_ID) From T_Reg_List trl Where trl.Test_ID = " +
                           TTestInfo.TestIdColumn.QualifiedName + ") as RegCount").From(TTestInfo.Schema.Name).
                    LeftOuterJoin(TTestTypeList.TestTypeIdColumn, TTestInfo.TestTypeIdColumn).
                    LeftOuterJoin(LUser.UserIdColumn, TTestInfo.AssignIdColumn).
                    //OrderAsc(TTestTypeList.Columns.IntOrder).
                    Where(TTestInfo.Columns.PatientId).IsEqualTo(patientId).ExecuteDataSet().Tables[0];
                grdTestInfo.DataSource = dtTestInfo;
                int rowCount = 0;
                foreach (var r in grdTestInfo.GetRows())
                {
                    if (Utility.Int32Dbnull(r.Cells["Test_ID"].Value) == currentTest_ID)
                    {

                        grdTestInfo.Row = rowCount;
                    }
                    rowCount++;
                }
            }
            catch (Exception)
            {
                
            }
            
        }

        private void LoadTestTypeButton()
        {
            //dtTestTypeList = new Select().From(TTestTypeList.Schema.Name).OrderAsc(TTestTypeList.Columns.IntOrder).
            //    ExecuteDataSet().Tables[0];
            int idx = 0;
            var btnTestTypeSize = new Size(180, 50);
            var btnTestTypeImageSize = new Size(24, 24);
            var btnTestTypePadding = new Padding(25, 25, 25, 25);
            Color btnTestTypeBackColor = Color.WhiteSmoke;
            foreach (DataRow dr in dtTestTypeList.Rows)
            {
                idx += 1;
                var obj = new UIButton();
                obj.Size = btnTestTypeSize;
                obj.ImageSize = btnTestTypeImageSize;
                obj.Padding = btnTestTypePadding;
                obj.BackColor = btnTestTypeBackColor;
                obj.TextHorizontalAlignment = TextAlignment.Near;
                obj.Text = string.Format("{0}. {1}", idx.ToString(CultureInfo.InvariantCulture), dr[TTestTypeList.Columns.TestTypeName]); // +" (F" + idx + ")";
                obj.Tag = dr[TTestTypeList.Columns.TestTypeId].ToString();
                obj.Click += BtnTestTypeClick;
                flpTestType.Controls.Add(obj);
            }

            //dtTestTypeList.Columns.Add("Short_Key");
            //dtTestTypeList.Columns.Add("Device_Control");
            //foreach (DataRow dr in dtTestTypeList.Rows)
            //{
            //    idx += 1;
            //    dr["Short_Key"] = "F" + idx;
            //    dr["Device_Control"] = IsBiDirectional(Convert.ToInt32(dr["TestType_ID"]));
            //}
        }

        #endregion

        #region ClickEvent

        /// <summary>
        /// Xử lý đăng ký theo nhóm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TestGroupButtonClick(object sender, EventArgs e)
        {
            try
            {
                var testGroup = (from detail in PreloadedLists.TestGroupRelation.AsEnumerable()
                                                where detail.Field<int>(TTestgroupDtl.Columns.TestGroupId).ToString(
                                                        CultureInfo.InvariantCulture).Equals(
                                                            ((UIButton) sender).Tag.ToString())
                                                select detail.Field<string>(TTestgroupDtl.Columns.TestDataId)).ToList();
                var testControl = from ctrl in flpStandardTest.Controls.Cast<Control>()
                                      where testGroup.Contains(ctrl.Tag.ToString())
                                      select ctrl;
                GroupButtonIsPressed = true;
                foreach (var control in testControl)
                {
                    ((UIButton)control).PerformClick();
                }
                GroupButtonIsPressed = false;
                FocusButtonDetail();
            }
            catch (Exception ex)
            {
                GroupButtonIsPressed = false;
                Utility.ShowMsg(ex.Message);
            }
        }

        private void RegButtonClick(object sender, EventArgs e)
        {
            try
            {
                var btn = (UIButton) sender;
                if (btn.ImageIndex == 0)
                {
                    if (LoadType != "ForResultDetail")
                    {
                        var objTRL = new TRegList();
                        objTRL.Barcode = Utility.sDbnull(grdTestInfo.GetValue("Barcode"));
                        objTRL.TestDataId = Utility.sDbnull(btn.Tag);
                        objTRL.TestId = Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"), -1);
                        objTRL.PatientId= Utility.DecimaltoDbnull(grdTestInfo.GetValue("Patient_id"));
                        objTRL.ParaName = btn.Text;
                        objTRL.AliasName = btn.Tag.ToString();
                        objTRL.Status = 0;
                        objTRL.IsNew = true;
                        objTRL.Save();

                        grdTestInfo.CurrentRow.Cells["RegCount"].Value =
                            Utility.Int32Dbnull(grdTestInfo.CurrentRow.Cells["RegCount"].Value, 0) + 1;
                        grdTestInfo.UpdateData();
                    }
                    else
                    {
                            ProcessData.AddRowTableDetail(ref dtResultDetail,Utility.sDbnull(btn.Tag),patientId,currentTest_ID);
                    }
                    btn.ImageIndex = 1;
                    ////////Todo: xử lý theo từng thiết bị

                    ////////Nạp các thiết bị có test Data ID này:
                    //////var dtDevices =
                    //////    new Select(DDeviceList.Columns.DeviceId, DDeviceList.Columns.DeviceName).From(
                    //////        DDataControl.Schema.Name).LeftOuterJoin(DDeviceList.DeviceIdColumn,
                    //////                                                DDataControl.DeviceIdColumn).Where(
                    //////                                                    DDataControl.Columns.TestDataId).IsEqualTo(
                    //////                                                        obj.Tag).ExecuteDataSet().Tables[0];
                    //////// Nạp danh sách vừa lấy được lên combobox
                    //////var dr = dtDevices.NewRow();
                    //////dr[DDeviceList.Columns.DeviceId] = -1;
                    //////dr[DDeviceList.Columns.DeviceName] = "Tất cả";
                    //////dtDevices.Rows.InsertAt(dr,0);

                    ////////Nạp danh sách lên Combobox
                    //////cboDevices.Items.Clear();
                    //////foreach (DataRow row in dtDevices.Rows)
                    //////{
                    //////    var deviceName = Utility.sDbnull(row[DDeviceList.Columns.DeviceName],"");
                    //////    var deviceId = Utility.Int32Dbnull(row[DDeviceList.Columns.DeviceId]);
                    //////    var item = new CCBoxItem(deviceName,deviceId);
                    //////    cboDevices.Items.Add(item);
                    //////}
                    
                    ////////Utility.ShowMsg("OK");


                }
                else if (btn.ImageIndex == 1)
                {
                    if (LoadType != "ForResultDetail")
                    {
                        new Delete().From(TRegList.Schema.Name).Where(TRegList.Columns.TestId).
                        IsEqualTo(Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"), -1)).
                        And(TRegList.Columns.Barcode).IsEqualTo(Utility.sDbnull(grdTestInfo.GetValue("Barcode"))).
                        And(TRegList.Columns.TestDataId).IsEqualTo(btn.Tag.ToString()).Execute();

                        
                        grdTestInfo.CurrentRow.Cells["RegCount"].Value =
                            Utility.Int32Dbnull(grdTestInfo.CurrentRow.Cells["RegCount"].Value, 0) - 1;
                        grdTestInfo.UpdateData();    
                    }
                    else ProcessData.DelRowTableDetail(ref dtResultDetail, Utility.sDbnull(btn.Tag),currentTest_ID);
                    btn.ImageIndex = 0;
                    }
                else if (btn.ImageIndex == 2 & !GroupButtonIsPressed)
                    Utility.ShowMsg("Không được hủy. Tồn tại dữ liệu !");
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        /// <summary>
        /// Hàm xử lý click vào nút đăng ký xn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTestTypeClick(object sender, EventArgs e)
        {
            try
            {
                int count;
                var btn = (UIButton) sender;
                int vTestTypeId = Utility.Int32Dbnull(btn.Tag);

                count = TTestInfo.CreateQuery().WHERE(TTestInfo.Columns.PatientId, patientId).
                        WHERE(TTestInfo.Columns.TestTypeId, vTestTypeId).GetRecordCount();
                if (count > 0)
                {
                    //Utility.ShowMsg("Loại Xét Nghiệm đã được đăng ký");
                    //Todo: focus vào test đã đăng ký
                    for (int i = 0; i < grdTestInfo.RowCount; i++)
                    {
                        if (Utility.sDbnull(grdTestInfo.GetRow(i).Cells["TestType_ID"].Value) == (string)btn.Tag)
                        {
                            grdTestInfo.MoveTo(i);
                            break;
                        }
                    }
                    return;
                }

                string vBarcode = "";
                DataRow drTestType = Utility.GetDataRow(dtTestTypeList, TTestTypeList.Columns.TestTypeId, btn.Tag);

                if (SysPara.AutoGenerateBarcode == 2 | (SysPara.AutoGenerateBarcode == 0 & dtTestInfo.Rows.Count == 0))
                {
                    frmInput_Update_Barcode oForm = new frmInput_Update_Barcode();
                    if (dtTestInfo.Rows.Count > 0)
                    {
                        oForm.txtBarcode.Text = Utility.sDbnull(grdTestInfo.GetValue("Barcode"));
                        oForm.txtBarcode.SelectAll();
                    }
                    oForm.vTestType_ID = vTestTypeId;
                    oForm.txtTestType_Name.Text = Utility.sDbnull(drTestType["TestType_Name"]);
                    oForm.ShowDialog();
                    if (string.IsNullOrEmpty(oForm.txtBarcode.Text)) return;
                    vBarcode = oForm.txtBarcode.Text;
                }
                else if (dtTestInfo.Rows.Count > 0)
                {
                    vBarcode = Utility.sDbnull(grdTestInfo.GetValue("Barcode")).Trim();
                    //count = new Select().From(TTestInfo.Schema).Where(TTestInfo.Columns.TestTypeId).IsEqualTo(vTestTypeId).
                    //                And(TTestInfo.Columns.Barcode).IsEqualTo(vBarcode).GetRecordCount();
                    //if (count > 0)
                    //{
                    //    Utility.ShowMsg("Barcode tồn tại. Mời nhập lại.");
                    //    return;
                    //}
                }
                else
                {
                    vBarcode = BarcodeInfo.GetBarcodeForPatient(patientId, vTestTypeId, drTestType[TTestTypeList.Columns.IntOrder].ToString());
                    if (vBarcode == "-1")
                    {
                        Utility.ShowMsg("Không tìm được Barcode");
                        return;
                    }
                }
                string canlamsangid;
                LPatientInfo lPatientInfo = new Select().From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.PatientId).IsEqualTo(patientId).ExecuteSingle<LPatientInfo>();
                canlamsangid=lPatientInfo.CanLamSangId;    
                var obj = new TTestInfo();
                obj.TestTypeId = vTestTypeId;
                obj.Barcode = vBarcode;
                obj.PatientId = patientId;
                obj.TestDate = DateTime.Now;
                obj.RequireDate = DateTime.Now;
                obj.AssignId = Utility.Int32Dbnull(cboAssignDoctor.SelectedValue);
                obj.CanLamSangId = "OO" + DateTime.Now.ToString("yyMMdd")+"."+canlamsangid;
                obj.IsNew = true;
                obj.Save();

                DataRow dr = dtTestInfo.NewRow();
                dr[TTestInfo.Columns.TestId] = TTestInfo.CreateQuery().WHERE(TTestInfo.Columns.PatientId, patientId).
                    WHERE(TTestInfo.Columns.TestTypeId, vTestTypeId).GetMax(TTestInfo.Columns.TestId);
                dr[TTestInfo.Columns.TestDate] = obj.TestDate;
                dr[TTestInfo.Columns.Barcode] = obj.Barcode;
                dr[TTestInfo.Columns.PatientId] = obj.PatientId;
                dr[TTestInfo.Columns.TestTypeId] = obj.TestTypeId;
                dr[TTestTypeList.Columns.TestTypeName] = drTestType[TTestTypeList.Columns.TestTypeName].ToString();
                dr[TTestInfo.Columns.AssignId] = obj.AssignId;
                dr["AssignDoctor_Name"] = Utility.Int32Dbnull(cboAssignDoctor.SelectedValue) == -1
                                              ? ""
                                              : cboAssignDoctor.Text;
                

                dtTestInfo.Rows.InsertAt(dr, 0);
                grdTestInfo.SelectionChanged -= grdTestInfo_SelectionChanged;
                dtTestInfo.AcceptChanges();
                grdTestInfo.SelectionChanged += grdTestInfo_SelectionChanged;
                grdTestInfo.MoveFirst();
                
                // Todo: xử lý sau khi nhấn nút đăng ký
                //Nếu ô đăng ký test có dl thì chuyển sang
                //if (flpTestGroup.Controls.Count > 0) flpTestGroup.Focus();
                //else flpStandardTest.Focus();
                
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
            finally {FocusButtonDetail();}
        }

        private void FocusButtonDetail()
        {
            try
            {
                if (flpStandardTest.Controls.Count > 0)
                    flpStandardTest.Controls[0].Focus();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        #endregion

        #region tabPages_RegList

        private void LoadStandardTestType(int vTestType)
        {
            try
            {
                DataRow[] arrTestGroup = PreloadedLists.TestGroupList.Select("TestType_ID = " + vTestType);
                if (arrTestGroup.Length <= 0) spcStandardTest.Panel1Collapsed = true;
                else
                {
                    spcStandardTest.Panel1Collapsed = false;
                    for (int i = 0; i < arrTestGroup.Count(); i++)
                    {
                        DataRow dr2 = arrTestGroup[i];
                        var btnTestGroup = new UIButton();
                        btnTestGroup.Text = string.Format("{0}. {1}", i + 1,Utility.sDbnull(dr2[TTestgroupList.Columns.TestGroupName]));
                        btnTestGroup.TextHorizontalAlignment = TextAlignment.Near;
                        btnTestGroup.Tag = dr2[TTestgroupList.Columns.TestGroupId].ToString();
                        btnTestGroup.BackColor = myButtonBackColor;
                        btnTestGroup.Size = myButtonSize;
                        btnTestGroup.ImageSize = myImageSize;
                        btnTestGroup.Margin = myPaddingSize;

                        btnTestGroup.Click += TestGroupButtonClick;
                        flpTestGroup.Controls.Add(btnTestGroup);
                    }
                }

                if (LoadType == "ForResultDetail") dtRegList = dtResultDetail;
                else
                    dtRegList =new Select(TRegList.Schema.Name + ".*", LStandardTest.Columns.TestTypeId).From(TRegList.Schema.Name).
                            LeftOuterJoin(LStandardTest.TestDataIdColumn, TRegList.TestDataIdColumn).
                            Where(TRegList.Columns.TestId).IsEqualTo(Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"))).
                            And(LStandardTest.Columns.TestTypeId).IsEqualTo(vTestType).
                            ExecuteDataSet().Tables[0];

                foreach (DataRow dr1 in PreloadedLists.StandardTest.Rows)
                {
                    if (Utility.Int32Dbnull(dr1["TestType_ID"])== vTestType)
                    {
                        var btnRegData = new UIButton();
                        //btnRegData.Text = string.Format("{0}", dr1["TestData_ID"]);
                        btnRegData.Text = Utility.sDbnull(dr1["Data_Name"]);
                        btnRegData.Tag = Utility.sDbnull(dr1[LStandardTest.Columns.TestDataId]);
                        btnRegData.BackColor = myButtonBackColor;
                        btnRegData.Size = myButtonSize;
                        btnRegData.ImageSize = myImageSize;
                        btnRegData.Margin = myPaddingSize;
                        btnRegData.ImageVerticalAlignment = ImageVerticalAlignment.Center;
                        btnRegData.ImageHorizontalAlignment = ImageHorizontalAlignment.Near;
                        btnRegData.ImageList = imgAdminnistration;
                        btnRegData.ContextMenuStrip = contextMenuStrip1;
                        btnRegData.ActiveFormatStyle.BackColor = Color.FromArgb(255, 224, 192);
                        btnRegData.ActiveFormatStyle.ForeColor = Color.Red;
                        btnRegData.ActiveFormatStyle.FontBold = TriState.True;
                        btnRegData.ActiveFormatStyle.FontItalic = TriState.True;
                        btnRegData.ActiveFormatStyle.FontUnderline = TriState.True;
                        btnRegData.ToolTipText = btnRegData.Text;

                        DataRow row = Utility.GetDataRow(dtRegList, new string[] { "TestData_ID", "TestType_ID" }, new object[] { dr1[LStandardTest.Columns.TestDataId], currentTestType_ID });
                        if (row != null)
                        {
                            if (LoadType != "ForResultDetail")
                                btnRegData.ImageIndex = 1;
                            else if (Utility.Int32Dbnull(row["TestDetail_ID"]) <= 0)
                                btnRegData.ImageIndex = 1;
                            else btnRegData.ImageIndex = 2;
                        }
                        else btnRegData.ImageIndex = 0;

                        btnRegData.Click += RegButtonClick;
                        btnRegData.KeyDown += btnStandardTest_KeyDown;
                        btnRegData.PreviewKeyDown += btnStandardTest_PreviewKeyDown;
                        btnRegData.KeyUp += btnStandardTest_KeyUp;
                        flpStandardTest.Controls.Add(btnRegData);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnStandardTest_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if((e.KeyCode != Keys.Down)&(e.KeyCode != Keys.Up)) return;
                var selectedButton = (Control)sender;
                
                var controlPerRow = flpStandardTest.Width/selectedButton.Width;
                var currIndex = flpStandardTest.Controls.GetChildIndex(selectedButton);
                int selectedIndex =0 ;
                if (e.KeyCode == Keys.Down)
                {
                    var controlCount = flpStandardTest.Controls.Count;
                    selectedIndex = currIndex + controlPerRow;
                    selectedIndex = selectedIndex >= controlCount - 1 ? controlCount - 1 : selectedIndex;
                   
                }
                if (e.KeyCode == Keys.Up)
                {
                    selectedIndex = currIndex - controlPerRow;
                    selectedIndex = selectedIndex < 0 ? 0 : selectedIndex;
                }
                flpStandardTest.Controls[selectedIndex].Focus();
                e.IsInputKey = true;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnStandardTest_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down)||(e.KeyCode == Keys.Up))
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void btnStandardTest_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {
                ((UIButton)sender).PerformClick();
                e.Handled = true;
            }
            
        }

        #endregion

        private void grdTestInfo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                flpStandardTest.Controls.Clear();
                flpTestGroup.Controls.Clear();
                if (grdTestInfo.CurrentRow == null)
                {
                    spcStandardTest.Panel1Collapsed = true;                 
                    return;
                }
                currentTestType_ID = Utility.Int32Dbnull(grdTestInfo.GetValue("TestType_ID"));
                LoadStandardTestType(currentTestType_ID);
                if (Utility.GetDataRow(dtTestTypeList, "TestType_ID", Utility.Int32Dbnull(grdTestInfo.GetValue("TestType_ID"))) == null)
                    uiGroupBox4.Enabled = false;
                else uiGroupBox4.Enabled = true;

                if (flpStandardTest.Controls.Count > 0)
                {
                    ResetTabKey resetTabKey = new ResetTabKey();
                    resetTabKey.ArrControl = new Control[] {grdTestInfo,flpStandardTest.Controls[0]};
                    resetTabKey.Implement();    
                }
                
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void frmTestTypeRegistration_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control)
                    switch (e.KeyCode)
                    {
                        case Keys.A:
                            PerformClickAllRegDataButton(0);
                            break;
                        case Keys.U:
                            PerformClickAllRegDataButton(1);
                            break;
                        default:
                            if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) ||
                                (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
                            {
                                string str = e.KeyCode.ToString();
                                int num = Utility.Int32Dbnull(str.Substring(str.Length - 1));
                                if (num <= flpTestGroup.Controls.Count)
                                {
                                    var btn = (UIButton) flpTestGroup.Controls[num - 1];
                                    btn.PerformClick();
                                }
                            }
                            break;
                    }
                //else if (e.Alt)
                //    switch (e.KeyCode)
                //    {
                //        case Keys.F:
                //            btnPrintBarcode.PerformClick();
                //            break;
                //    }
                else
                    switch (e.KeyCode)
                    {
                        case Keys.F9:
                            btnPrintBarcode.PerformClick();
                            break;
                        case Keys.F4:
                            btnPrint.PerformClick();
                            break;
                        case Keys.Escape:
                            Dispose();
                            break;
                       default:
                            if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9) ||
                                (e.KeyCode >= Keys.NumPad1 && e.KeyCode <= Keys.NumPad9))
                            {
                                string str = e.KeyCode.ToString();
                                int num = Utility.Int32Dbnull(str.Substring(str.Length - 1));
                                if (num <= flpTestType.Controls.Count)
                                {
                                    var btn = (UIButton) flpTestType.Controls[num - 1];
                                    btn.PerformClick();
                                }
                            }
                            break;
                    }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void PerformClickAllRegDataButton(int ImageIndex)
        {
            try
            {
                foreach (Control ctrl in flpStandardTest.Controls)
                {
                    UIButton btn = (UIButton) ctrl;
                    if (btn.ImageIndex == ImageIndex) btn.PerformClick();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //prjBussiness.frm_JCLV_InPhieuYeuCau_XETNGHIEM frm = new prjBussiness.frm_JCLV_InPhieuYeuCau_XETNGHIEM();
            //frm.p_Patient_ID = patientId;
            //frm.ShowDialog();
        }

        /// <summary>
        /// Hàm xử lý in barcode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            object value = grdTestInfo.GetValue("Barcode");
            if (string.IsNullOrEmpty(Utility.sDbnull(value).Trim()))
            {
                Utility.ShowMsg("Bạn chưa chọn barcode để in","Thông báo");
                return;
            }
            grdPatients.SetValue("Barcode",value);
            PrintbarcodeInstance();
        }
        
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //B1: Lấy về Source control
            var sourceControl = ((ContextMenuStrip) sender).SourceControl;

            // Adding a button to Menu
            Button B = new Button();
            B.Text = "My Button";

            // This will bind the event for the button
            //B.Click += new EventHandler(B_Click);
            ToolStripControlHost Ch = new ToolStripControlHost(B);

            // Adding a Month Calender
            MonthCalendar Mc = new MonthCalendar();
            ToolStripControlHost Ch1 = new ToolStripControlHost(Mc);

            //Adding a TextBox
            TextBox Tb = new TextBox();
            Tb.Text = "Add Text";
            ToolStripControlHost Ch2 = new ToolStripControlHost(Tb);

            //Adding a Check Box
            CheckBox Cb = new CheckBox();
            Cb.Text = "My Check Box";
            ToolStripControlHost Ch3 = new ToolStripControlHost(Cb);

            //Adding a Radio Buttion
            RadioButton Rb = new RadioButton();
            Rb.Text = "My Radio Button";
            ToolStripControlHost Ch4 = new ToolStripControlHost(Rb);

            contextMenuStrip1.Items.Clear();
            contextMenuStrip1.Items.Add(Ch);
            contextMenuStrip1.Items.Add(Ch1);
            contextMenuStrip1.Items.Add(Ch2);
            contextMenuStrip1.Items.Add(Ch3);
            contextMenuStrip1.Items.Add(Ch4);

            contextMenuStrip1.Refresh();
        }

        private void tsmUpdateBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (TResultDetail.CreateQuery().WHERE(TResultDetail.Columns.TestId,grdTestInfo.GetValue("Test_ID")).GetRecordCount() > 0)
                {
                    Utility.ShowMsg("Đăng ký đã có kết quả. Không được sửa barcode !");
                    return;
                }
                frmInput_Update_Barcode oForm = new frmInput_Update_Barcode();
                if (SysPara.AutoGenerateBarcode == 2)
                    oForm.vTestType_ID = Utility.Int32Dbnull(grdTestInfo.GetValue("TestType_ID"));
                oForm.txtBarcode.Text = Utility.sDbnull(grdTestInfo.GetValue("Barcode"));
                oForm.txtTestType_Name.Text = Utility.sDbnull(grdTestInfo.GetValue("TestType_Name"));
                oForm.vPatient_ID = patientId;
                oForm.ShowDialog();
                if (string.IsNullOrEmpty(oForm.txtBarcode.Text) | oForm.txtBarcode.Text == Utility.sDbnull(grdTestInfo.GetValue("Barcode")))
                {
                    return;
                }
                new Update(TTestInfo.Schema.Name).Set(TTestInfo.Columns.Barcode).EqualTo(oForm.txtBarcode.Text).
                    Where(TTestInfo.Columns.TestId).IsEqualTo(Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"))).
                    Execute();
                new Update(TRegList.Schema.Name).Set(TTestInfo.Columns.Barcode).EqualTo(oForm.txtBarcode.Text).
                    Where(TRegList.Columns.TestId).IsEqualTo(Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"))).
                    Execute();
                grdTestInfo.CurrentRow.Cells["Barcode"].Value = oForm.txtBarcode.Text;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void tsmDelTestInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                        TResultDetail.CreateQuery().WHERE(TResultDetail.Columns.TestId,
                                                          Utility.Int32Dbnull(
                                                              grdTestInfo.GetValue(TTestInfo.Columns.TestId))).
                            GetRecordCount() > 0)
                {
                    Utility.ShowMsg("Đã có kết quả. Không được xóa !");
                    return;
                }
                if (Utility.AcceptQuestion("Xóa " + grdTestInfo.GetValue(TTestTypeList.Columns.TestTypeName),
                                           "Thông báo", true))
                {
                    new Delete().From(TTestInfo.Schema.Name).Where(TTestInfo.Columns.TestId).
                        IsEqualTo(Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"))).Execute();
                    new Delete().From(TRegList.Schema.Name).Where(TRegList.Columns.TestId).
                        IsEqualTo(Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"))).Execute();
                    grdTestInfo.CurrentRow.Delete();
                    grdTestInfo.UpdateData();
                    dtTestInfo.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnSaveAssignDoctor_Click(object sender, EventArgs e)
        {
            new Update(TTestInfo.Schema.Name).Set(TTestInfo.Columns.AssignId).EqualTo(cboAssignDoctor.SelectedValue)
                .Where(TTestInfo.Columns.TestId).IsEqualTo(grdTestInfo.GetValue("Test_ID")).Execute();
            grdTestInfo.CurrentRow.Cells["AssignDoctor_Name"].Value = cboAssignDoctor.Text;
        }

        private void cboAssignDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboAssignDoctor.SelectedIndex != 0 && grdTestInfo.CurrentRow != null)
            {
                btnSaveAssignDoctor.Enabled = true;
            }
            else
            {
                btnSaveAssignDoctor.Enabled = false;
            }
        }
    }
}