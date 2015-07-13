using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Janus.Windows.GridEX;
using LIS.DAL;
using Lis.GiaoDien;
using Microsoft.VisualBasic;
using NLog;
using SubSonic;
using VietBaIT.HISLink.LoadDataCommon;
using VietBaIT.HISLink.UI.ControlUtility.BaseClass;
using VietBaIT.HISLink.UI.ControlUtility.CauHinh;
using VietBaIT.HISLink.UI.ControlUtility.NHOM_CLS;
using SortOrder = Janus.Windows.GridEX.SortOrder;
using VNS.Libs;

namespace VietBaIT.HISLink.UI.ControlUtility.Import_Excel
{
    public partial class frmImportExcel : Form
    {
        #region Khai bao

        private readonly List<TAssignDetail> _lstAssignDetail = new List<TAssignDetail>();
        private readonly Logger log;
        private int ServiceDetail_Id;
        private BussinessImportExcel _BussinessImportExcel = new BussinessImportExcel();
        private int _Value;
        private bool _bSuccess = true;
        private decimal _decFailed;
        private HISPrintProperties _hisPrintProperties;
        private List<TAssignInfo> _lstAssignInfo;
        private List<TPatientExam> _lstPatientExam;
        private List<TPatientInfo> _lstPatientInfo;
        private BackgroundWorker bgwImport = null;
        public GridEX grdAsignDetail;
        private int lastIndex;
        private char lastKey;
        private DataTable m_dtAssignDetail = new DataTable();
        private DataTable m_dtReport = new DataTable();
        private DataTable m_dtServiceDetail = new DataTable();
        private int v_AssignId = -1;

        #endregion

        #region Form event

        public delegate void AddLog(string logText, Color sActionColor);

        private const string _sNewline = "\r\n";
        private const string _sTab = "\t";
        private const string _sNewlineTab = "\r\n\t";
        private const string _sNewlineTabTab = "\r\n\t\t";

        private HISLISManager _HISLISManager;
        private bool wait4Tu;

        public frmImportExcel()
        {
            InitializeComponent();
            cboFilter.SelectedIndex = 0;
            log = LogManager.GetCurrentClassLogger();
            chkChiDinhNhanh.Checked = true;
            CreateTable();
            InitHISLISConnect();
            _hisPrintProperties = Utility.GetPrintPropertiesConfig();
        }

        private void InitHISLISConnect()
        {
            _HISLISManager = new HISLISManager();
            _HISLISManager._OnQueueChanged += _HISLISManager__OnQueueChanged;
            _HISLISManager._OnAction += _HISLISManager__OnAction;
            _HISLISManager._Onfinished += _HISLISManager__Onfinished;
            _HISLISManager._OnDoing += _HISLISManager__OnDoing;
            _HISLISManager.StartSending();
        }

        private void _HISLISManager__OnDoing(string sLogText, Color resultColor)
        {
            LogText(sLogText, resultColor);
        }

        private void _HISLISManager__Onfinished()
        {
            cmdPush2Lab.Text = "Đẩy vào Lab";
            cmdPush2Lab.Tag = "0";
        }

        private void _HISLISManager__OnAction(int result, string MA_CHIDINH, int vAssign_Id, string PATIENT_CODE,
            string sLogText, Color resultColor)
        {
            try
            {
                LogText(sLogText, resultColor);
                if (resultColor == Color.Red)
                {
                    _Visible(lblMsg, true);
                }
                foreach (GridEXRow row in grdData.GetCheckedRows())
                {
                    string ma_chidinh = Utility.sDbnull(row.Cells["assign_code"].Value, "Unknown");
                    long assign_id = Utility.Int32Dbnull(row.Cells["assign_id"].Value, -1);
                    string patient_code = Utility.sDbnull(row.Cells["patient_code"].Value, "Unknown");
                    if (ma_chidinh == MA_CHIDINH && vAssign_Id == assign_id && patient_code == PATIENT_CODE)
                    {
                        row.BeginEdit();
                        if (result != 0)
                        {
                            row.Cells["AssignDetail_Status"].Value = 0;
                            row.Cells["_error"].Value = 1;
                        }
                        else
                            row.IsChecked = false;
                        row.EndEdit();
                        break;
                    }
                }
            }
            catch
            {
            }
        }

        public static void _Visible(Control ctr, bool _visible)
        {
            try
            {
                if (ctr.InvokeRequired)
                {
                    ctr.Invoke(new VisibleControl(_Visible), new object[] {ctr, _visible});
                }
                else
                {
                    ctr.Visible = _visible;
                    Application.DoEvents();
                }
            }
            catch
            {
            }
            finally
            {
                Application.DoEvents();
            }
        }

        private void _HISLISManager__OnQueueChanged(int QueueCount)
        {
        }

