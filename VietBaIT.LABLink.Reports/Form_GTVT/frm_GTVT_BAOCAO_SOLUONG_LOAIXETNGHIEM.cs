using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Lis.BaoCao.Reports;
using LIS.DAL;
using SubSonic;
using Microsoft.VisualBasic;
using VNS.Libs;

using Vietbait.Lablink.Report.Business;

namespace VietBaIT.LABLink.Reports.Form_GTVT
{
    public partial class frm_GTVT_BAOCAO_SOLUONG_LOAIXETNGHIEM : Form
    {
        private DataTable m_dtObjectType=new DataTable();
        public frm_GTVT_BAOCAO_SOLUONG_LOAIXETNGHIEM()
        {
            InitializeComponent();
            ReportBusiness.CreateManagementUnit();
            cboHos_Status.SelectedIndex = 0;
            dtToDate.Value = dtFromDate.Value = dtCreatePrint.Value = Utility.getSysDate();
        }

        private void frm_GTVT_BAOCAO_SOLUONG_LOAIXETNGHIEM_Load(object sender, EventArgs e)
        {
            IntitalData();
           // chkTongKhoa.Checked = true;
           // chkTongLoaiXN.Checked = true;
        }
        private void IntitalData()
        {
            SqlQuery sqlQuery = new Select().From(LObjectType.Schema).OrderAsc(LObjectType.Columns.SName);
            DataBinding.BindDataCombox(cboObjectType, sqlQuery.ExecuteDataSet().Tables[0], LObjectType.Columns.Id,
                                       LObjectType.Columns.SName, "---Đối tượng---");
            sqlQuery = new Select().From(LDepartment.Schema).OrderAsc(LDepartment.Columns.SName);
            DataBinding.BindDataCombobox_Basic(cboDepartment, sqlQuery.ExecuteDataSet().Tables[0], LDepartment.Columns.Id,
                                      LDepartment.Columns.SName);
            sqlQuery = new Select().From(TTestTypeList.Schema).OrderAsc(TTestTypeList.Columns.IntOrder);
            DataBinding.BindDataCombox(cboLoaiXetnghiem, sqlQuery.ExecuteDataSet().Tables[0], TTestTypeList.Columns.TestTypeId,
                                      TTestTypeList.Columns.TestTypeName, "---Loại xét nghiệm---");


        }

        private void chkFormDate_CheckedChanged(object sender, EventArgs e)
        {
            dtFromDate.Enabled = dtToDate.Enabled = chkFormDate.Checked;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_GTVT_BAOCAO_SOLUONG_LOAIXETNGHIEM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
               cmdExit.PerformClick();
         if (e.KeyCode == Keys.F4)
                cmdINPHIEU.PerformClick();
        }

        private void cmdINPHIEU_Click(object sender, EventArgs e)
        {
            IN_BAOCAO_TIENKHAM_DICHVU();
        }
        public string Getsday(DateTime pv_date)
        {
            return string.Format("Ngày {0} tháng {1} năm {2}", pv_date.Day, pv_date.Month, pv_date.Year);
        }
        /// <summary>
        /// Creates an object wrapper for the GTVT_BAOCAO_TONGSLUONG_LOAIXETNGHIEM Procedure
        /// </summary>
        public static StoredProcedure GtvtBaocaoTongsluongLoaixetnghiem(DateTime? FromDate, DateTime? ToDate, int? ObjectTypeID, int? IDKhoa, int? IDLoaiXN, int? HosStatus, int? IsTongKhoa)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GTVT_BAOCAO_TONGSLUONG_LOAIXETNGHIEM", DataService.GetInstance("ORM"), "dbo");

            sp.Command.AddParameter("@FromDate", FromDate, DbType.DateTime, null, null);

            sp.Command.AddParameter("@ToDate", ToDate, DbType.DateTime, null, null);

