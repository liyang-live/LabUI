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
using SubSonic;
using VNS.Libs;
using Microsoft.VisualBasic;



namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frm_BAOCAO_SLUONG_KPHONG_GUI : Form
    {
        private DataTable m_dtReport=new DataTable();
        private string sTitleReport = "";
        public frm_BAOCAO_SLUONG_KPHONG_GUI(string TitleReport)
        {
            InitializeComponent();
            this.KeyPreview = true;
            ReportBusiness.CreateManagementUnit();
            sTitleReport = TitleReport;
            cboHosStatus.SelectedIndex = 0;
            dtToDate.Value = dtCreateDate.Value = dtFromDate.Value = DateTime.Now;
            cboLoaiBaoCao.SelectedIndex = 0;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_BAOCAO_SLUONG_KPHONG_GUI_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)cmdClose.PerformClick();
            if (e.KeyCode == Keys.F4) cmdPrint.PerformClick();
        }

        private void frm_BAOCAO_SLUONG_KPHONG_GUI_Load(object sender, EventArgs e)
        {
            IntialData();
        }
        private void IntialData()
        {
            SqlQuery sqlQuery = new Select().From(LObjectType.Schema);

           DataBinding.BindDataCombox(cboDoiTuong, sqlQuery.ExecuteDataSet().Tables[0],
                                                              LObjectType.Columns.Id, LObjectType.Columns.SName,
                                                              "---Đối tượng---");
            sqlQuery = new Select().From(LDepartment.Schema);
           DataBinding.BindDataCombox(cboKhoa, sqlQuery.ExecuteDataSet().Tables[0],
                                                            LDepartment.Columns.Id, LDepartment.Columns.SName,
                                                            "---Khoa phòng--");

            sqlQuery = new Select().From(TTestTypeList.Schema).OrderAsc(TTestTypeList.Columns.IntOrder);
           DataBinding.BindDataCombox(cboLoaiXN, sqlQuery.ExecuteDataSet().Tables[0],
                                                           TTestTypeList.Columns.TestTypeId, TTestTypeList.Columns.TestTypeName,
                                                           "---Loại xét nghiệm--");
           sqlQuery = new Select().From(SysUser.Schema).OrderAsc(SysUser.Columns.SFullName);
           DataBinding.BindDataCombobox_Basic(cboNguoiDung, sqlQuery.ExecuteDataSet().Tables[0],
                                                          SysUser.Columns.PkSuid, SysUser.Columns.SFullName);
        }
        /// <summary>
        /// hàm thực hiện in báo cáo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPrint_Click(object sender, EventArgs e)
        {
           
            m_dtReport =
                SPs.NhtdBaocaoSluongPkhamGuilen(
                    chkByDate.Checked ? dtFromDate.Value : Convert.ToDateTime("01/01/1900"),
                    chkByDate.Checked ? dtToDate.Value : DateTime.Now,
                    Utility.Int32Dbnull(cboDoiTuong.SelectedValue, -1), Utility.Int32Dbnull(cboLoaiXN.SelectedValue, -1),
                    Utility.Int32Dbnull(cboKhoa.SelectedValue, -1), Utility.Int32Dbnull(cboHosStatus.SelectedValue, -1),
                    Utility.sDbnull(cboLoaiBaoCao.SelectedValue, ""), Utility.sDbnull(cboNguoiDung.SelectedValue, "")).
                    GetDataSet().Tables[0];
            if (m_dtReport.Rows.Count <= 0)
            {
                Utility.ShowMsg("Không tìm thấy bản ghi nào", "Thông báo");
                return;
            }
            string sTungayDenNgay = dtFromDate.Value.Date != dtToDate.Value.Date
                                      ? string.Format("{0} --- đến --- {1}", Getsday(dtFromDate.Value),
                                                      Getsday(dtToDate.Value))
                                      : Getsday(dtFromDate.Value);
            Utility.WaitNow(this);
            CRPT_BAOCAO_SLUONG_XETNGHIEM crpt = new CRPT_BAOCAO_SLUONG_XETNGHIEM();//=  GetReportDocument(cboReportType.SelectedIndex,cboObjectType.SelectedIndex);
            frmPrintPreview objForm = new frmPrintPreview("THỐNG KÊ TỔNG HỢP SỐ LƯỢNG XÉT NGHIỆM GỬI", crpt, true, true);

            try
            {
                crpt.SetDataSource(m_dtReport);
                crpt.DataDefinition.FormulaFields["Formula_1"].Text = Strings.Chr(34) + "        NGƯỜI LẬP                                       THỦ TRƯỞNG ĐƠN VỊ           ".Replace("#$X$#", Strings.Chr(34) + "&Chr(13)&" + Strings.Chr(34)) + Strings.Chr(34);
                crpt.SetParameterValue("ParentBranchName", globalVariables.ParentBranch_Name);
                crpt.SetParameterValue("BranchName", globalVariables.Branch_Name);
             //   crpt.SetParameterValue("ReportCondition", GetReportCondition());
                crpt.SetParameterValue("sCurrentDate", Utility.FormatDateTime(dtCreateDate.Value));
                crpt.SetParameterValue("sTitleReport",sTitleReport);
                crpt.SetParameterValue("sTuNgayDenNgay", sTungayDenNgay);
                objForm.crptViewer.ReportSource = crpt;

                objForm.ShowDialog();
               // Utility.DefaultNow(this);
                Utility.DefaultNow(this);
            }
            catch (Exception ex)
            {
                Utility.DefaultNow(this);
            }

        }
        /// <summary>
        /// thuc hien in bao cao theo kieu thu 3 la in bao cao so luong hang ngay
        /// </summary>
        /// <param name="m_dsReport"></param>
        /// <param name="pv_date"> </param>
        public string Getsday(DateTime pv_date)
        {
            return string.Format("Ngày {0} tháng {1} năm {2}", pv_date.Day, pv_date.Month, pv_date.Year);
        }
        private void chkByDate_CheckedChanged(object sender, EventArgs e)
        {
            dtFromDate.Enabled = dtToDate.Enabled = chkByDate.Checked;
        }
    }
}
