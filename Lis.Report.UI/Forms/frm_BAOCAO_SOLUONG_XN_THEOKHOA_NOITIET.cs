using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LIS.DAL;
using Lis.Report.UI;
using Lis.Report.UI.Reports;
using VNS.Libs;

using SubSonic;
using Microsoft.VisualBasic;

namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frm_GTVT_BAOCAO_SOLUONG_XN_THEOKHOA_NOITIET : Form
    {
        public frm_GTVT_BAOCAO_SOLUONG_XN_THEOKHOA_NOITIET()
        {
            InitializeComponent();
            ReportBusiness.CreateManagementUnit();
        }


        void LoadDataToCombobox()
        {
            try
            {
                DataTable dtDepartment = new Select().From(LDepartment.Schema).ExecuteDataSet().Tables[0];
                DataBinding.BindDataCombobox_Basic(cboDepartment,dtDepartment, LDepartment.Columns.Id, LDepartment.Columns.SName);

                DataTable dtDoctor = new Select().From(LUser.Schema).ExecuteDataSet().Tables[0];
                DataBinding.BindDataCombobox_Basic(cboDoctor, dtDoctor, LUser.Columns.UserId, LUser.Columns.UserName);

                DataTable dtObjectType = new Select().From(LObjectType.Schema).ExecuteDataSet().Tables[0];
                DataBinding.BindDataCombobox_Basic(cboObjectType, dtObjectType, LObjectType.Columns.Id, LObjectType.Columns.SName);

                DataTable dtTestTypeList = new Select().From(TTestTypeList.Schema).ExecuteDataSet().Tables[0];
                DataBinding.BindDataCombobox_Basic(cboTestTypeList, dtTestTypeList, TTestTypeList.Columns.TestTypeId, TTestTypeList.Columns.TestTypeName);

            }
            catch (Exception)
            {
                Utility.ShowMsg("Có lỗi trong quá trình lấy thông tin combobox");
                throw;
            }
        }
        private void frm_BAOCAO_SOLUONG_XN_THEOKHOA_Load(object sender, EventArgs e)
        {
            LoadDataToCombobox();
        }

        private DataTable dtPrint;
        void LoadDataPrint()
        {
            try
            {
                dtPrint =
                    SPs.GetDataSlXnTheokhoaBacsi(dtpFromDate.Value, dtpToDate.Value,
                                                 Utility.Int32Dbnull(cboDepartment.SelectedValue, -1),
                                                 Utility.Int32Dbnull(cboDoctor.SelectedValue, -1),
                                                 Utility.Int32Dbnull(cboObjectType.SelectedValue, -1),
                                                 Utility.Int32Dbnull(cboTestTypeList.SelectedValue, -1)).GetDataSet().
                        Tables[0];
                if(dtPrint.Rows.Count <= 0)
                {
                    Utility.ShowMsg("Không có dữ liệu theo điều kiện bạn chọn");
                    return;
                }
                var crpt = new crpt_BAOCAO_SOLUONG_XN_THEOKHOA();
                var objForm = new frmPrintPreview("BÁO CÁO SỐ LƯỢNG XÉT NGHIỆM", crpt, true, true);
                Utility.UpdateLogotoDatatable(ref dtPrint);

                crpt.SetDataSource(dtPrint);
                crpt.DataDefinition.FormulaFields["Formula_1"].Text = Strings.Chr(34) + "        NGƯỜI LẬP                                       THỦ TRƯỞNG ĐƠN VỊ           ".Replace("#$X$#", Strings.Chr(34) + "&Chr(13)&" + Strings.Chr(34)) + Strings.Chr(34);
                crpt.SetParameterValue("ParentBranchName", globalVariables.ParentBranch_Name);
                crpt.SetParameterValue("BranchName", globalVariables.Branch_Name);
                crpt.SetParameterValue("Branch_Address", globalVariables.Branch_Address);
                crpt.SetParameterValue("Branch_Phone", globalVariables.Branch_Phone);
                crpt.SetParameterValue("Khoa", cboDepartment.Text);
                crpt.SetParameterValue("BacSi", cboDoctor.Text);
                crpt.SetParameterValue("NgayIn", dtpDatePrint.Value.Date);
                crpt.SetParameterValue("TileRepost", "BÁO CÁO SỐ LƯỢNG XÉT NGHIỆM");
                crpt.SetParameterValue("DateTime","Từ ngày " + dtpFromDate.Value.ToShortDateString() + " đến ngày " + dtpToDate.Value.ToShortDateString());
                objForm.ShowDialog();


            }
            catch (Exception)
            {
                Utility.ShowMsg("Có lỗi trong quá trình lấy thông tin báo cáo");
                throw;
            }
        }
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            LoadDataPrint();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_BAOCAO_SOLUONG_XN_THEOKHOA_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F4)
            {
                cmdPrint.PerformClick();
            }
            else if(e.KeyCode == Keys.Escape)
            {
                cmdCancel.PerformClick();
            }
        }
    }
}
