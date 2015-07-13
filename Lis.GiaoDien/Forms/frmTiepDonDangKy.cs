using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Janus.Windows.EditControls;
using Janus.Windows.GridEX;
using Lis.GiaoDien;
using Lis.GiaoDien.Class;
using Lis.LoadData;
using SubSonic;
using VNS.Libs;
using LIS.DAL;
using ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment;
using ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment;
using TextAlignment = Janus.Windows.EditControls.TextAlignment;
using TriState = Janus.Windows.UI.TriState;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class frmTiepDonDangKy : Form
    {
        #region Attributes
        public Janus.Windows.GridEX.GridEX grdPatients;
        public DataTable dtResultDetail;
        public string LoadType;
        public int currentTest_ID = -1;
        public int currentTestType_ID = -1;
        private bool GroupButtonIsPressed = false;
        private DataTable dtRegList;
        public DataTable mv_ParentTable;
        private DataTable m_DC;
        private DataTable dtTestInfo;
        public DataTable dtTestTypeList;

        private Color myButtonBackColor;
        private Size myButtonSize, myImageSize;
        private Padding myPaddingSize;

        public int patientId;
        private LPatientInfo patientInfo;
        List<clsHanhChinh> listdvhclst = new List<clsHanhChinh>();
        List<clsNgheNghiep> listnghenghiep = new List<clsNgheNghiep>();
        List<clsChucVu> ListChucVu = new List<clsChucVu>();
        public delegate void PrintBarcodeDelegate();

        public PrintBarcodeDelegate PrintbarcodeInstance;

        #endregion


        #region field
        // Danh sách các control được set index
        IEnumerable<Control> controlToSetTabIndex;
        // Danh sách tất cả các control của form
        IEnumerable<Control> arrAllControl;
        // Danh sách cấu hình TabIndex
        private List<TabOrderItem> _tabOrderConfig = new List<TabOrderItem>();
        public bool Ok = false;

        public DataTable dtDepartment;
        public DataTable m_dtDepartment;

        public DataTable dtObjectType;
        private int pv_CurrentYear = DateTime.Now.Year;

        public GridEX grdList;
        public action m_iAction;

        public bool AutoLoadRegForm = false;
        public DataRow mv_DR;
        private DateTime errDate = Utility.getSysDate();

        private string xmlPath;
        private string _tabConfigFile = "TabOrderConfig.txt";
        public DataTable dtDmChung=new DataTable();
        public DataTable dtnNgheNghiep = null;
        public DataTable dtChucVu = null;

        #endregion
        public frmTiepDonDangKy()
        {
            InitializeComponent();
        }

        #region LoadForm

        /// <summary>
        /// Lấy về toàn bộ các control
        /// </summary>
        /// <param name="what"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        private IEnumerable<Control> GetAllControls(string what, Control where)
        {
            var controles = new List<Control>();
            foreach (Control c in where.Controls)
            {
                if ((c.GetType().Name == what) || (string.IsNullOrEmpty(what.Trim())))
                    controles.Add(c);
                if (c.Controls.Count > 0)
                    controles.AddRange(GetAllControls(what, c));
            }
            return controles;
        }

        private void LoadConfig()
        {
            try
            {
                xmlPath = Application.StartupPath + @"\Config\" + Name + ".xml";
                if (!File.Exists(xmlPath))
                {
                    string directoryName = Path.GetDirectoryName(xmlPath);
                    if (!Directory.Exists(directoryName))
                        Directory.CreateDirectory(directoryName);
                    File.WriteAllText(xmlPath, "");
                    return;
                }
                var doc = new XmlDocument();
                doc.Load(xmlPath);
               // chkIsBirth.Checked = doc.GetElementsByTagName(chkIsBirth.Name)[0].InnerText == "1";
                chkDOB.Checked = doc.GetElementsByTagName(chkDOB.Name)[0].InnerText == "1";
            }
            catch (Exception ex)
            {
            }
        }

        private void LoadData()
        {
            try
            {
                txtPatient_ID.Text = Utility.sDbnull(mv_DR["Patient_ID"]);
                LPatientInfo obj = LPatientInfo.FetchByID(Utility.Int32Dbnull(txtPatient_ID.Text));
                if (obj == null)
                {
                    Utility.ShowMsg("Bệnh nhân không tồn tại");
                    return;
                }
                {
                    //txtPID.Enabled = (m_iAction == action.Insert);
                    txtPID.Text = obj.Pid;

                    if (obj.YearBirth != null)
                    {
                     //   chkIsBirth.Checked = true;
                        if (obj.Dob.HasValue)
                        {
                            chkDOB.Checked = true;
                            try
                            {
                                dtpDOB.Value = Convert.ToDateTime(obj.Dob);
                            }
                            catch (Exception)
                            {
                                dtpDOB.Value = errDate;
                            }
                        }
                        else
                        {
                            chkDOB.Checked = false;
                        }
                        txtYearOfBirth.Value = obj.YearBirth;
                    }
                    else
                    {
                        obj.Dob = DateTime.Now;
                       
                    }

                    txtPName.Text = obj.PatientName;
                    txtInsuranceNum.Text = obj.InsuranceNum;
                    txtAddress.Text = obj.Address;
                    txtDiagnostic.Text = obj.Diagnostic;
                    txtCMT.Text = obj.IdentifyNum;
                    txtRoom.Text = obj.Room;
                    txtBed.Text = obj.Bed;
                    txtCanLamSangID.Text = obj.CanLamSangId;
                    txtNgheNghiep.Text = obj.NgheNghiep;
                    txtChucVu.Text = obj.ChucVu;
                    if ((obj.Dateupdate != null))
                    {
                        try
                        {
                            dtmDate.Value = Convert.ToDateTime(obj.Dateupdate);
                        }
                        catch (Exception)
                        {
                            dtmDate.Value = errDate;
                        }

                    }

                    if (obj.Sex == null)
                    {
                        cboSex.SelectedIndex = 1;
                    }
                    else
                    {
                        cboSex.SelectedValue = Utility.Int16Dbnull(obj.Sex, 0);
                    }

                    cboDepartment.SelectedIndex = Utility.GetSelectedIndex(cboDepartment,
                                                                           Utility.sDbnull(obj.DepartmentID, -1));
                    //cboDepartment.SelectedValue = Utility.Int32Dbnull(obj.DepartmentID,-1);
                    cboObject.SelectedValue = Utility.Int32Dbnull(obj.ObjectType, 0);
                 //   cboHosStatus.SelectedIndex = Utility.Int16Dbnull(obj.HosStatus, 0);
                   // cboLot.SelectedValue = Utility.Int32Dbnull(obj.LotID);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }


        private void LoadTabOrderConfig()
        {
            try
            {
                // Kiểm tra file dữ liệu xem tồn tại chưa. Nếu chưa tồn tại thì tạo mới.
                if (!File.Exists(_tabConfigFile))
                {
                    // Tạo mới biến cấu hình từ các control được set Index
                    foreach (var control in controlToSetTabIndex)
                        _tabOrderConfig.Add(new TabOrderItem
                        {
                            ControlName = control.Name,
                            ControlTag = (control.Tag ?? "").ToString(),
                            ControlTabStop = control.TabStop,// ?? true,
                            ControlTabIndex = control.TabIndex
                        });
                    // Lưu lại file cấu hình
                    SaveTabOrderConfig();
                }
                // Nếu tồn tại thì nạp file lên
                else
                {
                    var strConfig = File.ReadAllLines(_tabConfigFile);
                    foreach (string s in strConfig)
                    {
                        _tabOrderConfig.Add(new TabOrderItem(s));
                    }
                }
                _tabOrderConfig = _tabOrderConfig.OrderBy(o => o.ControlTabIndex).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveTabOrderConfig()
        {
            try
            {
                var strConfig = (from item in _tabOrderConfig
                                 select item.ToString()).ToArray();
                File.WriteAllLines(_tabConfigFile, strConfig);
            }
            catch (Exception)
            {
                Utility.ShowMsg("Lỗi khi lưu danh sách TabOrder");
            }
        }
      
        private void LoadSexCombo()
        {
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Sex_Name", typeof(string));
            DataRow dr = dt.NewRow();
            dr["ID"] = -1;
            dr["Sex_Name"] = "--- Chọn ---";
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

        private void frmTestTypeRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                arrAllControl = GetAllControls("", this);

                LoadSexCombo();
                // Lấy về danh sách các control được set index
                var types = new List<Type>
                            {
                                typeof (TextBox), 
                                typeof (CheckBox), 
                                typeof (Janus.Windows.CalendarCombo.CalendarCombo),
                                typeof (Janus.Windows.GridEX.EditControls.EditBox),
                                typeof (Janus.Windows.GridEX.EditControls.NumericEditBox),
                                typeof (Janus.Windows.EditControls.UICheckBox),
                                typeof (Janus.Windows.EditControls.UIButton),
                                typeof (ComboBox),typeof(BetterTextbox)

                            };
                controlToSetTabIndex = arrAllControl.Where(
                    control =>
                    types.Contains(control.GetType()) && control.Visible &&
                    !string.IsNullOrEmpty(control.Name.Trim()));
                // Gán sự kiện keyup cho tất cả control
                //foreach (Control control in controlToSetTabIndex)
                //{
                //    //control.KeyDown += new KeyEventHandler(ControlToSetTabIndex_KeyUp);
                //    //control.KeyDown +=new KeyEventHandler(control_KeyDown);
                //    //control.KeyPress+= control_KeyPress;
                //}
                LoadConfig();
                LoadTabOrderConfig();
                ActiveControl = (from control in arrAllControl
                                 where (control.Name == (from x in _tabOrderConfig
                                                         where x.ControlTabStop
                                                         select x.ControlName).FirstOrDefault())
                                 select control).FirstOrDefault();
                myButtonSize = new Size(115, 35);
                myImageSize = new Size(24, 24);
                myPaddingSize = new Padding(1);
                myButtonBackColor = Color.WhiteSmoke;
                //
                if (m_iAction == action.Insert || m_iAction == action.Update||m_iAction == action.Normal)
                {
                    DmHc();
                    m_dtDepartment = dtDepartment.Copy();
                    DataBinding.BindData(cboDepartment, m_dtDepartment, LDepartment.Columns.Id,
                        LDepartment.Columns.SName);

                    try
                    {
                        cboDepartment.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                    }
                    DataBinding.BindData(cboObject, dtObjectType, "ID", "sName");
                    txtYearOfBirth.Value = pv_CurrentYear;
                    switch (m_iAction)
                    {
                        case action.Insert:
                            txtPID.Text = Utility.GetYYYYMMDDHHMMSS(Utility.getSysDate());
                            LoadAssignDoctor();
                            break;
                        case action.Update:
                            LoadData();

                            if (AutoLoadRegForm && Ok)
                            {
                                grboxLoaixn.Enabled = false;
                                splitContainer1.Enabled = false;
                            }
                            
                            break;
                        case action.Normal:
                            btnSave.Enabled = false;
                            LoadData();
                            LoadTestTypeButton();
                            LoadRegisteredTestType();
                            LoadAssignDoctor();
                            LoadPatientInfo();
                            break;
                    }
                  

                }
                // Lấy về tất cả các control của form
              
                if (LoadType == "ForResultDetail")
                {
                  //btnPrintBarcode.Visible = false;
                    //btnPrint.Visible = false;
                    LoadStandardTestType(currentTestType_ID);
                    return;
                }
                LaydmChucVu();
                LaydmNgheNghiep();


            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                Dispose();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                // tabindex lớn nhất của control có tabstop
                int maxTab = (from i in _tabOrderConfig
                              where i.ControlTabStop
                              select i.ControlTabIndex).Max();
                // Lấy về current TabIndx
                int currTabIdx = (from i in _tabOrderConfig
                                  where i.ControlName == ActiveControl.Name
                                  select i.ControlTabIndex).FirstOrDefault();


                // Tìm ra i là thứ tự trong danh sách của control được chọn
                // nếu không phải là control cuối cùng
                Control nextControl = currTabIdx < maxTab
                                          ? (from control in arrAllControl
                                             where (control.Name == (from x in _tabOrderConfig
                                                                     where
                                                                         x.ControlTabStop &&
                                                                         (x.ControlTabIndex > currTabIdx)
                                                                     select x.ControlName).FirstOrDefault())
                                             select control).FirstOrDefault()
                                          : (from control in arrAllControl
                                             where (control.Name == (from x in _tabOrderConfig
                                                                     where x.ControlTabStop
                                                                     select x.ControlName).FirstOrDefault())
                                             select control).FirstOrDefault();

                // Setfocus
                if (nextControl != null)
                    nextControl.Focus();
                return true;
            }
            return false;
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
            txtPName.Text = patientInfo.PatientName;
            txtAge.Text = (DateTime.Now.Year - patientInfo.YearBirth).ToString().Trim();
            cboSex.Text = patientInfo.Sex == true ? "Nam" : "Nữ";
            txtAddress.Text = Utility.sDbnull(patientInfo.Address);
            txtCMT.Text = Utility.sDbnull(patientInfo.IdentifyNum);
            txtDiagnostic.Text = Utility.sDbnull(patientInfo.Diagnostic);
            txtInsuranceNum.Text = Utility.sDbnull(patientInfo.InsuranceNum);
            txtRoom.Text = Utility.sDbnull(patientInfo.Room);
            txtBed.Text = Utility.sDbnull(patientInfo.Bed);
            txtYearOfBirth.Text = Utility.sDbnull(patientInfo.YearBirth).Trim();
            cboDepartment.SelectedValue = Utility.Int16Dbnull(patientInfo.DepartmentID);
            cboObject.SelectedValue = Utility.Int16Dbnull(patientInfo.ObjectType);

            // dtpDOB.Value =Convert.ToDateTime(patientInfo.Dob);
        }

        private void LoadRegisteredTestType()
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

        private void LoadTestTypeButton()
        {
            dtTestTypeList = new Select().From(TTestTypeList.Schema.Name).OrderAsc(TTestTypeList.Columns.IntOrder).
                ExecuteDataSet().Tables[0];
            int idx = 0;
            var btnTestTypeSize = new Size(131, 35);
            var btnTestTypeImageSize = new Size(24, 24);
            var btnTestTypePadding = new Padding(25, 25, 25, 25);
            Color btnTestTypeBackColor = Color.Black;
               Color fontcolor = Color.ForestGreen;
            foreach (DataRow dr in dtTestTypeList.Rows)
            {
                idx += 1;
                var obj = new UIButton();
                obj.Size = btnTestTypeSize;
                obj.ImageSize = btnTestTypeImageSize;
                obj.Padding = btnTestTypePadding;
                obj.BackColor = btnTestTypeBackColor;
                obj.ForeColor = fontcolor;
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
                LPatientInfo lPatientInfo =  new Select().From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.PatientId).IsEqualTo(patientId).ExecuteSingle<LPatientInfo>();
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
                //grdTestInfo.SelectionChanged -= grdTestInfo_SelectionChanged;
                //dtTestInfo.AcceptChanges();
                //grdTestInfo.SelectionChanged += grdTestInfo_SelectionChanged;
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
                            else if (Utility.Int32Dbnull(row["TestRegDetail_ID"]) <= 0)
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
       
        private void CreateTable()
        {
            if (m_DC == null || m_DC.Columns.Count <= 0)
            {
                m_DC = new DataTable();
                //m_DC.Columns.AddRange(new DataColumn[] { new DataColumn("ShortCut", typeof(string)), new DataColumn("Value", typeof(string)) });
                m_DC.Columns.AddRange(new[]
                                          {
                                              new DataColumn("ShortCutXP", typeof (string)),
                                              new DataColumn("ShortCutQH", typeof (string)),
                                              new DataColumn("ShortCutTP", typeof (string)),
                                              new DataColumn("Value", typeof (string))
                                          });
            }
        }
        
        private void DmHc()
        {
            try
            {
                DataTable m_dtDataThanhPho = PreloadedLists.dtdvhc;
                //AutoUpdate(m_dtDataThanhPho);
                //AutoAdd_Khong_xac_dinh();
                CreateTable();
                if (m_DC == null) return;
                if (!m_DC.Columns.Contains("ShortCut")) m_DC.Columns.Add(new DataColumn("ShortCut", typeof(string)));
                foreach (DataRow dr in m_dtDataThanhPho.Select("loai_diachinh=0"))
                {
                    DataRow drShortcut = m_DC.NewRow();
                    string _Value = "";
                    string realName = "";

                    DataRow[] arrQuanHuyen =
                        m_dtDataThanhPho.Select("ma_cha='" + Utility.sDbnull(dr[DmucDiachinh.Columns.MaDiachinh], "") +
                                                "'");
                    foreach (DataRow drQH in arrQuanHuyen)
                    {
                        DataRow[] arrXaPhuong =
                            m_dtDataThanhPho.Select("ma_cha='" +
                                                    Utility.sDbnull(drQH[DmucDiachinh.Columns.MaDiachinh], "") + "'");
                        foreach (DataRow drXP in arrXaPhuong)
                        {
                            drShortcut = m_DC.NewRow();
                            realName = "";
                            _Value = drXP[DmucDiachinh.Columns.TenDiachinh] + ", ";

                            drShortcut["ShortCutXP"] = drXP["mota_them"].ToString().Trim();

                            #region addShortcut

                            _Value += drQH[DmucDiachinh.Columns.TenDiachinh] + ", ";
                            drShortcut["ShortCutQH"] = drQH["mota_them"].ToString().Trim();

                            _Value += dr[DmucDiachinh.Columns.TenDiachinh].ToString();
                            drShortcut["ShortCutTP"] = dr["mota_them"].ToString().Trim();
                            //Ghép chuỗi

                            drShortcut["Value"] = _Value;
                            m_DC.Rows.Add(drShortcut);

                            #endregion
                        }

                        if (arrXaPhuong.Length <= 0)
                        {
                            #region addShortcut

                            drShortcut = m_DC.NewRow();
                            realName = "";
                            drShortcut["ShortCutXP"] = "kx";
                            _Value = drQH[DmucDiachinh.Columns.TenDiachinh] + ", ";
                            drShortcut["ShortCutQH"] = drQH["mota_them"].ToString().Trim();

                            _Value += dr[DmucDiachinh.Columns.TenDiachinh].ToString();
                            drShortcut["ShortCutTP"] = dr["mota_them"].ToString().Trim();

                            drShortcut["Value"] = _Value;
                            m_DC.Rows.Add(drShortcut);

                            #endregion
                        }
                    }
                    if (arrQuanHuyen.Length <= 0)
                    {
                        #region addShortcut

                        drShortcut = m_DC.NewRow();
                        realName = "";
                        drShortcut["ShortCutXP"] = "kx";
                        drShortcut["ShortCutQH"] = "kx";
                        drShortcut["ShortCutTP"] = dr["mota_them"].ToString().Trim();
                        _Value = dr[DmucDiachinh.Columns.TenDiachinh].ToString();
                        drShortcut["Value"] = _Value;
                        m_DC.Rows.Add(drShortcut);

                        #endregion
                    }
                }
            }
            catch
            {
            }
            finally
            {
                //txtphuongxa.AutoCompleteMode = AutoCompleteMode.Suggest;
                //txtphuongxa.AutoCompleteSource = AutoCompleteSource.CustomSource;
                var source = new List<string>();
                var query = from p in m_DC.AsEnumerable()
                            select new clsHanhChinh()
                            {
                                //TenTenDonVi=  p.Field<string>("ShortCutTP").ToString() + p.Field<string>("ShortCutQH").ToString() 
                                //+p.Field<string>("ShortCutXP").ToString(), //+ "@" + p.Field<string>("Value").ToString() ,
                                //   //+ "@" + p.Field<string>("Value").ToString(),
                                TenTenDonVi = p.Field<string>("Value").ToString(),
                                //+ "@" + p.Field<string>("Value").ToString(),
                                IdTenDonVi = ""
                            };
                listdvhclst = query.ToList();
                txtQuanHuyenTinh.donvihc(listdvhclst);
            }
        }


        #endregion
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

        void LaydmNgheNghiep()
        {
            dtnNgheNghiep =
                new Select().From(DmucChung.Schema.Name)
                    .Where(DmucChung.Columns.Loai)
                    .IsEqualTo("NGHE_NGHIEP")
                    .ExecuteDataSet()
                    .Tables[0];
            var query = from p in dtnNgheNghiep.AsEnumerable()
                        select new clsNgheNghiep()
                        {
                            TenNgheNghiep = p.Field<string>("Ten").ToString()
                        };
            listnghenghiep = query.ToList();
            txtNgheNghiep.SentDsNgheNghiep(listnghenghiep);
        }

         void LaydmChucVu()
         {
             dtChucVu =
                 new Select().From(DmucChung.Schema.Name)
                     .Where(DmucChung.Columns.Loai)
                     .IsEqualTo("LOAINHANVIEN")
                     .ExecuteDataSet()
                     .Tables[0];
             var query = from p in dtChucVu.AsEnumerable()
                         select new clsChucVu()
                         {
                             TenChucVu = p.Field<string>("Ten").ToString()
                         };
             ListChucVu = query.ToList();
             txtChucVu.ChucVu(ListChucVu);
         }
        
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
                        case Keys.S:
                            btnSave.PerformClick();
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
                            cmdPrintbarcode.PerformClick();
                            break;
                        case Keys.F4:
                            cmd_InPhieu_ChiDinh.PerformClick();
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
        
        /// <summary>
        /// Hàm xử lý in barcode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
     
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
        
        private void txtQuanHuyenTinh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQuanHuyenTinh.TextLength > 0)
                {
                    txtAddress.Text = txtSoNha.Text + ", " + txtQuanHuyenTinh.Text;
                }

            }
            catch (Exception)
            {
            }
        }

        private void txtSoNha_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSoNha.TextLength > 0)
                {
                    txtAddress.Text = txtSoNha.Text + ", " + txtQuanHuyenTinh.Text; ;
                }

            }
            catch (Exception)
            {
            }
        }

        private void InsertIntoDataTableAndDataGrid()
        {
            try
            {
                DataRow dr = null;
                Utility.AddColumToDataTable(ref mv_ParentTable, "Patient_ID", typeof(int));
                Utility.AddColumToDataTable(ref mv_ParentTable, "PID", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "Patient_Name", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "Age", typeof(int));
                Utility.AddColumToDataTable(ref mv_ParentTable, "Year_Birth", typeof(int));
                Utility.AddColumToDataTable(ref mv_ParentTable, "DOB", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "sexName", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "Sex", typeof(int));
                Utility.AddColumToDataTable(ref mv_ParentTable, "ObjectType", typeof(int));
                Utility.AddColumToDataTable(ref mv_ParentTable, "ObjectType_Name", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "Diagnostic", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "IdentifyNum", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "Insurance_Num", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "Address", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "Department_Name", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "DepartmentID", typeof(int));
                Utility.AddColumToDataTable(ref mv_ParentTable, "Room", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "DateUpdate", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "Bed", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "LotID", typeof(int));
                Utility.AddColumToDataTable(ref mv_ParentTable, "CanLamSang_ID", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "User_ID", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "ChucVu", typeof(string));
                Utility.AddColumToDataTable(ref mv_ParentTable, "NgheNghiep", typeof(string));
                dr = mv_ParentTable.NewRow();
                if (mv_ParentTable.Columns.Contains("Barcode"))
                {
                    dr["Barcode"] = "";
                }
                try
                {
                    dr["Patient_ID"] =Utility.sDbnull(patientId);
                    dr["PID"] = txtPID.Text;
                    dr["Patient_Name"] = txtPName.Text;

                    if (chkDOB.Checked)
                    {
                        dr["Age"] = Convert.ToInt32(txtAge.Text);
                        dr["Year_Birth"] = Convert.ToInt32(txtYearOfBirth.Text);
                        if (chkDOB.Checked)
                        {
                            dr[LPatientInfo.Columns.Dob] = dtpDOB.Value.Date;
                        }
                        else
                        {
                            dr[LPatientInfo.Columns.Dob] = DBNull.Value;
                        }
                    }
                    else
                    {
                        dr["Age"] = DBNull.Value;
                        dr["Year_Birth"] = DBNull.Value;
                    }
                    if (cboSex.SelectedValue == DBNull.Value)
                    {
                        dr["Sex"] = DBNull.Value;
                        dr["sexName"] = "";
                    }
                    else
                    {
                        dr["Sex"] = Convert.ToInt32(cboSex.SelectedValue);
                        dr["sexName"] = cboSex.Text;
                    }

                    dr["ObjectType"] = Utility.Int32Dbnull(cboObject.SelectedValue, -1);
                    dr["ObjectType_Name"] = Utility.sDbnull(cboObject.Text, "");
                    dr["Diagnostic"] = txtDiagnostic.Text;
                    dr["IdentifyNum"] = txtCMT.Text;
                    dr["Insurance_Num"] = Utility.sDbnull(txtInsuranceNum.Text);
                    dr["Address"] = txtAddress.Text;
                    dr["Department_Name"] = (Utility.Int32Dbnull(cboDepartment.SelectedValue) < 1 ? "" : cboDepartment.Text);
                    int departmentId = Utility.Int32Dbnull(cboDepartment.SelectedValue, -1);
                    dr["DepartmentID"] = departmentId;
                    dr["Room"] = txtRoom.Text.Trim();
                    dr["Bed"] = txtBed.Text.Trim();
                    dr["DateUpdate"] = dtmDate.Text;
                    dr["NgheNghiep"] = txtNgheNghiep.Text;
                    dr["ChucVu"] = txtChucVu.Text;
                  //  dr["LotID"] = Utility.Int32Dbnull(cboLot.SelectedValue, -1);
                    dr["CanLamSang_ID"] = txtCanLamSangID.Text;
                    dr["User_ID"] = Utility.sDbnull(globalVariables.UserName);
                }
                catch (Exception ex)
                {
                    Utility.ShowMsg(ex.Message);
                }


                PatientInfo2Datarow(ref dr);
                mv_ParentTable.Rows.InsertAt(dr, 0);
                grdList.MoveFirst();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool bCheckData()
        {
            if (string.IsNullOrEmpty(txtPID.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập Barcode", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPName.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập tên bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPName.Focus();
                return false;
            }
            if (cboSex.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn giới tính bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboObject.Items.Count <= 0)
            {
                Utility.ShowMsg("Bạn phải nhập danh mục loại đối tượng dịch vụ");
                return false;
            }
            if (chkDOB.Checked)
            {
                if (chkDOB.Checked)
                {
                    if (Utility.CompareToDate(dtpDOB.Value, Utility.getSysDate().Date))
                    {
                        Utility.ShowMsg("Ngày sinh không được lớn hơn ngày hiện tại,Yêu cầu nhập lại", "Thông báo", MessageBoxIcon.Warning);
                        dtpDOB.Focus();
                        return false;
                    }
                    //Return False
                }
                else
                {
                    if (Utility.Int32Dbnull(txtYearOfBirth.Text, -1) > Utility.getSysDate().Year)
                    {
                        Utility.ShowMsg("Năm sinh của bệnh nhân không lớn hơn năm hiện tại", "Thông báo", MessageBoxIcon.Warning);
                        txtYearOfBirth.Focus();
                        return false;
                    }
                    if ((Utility.Int32Dbnull(txtYearOfBirth.Text, -1)) <= 0)
                    {
                        Utility.ShowMsg("Năm sinh của bệnh nhân không thể lưu số âm hoặc =0", "Thông báo", MessageBoxIcon.Warning);
                        txtYearOfBirth.Focus();
                        return false;
                    }
                    if (Utility.Int32Dbnull(txtAge.Text, -1) < 0)
                    {
                        Utility.ShowMsg("Tuổi của bệnh nhân không thể lưu số âm", "Thông báo", MessageBoxIcon.Warning);
                        txtAge.Focus();
                        return false;
                    }

                }
            }

            return true;
        }

        private bool AddPatient()
        {
            try
            {
                LPatientInfo obj = new LPatientInfo();
                obj.Pid = txtPID.Text;
                obj.PatientName = txtPName.Text;
                obj.Address = txtAddress.Text;
                if (chkDOB.Checked)
                {
                    if (chkDOB.Checked)
                    {
                        obj.Dob = dtpDOB.Value;
                        obj.YearBirth = dtpDOB.Value.Year;
                    }
                    else
                    {
                        obj.YearBirth = Utility.Int32Dbnull(txtYearOfBirth.Text);
                    }
                }

              //  obj.HosStatus = cboHosStatus.SelectedIndex;
                //obj.LotID = Utility.Int32Dbnull(cboLot.SelectedValue, -1);
                obj.Sex = DBNull.Value == cboSex.SelectedValue
                    ? (bool?)null
                    : Utility.Int16Dbnull(cboSex.SelectedValue) == 1;

                obj.Diagnostic = txtDiagnostic.Text;
                obj.IdentifyNum = txtCMT.Text;
                obj.InsuranceNum = txtInsuranceNum.Text;
                obj.DepartmentID = Utility.Int16Dbnull(cboDepartment.SelectedValue);
                obj.CanLamSangId = txtCanLamSangID.Text;
                obj.Room = txtRoom.Text;
                obj.Bed = txtBed.Text;
                obj.Dateupdate = dtmDate.Value;
                obj.ObjectType = Convert.ToInt32(cboObject.SelectedValue);
                obj.UserId = Utility.sDbnull(globalVariables.UserName);
                obj.ChucVu = txtChucVu.Text;
                obj.NgheNghiep = txtNgheNghiep.Text;
                obj.IsNew = true;
                obj.Save();
                patientId= Utility.Int32Dbnull(obj.PatientId);
                return true;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                return false;
            }
        }

        private bool EditPatientInfo()
        {
            try
            {
                new Update(LPatientInfo.Schema.TableName).Set(LPatientInfo.Columns.PatientName).EqualTo(txtPName.Text).
                    Set(LPatientInfo.Columns.Address).EqualTo(txtAddress.Text).
                    Set(LPatientInfo.Columns.InsuranceNum).EqualTo(txtInsuranceNum.Text).
                    Set(LPatientInfo.Columns.Sex).EqualTo(DBNull.Value == cboSex.SelectedValue
                        ? (bool?)null
                        : Utility.Int16Dbnull(cboSex.SelectedValue) == 1).
                    Set(LPatientInfo.Columns.ObjectType).EqualTo(cboObject.SelectedValue).
                    Set(LPatientInfo.Columns.Diagnostic).EqualTo(txtDiagnostic.Text).
                    Set(LPatientInfo.Columns.DepartmentID).EqualTo(cboDepartment.SelectedValue).
                    Set(LPatientInfo.Columns.Room).EqualTo(txtRoom.Text).
                    Set(LPatientInfo.Columns.Bed).EqualTo(txtBed.Text).
                    Set(LPatientInfo.Columns.IdentifyNum).EqualTo(txtCMT.Text).
                    //Set(LPatientInfo.Columns.LotID).EqualTo(Convert.ToInt32(cboLot.SelectedValue)).
                    //Set(LPatientInfo.Columns.HosStatus).EqualTo(Utility.Int32Dbnull(cboHosStatus.SelectedIndex)).
                    Set(LPatientInfo.Columns.Dob).EqualTo(chkDOB.Checked
                                                              ? (chkDOB.Checked ? dtpDOB.Value.Date : SqlDateTime.Null)
                                                              : SqlDateTime.Null)
                                                              .Set(LPatientInfo.Columns.YearBirth).EqualTo(chkDOB.Checked
                                                                    ? Utility.Int32Dbnull(txtYearOfBirth.Text)
                                                                    : SqlInt32.Null).
                    Set(LPatientInfo.Columns.Dateupdate).EqualTo(dtmDate.Value)
                    .Set(LPatientInfo.Columns.ChucVu).EqualTo(txtChucVu.Text)
                    .Set(LPatientInfo.Columns.NgheNghiep).EqualTo(txtNgheNghiep.Text)
                    .Set(LPatientInfo.Columns.CanLamSangId).EqualTo(txtCanLamSangID.Text).
                    Set(LPatientInfo.Columns.UserId).EqualTo(Utility.sDbnull(globalVariables.UserName)).
                        Where(LPatientInfo.Columns.PatientId).IsEqualTo(Utility.Int32Dbnull(txtPatient_ID.Text)).Execute();

                if ((mv_DR != null))
                {
                    PatientInfo2Datarow(ref mv_DR);
                    mv_DR.AcceptChanges();
                }
                return true;
              
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                return false;
            }
        }

        private void PatientInfo2Datarow(ref DataRow dr)
        {
            try
            {
                dr["Patient_ID"] = patientId;
                dr["PID"] = txtPID.Text;
                dr["Patient_Name"] = txtPName.Text;

                if (chkDOB.Checked)
                {
                    dr["Age"] = Convert.ToInt32(txtAge.Text);
                    dr["Year_Birth"] = Convert.ToInt32(txtYearOfBirth.Text);
                    if (chkDOB.Checked)
                    {
                        dr[LPatientInfo.Columns.Dob] = dtpDOB.Value.Date;
                    }
                    else
                    {
                        dr[LPatientInfo.Columns.Dob] = DBNull.Value;
                    }
                }
                else
                {
                    dr["Age"] = DBNull.Value;
                    dr["Year_Birth"] = DBNull.Value;
                }
                if (cboSex.SelectedValue == DBNull.Value)
                {
                    dr["Sex"] = DBNull.Value;
                    dr["sexName"] = "";
                }
                else
                {
                    dr["Sex"] = Convert.ToInt32(cboSex.SelectedValue);
                    dr["sexName"] = cboSex.Text;
                }

                dr["ObjectType"] = Utility.Int32Dbnull(cboObject.SelectedValue, -1);
                dr["ObjectType_Name"] = Utility.sDbnull(cboObject.Text, "");
                dr["Diagnostic"] = txtDiagnostic.Text;
                dr["IdentifyNum"] = txtCMT.Text;
                dr["Insurance_Num"] = Utility.sDbnull(txtInsuranceNum.Text);
                dr["Address"] = txtAddress.Text;
                dr["Department_Name"] = (Utility.Int32Dbnull(cboDepartment.SelectedValue) < 1 ? "" : cboDepartment.Text);
                int departmentId = Utility.Int32Dbnull(cboDepartment.SelectedValue, -1);
                dr["DepartmentID"] = departmentId;
                dr["Room"] = txtRoom.Text.Trim();
                dr["Bed"] = txtBed.Text.Trim();
                dr["NgheNghiep"] = txtNgheNghiep.Text.Trim();
                dr["ChucVu"] = txtChucVu.Text.Trim();
                dr["DateUpdate"] = dtmDate.Text;
             //   dr["LotID"] = Utility.Int32Dbnull(cboLot.SelectedValue, -1);
                dr["CanLamSang_ID"] = txtCanLamSangID.Text;
                dr["User_ID"] = Utility.sDbnull(globalVariables.UserName);
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AutoLoadRegForm = true;
            RegNewPatient();
        }

        private void SaveConfig()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                XmlNode node = doc.CreateElement(this.Name);

                XmlNode node1 = doc.CreateElement(chkDOB.Name);
                node1.InnerText = chkDOB.Checked ? "1" : "0";
                node.AppendChild(node1);

                XmlNode node2 = doc.CreateElement(chkDOB.Name);
                node2.InnerText = chkDOB.Checked ? "1" : "0";
                node.AppendChild(node2);

                doc.AppendChild(node);
                doc.Save(xmlPath);
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void RegNewPatient()
        {
            try
            {
                if (!bCheckData())
                    return;

               SaveConfig();
                switch (m_iAction)
                {
                    case action.Insert:
                        //Add Patient
                        if (AddPatient())
                        {
                            //mv_bCancel = False
                            InsertIntoDataTableAndDataGrid();
                            if (AutoLoadRegForm)
                            {
                                LoadTestTypeButton();
                                LoadRegisteredTestType();
                                LoadAssignDoctor();
                                lblMessage.Text = "Thêm mới bệnh nhân thành công!";
                                btnSave.Enabled = false;
                                // Close();
                            }
                            else
                            {
                                txtPatient_ID.Text = "-1";
                                txtPID.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
                                txtPName.Clear();
                                txtBed.Clear();
                                txtRoom.Clear();
                                txtInsuranceNum.Clear();
                                txtCMT.Clear();
                                txtDiagnostic.Clear();
                                txtAddress.Clear();
                                ActiveControl = txtPName;
                                AutoLoadRegForm = false;
                            }
                        }
                        break;
                    case action.Update:
                        //Edit patient info
                        if (EditPatientInfo())
                        {
                            lblMessage.Text = "Cập nhật bệnh nhân thành công!";
                            this.Close();
                        }
                        break;
                    case action.Normal:
                        //Edit patient info
                        if (EditPatientInfo())
                        {
                            lblMessage.Text = "Cập nhật bệnh nhân thành công!";
                            this.Close();
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi khi lưu bệnh nhân", "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void cmdPrintbarcode_Click(object sender, EventArgs e)
        {
            object value = grdTestInfo.GetValue("Barcode");
            if (string.IsNullOrEmpty(Utility.sDbnull(value).Trim()))
            {
                Utility.ShowMsg("Bạn chưa chọn barcode để in", "Thông báo");
                return;
            }
            grdPatients.SetValue("Barcode", value);
            PrintbarcodeInstance();
        }

        private void cmdUpdatePatient_Click(object sender, EventArgs e)
        {
          //  AutoLoadRegForm = true;
            RegNewPatient();
        }

        private void cboDepartment_SelectedValueChanged(object sender, EventArgs e)
        {

            try
            {
                txtDepartment.TextChanged -= txtDepartment_TextChanged;
                var query = from loz in m_dtDepartment.AsEnumerable()
                            where
                                Utility.sDbnull(loz[LDepartment.Columns.Id]) ==
                                Utility.sDbnull(cboDepartment.SelectedValue)
                            select loz[LDepartment.Columns.SDesc];

                if (query.Count() > 0)
                {
                    txtDepartment.Text = Utility.sDbnull(query.FirstOrDefault());
                }


            }
            catch (Exception exception)
            {
                throw exception;
            }
            txtDepartment.TextChanged += txtDepartment_TextChanged;
        }

        private void txtDepartment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.SelectedValueChanged -= cboDepartment_SelectedValueChanged;
                string rowFilter = "1=1";
                if (!string.IsNullOrEmpty(txtDepartment.Text))
                {
                    rowFilter = string.Format("{0}='{1}'", LDepartment.Columns.SDesc, txtDepartment.Text);
                }
                m_dtDepartment.DefaultView.RowFilter = rowFilter;
                m_dtDepartment.AcceptChanges();
                cboDepartment.SelectedValueChanged += cboDepartment_SelectedValueChanged;
            }
            catch (Exception)
            {
            }
        }

        private void txtYearOfBirth_TextChanged(object sender, EventArgs e)
        {
            txtAge.Value = pv_CurrentYear - Utility.Int32Dbnull(txtYearOfBirth.Value);
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            txtYearOfBirth.Value = pv_CurrentYear - Utility.Int32Dbnull(txtAge.Value);
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            txtYearOfBirth.Value = dtpDOB.Value.Year;
        }

        private void cmd_InPhieu_ChiDinh_Click(object sender, EventArgs e)
        {

        }

        private void cmdEscape_Click(object sender, EventArgs e)
        {
            Dispose(true);
        }

        private void btnConfigTabOrder_Click(object sender, EventArgs e)
        {
            var f = new frmQuickTabConfig(_tabOrderConfig);
            f.ShowDialog();
            SaveTabOrderConfig();
            ActiveControl = (from control in arrAllControl
                             where (control.Name == (from x in _tabOrderConfig
                                                     where x.ControlTabStop
                                                     select x.ControlName).FirstOrDefault())
                             select control).FirstOrDefault();
        }
    }
}