using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using LIS.DAL;
using SubSonic;
using Microsoft.VisualBasic;
using VietBaIT.LABLink.Reports.Reports;
using Vietbait.Lablink.Report.Business;

namespace VietBaIT.LABLink.Reports.Form_GTVT
{
    public partial class frm_DA_BAOCAO_THOIGIAN_XETNGHIEM : Form
    {
        private DataTable m_dtObjectType=new DataTable();
        public frm_DA_BAOCAO_THOIGIAN_XETNGHIEM()
        {
            InitializeComponent();
            ReportBusiness.CreateManagementUnit();
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
            sqlQuery = new Select().From(TTestTypeList.Schema).Where(TTestTypeList.Columns.TestTypeId).IsEqualTo(2).Or(TTestTypeList.Columns.TestTypeId).IsEqualTo(5).OrderAsc(TTestTypeList.Columns.IntOrder);
            //DataBinding.BindDataCombox(cboLoaiXetnghiem, sqlQuery.ExecuteDataSet().Tables[0], TTestTypeList.Columns.TestTypeId,
            //                          TTestTypeList.Columns.TestTypeName);
            DataBinding.BindDataCombobox(cboLoaiXetnghiem, sqlQuery.ExecuteDataSet().Tables[0], TTestTypeList.Columns.TestTypeId,
                                      TTestTypeList.Columns.TestTypeName);

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
            IN_BAOCAO_THOIGIAN_XETNGHIEM();
        }
        public string Getsday(DateTime pv_date)
        {
            return string.Format("Ngày {0} tháng {1} năm {2}", pv_date.Day, pv_date.Month, pv_date.Year);
        }

        
        private void IN_BAOCAO_THOIGIAN_XETNGHIEM()
        {
            DataTable v_dtData = new DataTable();
            
            v_dtData =
                SPs.DaBaocaoThoigianXetnghiem(
                    dtFromDate.Value,
                    dtToDate.Value.AddDays(1).AddSeconds(-1),
                    Utility.Int32Dbnull(cboLoaiXetnghiem.SelectedValue, -1)).GetDataSet().Tables[0];

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
            crpt = new CRPT_DA_BAOCAO_THOIGIAN_XETNGHIEM();
            var objForm = new VietBaIT.LABLink.Reports.frmPrintPreview("BÁO CÁO THỜI GIAN XÉT NGHIỆM", crpt, true,true);
            crpt.SetDataSource(v_dtData);
            crpt.DataDefinition.FormulaFields["Formula_1"].Text = Strings.Chr(34) +
                                                                  "        NGƯỜI LẬP BẢNG KÊ                                                           KẾ TOÁN                "
                                                                      .Replace("#$X$#",
                                                                               Strings.Chr(34) + "&Chr(13)&" +
                                                                               Strings.Chr(34)) +
                                                                  Strings.Chr(34);
            crpt.SetParameterValue("ParentBranchName", globalVariables.ParentBranch_Name);
            crpt.SetParameterValue("BranchName", globalVariables.Branch_Name);
            crpt.SetParameterValue("sTitleReport", "BÁO CÁO THỜI GIAN XÉT NGHIỆM " + cboLoaiXetnghiem.Text.ToUpper());
            crpt.SetParameterValue("sTuNgayDenNgay", sTungayDenNgay);
            
           objForm.crptViewer.ReportSource = crpt;
            objForm.ShowDialog();
            Utility.DefaultNow(this);

        }
    }
}