            sp.Command.AddParameter("@ObjectType_ID", ObjectTypeID, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@ID_Khoa", IDKhoa, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@ID_LoaiXN", IDLoaiXN, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@Hos_Status", HosStatus, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@IsTongKhoa", IsTongKhoa, DbType.Int32, 0, 10);

            return sp;
        }
        
        private void IN_BAOCAO_TIENKHAM_DICHVU()
        {
            DataTable v_dtData = new DataTable();
            v_dtData =
                GtvtBaocaoTongsluongLoaixetnghiem(
                    chkFormDate.Checked ? dtFromDate.Value : Convert.ToDateTime("01/01/1900"),
                    chkFormDate.Checked ? dtToDate.Value : Utility.getSysDate(),
                    Utility.Int32Dbnull(cboObjectType.SelectedValue, -1),
                    Utility.Int32Dbnull(cboDepartment.SelectedValue, -1),
                    Utility.Int32Dbnull(cboLoaiXetnghiem.SelectedValue, -1),
                    Utility.Int32Dbnull(cboHos_Status.SelectedValue, -1),chkTongKhoa.Checked?1:0).GetDataSet().Tables[0];

           // SubSonic.StoredProcedure.
            if (v_dtData.Rows.Count <= 0)
            {
                Utility.ShowMsg("Không tìm thấy bản ghi nào", "Thông báo");
                return;
            }
             string sTungayDenNgay = dtFromDate.Value.Date != dtToDate.Value.Date
                                      ? string.Format("{0} --- đến --- {1}", Getsday(dtFromDate.Value),
                                                      Getsday(dtToDate.Value))
                                      : Getsday(dtFromDate.Value);
            Utility.UpdateLogotoDatatable(ref v_dtData);
            var crpt = new ReportDocument();
                if(chkTongLoaiXN.Checked)
                {
                    crpt = new CRTP_GTVT_BAOCAO_SLUONG_XNGHIEM_THEO_TLOAI();
                }
                else
                {
                    crpt = new CRPT_GTVT_BAOCAO_SOLUONG_LOAIXETNGHIEM();
                }
            var objForm = new frmPrintPreview("THỐNG KÊ TIỀN KHÁM DỊCH VỤ", crpt, true,true);
            crpt.SetDataSource(v_dtData);
            crpt.DataDefinition.FormulaFields["Formula_1"].Text = Strings.Chr(34) +
                                                                  "        NGƯỜI LẬP BẢNG KÊ                                                           KẾ TOÁN                "
                                                                      .Replace("#$X$#",
                                                                               Strings.Chr(34) + "&Chr(13)&" +
                                                                               Strings.Chr(34)) +
                                                                  Strings.Chr(34);
            crpt.SetParameterValue("ParentBranchName", globalVariables.ParentBranch_Name);
            crpt.SetParameterValue("BranchName", globalVariables.Branch_Name);
            crpt.SetParameterValue("sTitleReport", "BÁO CÁO SỐ LƯỢNG LOẠI XÉT NGHIỆM");
            crpt.SetParameterValue("sTuNgayDenNgay", sTungayDenNgay);
            crpt.SetParameterValue("sCurrentDate", Utility.FormatDateTime(dtCreatePrint.Value));
           /// crpt.SetParameterValue("NgayIn", "Ngày " + dtCreatePrint.Value.Day + " tháng " + dtCreatePrint.Value.Month + " năm " + dtCreatePrint.Value.Year);
           // crpt.SetParameterValue("TienBangChu", sMoneyByLetter.sMoneyToLetter(v_dtData.Compute("SUM(TONG)", "1=1").ToString()));
          //  crpt.SetParameterValue("DateTime", "Từ ngày: " + dtFromDate.Value.ToShortDateString() + " đến ngày: " + dtToDate.Value.ToShortDateString());
            objForm.crptViewer.ReportSource = crpt;
            objForm.ShowDialog();
            Utility.DefaultNow(this);

        }
    }
}