        public void LogText(string sLogText, Color sActionColor)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new AddLog(LogText), new object[] {sLogText, sActionColor});
                }
                else
                {
                    AddAction(sLogText, sActionColor);
                    //rtxtLogs.AppendText(sLogText);
                    rtxtLogs.AppendText(_sNewline);
                    //TextBoxTraceListener.SendMessage(_richTextBoxLog.Handle, TextBoxTraceListener.WM_VSCROLL, TextBoxTraceListener.SB_BOTTOM, 0);
                }
            }
            catch
            {
            }
        }

        private void AddAction(string sLogText, Color color)
        {
            try
            {
                if (sLogText.Length > 0)
                {
                    Color oldColor = rtxtLogs.SelectionColor;
                    rtxtLogs.SelectionLength = 0;
                    rtxtLogs.SelectionStart = rtxtLogs.Text.Length;
                    rtxtLogs.SelectionColor = color;
                    rtxtLogs.SelectionFont = new Font(rtxtLogs.SelectionFont, FontStyle.Bold);
                    rtxtLogs.AppendText(sLogText);
                    rtxtLogs.SelectionColor = oldColor;
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        private void CreateTable()
        {
            try
            {
                StoredProcedure sp = SPs.LaokhoaInphieuKhambenh(-1);
                m_dtReport = sp.GetDataSet().Tables[0];
            }
            catch (Exception ex)
            {
                m_dtReport = null;
            }
        }

        private void LaySoLoImportExcel()
        {
            try
            {
                int iLo = 0;
                DataTable dtLo = new Select()
                    .From(TPatientInfo.Schema).ExecuteDataSet().Tables[0];
                iLo = Utility.Int32Dbnull(dtLo.Select().Max(e => Utility.Int32Dbnull(e[TPatientInfo.Columns.SoLo])), 0);
                if (dtLo.Rows.Count > 0)
                {
                    iLo = iLo + 1;
                    txtLo.Text = iLo.ToString();
                }
                else
                {
                    iLo = 0;
                    txtLo.Text = iLo.ToString();
                }
              
            }
            catch (Exception ex)
            {
                txtLo.Text = "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void frmImportExcel_Load(object sender, EventArgs e)
        {
            DataBinding.BindDataCombox(cboDichVu, CommonBusiness.LayThongTinDichVuCLS(), LService.Columns.ServiceId,
                LService.Columns.ServiceName, "Lọc thông tin theo loại dịch vụ");
            IntitalData();
            GetWebservice();
            LayThongTin_Chitiet_CLS();
            LaySoLoImportExcel();
            wait4Tu = File.Exists(Application.StartupPath + @"\wait4Tu.txt");
        }

        private delegate void VisibleControl(Control ctr, bool _visible);

        #endregion

        #region Browse file excel

        private void LoadDataFromFileExcelToGrid(string Path)
        {
            var odbConnection =
                //new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;");
                new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path +
                                    ";Extended Properties=Excel 12.0;");
            string sheetName = "";
            try
            {
                odbConnection.Open();
                DataTable dt = odbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                sheetName = dt.Rows[1]["TABLE_NAME"].ToString();
                var oldbAdapter = new OleDbDataAdapter("Select * from [Data$] WHERE HO_TEN <>'' ", odbConnection);
                var ods = new DataSet();
                oldbAdapter.TableMappings.Add("Table", "TestTable");
                oldbAdapter.Fill(ods);
                var col = new DataColumn("colCHON", typeof (bool));
                col.DefaultValue = true;
                var col1 = new DataColumn("_Error", typeof (int));
                col1.DefaultValue = 0;

                var col2 = new DataColumn("Patient_id", typeof (int));
                col2.DefaultValue = 0;

                var col3 = new DataColumn("patient_code", typeof (string));
                col3.DefaultValue = "";

                var col4 = new DataColumn("assign_id", typeof (int));
                col4.DefaultValue = 0;

                var col5 = new DataColumn("assign_code", typeof (string));
                col5.DefaultValue = "";

                ods.Tables[0].Columns.Add(col);
                ods.Tables[0].Columns.Add(col1);
                ods.Tables[0].Columns.Add(col2);
                ods.Tables[0].Columns.Add(col3);
                ods.Tables[0].Columns.Add(col4);
                ods.Tables[0].Columns.Add(col5);
                grdData.DataSource = ods.Tables[0];
                grdData.CheckAllRecords();
                if (chkGhepLo.Checked) LaySoLoImportExcel();
                _Value = 0;
                _decFailed = 0;
                _bSuccess = true;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
            finally
            {
                odbConnection.Close();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Excel File (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofd.FileName;
                LoadDataFromFileExcelToGrid(ofd.FileName);
            }
        }

        private void txtPath_Leave(object sender, EventArgs e)
        {
            if (txtPath.Text.Trim() != "")
                LoadDataFromFileExcelToGrid(txtPath.Text.Trim());
        }

        #endregion

        #region Chon CLS

        private void cboDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDichVu.SelectedIndex > 0)
                {
                    EnumerableRowCollection<DataRow> query = from addresses in m_dtServiceDetail.AsEnumerable()
                        where
                            addresses.Field<short>(
                                LServiceDetail.Columns.ServiceId) ==
                            Utility.Int32Dbnull(cboDichVu.SelectedValue, -1)
                        select addresses;
                    if (query.Any())
                    {
                        Utility.SetDataSourceForDataGridEx(grdServiceDetail, query.CopyToDataTable(), true, true, "1=1",
                            "");
                        grdServiceDetail.MoveFirst();
                    }
                }
                else
                {
                    Utility.SetDataSourceForDataGridEx(grdServiceDetail, m_dtServiceDetail, true, true, "1=1", "");
                    grdServiceDetail.MoveFirst();
                }
            }
            catch (Exception)
            {
            }
        }

        private void IntitalData()
        {
            try
            {
                m_dtServiceDetail = CommonBusiness.LoadDataServiceDetail_KSK("DV", -1, globalVariables.MA_KHOA_THIEN);
                if (!m_dtServiceDetail.Columns.Contains("Quantity"))
                    m_dtServiceDetail.Columns.Add("Quantity", typeof (int));
                if (!m_dtServiceDetail.Columns.Contains("Unit_Name"))
                    m_dtServiceDetail.Columns.Add("Unit_Name", typeof (string));
                // ProcessData(ref m_dtServiceDetail);
                Utility.AddColumToDataTable(ref m_dtServiceDetail, "ShortName", typeof (string));

                IEnumerable<DataRow> query = from r in globalVariables.g_dtMeasureUnit.Rows.Cast<DataRow>()
                    where r.ItemArray.All(c => c != DBNull.Value)
                    select r;
                if (query.Count() <= 0)
                {
                    globalVariables.g_dtMeasureUnit = CommonBusiness.LayThongTinDonViTinh();
                }
                foreach (DataRow drv in m_dtServiceDetail.Rows)
                {
                    drv["Quantity"] = 1;
                    drv["ShortName"] =
                        Utility.UnSignedCharacter(
                            Utility.sDbnull(drv[LServiceDetail.Columns.ServiceDetailName]).ToUpper());

                    EnumerableRowCollection<string> querydvt =
                        globalVariables.g_dtMeasureUnit.AsEnumerable().Select(
                            dvt => new {dvt, y = Utility.sDbnull(drv["Unit_Name"])}).Where(
                                @t => Utility.Int32Dbnull(@t.dvt["Unit_ID"]) == Utility.Int32Dbnull(drv["Unit_ID"], -1))
                            .Select(@t => @t.y);


                    if (querydvt.Any())
                    {
                        drv["Unit_Name"] = Utility.sDbnull(querydvt.FirstOrDefault(), "");
                    }
                }

                m_dtServiceDetail.AcceptChanges();
                GridEXColumn gridExColumnGroup = grdServiceDetail.RootTable.Columns["GroupIntOrder"];
                GridEXColumn gridExColumn = grdServiceDetail.RootTable.Columns["sIntOrder"];
                var gridExSortKeyGroup = new GridEXSortKey(gridExColumnGroup, SortOrder.Ascending);
                var gridExSortKey = new GridEXSortKey(gridExColumn, SortOrder.Ascending);
                grdServiceDetail.RootTable.SortKeys.Add(gridExSortKeyGroup);
                grdServiceDetail.RootTable.SortKeys.Add(gridExSortKey);
                Utility.SetDataSourceForDataGridEx(grdServiceDetail, m_dtServiceDetail, false, true, "", "");
                //grdServiceDetail.RootTable.SortKeys.Clear();

                grdServiceDetail.MoveFirst();
                grdServiceDetail.RootTable.Columns["sIntOrder"].Visible = globalVariables.IsAdmin;
                // Janus.Windows.GridEX.GridEXColumn gridExColumnThuTu = grdServiceDetail.RootTable.Columns["sIntOrder"];
                Utility.VisiableGridEx(grdServiceDetail, "sIntOrder", globalVariables.IsAdmin);
                txtFilterName.Focus();
                txtFilterName.SelectAll();
            }
            catch (Exception exception)
            {
                Utility.ShowMsg("Lỗi trong quá trình load thông tin :" + exception);
            }
        }

        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            FilterCLS();
        }

        private void FilterCLS()
        {
            try
            {
                string FiledName = LServiceDetail.Columns.ServiceDetailName;
                if (!string.IsNullOrEmpty(txtFilterName.Text))
                {
                    if (cboDichVu.SelectedIndex > 0)
                    {
                        EnumerableRowCollection<DataRow> query = from addresses in m_dtServiceDetail.AsEnumerable()
                            where
                                ((addresses.Field<string>("ShortName").StartsWith(
                                    txtFilterName.Text.ToUpper())
                                  ||
                                  addresses.Field<string>("ShortName").Contains(
                                      txtFilterName.Text.ToUpper()))
                                 ||
                                 (addresses.Field<string>(FiledName).StartsWith(
                                     txtFilterName.Text)
                                  ||
                                  addresses.Field<string>(FiledName).Contains(
                                      txtFilterName.Text)))
                                &&
                                addresses.Field<short>(
                                    LServiceDetail.Columns.ServiceId) ==
                                Utility.Int32Dbnull(cboDichVu.SelectedValue, -1)
                            select addresses;
                        if (query.Any())
                        {
                            Utility.SetDataSourceForDataGridEx(grdServiceDetail, query.CopyToDataTable(), true, true,
                                "1=1", "");
                            grdServiceDetail.MoveFirst();
                        }
                    }
                    else
                    {
                        EnumerableRowCollection<DataRow> query = from addresses in m_dtServiceDetail.AsEnumerable()
                            where
                                ((addresses.Field<string>("ShortName").StartsWith(
                                    txtFilterName.Text.ToUpper())
                                  ||
                                  addresses.Field<string>("ShortName").Contains(
                                      txtFilterName.Text.ToUpper()))
                                 ||
                                 (addresses.Field<string>(FiledName).StartsWith(
                                     txtFilterName.Text)
                                  ||
                                  addresses.Field<string>(FiledName).Contains(
                                      txtFilterName.Text)))
                            select addresses;
                        if (query.Any())
                        {
                            Utility.SetDataSourceForDataGridEx(grdServiceDetail, query.CopyToDataTable(), true, true,
                                "1=1", "");
                            grdServiceDetail.MoveFirst();
                        }
                    }
                }
                else
                {
                    Utility.SetDataSourceForDataGridEx(grdServiceDetail, m_dtServiceDetail, true, true, "1=1", "");
                }
            }
            catch (Exception exception)
            {
            }
        }

        private void grdServiceDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdServiceDetail.Focused)
                if (e.KeyCode == Keys.Escape)
                {
                    txtFilterName.Focus();
                    txtFilterName.SelectAll();
                }
            if (e.KeyCode == Keys.Enter)
            {
                if (grdServiceDetail.CurrentRow.RowType == RowType.Record)
                {
                    if (!grdServiceDetail.CurrentRow.IsChecked) grdServiceDetail.CurrentRow.IsChecked = true;
                }

                cmdAddDetail.PerformClick();
                txtFilterName.Focus();
                txtFilterName.SelectAll();
            }
        }

        private void grdServiceDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                IEnumerable<GridEXRow> query = from cls in grdServiceDetail.GetDataRows()
                    let y = cls.RowType == RowType.Record
                    select cls;
                string sKeyChar = Utility.sDbnull(e.KeyChar);
                int length = query.Count();
                for (int i = 0; i < length; i++)
                {
                    string ServiceName =
                        Utility.sDbnull(grdServiceDetail.GetRow(i).Cells["ServiceDetail_Name"].Value);

                    if (ServiceName.StartsWith(sKeyChar, true, CultureInfo.InvariantCulture))
                    {
                        if (lastKey == '\0')
                        {
                            lastKey = e.KeyChar;
                            if (lastKey == e.KeyChar && lastIndex < i)
                            {
                                int last = lastIndex;
                                lastIndex = i;
                                lastKey = e.KeyChar;
                                clearGrid(last);
                                grdServiceDetail.MoveTo(i);
                                return;
                            }
                            continue;
                        }
                        if (lastKey != e.KeyChar)
                        {
                            int last = lastIndex;
                            lastIndex = i;
                            lastKey = e.KeyChar;
                            clearGrid(last);
                            grdServiceDetail.MoveFirst();
                            return;
                        }
                        // int last = lastIndex;
                        if (lastKey == e.KeyChar && lastIndex < i)
                        {
                            int last = lastIndex;
                            lastIndex = i;
                            lastKey = e.KeyChar;
                            clearGrid(last);
                            grdServiceDetail.MoveFirst();
                            return;
                        }
                    }
                }
            }
        }

        private void clearGrid(int i)
        {
            grdServiceDetail.MoveFirst();
        }

        private void grdServiceDetail_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string servicedetail_id =
                    Utility.sDbnull(grdServiceDetail.GetValue(LServiceDetail.Columns.ServiceDetailId));
                Utility.GonewRowJanus(grdAsignDetail, TAssignDetail.Columns.ServiceDetailId, servicedetail_id);
            }
            catch (Exception)
            {
            }
        }

        private void cmdAddDetail_Click(object sender, EventArgs e)
        {
            AddDetail();
        }

        private void AddDetail()
        {
            try
            {
                Utility.EnableButton(cmdAddDetail, false);
                GridEXRow[] ArrCheckList = grdServiceDetail.GetCheckedRows();
                foreach (GridEXRow gridExRow in ArrCheckList)
                {
                    Int32 ServiceDetail_Id = Utility.Int32Dbnull(gridExRow.Cells["ServiceDetail_ID"].Value, -1);
                    EnumerableRowCollection<DataRow> query =
                        m_dtAssignDetail.AsEnumerable().Cast<DataRow>().Where(
                            loz =>
                                Utility.Int32Dbnull(loz[TAssignDetail.Columns.ServiceDetailId], -1) == ServiceDetail_Id);
                    if (query.Count() <= 0)
                    {
                        DataRow newDr = m_dtAssignDetail.NewRow();
                        newDr[TAssignDetail.Columns.AssignDetailId] = -1;
                        newDr[TAssignDetail.Columns.IdGoiDvu] = Utility.Int32Dbnull(
                            gridExRow.Cells["ID_GOI_DVU"].Value, -1);
                        newDr[TAssignDetail.Columns.TrongGoi] = Utility.Int32Dbnull(gridExRow.Cells["TRONG_GOI"].Value,
                            0);
                        newDr[TAssignDetail.Columns.AssignId] = v_AssignId;
                        int Service_ID = Utility.Int32Dbnull(gridExRow.Cells[LServiceDetail.Columns.ServiceId].Value, -1);

                        newDr[TAssignDetail.Columns.ServiceId] = Service_ID;
                        LService objService = LService.FetchByID(Service_ID);
                        if (objService != null)
                        {
                            if (m_dtAssignDetail.Columns.Contains("IntOrderGroup"))
                            {
                                newDr["IntOrderGroup"] = Utility.Int32Dbnull(objService.IntOrder);
                            }
                        }
                        int ServiceDetail_ID =
                            Utility.Int32Dbnull(gridExRow.Cells[LServiceDetail.Columns.ServiceDetailId].Value, -1);
                        newDr[TAssignDetail.Columns.ServiceDetailId] = ServiceDetail_ID;
                        LServiceDetail objServiceDetail = LServiceDetail.FetchByID(ServiceDetail_ID);
                        if (objServiceDetail != null)
                        {
                            if (m_dtAssignDetail.Columns.Contains("IntOrder"))
                            {
                                newDr["IntOrder"] = Utility.Int32Dbnull(objServiceDetail.IntOrder);
                            }
                        }
                        newDr[TAssignDetail.Columns.DiscountRate] =
                            Utility.DecimaltoDbnull(gridExRow.Cells["Discount_Rate"].Value, 0);
                        newDr[TAssignDetail.Columns.DiscountPrice] =
                            Utility.DecimaltoDbnull(gridExRow.Cells["LastPrice"].Value, 0);
                        newDr[TAssignDetail.Columns.OriginPrice] =
                            Utility.DecimaltoDbnull(gridExRow.Cells["Price"].Value, 0);
                        newDr[TAssignDetail.Columns.DiscountType] =
                            Utility.ByteDbnull(gridExRow.Cells["Discount_Type"].Value);
                        newDr["ServiceDetail_Name"] = Utility.sDbnull(gridExRow.Cells["ServiceDetail_Name"].Value, "");
                        newDr["IsNew"] = 1;
                        newDr["IsLocked"] = 0;
                        newDr["ObjectType_ID"] = 1;
                        newDr[TAssignDetail.Columns.DisplayOnReport] = 1;
                        newDr["Quantity"] = Utility.Int32Dbnull(gridExRow.Cells["Quantity"].Value, 1);
                        newDr[TAssignDetail.Columns.IsPayment] = Utility.Int32Dbnull(gridExRow.Cells["IsPayment"].Value);
                        newDr["Service_Name"] = Utility.sDbnull(gridExRow.Cells["Service_Name"].Value, "");
                        newDr[TAssignDetail.Columns.DiagPerson] = globalVariables.gv_StaffID;
                        newDr[TAssignDetail.Columns.SurchargePrice] =
                            Utility.DecimaltoDbnull(gridExRow.Cells["Surcharge"].Value, 0);
                        newDr[TAssignDetail.Columns.DiscountPrice] =
                            Utility.DecimaltoDbnull(gridExRow.Cells["LastPrice"].Value, 0);
                        newDr[TAssignDetail.Columns.UserId] = globalVariables.UserName;
                        newDr[TAssignDetail.Columns.InputDate] = BusinessHelper.GetSysDateTime();

                        m_dtAssignDetail.Rows.Add(newDr);
                    }
                }
                m_dtServiceDetail.AcceptChanges();
                Utility.EnableButton(cmdAddDetail, true);
            }
            catch (Exception)
            {
                Utility.EnableButton(cmdAddDetail, true);
            }
            finally
            {
                Utility.EnableButton(cmdAddDetail, true);
            }
        }

        private void grdServiceDetail_CellValueChanged(object sender, ColumnActionEventArgs e)
        {
            if (chkChiDinhNhanh.Checked)
            {
                if (grdServiceDetail.CurrentRow.IsChecked)
                {
                    AddOneRow_ServiceDetail();
                }
            }
        }

        private void AddOneRow_ServiceDetail()
        {
            GridEXRow gridExRow = grdServiceDetail.CurrentRow;
            Int32 ServiceDetailId = Utility.Int32Dbnull(gridExRow.Cells["ServiceDetail_ID"].Value, -1);
            DataRow[] arrDR = m_dtAssignDetail.Select("ServiceDetail_ID=" + ServiceDetailId);
            //EnumerableRowCollection<DataRow> query =
            //    m_dtAssignDetail.AsEnumerable().Cast<DataRow>().Where(loz => Utility.Int32Dbnull(
            //        loz[TAssignDetail.Columns.ServiceDetailId], -1) == ServiceDetailId);
            if (arrDR.Length <= 0)
            {
                DataRow newDr = m_dtAssignDetail.NewRow();
                newDr[TAssignDetail.Columns.AssignDetailId] = -1;
                newDr[TAssignDetail.Columns.IdGoiDvu] = Utility.Int32Dbnull(gridExRow.Cells["ID_GOI_DVU"].Value, -1);
                newDr[TAssignDetail.Columns.TrongGoi] = Utility.Int32Dbnull(gridExRow.Cells["TRONG_GOI"].Value, 0);
                newDr[TAssignDetail.Columns.AssignId] = v_AssignId;
                newDr[TAssignDetail.Columns.ServiceId] =
                    Utility.Int32Dbnull(gridExRow.Cells[LServiceDetail.Columns.ServiceId].Value, -1);
                newDr[TAssignDetail.Columns.ServiceDetailId] =
                    Utility.Int32Dbnull(gridExRow.Cells[LServiceDetail.Columns.ServiceDetailId].Value, -1);
                newDr[TAssignDetail.Columns.DiscountRate] =
                    Utility.DecimaltoDbnull(gridExRow.Cells["Discount_Rate"].Value, 0);
                newDr[TAssignDetail.Columns.DiscountPrice] =
                    Utility.DecimaltoDbnull(gridExRow.Cells["LastPrice"].Value, 0);
                newDr[TAssignDetail.Columns.OriginPrice] = Utility.DecimaltoDbnull(gridExRow.Cells["Price"].Value, 0);
                newDr[TAssignDetail.Columns.DiscountType] =
                    Utility.ByteDbnull(gridExRow.Cells["Discount_Type"].Value);
                newDr["ServiceDetail_Name"] = Utility.sDbnull(gridExRow.Cells["ServiceDetail_Name"].Value, "");
                newDr["IsNew"] = 1;
                newDr["IsLocked"] = 0;
                newDr["ObjectType_ID"] = 1;
                newDr[TAssignDetail.Columns.DisplayOnReport] = 1;
                newDr["Quantity"] = Utility.Int32Dbnull(gridExRow.Cells["Quantity"].Value, 1);
                newDr[TAssignDetail.Columns.IsPayment] = Utility.Int32Dbnull(gridExRow.Cells["IsPayment"].Value);
                newDr["Service_Name"] = Utility.sDbnull(gridExRow.Cells["Service_Name"].Value, "");
                newDr[TAssignDetail.Columns.DiagPerson] = globalVariables.gv_StaffID;
                newDr[TAssignDetail.Columns.SurchargePrice] =
                    Utility.DecimaltoDbnull(gridExRow.Cells["Surcharge"].Value, 0);
                newDr[TAssignDetail.Columns.DiscountPrice] =
                    Utility.DecimaltoDbnull(gridExRow.Cells["LastPrice"].Value, 0);
                m_dtAssignDetail.Rows.Add(newDr);
                m_dtServiceDetail.AcceptChanges();
            }
        }

        private void LayThongTin_Chitiet_CLS()
        {
            try
            {
                m_dtAssignDetail = SPs.YhhqLaythongtinDichvuThuocVattu(-1, "DICHVU").GetDataSet().Tables[0];
                //grdAssignDetail.DataSource = m_dtAssignDetail;

                Utility.SetDataSourceForDataGridEx(grdAssignDetail, m_dtAssignDetail, false, true, "", "");
                grdAssignDetail.RootTable.SortKeys.Clear();
                GridEXColumn gridExColumnGroup = grdAssignDetail.RootTable.Columns["IntOrderGroup"];
                GridEXColumn gridExColumn = grdAssignDetail.RootTable.Columns["IntOrder"];
                var gridExSortKeyGroup = new GridEXSortKey(gridExColumnGroup, SortOrder.Ascending);
                var gridExSortKey = new GridEXSortKey(gridExColumn, SortOrder.Ascending);
                grdAssignDetail.RootTable.SortKeys.Add(gridExSortKeyGroup);
                grdAssignDetail.RootTable.SortKeys.Add(gridExSortKey);
                grdAssignDetail.MoveFirst();
            }
            catch (Exception)
            {
            }
        }

        private void cmdNhom_CLS_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frm_Nhom_DVuCLS();
                frm.MaDoiTuong = "DV";
                frm.ShowDialog();
                if (frm.b_Cancel)
                {
                    GridEXRow[] gridExRows = frm.gridExRows;
                    foreach (GridEXRow gridExRow in gridExRows)
                    {
                        int ServiceDetail_Id = Utility.Int32Dbnull(gridExRow.Cells[LNhomDvuCl.Columns.IdDvu].Value);
                        EnumerableRowCollection<DataRow> query =
                            from nhom in m_dtAssignDetail.AsEnumerable().Cast<DataRow>()
                            where
                                Utility.Int32Dbnull(nhom[TAssignDetail.Columns.ServiceDetailId], -1) == ServiceDetail_Id
                            select nhom;

                        if (query.Count() <= 0)
                        {
                            AddNhomCLS(gridExRow);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
            }
        }

        private void AddNhomCLS(GridEXRow gridExRow)
        {
            DataRow newDr = m_dtAssignDetail.NewRow();
            newDr[TAssignDetail.Columns.AssignDetailId] = -1;

            newDr[TAssignDetail.Columns.AssignId] = v_AssignId;
            newDr[TAssignDetail.Columns.ServiceId] =
                Utility.Int32Dbnull(gridExRow.Cells[LNhomDvuCl.Columns.IdLoaiDvu].Value, -1);
            ServiceDetail_Id = Utility.Int32Dbnull(gridExRow.Cells[LNhomDvuCl.Columns.IdDvu].Value, -1);
            newDr[TAssignDetail.Columns.ServiceDetailId] = ServiceDetail_Id;
            //newDr[TAssignDetail.Columns.OriginPrice] = Utility.DecimaltoDbnull(gridExRow.Cells["Price"].Value, 0);
            newDr[TAssignDetail.Columns.DiscountType] = 1;
            newDr["ServiceDetail_Name"] = Utility.sDbnull(gridExRow.Cells["TEN_DVU"].Value, "");
            newDr["IsNew"] = 1;
            newDr["IsLocked"] = 0;
            newDr["ObjectType_ID"] = 1;
            newDr[TAssignDetail.Columns.DisplayOnReport] = 1;
            newDr["Quantity"] = Utility.Int32Dbnull(gridExRow.Cells[LNhomDvuCl.Columns.SoLuong].Value, 1);
            newDr[TAssignDetail.Columns.IsPayment] = 0;
            newDr["Service_Name"] = Utility.sDbnull(gridExRow.Cells["TEN_LOAI_DVU"].Value, "");
            newDr[TAssignDetail.Columns.DiagPerson] = globalVariables.gv_StaffID;
            IEnumerable<GridEXRow> query = from dichvu in grdServiceDetail.GetDataRows().AsEnumerable()
                where
                    Utility.Int32Dbnull(
                        dichvu.Cells[LServiceDetail.Columns.ServiceDetailId].Value) ==
                    ServiceDetail_Id
                select dichvu;
            if (query.Count() > 0)
            {
                GridEXRow exRow = query.FirstOrDefault();
                newDr[TAssignDetail.Columns.DiscountPrice] = Utility.DecimaltoDbnull(exRow.Cells["LastPrice"].Value, 0);
                newDr[TAssignDetail.Columns.SurchargePrice] = Utility.DecimaltoDbnull(exRow.Cells["Surcharge"].Value, 0);
                newDr[TAssignDetail.Columns.OriginPrice] = Utility.DecimaltoDbnull(exRow.Cells["Price"].Value, 0);

                newDr[TAssignDetail.Columns.IdGoiDvu] = Utility.Int32Dbnull(exRow.Cells["ID_GOI_DVU"].Value, -1);
                newDr[TAssignDetail.Columns.TrongGoi] = Utility.Int32Dbnull(exRow.Cells["TRONG_GOI"].Value, 0);
            }
            else
            {
                SqlQuery sqlQuery = new Select().From(LObjectTypeService.Schema)
                    .Where(LObjectTypeService.Columns.MaDtuong).IsEqualTo("DV")
                    .And(LNhomDvuCl.Columns.IdDvu).IsEqualTo(ServiceDetail_Id);
                var objectTypeService = sqlQuery.ExecuteSingle<LObjectTypeService>();
                if (objectTypeService != null)
                {
                    newDr[TAssignDetail.Columns.SurchargePrice] = Utility.DecimaltoDbnull(objectTypeService.Surcharge, 0);
                    newDr[TAssignDetail.Columns.DiscountPrice] = Utility.DecimaltoDbnull(objectTypeService.Surcharge, 0);
                    newDr[TAssignDetail.Columns.IdGoiDvu] = -1;
                    newDr[TAssignDetail.Columns.TrongGoi] = 0;
                }
            }

            //  newDr["TT"] = Utility.DecimaltoDbnull(drv["Surcharge"], 0) + Utility.DecimaltoDbnull(drv["Price"], 0);

            m_dtAssignDetail.Rows.Add(newDr);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (!InValiXoaCLS()) return;

            foreach (GridEXRow gridExRow in grdAssignDetail.GetCheckedRows())
            {
                long AssignDetail = Utility.Int64Dbnull(gridExRow.Cells[TAssignDetail.Columns.AssignDetailId].Value, -1);

                StoredProcedure sp = SPs.ClsTAssignDetailDelete(AssignDetail);
                sp.Execute();
                gridExRow.Delete();
                grdAssignDetail.UpdateData();
                grdAssignDetail.Refresh();
                m_dtAssignDetail.AcceptChanges();
            }
        }

        private bool InValiXoaCLS()
        {
            if (grdAssignDetail.GetCheckedRows().Length <= 0)
            {
                Utility.ShowMsg("Bạn phải thực hiện chọn một bản ghi thực hiện xóa thông tin dịch vụ cận lâm sàng",
                    "Thông báo", MessageBoxIcon.Warning);
                grdAssignDetail.Focus();
                return false;
            }

            if (!globalVariables.IsAdmin)
            {
                if (!globalVariables.gv_QuyenSuaDuLieu)
                {
                    if (globalVariables.gv_UserAcceptDeleted)
                    {
                        foreach (GridEXRow gridExRow in grdAssignDetail.GetCheckedRows())
                        {
                            int AssignDetail_ID =
                                Utility.Int32Dbnull(gridExRow.Cells[TAssignDetail.Columns.AssignDetailId].Value, -1);
                            SqlQuery sqlQuery = new Select().From(TAssignDetail.Schema)
                                .Where(TAssignDetail.Columns.AssignDetailId).IsEqualTo(AssignDetail_ID)
                                .And(TAssignDetail.Columns.UserId).IsNotEqualTo(globalVariables.UserName);
                            if (sqlQuery.GetRecordCount() > 0)
                            {
                                Utility.ShowMsg(
                                    "Bạn chỉ được xóa các chỉ định của mình, Bạn không thể xóa chỉ định của người khác",
                                    "Thông báo", MessageBoxIcon.Warning);
                                return false;
                                break;
                            }
                        }
                    }
                }

                foreach (GridEXRow gridExRow in grdAssignDetail.GetCheckedRows())
                {
                    int AssignDetail_ID =
                        Utility.Int32Dbnull(gridExRow.Cells[TAssignDetail.Columns.AssignDetailId].Value,
                            -1);
                    SqlQuery sqlQuery = new Select().From(TAssignDetail.Schema)
                        .Where(TAssignDetail.Columns.AssignDetailId).IsEqualTo(AssignDetail_ID)
                        .And(TAssignDetail.Columns.PaymentStatus).IsEqualTo(1);
                    if (sqlQuery.GetRecordCount() > 0)
                    {
                        Utility.ShowMsg("Bạn chỉ có thể xóa những chỉ định chưa thanh toán !\n mời bạn xem lại",
                            "Thông báo", MessageBoxIcon.Warning);
                        return false;
                        break;
                    }
                }
                foreach (GridEXRow gridExRow in grdAssignDetail.GetCheckedRows())
                {
                    int AssignDetail_ID =
                        Utility.Int32Dbnull(gridExRow.Cells[TAssignDetail.Columns.AssignDetailId].Value, -1);
                    SqlQuery sqlQuery = new Select().From(TAssignDetail.Schema)
                        .Where(TAssignDetail.Columns.AssignDetailId).IsEqualTo(AssignDetail_ID)
                        .And(TAssignDetail.Columns.AssignDetailStatus).IsGreaterThanOrEqualTo(1);
                    if (sqlQuery.GetRecordCount() > 0)
                    {
                        Utility.ShowMsg("Bạn chỉ có thể xóa những chỉ định chưa xác nhận !\n Mời bạn xem lại",
                            "Thông báo", MessageBoxIcon.Warning);
                        return false;
                        break;
                    }
                }
            }

            return true;
        }

        #endregion

        #region Import

        private bool CheckValidData()
        {
            bool bRet = true;
            int count = 0;
            try
            {
                List<string> lstBarCode =
                    grdData.GetCheckedRows().Select(e => e.Cells[TAssignInfo.Columns.Barcode].Value.ToString()).ToList();
                string sBarcode = "";
                int iRow = 1;
                if (grdData.RowCount == 0)
                {
                    Utility.ShowMsg("Không có thông tin bệnh nhân", "Thông báo");
                    tabImportExcel.SelectedIndex = 0;
                    btnBrowse.Focus();
                    bRet = false;
                }
                else if (grdAssignDetail.RowCount == 0)
                {
                    Utility.ShowMsg("Không có thông tin chỉ định. Kiểm tra lại");
                    tabImportExcel.SelectedIndex = 1;
                    bRet = false;
                }
                else
                {
                    foreach (GridEXRow row in grdData.GetCheckedRows())
                    {
                        sBarcode = ChuanHoaChuoi(Utility.sDbnull(row.Cells[TAssignInfo.Columns.Barcode].Value, ""));
                        if (string.IsNullOrEmpty(sBarcode))
                        {
                            Utility.ShowMsg(string.Format("Dòng thứ {0} Không có Barcode. Kiểm tra lại", iRow),
                                "Thông báo", MessageBoxIcon.Warning);
                            bRet = false;
                            break;
                        }
                        iRow = iRow + 1;
                    }
                    if (bRet)
                    {
                        iRow = 1;
                        foreach (GridEXRow row in grdData.GetCheckedRows())
                        {
                            sBarcode = ChuanHoaChuoi(Utility.sDbnull(row.Cells[TAssignInfo.Columns.Barcode].Value, ""));
                            count = lstBarCode.Where(e => e.Equals(sBarcode)).ToList().Count;
                            if (count >= 2)
                            {
                                Utility.ShowMsg(
                                    string.Format("Dòng thứ {0} đã tồn tại Barcode {1}. Kiểm tra lại", iRow, sBarcode),
                                    "Thông báo", MessageBoxIcon.Warning);
                                bRet = false;
                                break;
                            }
                            iRow = iRow + 1;
                        }
                    }
                }
                if (grdData.GetCheckedRows().Length == 0)
                {
                    Utility.ShowMsg("Bạn cần chọn các bệnh nhân đẩy vào hệ thống", "Thông báo");
                    tabImportExcel.SelectedIndex = 0;
                    grdData.Focus();
                    bRet = false;
                }
            }
            catch (Exception ex)
            {
                bRet = false;
            }
            return bRet;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!CheckValidData()) return;
            tabImportExcel.SelectedIndex = 0;
            Save();
            cmdPush2Lab.Enabled = true;
        }

        private string ChuanHoaChuoi(string sValue)
        {
            sValue = sValue.Trim();
            sValue = sValue.Replace("'", "");
            return sValue;
        }


        private void Save()
        {
            progressImport.Maximum = grdData.GetCheckedRows().Length;
            progressImport.Value = 0;
            ImportData();
            //bgwImport = new BackgroundWorker();
            //bgwImport.WorkerReportsProgress = true;
            //bgwImport.WorkerSupportsCancellation = true;   
            //bgwImport.DoWork += new DoWorkEventHandler(bgwImport_DoWork);
            //bgwImport.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwImport_RunWorkerCompleted);
            //bgwImport.ProgressChanged += new ProgressChangedEventHandler(bgwImport_ProgressChanged);
            //bgwImport.RunWorkerAsync();            
        }

        private void bgwImport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // progressImport.Invoke((Action)(() => UpdateProgressBar()));
        }

        private void bgwImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_bSuccess)
            {
                if (_decFailed > 0)
                    Utility.ShowMsg(string.Format("Có {0} khách hàng import không thành công", _decFailed));
                else
                {
                    Utility.ShowMsg("Import dữ liệu thành công");
                }
            }
        }

        private void UpdateProgressBar()
        {
            try
            {
                int percent = 0;
                percent = _Value*100/grdData.GetCheckedRows().Length;
                progressImport.Text = string.Format("{0}%", percent);
                progressImport.Value = percent;
                progressImport.PerformStep();
            }
            catch
            {
            }
        }

        private void bgwImport_DoWork(object sender, DoWorkEventArgs e)
        {
            ImportData();
        }

        private void SetValue4Prg(ProgressBar Prg, int _Value)
        {
            try
            {
                if (Prg.InvokeRequired)
                {
                    Prg.Invoke(new SetPrgValue(SetValue4Prg), new object[] {Prg, _Value});
                }
                else
                {
                    if (Prg.Value + _Value <= Prg.Maximum) Prg.Value += _Value;
                    Prg.Refresh();
                }
            }
            catch
            {
            }
        }

        private void ImportData()
        {
            TAssignDetail objAssignDetail = null;
            TAssignInfo objAsignInfo = null;
            TPatientExam objPatientExam = null;
            TPatientInfo objPatientInfo = null;
            string SoCMND = "";
            string sNgaySinh = "";
            string sGioiTinh = "";
            string sCoQuan = "";
            string sChucVu = "";
            byte btGioitinh = 0;
            string sDiaChi = "";
            string sSDT = "";
            string sMaNV = "";
            var dtNgaySinh = new DateTime();
            _lstAssignDetail.Clear();
            if (!chkGhepLo.Checked) LaySoLoImportExcel();
            int iSTT = 1;
            _Value = 0;
            try
            {
                DateTime sysdate = BusinessHelper.GetSysDateTime();

                #region Get AssignInfo

                objAsignInfo = new TAssignInfo();
                objAsignInfo.ExamId = -1;
                objAsignInfo.TreatId = -1;
                objAsignInfo.PatientDeptId = -1;
                objAsignInfo.PatientCode = SoCMND;
                objAsignInfo.ServiceId = -1;
                objAsignInfo.ServiceTypeId = -1;
                objAsignInfo.RegDate = dtNgayNhap.Value;
                objAsignInfo.PaymentStatus = 0;
                objAsignInfo.CreatedBy = globalVariables.UserName;
                objAsignInfo.CreateDate = sysdate;
                objAsignInfo.ObjectTypeId = -1;
                objAsignInfo.MaKhoaThien = "KSK";
                objAsignInfo.Actived = 0;
                objAsignInfo.NoiTru = 0;

                objAsignInfo.IsPHIDvuKtheo = 0;

                #endregion

                #region Get AssignDetail

                foreach (DataRow dr in m_dtAssignDetail.Rows)
                {
                    objAssignDetail = new TAssignDetail();
                    objAssignDetail.ExamId = -1;
                    objAssignDetail.ServiceId = Convert.ToInt16(dr["Service_Id"]);
                    objAssignDetail.ServiceDetailId = Convert.ToInt16(dr["ServiceDetail_Id"]);
                    objAssignDetail.DiagPerson = Convert.ToInt16(dr["Diag_Person"]);
                    objAssignDetail.DiscountRate = Convert.ToDecimal(Utility.DecimaltoDbnull(dr["Discount_Rate"], 0));
                    objAssignDetail.DiscountType = Convert.ToByte(Utility.ByteDbnull(dr["Discount_Type"], 0));
                    objAssignDetail.OriginPrice = Convert.ToDecimal(Utility.DecimaltoDbnull(dr["Origin_Price"], 0));
                    objAssignDetail.DiscountPrice = Convert.ToDecimal(Utility.DecimaltoDbnull(dr["Discount_Price"], 0));
                    objAssignDetail.SurchargePrice = Convert.ToDecimal(Utility.DecimaltoDbnull(dr["Surcharge_Price"], 0));
                    objAssignDetail.UserId = globalVariables.UserName;
                    if (!string.IsNullOrEmpty(dr["Assign_Type_Id"].ToString()))
                        objAssignDetail.AssignTypeId = Convert.ToByte(Utility.ByteDbnull(dr["Assign_Type_Id"], 0));
                    else
                        objAssignDetail.AssignTypeId = 0;
                    objAssignDetail.InputDate = dtNgayNhap.Value;
                    objAssignDetail.PaymentStatus = 0;
                    objAssignDetail.IsCancel = 0;
                    objAssignDetail.IsPayment = 0;
                    objAssignDetail.ObjectTypeId = 1;
                    objAssignDetail.Quantity = Convert.ToInt32(dr["Quantity"]);
                    objAssignDetail.AssignDetailStatus = 0;
                    objAssignDetail.BhytStatus = 0;
                    objAssignDetail.DisplayOnReport = 0;
                    objAssignDetail.GiaBhytCt = 0;
                    objAssignDetail.PaymentId = 0;
                    objAssignDetail.ChoPhepIn = 0;
                    _lstAssignDetail.Add(objAssignDetail);
                }

                foreach (GridEXRow row in grdData.GetCheckedRows())
                {
                    string patient_code = Utility.sDbnull(row.Cells["patient_code"].Value, "");
                    if (patient_code == "")
                    {
                        _BussinessImportExcel = new BussinessImportExcel();

                        #region Get PatientInfo

                        SoCMND = ChuanHoaChuoi(row.Cells["CMT"].Value.ToString());
                        sNgaySinh = ChuanHoaChuoi(row.Cells["NGAY_SINH"].Value.ToString());
                        sGioiTinh = ChuanHoaChuoi(row.Cells["GIOI_TINH"].Value.ToString());
                        sCoQuan = ChuanHoaChuoi(row.Cells["CO_QUAN"].Value.ToString());
                        sChucVu = ChuanHoaChuoi(row.Cells["CHUC_VU"].Value.ToString());
                        sSDT = ChuanHoaChuoi(row.Cells["SDT"].Value.ToString());
                        sMaNV = ChuanHoaChuoi(row.Cells["Ma_NV"].Value.ToString());
                        // sDiaChi = ChuanHoaChuoi(row.Cells["DIA_CHI"].Value.ToString());
                        sDiaChi = ChuanHoaChuoi(row.Cells["DIACHI"].Value.ToString());
                        if (sGioiTinh.ToLower().Equals("m")) btGioitinh = 0;
                        else if (sGioiTinh.ToLower().Equals("f")) btGioitinh = 1;
                        else if (sGioiTinh.ToLower().Equals("nam")) btGioitinh = 0;
                        else if (sGioiTinh.ToLower().Equals("nữ")) btGioitinh = 1;
                        else btGioitinh = 2;

                        if (string.IsNullOrEmpty(SoCMND)) SoCMND = dtNgayNhap.Value.ToString("yyyyMMdd") + "@" + iSTT;
                        objPatientInfo = new TPatientInfo();
                        objPatientInfo.CountryId = 1;
                        objPatientInfo.DanToc = 1;
                        objPatientInfo.IdentifyNum = SoCMND;
                        objPatientInfo.InputDate = dtNgayNhap.Value;
                        objPatientInfo.Locked = 0;
                        objPatientInfo.PatientJob = sChucVu;
                        objPatientInfo.PatientName = ChuanHoaChuoi(row.Cells["HO_TEN"].Value.ToString());
                        objPatientInfo.PatientEmail = sMaNV;
                        objPatientInfo.PatientPhone = sSDT;
                        objPatientInfo.PatientAddr = sDiaChi;
                        objPatientInfo.PatientSex = btGioitinh;
                        objPatientInfo.Offices = sCoQuan;
                        objPatientInfo.UserId = globalVariables.UserName;
                        objPatientInfo.NgayTao = sysdate;
                        int namsinh = DateTime.Now.Year;
                        DateTime ngay_sinh = DateTime.Now;
                        if (!string.IsNullOrEmpty(sNgaySinh))
                        {
                            try
                            {
                                if (sNgaySinh.TrimStart().TrimEnd() == "")
                                {
                                    namsinh = BusinessHelper.GetSysDateTime().Year;
                                    ngay_sinh = new DateTime(namsinh, 1, 1);
                                }
                                if (sNgaySinh.TrimStart().TrimEnd().Length == 4)
                                {
                                    namsinh = Utility.Int32Dbnull(sNgaySinh, BusinessHelper.GetSysDateTime().Year);
                                    ngay_sinh = new DateTime(namsinh, 1, 1);
                                }
                                else
                                {
                                    ngay_sinh = Convert.ToDateTime(sNgaySinh);
                                    namsinh = ngay_sinh.Year;
                                }
                            }
                            catch
                            {
                            }
                            objPatientInfo.PatientBirth = ngay_sinh;
                            objPatientInfo.YearOfBirth = (Int16) namsinh;
                        }
                        objPatientInfo.SoLo = Convert.ToInt32(txtLo.Text);

                        #endregion

                        #region Get PatientExam

                        objPatientExam = new TPatientExam();
                        objPatientExam.PatientCode = SoCMND;
                        objPatientExam.ObjectTypeId = 1;
                        objPatientExam.HosTrans = 0;
                        objPatientExam.InputDate = objPatientInfo.InputDate;
                        objPatientExam.UserId = objPatientInfo.UserId;
                        objPatientExam.HosStatus = 0;
                        objPatientExam.DiscountRate = 0;
                        objPatientExam.Locked = 0;
                        objPatientExam.IndentityNo = 1;
                        objPatientExam.DisplayOnReport = 0;
                        objPatientExam.NgayTao = objPatientInfo.NgayTao;
                        objPatientExam.NguoiTao = objPatientInfo.UserId;
                        objPatientExam.MaKhoaThien = "KSK";
                        objPatientExam.MaDoiTuong = "DV";
                        objPatientExam.EmergencyHos = 0;

                        #endregion

                        objAsignInfo.Barcode =
                            ChuanHoaChuoi(Utility.sDbnull(row.Cells[TAssignInfo.Columns.Barcode].Value, ""));

                        iSTT = iSTT + 1;


                        row.BeginEdit();
                        string sMaDonVi = "";
                        string errMsg = "";

                        if (
                            !_BussinessImportExcel.Save(objPatientInfo, objPatientExam, objAsignInfo, _lstAssignDetail,
                                dtNgayNhap.Value, sMaDonVi, ref errMsg))
                        {
                            row.Cells["_Error"].Value = 1;
                            _decFailed = _decFailed + 1;
                            Utility.ShowMsg(
                                "Import dữ liệu không thành công. Bạn hãy nhấn vào nút tìm kiếm theo lô và thực hiện xóa trước khi import lại.\n" +
                                errMsg);
                            return;
                        }
                        _Value = _Value + 1;
                        row.Cells["_Error"].Value = 0;
                        row.Cells["patient_code"].Value = objPatientExam.PatientCode;
                        row.Cells["patient_id"].Value = objPatientExam.PatientId;
                        row.Cells["assign_code"].Value = objAsignInfo.MaChidinh;
                        row.Cells["assign_id"].Value = objAsignInfo.AssignId;
                        row.EndEdit();
                        SetValue4Prg(progressImport, 1);
                        Application.DoEvents();
                        //if (iSTT % 10 == 0) System.Threading.Thread.Sleep(1000);
                        //Application.DoEvents();

                        #endregion
                    }
                    else
                    {
                        SetValue4Prg(progressImport, 1);
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Import dữ liệu không thành công" + ex.Message);
            }
        }

        private delegate void SetPrgValue(ProgressBar Prg, int _Value);

        #endregion

        #region Print report

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReport();
        }

        private void PrintReport()
        {
            try
            {
                if (_lstPatientInfo == null)
                {
                    Utility.ShowMsg("Không có dữ liệu in báo cáo");
                    return;
                }
                TPatientExam objPatientExam = null;
                foreach (TPatientInfo objPatientInfo in _lstPatientInfo)
                {
                    m_dtReport.Clear();
                    objPatientExam =
                        _lstPatientExam.Where(e => e.PatientId.Equals(objPatientInfo.PatientId)).FirstOrDefault();
                    DataRow dr = m_dtReport.NewRow();
                    dr["Patient_Addr"] = objPatientInfo.PatientAddr;
                    dr["Patient_Code"] = objPatientExam.PatientCode;
                    dr["NGHE_NGHIEP"] = objPatientInfo.PatientJob;
                    dr["Patient_Name"] = objPatientInfo.PatientName;
                    dr["Patient_Email"] = objPatientInfo.PatientEmail;
                    dr["Patient_ID"] = objPatientInfo.PatientId;
                    if (objPatientInfo.YearOfBirth != null)
                    {
                        dr["nam_sinh"] = objPatientInfo.YearOfBirth;
                        dr["tuoi"] = DateTime.Now.Year - objPatientInfo.YearOfBirth;
                    }
                    if (objPatientInfo.PatientSex == 1)
                        dr["Patient_Sex"] = "Nữ";
                    else
                        dr["Patient_Sex"] = "Nam";
                    m_dtReport.Rows.Add(dr);
                    LAOKHOA_InPhieuKhambenh_DV(m_dtReport, "PHIẾU KHÁM BỆNH", "A4");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi trong quá trình in report");
            }
        }

        private void LAOKHOA_InPhieuKhambenh_DV(DataTable m_dtReport, string sTitleReport, string KhoGiay)
        {
            var crpt = new ReportDocument();
            string path = "";
            switch (KhoGiay)
            {
                case "A4":

                    path = Utility.sDbnull(SystemReports.GetPathReport("PHIEU_KHAM_DV_A4"));
                    break;
                case "A5":
                    path = Utility.sDbnull(SystemReports.GetPathReport("PHIEU_KHAM_DV_A5"));
                    // crpt = new CRPT_BAOCAO_PHIEUKHAMBENH_DICHVU_A5();
                    break;
                default:

                    path = Utility.sDbnull(SystemReports.GetPathReport("PHIEU_KHAM_DV_A4"));
                    break;
            }


            if (File.Exists(path))
            {
                crpt.Load(path);
            }
            else
            {
                Utility.ShowMsg(string.Format("Không tìm thấy File {0}", path), "Thông báo không tìm thấy File",
                    MessageBoxIcon.Warning);
                return;
            }

            // var crpt = reportDocument;
            var objForm = new frmPrintPreview(sTitleReport, crpt, true, m_dtReport.Rows.Count <= 0 ? false : true);
            try
            {
                m_dtReport.AcceptChanges();
                crpt.SetDataSource(m_dtReport);
                objForm.crptViewer.ReportSource = crpt;
                objForm.crptTrinhKyName = Path.GetFileName(path);
                crpt.DataDefinition.FormulaFields["Formula_1"].Text = Strings.Chr(34) +
                                                                      "  PHÒNG TIẾP ĐÓN   ".Replace("#$X$#",
                                                                          Strings.Chr(34) + "&Chr(13)&" +
                                                                          Strings.Chr(34)) + Strings.Chr(34);
                crpt.SetParameterValue("Phone", globalVariables.Branch_Phone);
                crpt.SetParameterValue("Address", globalVariables.Branch_Address);
                crpt.SetParameterValue("BranchName", globalVariables.Branch_Name);
                crpt.SetParameterValue("CurrentDate", Utility.FormatDateTime(BusinessHelper.GetSysDateTime()));
                crpt.SetParameterValue("sTitleReport", sTitleReport);
                crpt.SetParameterValue("BottomCondition", BusinessHelper.BottomCondition());
                crpt.PrintOptions.PrinterName = _hisPrintProperties.Tenmayinphieukham;
                crpt.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception ex)
            {
                if (globalVariables.IsAdmin)
                {
                    Utility.ShowMsg(ex.ToString());
                }
            }
        }

        #endregion

        #region Config

        private void cmdCauhinh_Click(object sender, EventArgs e)
        {
            var frm = new frm_CauHinh_Mayin();
            frm._HISPrintProperties = _hisPrintProperties;
            frm.ShowDialog();
            _hisPrintProperties = Utility.GetPrintPropertiesConfig();
        }

        #endregion

        private readonly string strWebservicePath = Application.StartupPath + @"\CAUHINH\Webservice_moi.txt";

        private void chkGhepLo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGhepLo.Checked)
                txtLo.ReadOnly = false;
            else
            {
                LaySoLoImportExcel();
                txtLo.ReadOnly = true;
            }
            //btnBrowse.Enabled = !chkGhepLo.Checked;
            //btnImport.Enabled = !chkGhepLo.Checked;
            cmdSearchByLo.Enabled = chkGhepLo.Checked;
            cmdXoalo.Enabled = chkGhepLo.Checked;
        }

        private void cmdSearchByLo_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable dt = SPs.KskLaydulieutheolo(Utility.Int32Dbnull(txtLo.Text, -1)).GetDataSet().Tables[0];
                //grdData.DataSource = dt;
                //grdData.CheckAllRecords();
                //cmdXoalo.Enabled = grdData.GetDataRows().Count() > 0 && chkGhepLo.Checked;
                //cmdPush2Lab.Enabled = grdData.GetCheckedRows().Length > 0;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void _BussinessImportExcel__OnDoing(int value)
        {
            SetValue4Prg(progressImport, 1);
        }

        private void cmdXoalo_Click(object sender, EventArgs e)
        {
            if (Utility.AcceptQuestion("Bạn có chắc chắn muốn xóa dữ liệu lô vừa chọn", "Cảnh báo", true))
            {
                _BussinessImportExcel = new BussinessImportExcel();
                _BussinessImportExcel._OnDoing += _BussinessImportExcel__OnDoing;
                _Value = 0;
                var lstID = new List<int>();
                progressImport.Maximum = grdData.GetCheckedRows().Length;
                progressImport.Value = 0;
                foreach (GridEXRow row in grdData.GetCheckedRows())
                {
                    int patient_id = Utility.Int32Dbnull(row.Cells["patient_id"].Value, -1);
                    lstID.Add(patient_id);
                }
                _BussinessImportExcel.DeleteData(lstID, wait4Tu);
                Utility.ShowMsg("Đã xóa xong dữ liệu. Nhấn OK để kết thúc");
            }
        }

        private void cmdPush2Lab_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmdPush2Lab.Tag.ToString() == "0")
                {
                    cmdPush2Lab.Text = "Dừng đẩy";
                    cmdPush2Lab.Tag = "1";
                    progressImport.Value = 0;
                    progressImport.Maximum = grdData.GetCheckedRows().Count();
                    foreach (GridEXRow row in grdData.GetCheckedRows())
                    {
                        string ma_chidinh = Utility.sDbnull(row.Cells["assign_code"].Value, "Unknown");
                        long assign_id = Utility.Int32Dbnull(row.Cells["assign_id"].Value, -1);
                        int AssignDetail_Status = Utility.Int32Dbnull(row.Cells["AssignDetail_Status"].Value, 0);
                        string patient_code = Utility.sDbnull(row.Cells["patient_code"].Value, "Unknown");
                        if (AssignDetail_Status == 0 && ma_chidinh != "" && patient_code != "" && assign_id != -1)
                        {
                            var _HISLISItem = new HISLISItem(ma_chidinh, (int) assign_id, patient_code, log);
                            _HISLISManager.AddItems2Queue(_HISLISItem);
                        }
                        if (progressImport.Value + 1 <= progressImport.Maximum) progressImport.Value += 1;
                    }
                }
                else
                {
                    cmdPush2Lab.Text = "Đẩy vào Lab";
                    cmdPush2Lab.Tag = "0";
                    _HISLISManager.Stop();
                }
            }
            catch
            {
            }
        }

        private void mnuDelLog_Click(object sender, EventArgs e)
        {
            rtxtLogs.Clear();
        }

        private void cmdSaveWebservice_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Utility.SetMsg(lblmsg1, "", false);
            //    if (txtWebService.Text.TrimStart().TrimEnd() == "")
            //    {
            //        Utility.SetMsg(lblmsg1, "Bạn cần nhập địa chỉ webservice", true);
            //        txtWebService.Focus();
            //        return;
            //    }
            //    using (var _writer = new StreamWriter(strWebservicePath))
            //    {
            //        _writer.WriteLine(txtWebService.Text.TrimStart().TrimEnd());
            //        _writer.Flush();
            //        _writer.Close();
            //    }
            //}
            //catch
            //{
            //}
            //finally
            //{
            //    globalVariables.WebPath = txtWebService.Text.TrimStart().TrimEnd();
            //}
        }

        private void GetWebservice()
        {
            //try
            //{
            //    if (!File.Exists(strWebservicePath))
            //    {
            //        Utility.ShowMsg(
            //            "Bạn cần cấu hình địa chỉ webservice kết nối với hệ thống Lablink trước khi sử dụng tính năng này");
            //        tabImportExcel.SelectedTab = uiTabPageWebservice;
            //        txtWebService.Focus();
            //        return;
            //    }
            //    using (var _Reader = new StreamReader(strWebservicePath))
            //    {
            //        txtWebService.Text = _Reader.ReadToEnd();
            //        _Reader.BaseStream.Flush();
            //        _Reader.Close();
            //    }
            //}
            //catch
            //{
            //}
            //finally
            //{
            //    globalVariables.WebPath = txtWebService.Text.TrimStart().TrimEnd();
            //}
        }

        private void mnuSelectNoImports_Click(object sender, EventArgs e)
        {
            foreach (GridEXRow row in grdData.GetCheckedRows())
            {
                string patient_code = Utility.sDbnull(row.Cells["patient_code"].Value, "");
                if (patient_code != "")
                    row.IsChecked = false;
            }
        }
    }
}