using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using LIS.DAL;
using Lis.Report.UI.GTVT;
using  SubSonic;

using System.Windows.Forms;
using VNS.Libs;


namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frm_GTVT_BAOCAO_SLUONG_XETNGHIEM_THEODOITUONG : Form
    {
        public frm_GTVT_BAOCAO_SLUONG_XETNGHIEM_THEODOITUONG()
        {
            InitializeComponent();
            CreateManagementUnit();
        }
        /// <summary>
        /// khai báo DataTable
        /// </summary>
        private DataTable dtPatient;

        #region Method
        public static void CreateManagementUnit()
        {
            SqlQuery q = new Select().From(SysManagementUnit.Schema);
            var objManagementUnit = q.ExecuteSingle<SysManagementUnit>();
            if (objManagementUnit != null)
            {
                globalVariables.ParentBranch_Name = objManagementUnit.SParentBranchName;
                globalVariables.Branch_Name = objManagementUnit.SName;
                globalVariables.Branch_Phone = objManagementUnit.SPhone;
                globalVariables.Branch_Address = objManagementUnit.SAddress;
            }
        }
       
        #endregion

        #region Event
        private void cmdINPHIEU_Click(object sender, EventArgs e)
        {
            try
            {
                dtPatient =null;//SPs.GtvtBaocaoSluongXetnghiemTheodoituong(dtpFromDate.Value.Date, dtpToDate.Value.Date).GetDataSet().Tables[0];
                if (dtPatient.Rows.Count < 0)
                {
                    Utility.ShowMsg("Không có dữ liệu để in");
                }
                else
                {
                    string s = "";

                    if (dtpFromDate.Value.Equals(dtpToDate.Value))
                    {
                        s = string.Format("{0}{1}", s,
                                          string.Format("Ngày {0}", dtpFromDate.Value.ToString("dd/MM/yyyy")));
                    }
                    else
                    {
                        s = string.Format("{0}{1}", s,
                                          string.Format("Từ ngày {0} đến ngày {1}",
                                                        dtpFromDate.Value.ToString("dd/MM/yyyy"),
                                                        dtpToDate.Value.ToString("dd/MM/yyyy")));
                    }
                    Utility.UpdateLogotoDatatable(ref dtPatient);
                        CRPT_GTVT_BAOCAO_SLUONG_XETNGHIEM_THEODOITUONG crpt = new CRPT_GTVT_BAOCAO_SLUONG_XETNGHIEM_THEODOITUONG();
                        var objForm = new frmPrintPreview("In Báo Cáo", crpt, true, true);
                        crpt.SetDataSource(dtPatient);

                        crpt.SetParameterValue("ParentBranchName", globalVariables.ParentBranch_Name);
                        crpt.SetParameterValue("BranchName", globalVariables.Branch_Name);
                        crpt.SetParameterValue("sTitleReport", label7.Text);
                        crpt.SetParameterValue("sTuNgayDenNgay", s);
                        crpt.SetParameterValue("sCurrentDate", Utility.FormatDateTime(dtNgayInPhieu.Value));
                        objForm.crptViewer.ReportSource = crpt;
                        objForm.ShowDialog();
                        Utility.DefaultNow(this);
                    
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.ToString());
            }
        }

      
        private void cmdExit_Click(object sender, EventArgs e)
        {
           Dispose();
        }

        private void frm_DANGKY_KETQUA_THEO_LOAIXN_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
                {
                    case Keys.F3:
                        cmdINPHIEU.PerformClick();
                        break;
                    case Keys.Escape:
                        cmdExit.PerformClick();
                        break;
                }
         }
        #endregion

    }
}
