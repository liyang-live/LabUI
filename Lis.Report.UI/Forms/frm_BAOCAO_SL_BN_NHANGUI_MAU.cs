using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Transactions;
using System.Windows.Forms;
using Janus.Windows.CalendarCombo;

using LIS.DAL;
using Lis.Report.UI;
using Lis.Report.UI.Reports;
using SubSonic;
using VNS.Libs;
using Microsoft.VisualBasic;


namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frm_BAOCAO_SL_BN_NHANGUI_MAU : Form
    {
        public frm_BAOCAO_SL_BN_NHANGUI_MAU()
        {
            InitializeComponent();
            ReportBusiness.CreateManagementUnit();
            Utility.loadIconToForm(this);
            
        }

        private DataTable _dtObjectType;

        private DataTable _dtDepartment;

        private DataTable _dtLoaiXetNghiem;
        private DataTable _dtUser;
        void LoadDataCombobox()
        {
            try
            {
                _dtObjectType = new LObjectTypeController().FetchAll().ToDataTable();
                DataBinding.BindDataCombobox_Basic(cboObjectType, _dtObjectType, LObjectType.Columns.Id, LObjectType.Columns.SName);

                _dtDepartment = new LDepartmentController().FetchAll().ToDataTable();
                DataBinding.BindDataCombobox_Basic(cboDepartment, _dtDepartment, LDepartment.Columns.Id, LDepartment.Columns.SName);

                _dtLoaiXetNghiem = new TTestTypeListController().FetchAll().ToDataTable();
                DataBinding.BindDataCombobox_Basic(cboLoaiXN, _dtLoaiXetNghiem, TTestTypeList.Columns.TestTypeId, TTestTypeList.Columns.TestTypeName);



                _dtUser = new Select().From(SysUser.Schema).ExecuteDataSet().Tables[0];
                //foreach (DataRow row in _dtUser.Rows)
                //{
                //    if(string.IsNullOrEmpty(Utility.sDbnull(row[TblUser.Columns.SFullName],"")))
                //    {
                //        row[TblUser.Columns.SFullName] = row[TblUser.Columns.PkSuid].ToString();
                //    }
                //}
                _dtUser.AcceptChanges();
                DataBinding.BindDataCombobox_Basic(cboNguoiGui, _dtUser, SysUser.Columns.PkSuid, SysUser.Columns.SFullName);
                
                cboNguoiNhan.DataSource = _dtUser;
                cboNguoiNhan.DisplayMember = SysUser.Columns.SFullName;
                cboNguoiNhan.ValueMember = SysUser.Columns.PkSuid;
                cboNguoiNhan.SelectedIndex = 0;
                cboTrangThaiBN.SelectedIndex = 0;
                cboTrangthai.SelectedIndex = 0;
                cboStatusPrint.SelectedIndex = 0;
                
            }
            catch (Exception)
            {
                Utility.ShowMsg("Có lỗi trong quá trình lấy thông tin combobox");
                return;
            }
        }
        private void frm_BAOCAO_SL_BN_NHANGUI_MAU_Load(object sender, EventArgs e)
        {
            LoadDataCombobox();
        }

        private DataTable _dtPrint;
        private DataSet dsPrint;
        void PrintData()
        {
            try
            {
                dsPrint =
                    SPs.BaocaoSoluongNhanguiMau(dtpFromDate.Value, dtpToDate.Value,
                                                Utility.Int32Dbnull(cboObjectType.SelectedValue),
                                                Utility.Int32Dbnull(cboLoaiXN.SelectedValue, -1),
                                                Utility.Int32Dbnull(cboDepartment.SelectedValue, -1),
                                                Utility.Int32Dbnull(cboTrangThaiBN.SelectedValue, -1),
                                                Utility.Int32Dbnull(cboTrangthai.SelectedValue, -1),
                                                Utility.sDbnull(cboNguoiNhan.SelectedValue, "-1"),
                                                Utility.sDbnull(cboNguoiGui.SelectedValue, "-1"), Utility.Int32Dbnull(cboStatusPrint.SelectedValue, -1), Utility.Int32Dbnull(chkGionhan.Checked, -1)).GetDataSet();
                _dtPrint = dsPrint.Tables[0];

                if(_dtPrint.Rows.Count <=0)
                {
                    Utility.ShowMsg("Không có dữ liệu theo điều kiện bạn chọn");
                    return;
                }

                using (var Scope = new TransactionScope())
                {
                    using (var dbScope = new SharedDbConnectionScope())
                    {
                        foreach (Janus.Windows.GridEX.GridEXRow gridExRow in grdList.GetCheckedRows())
                        {
                            new Update(TTestInfo.Schema).Set(TTestInfo.Columns.PrintStatus).EqualTo(
                                Utility.Int32Dbnull(1)).Where(TTestInfo.Columns.PatientId).IsEqualTo(
                                    Utility.Int32Dbnull(gridExRow.Cells[TTestInfo.Columns.PatientId].Value, -1)).Execute();
                            gridExRow.BeginEdit();
                            gridExRow.Cells[TTestInfo.Columns.PrintStatus].Value = 1;
                            gridExRow.EndEdit();
                        }
                    }
                    _dtPrint.AcceptChanges();
                    Scope.Complete();
                }
                PrintView(_dtPrint);
            }
            catch (Exception)
            {
                Utility.ShowMsg("Có lỗi trong quá trình lấy thông tin báo cáo");
            }
        }

        private void PrintView(DataTable dtPrint)
        {
            crpt_BAOCAO_SLUONG_BN_NHANGUI_MAU crpt = new crpt_BAOCAO_SLUONG_BN_NHANGUI_MAU();
           var  frm =
                new frmPrintPreview("BÁO CÁO SỐ LƯỢNG BỆNH NHÂN NHẬN GỬI MẪU", crpt, true, true);
            Utility.UpdateLogotoDatatable(ref dtPrint);
            crpt.SetDataSource(dtPrint);
            crpt.SetParameterValue("TIEUDE", "BÁO CÁO SỐ LƯỢNG BỆNH NHÂN NHẬN GỬI MẪU");
            crpt.SetParameterValue("DateTime",
                                   "Từ ngày: " + dtpFromDate.Value.ToShortDateString() + " đến ngày: " +
                                   dtpToDate.Value.ToShortDateString());
            crpt.DataDefinition.FormulaFields["Formula_1"].Text = Strings.Chr(34) +
                                                                  "        NGƯỜI LẬP                                       THỦ TRƯỞNG ĐƠN VỊ           "
                                                                      .Replace("#$X$#",
                                                                               Strings.Chr(34) + "&Chr(13)&" + Strings.Chr(34)) +
                                                                  Strings.Chr(34);

            crpt.SetParameterValue("ParentBranchName", globalVariables.ParentBranch_Name);
            crpt.SetParameterValue("BranchName", globalVariables.Branch_Name);
            crpt.SetParameterValue("sCurrentDate", Utility.FormatDateTime(dtCreateDate.Value));
            frm.ShowDialog();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            PrintData();
        }

        private void cboThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if(dtpFromDate.Value > dtpToDate.Value)
            {
                dtpToDate.ValueChanged -= dtpToDate_ValueChanged;
                dtpToDate.Value = dtpFromDate.Value;
                dtpToDate.ValueChanged += dtpToDate_ValueChanged;
            }

        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if(dtpToDate.Value < dtpFromDate.Value)
            {
                dtpFromDate.ValueChanged -= dtpFromDate_ValueChanged;
                dtpFromDate.Value = dtpToDate.Value;
                dtpFromDate.ValueChanged += dtpFromDate_ValueChanged; 
            }

        }

        private void frm_BAOCAO_SL_BN_NHANGUI_MAU_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F4)
                cmdPrint.PerformClick();
            else if(e.KeyCode == Keys.Escape)
                cmdThoat.PerformClick();
            else if(e.KeyCode == Keys.F3)
                cmdThongKe.PerformClick();
            else if(e.KeyCode == Keys.F5)
                cmdInLai.PerformClick();
        }

        private void cboThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                _dtPrint =
                    SPs.BaocaoSoluongNhanguiMau(dtpFromDate.Value, dtpToDate.Value, Utility.Int32Dbnull(cboObjectType.SelectedValue),
                                                Utility.Int32Dbnull(cboLoaiXN.SelectedValue, -1),
                                                Utility.Int32Dbnull(cboDepartment.SelectedValue, -1),
                                                Utility.Int32Dbnull(cboTrangThaiBN.SelectedValue, -1), Utility.Int32Dbnull(cboTrangthai.SelectedValue, -1), Utility.sDbnull(cboNguoiNhan.SelectedValue, "-1"), Utility.sDbnull(cboNguoiGui.SelectedValue, "-1"), Utility.Int32Dbnull(cboStatusPrint.SelectedValue, -1), Utility.Int32Dbnull(chkGionhan.Checked, -1)).GetDataSet().
                        Tables[0];

                grdList.DataSource = _dtPrint;

            }
            catch (Exception)
            {
                Utility.ShowMsg("Có lỗi trong quá trình lấy dữ liệu");               
            }
        }

        private void cmdInLai_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dtPrint.Select("CHON = 1").GetLength(0) < 0)
                {
                    Utility.ShowMsg("Bạn phải chọn bản ghi để in");
                    return;
                }
                PrintView(_dtPrint.Select("CHON = 1").CopyToDataTable());
            }
            catch (Exception)
            {
                Utility.ShowMsg("Có lỗi trong quá trình xử lý in");                
            }
        }
    }
}
