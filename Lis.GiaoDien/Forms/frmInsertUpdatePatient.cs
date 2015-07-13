using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using VNS.Libs;
using SubSonic;

using LIS.DAL;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class frmInsertUpdatePatient : Form
    {
        // Danh sách các control được set index
        IEnumerable<Control> controlToSetTabIndex;
        // Danh sách tất cả các control của form
        IEnumerable<Control> arrAllControl;
        // Danh sách cấu hình TabIndex
        private List<TabOrderItem> _tabOrderConfig = new List<TabOrderItem>();
      
     
        public DataTable dtDepartment;
        public DataTable m_dtDepartment;

        public DataTable dtObjectType;
        private int pv_CurrentYear = DateTime.Now.Year;

        public DataTable mv_ParentTable;
        public GridEX grdList;
        public action m_iAction;

        public bool AutoLoadRegForm = false;
        public DataRow mv_DR;
        private DateTime errDate = Utility.getSysDate();

        private string xmlPath;
        private string _tabConfigFile = "frmInsertUpdatePatient_TabOrderConfig.txt";

        public frmInsertUpdatePatient()
        {
            InitializeComponent();
        }

        private void frmInsertUpdatePatient_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy về tất cả các control của form
                arrAllControl = GetAllControls("", this);

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
                                typeof (ComboBox)

                            };
                controlToSetTabIndex = arrAllControl.Where(
                    control =>
                    types.Contains(control.GetType()) && control.Visible &&
                    !string.IsNullOrEmpty(control.Name.Trim()));
                // Gán sự kiện keyup cho tất cả control
                foreach (Control control in controlToSetTabIndex)
                {
                    //control.KeyDown += new KeyEventHandler(ControlToSetTabIndex_KeyUp);
                    //control.KeyDown +=new KeyEventHandler(control_KeyDown);
                    //control.KeyPress+= control_KeyPress;
                }

                LoadConfig();
                LoadTabOrderConfig();
                cboHosStatus.SelectedIndex = 0;
                FillSexCombobox();
                m_dtDepartment = dtDepartment.Copy();
                DataBinding.BindData(cboDepartment, m_dtDepartment, LDepartment.Columns.Id, LDepartment.Columns.SName);
               
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
                        break;
                    case action.Update:
                        LoadData();
                        break;
                }

                ActiveControl = (from control in arrAllControl
                                 where (control.Name == (from x in _tabOrderConfig
                                                         where x.ControlTabStop
                                                         select x.ControlName).FirstOrDefault())
                                 select control).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(string.Format("Lỗi trong quá trình khởi tạo {0}", ex.ToString()));
                this.Dispose();
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

        /// <summary>
        /// Nạp thông tin cấu hình tab và đặt control mặc định
        /// </summary>
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
                File.WriteAllLines(_tabConfigFile,strConfig);
            }
            catch (Exception)
            {
                Utility.ShowMsg("Lỗi khi lưu danh sách TabOrder");
            }
        }

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
                chkIsBirth.Checked = doc.GetElementsByTagName(chkIsBirth.Name)[0].InnerText == "1";
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
                        chkIsBirth.Checked = true;
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
                        chkIsBirth.Checked = false;
                    }

                    txtPName.Text = obj.PatientName;
                    txtInsuranceNum.Text = obj.InsuranceNum;
                    txtAddress.Text = obj.Address;
                    txtDiagnostic.Text = obj.Diagnostic;
                    txtCMT.Text = obj.IdentifyNum;
                    txtRoom.Text = obj.Room;
                    txtBed.Text = obj.Bed;
                    txtCanLamSangID.Text = obj.CanLamSangId;

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
                    cboObject.SelectedValue = Utility.Int32Dbnull(obj.ObjectType,0);
                    cboHosStatus.SelectedIndex = Utility.Int16Dbnull(obj.HosStatus,0);
                    cboLot.SelectedValue = Utility.Int32Dbnull(obj.LotID);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void FillSexCombobox()
        {
            cboSex.DataSource = null;
            cboSex.Items.Clear();

            DataTable dt = new DataTable();
            dt.Columns.Add("ValueItem");
            dt.Columns.Add("DisplayItem");

            DataRow dr = dt.NewRow();

            dr = dt.NewRow();
            dr[0] = DBNull.Value;
            dr[1] = "--- Chọn ---";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = 1;
            dr[1] = "Nam";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = 0;
            dr[1] = "Nữ";
            dt.Rows.Add(dr);

            cboSex.DataSource = dt;
            cboSex.DisplayMember = "DisplayItem";
            cboSex.ValueMember = "ValueItem";

            cboSex.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RegNewPatient();
        }

        private void btnSaveAndReg_Click(object sender, EventArgs e)
        {
            AutoLoadRegForm = true;
            RegNewPatient();
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
                            if (chkCloseAfterInsert.Checked | AutoLoadRegForm)
                            {
                                Close();
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
                            this.Close();
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi khi lưu bệnh nhân","Lỗi",MessageBoxIcon.Error);
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
                
            
            dr = mv_ParentTable.NewRow();
                if (mv_ParentTable.Columns.Contains("Barcode"))
                {
                    dr["Barcode"] = "";
                }
                try
                {
                    dr["Patient_ID"] = txtPatient_ID.Text;
                    dr["PID"] = txtPID.Text;
                    dr["Patient_Name"] = txtPName.Text;

                    if (chkIsBirth.Checked)
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
                    dr["LotID"] = Utility.Int32Dbnull(cboLot.SelectedValue, -1);
                    dr["CanLamSang_ID"] = txtCanLamSangID.Text;
                    dr["User_ID"] = Utility.sDbnull(globalVariables.UserName);
                }
                catch (Exception ex)
                {
                    Utility.ShowMsg(ex.Message);
                }


            //  PatientInfo2Datarow(ref dr);
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
            if (cboSex.SelectedIndex == 0)
            {
                MessageBox.Show("Bạn phải chọn giới tính bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboObject.Items.Count <= 0)
            {
                Utility.ShowMsg("Bạn phải nhập danh mục loại đối tượng dịch vụ");
                return false;
            }
            if (chkIsBirth.Checked)
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
                if (chkIsBirth.Checked)
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

                obj.HosStatus = cboHosStatus.SelectedIndex;
                obj.LotID = Utility.Int32Dbnull(cboLot.SelectedValue, -1);
                obj.Sex = DBNull.Value == cboSex.SelectedValue
                    ? (bool?) null
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
                obj.IsNew = true;
                obj.Save();
                txtPatient_ID.Text = Utility.sDbnull(obj.PatientId);
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
                        ? (bool?) null
                        : Utility.Int16Dbnull(cboSex.SelectedValue) == 1).
                    Set(LPatientInfo.Columns.ObjectType).EqualTo(cboObject.SelectedValue).
                    Set(LPatientInfo.Columns.Diagnostic).EqualTo(txtDiagnostic.Text).
                    Set(LPatientInfo.Columns.DepartmentID).EqualTo(cboDepartment.SelectedValue).
                    Set(LPatientInfo.Columns.Room).EqualTo(txtRoom.Text).
                    Set(LPatientInfo.Columns.Bed).EqualTo(txtBed.Text).
                    Set(LPatientInfo.Columns.IdentifyNum).EqualTo(txtCMT.Text).
                    Set(LPatientInfo.Columns.LotID).EqualTo(Convert.ToInt32(cboLot.SelectedValue)).
                    Set(LPatientInfo.Columns.HosStatus).EqualTo(Utility.Int32Dbnull(cboHosStatus.SelectedIndex)).
                    Set(LPatientInfo.Columns.Dob).EqualTo(chkIsBirth.Checked
                                                              ? (chkDOB.Checked ? dtpDOB.Value.Date : SqlDateTime.Null)
                                                              : SqlDateTime.Null).
                    Set(LPatientInfo.Columns.YearBirth).EqualTo(chkIsBirth.Checked
                                                                    ? Utility.Int32Dbnull(txtYearOfBirth.Text)
                                                                    : SqlInt32.Null).
                    Set(LPatientInfo.Columns.Dateupdate).EqualTo(dtmDate.Value).
                    Set(LPatientInfo.Columns.CanLamSangId).EqualTo(txtCanLamSangID.Text).
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
                dr["Patient_ID"] = txtPatient_ID.Text;
                dr["PID"] = txtPID.Text;
                dr["Patient_Name"] = txtPName.Text;

                if (chkIsBirth.Checked)
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
                dr["LotID"] = Utility.Int32Dbnull(cboLot.SelectedValue, -1);
                dr["CanLamSang_ID"] = txtCanLamSangID.Text;
                dr["User_ID"] = Utility.sDbnull(globalVariables.UserName);
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void chkIsBirth_CheckedChanged(object sender, EventArgs e)
        {
            //grpBirth.ControlTabStop = chkIsBirth.Checked;
            chkDOB.Enabled = chkIsBirth.Checked;
            dtpDOB.Enabled = chkIsBirth.Checked;
            txtYearOfBirth.Enabled = chkIsBirth.Checked;
            txtAge.Enabled = chkIsBirth.Checked;
        }

        private void chkDOB_CheckedChanged(object sender, EventArgs e)
        {
            dtpDOB.Enabled = chkDOB.Checked;
            txtYearOfBirth.Enabled = !chkDOB.Checked;
            txtAge.Enabled = !chkDOB.Checked;
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            txtYearOfBirth.Value = dtpDOB.Value.Year;
        }

        private void txtYearOfBirth_ValueChanged(object sender, EventArgs e)
        {
            txtAge.Value = pv_CurrentYear - Utility.Int32Dbnull(txtYearOfBirth.Value);
        }

        private void txtAge_ValueChanged(object sender, EventArgs e)
        {
            txtYearOfBirth.Value = pv_CurrentYear - Utility.Int32Dbnull(txtAge.Value);
        }

        private void SaveConfig()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                XmlNode node = doc.CreateElement(this.Name);

                XmlNode node1 = doc.CreateElement(chkIsBirth.Name);
                node1.InnerText = chkIsBirth.Checked ? "1" : "0";
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


        private void frmInsertUpdatePatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.S :
                        btnSave.PerformClick();
                        break;
                }
            else if (e.Alt)
                switch (e.KeyCode)
                {
                    case Keys.S:
                        btnSaveAndReg.PerformClick();
                        break;
                }
            else
                switch (e.KeyCode)
                {
                    case Keys.Escape :
                        btnExit.PerformClick();
                        break;
                    case Keys.Enter:
                        SendKeys.Send("{Tab}");
                        break;
                }
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
                     
                     if(query.Count()>0)
                     {
                         txtDepartment.Text = Utility.sDbnull(query.FirstOrDefault()); 
                     }
                     

                 }catch(Exception exception)
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
                    rowFilter = string.Format("{0}='{1}'",LDepartment.Columns.SDesc,txtDepartment.Text);
                }
                m_dtDepartment.DefaultView.RowFilter = rowFilter;
                m_dtDepartment.AcceptChanges();
                cboDepartment.SelectedValueChanged += cboDepartment_SelectedValueChanged;
            }
            catch (Exception)
            {
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCanLamSangID_Leave(object sender, EventArgs e)
        {
            string clsId = txtCanLamSangID.Text.Trim();
            if (string.IsNullOrEmpty(clsId)) return;
            bool x = false;
            if(m_iAction==action.Insert)
            x = new Select().From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.CanLamSangId).IsEqualTo(clsId).
                    And(LPatientInfo.Columns.Dateupdate).IsBetweenAnd(GetBeginTime(dtmDate.Value),
                                                                      GetEndTime(dtmDate.Value)).GetRecordCount() > 0;
            else if (m_iAction == action.Update)
            {
                x = new Select().From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.CanLamSangId).IsEqualTo(clsId).
                   And(LPatientInfo.Columns.Dateupdate).IsBetweenAnd(GetBeginTime(dtmDate.Value),
                                                                     GetEndTime(dtmDate.Value)).And(LPatientInfo.Columns.PatientId).IsNotEqualTo(txtPatient_ID.Text.Trim()).GetRecordCount() > 0;
            }
            if (!x) return;
            Utility.ShowMsg("Mã HIS đã tồn tại - Bạn phải nhập mã khác", "Thông Báo");
            txtCanLamSangID.Focus();
            txtCanLamSangID.SelectAll();
        }

        private void ClearAllField()
        {
            txtAddress.Clear();
            txtAge.Text = "0";
            txtBed.Clear();
            txtCMT.Clear();
            txtCanLamSangID.Clear();
            txtDepartment.Clear();
            txtDiagnostic.Clear();
            txtInsuranceNum.Clear();
            txtPName.Clear();
            txtPatient_ID.Clear();
            txtRoom.Clear();
            txtYearOfBirth.Text = Utility.sDbnull(DateTime.Now.Year);
            cboObject.SelectedIndex = 0;
            cboHosStatus.SelectedIndex = 0;
            cboDepartment.SelectedIndex = 0;
            cboSex.SelectedIndex = 0;
        }

        private void txtCMT_Leave(object sender, EventArgs e)
        {
            //Tự động fill thông tin bệnh nhân
            if (SysPara.AutoFillByCmt == 1)
            {
                string clsId = txtCMT.Text.Trim();
                if (string.IsNullOrEmpty(clsId))
                {
                    ClearAllField();
                    return;
                }
                if (m_iAction == action.Insert)
                {
                    var dtPatientInfo =
                        new Select().From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.IdentifyNum).IsEqualTo(
                            clsId).ExecuteDataSet().Tables[0];
                    if (dtPatientInfo.Rows.Count <= 0)
                    {
                        ClearAllField();
                        return;
                    }
                    txtAddress.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["Address"]);
                    txtAge.Text = Utility.sDbnull(DateTime.Now.Year - Utility.Int32Dbnull(dtPatientInfo.Rows[0]["YEAR_BIRTH"]));
                    txtCanLamSangID.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["CanLamSang_ID"]);
                    txtPName.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["Patient_Name"]);
                    cboSex.SelectedIndex = Utility.Int32Dbnull(dtPatientInfo.Rows[0]["Sex"]) == 1 ? 1 : 2;
                    cboHosStatus.SelectedIndex = Utility.Int32Dbnull(dtPatientInfo.Rows[0]["Hos_Status"]) == 1 ? 1 : 0;
                    cboObject.Text = Utility.sDbnull((from a in dtObjectType.AsEnumerable()
                                                      where
                                                          Utility.Int32Dbnull(a["ID"]).Equals(
                                                              Utility.Int32Dbnull(dtPatientInfo.Rows[0]["ObjectType"]))
                                                      select a["sName"]).FirstOrDefault());
                    cboDepartment.Text = Utility.sDbnull((from b in dtDepartment.AsEnumerable()
                                                          where
                                                              Utility.Int32Dbnull(b["ID"]).Equals(
                                                                  Utility.Int32Dbnull(
                                                                      dtPatientInfo.Rows[0]["DepartmentID"]))
                                                          select b["sName"]).FirstOrDefault());
                    txtDepartment.Text = Utility.sDbnull((from b in dtDepartment.AsEnumerable()
                                                          where
                                                              Utility.Int32Dbnull(b["ID"]).Equals(
                                                                  Utility.Int32Dbnull(
                                                                      dtPatientInfo.Rows[0]["DepartmentID"]))
                                                          select b["sDesc"]).FirstOrDefault());
                    txtDiagnostic.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["Diagnostic"]);
                    txtRoom.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["Room"]);
                    txtBed.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["Bed"]);
                    txtInsuranceNum.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["Insurance_Num"]);
                    txtYearOfBirth.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["YEAR_BIRTH"]);
                }
            }
            else
            {
                string clsId = txtCMT.Text.Trim();
                if (string.IsNullOrEmpty(clsId)) return;
                bool x = false;
                if (m_iAction == action.Insert)
                    x = new Select().From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.IdentifyNum).IsEqualTo(
                        clsId).
                            And(LPatientInfo.Columns.Dateupdate).IsBetweenAnd(GetBeginTime(dtmDate.Value),
                                                                              GetEndTime(dtmDate.Value)).GetRecordCount() >
                        0;
                else if (m_iAction == action.Update)
                {
                    x = new Select().From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.IdentifyNum).IsEqualTo(
                        clsId).
                            And(LPatientInfo.Columns.Dateupdate).IsBetweenAnd(GetBeginTime(dtmDate.Value),
                                                                              GetEndTime(dtmDate.Value)).And(
                                                                                  LPatientInfo.Columns.PatientId).
                            IsNotEqualTo(txtPatient_ID.Text.Trim()).GetRecordCount() > 0;
                }
                if (!x) return;
                Utility.ShowMsg("Số CMT đã tồn tại - Bạn phải nhập mã khác", "Thông Báo");
                txtCMT.Focus();
                txtCMT.SelectAll();

                
            }
        }

        private void txtInsuranceNum_Leave(object sender, EventArgs e)
        {
            //Tự động fill thông tin bệnh nhân
            if (SysPara.AutoFillByCmt == 1)
            {
                string bhyt = txtInsuranceNum.Text.Trim();
                if(string.IsNullOrEmpty(bhyt))
                {
                    ClearAllField();
                    return;
                }
                if (m_iAction == action.Insert)
                {
                    var dtPatientInfo =
                        new Select().From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.InsuranceNum).IsEqualTo(
                            bhyt).ExecuteDataSet().Tables[0];
                    if (dtPatientInfo.Rows.Count <= 0)
                    {
                        ClearAllField();
                        return;
                    }
                    txtAddress.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["Address"]);
                    txtAge.Text = Utility.sDbnull(DateTime.Now.Year - Utility.Int32Dbnull(dtPatientInfo.Rows[0]["YEAR_BIRTH"]));
                    txtCanLamSangID.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["CanLamSang_ID"]);
                    txtPName.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["Patient_Name"]);
                    cboSex.SelectedIndex = Utility.Int32Dbnull(dtPatientInfo.Rows[0]["Sex"]) == 1 ? 1 : 2;
                    cboHosStatus.SelectedIndex = Utility.Int32Dbnull(dtPatientInfo.Rows[0]["Hos_Status"]) == 1 ? 1 : 0;
                    cboObject.Text = Utility.sDbnull((from a in dtObjectType.AsEnumerable()
                                                      where
                                                          Utility.Int32Dbnull(a["ID"]).Equals(
                                                              Utility.Int32Dbnull(dtPatientInfo.Rows[0]["ObjectType"]))
                                                      select a["sName"]).FirstOrDefault());
                    cboDepartment.Text = Utility.sDbnull((from b in dtDepartment.AsEnumerable()
                                                          where
                                                              Utility.Int32Dbnull(b["ID"]).Equals(
                                                                  Utility.Int32Dbnull(
                                                                      dtPatientInfo.Rows[0]["DepartmentID"]))
                                                          select b["sName"]).FirstOrDefault());
                    txtDepartment.Text = Utility.sDbnull((from b in dtDepartment.AsEnumerable()
                                                          where
                                                              Utility.Int32Dbnull(b["ID"]).Equals(
                                                                  Utility.Int32Dbnull(
                                                                      dtPatientInfo.Rows[0]["DepartmentID"]))
                                                          select b["sDesc"]).FirstOrDefault());
                    txtDiagnostic.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["Diagnostic"]);
                    txtRoom.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["Room"]);
                    txtBed.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["Bed"]);
                    txtCMT.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["IdentifyNum"]);
                    txtYearOfBirth.Text = Utility.sDbnull(dtPatientInfo.Rows[0]["YEAR_BIRTH"]);
                }
            }
        }

        private DateTime GetBeginTime(DateTime dateTime)
        {
            return new DateTime(dateTime.Year,dateTime.Month,dateTime.Day,0,0,0,0);
        }

        private DateTime GetEndTime(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 58, 0);
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
