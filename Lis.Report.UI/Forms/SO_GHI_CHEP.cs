using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lis.Report.UI.Reports;
using newLib;
using SubSonic;
using VNS.Libs;




namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frmSoGhiChep : Form
    {
        public frmSoGhiChep()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Close();
        }
      private StoredProcedure BaocaoSoghichep(DateTime? pFromDate, DateTime? pToDate)
      {
          SubSonic.StoredProcedure sp = new StoredProcedure("spSoGhiChep", DataService.GetInstance("ORM"), "dbo");
          sp.Command.AddParameter("@pFromDate",pFromDate,DbType.DateTime,null,null);
          sp.Command.AddParameter("@pToDate",pToDate,DbType.DateTime,null,null);
          return sp;
      }
        private DataTable dtSoghichep;
        private void cmdINPHIEU_Click(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                if (dtpFromDate.Value.Date == dtpToDate.Value.Date)
                {
                    s = string.Format("{0}Ngày {1}", s, dtpFromDate.Value.ToString("dd/MM/yyyy"));
                }
                else
                {
                    s = string.Format("{0}{1}", s,
                                      string.Format("Từ ngày {0} đến ngày {1}", dtpFromDate.Value.ToString("dd/MM/yyyy"),
                                                    dtpToDate.Value.ToString("dd/MM/yyyy")));
                }
                dtSoghichep = BaocaoSoghichep(dtpFromDate.Value,dtpToDate.Value).GetDataSet().Tables[0];
                int totalBN = dtSoghichep.Rows.Count;
                if (dtSoghichep.Rows.Count <= 0)
                {
                    Utility.ShowMsg("Không có dữ liệu để in");
                }
                else
                {
                    var crpt = new crpt_SoGhiChep(); 
                    var objForm = new frmPrintPreview("In Báo Cáo", crpt, true, true);
                    crpt.SetDataSource(dtSoghichep);
                    crpt.DataDefinition.FormulaFields["Formula_1"].Text = "";
                    crpt.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                    crpt.SetParameterValue("ParentBranchName", ManagementUnit.gv_sParentBranchName);
                    crpt.SetParameterValue("TestDate",s);
                    crpt.SetParameterValue("PrintDate",dtpPrintDate.Value);
                    crpt.SetParameterValue("TotalBN", totalBN);
                    objForm.crptViewer.ReportSource = crpt;
                    objForm.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                Utility.ShowMsg("Lỗi trong quá trình xuất báo cáo" + exception);
            }   
         }

        private void frmSoGhiChep_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                    case Keys.F4:
                    cmdINPHIEU.PerformClick();
                    break;
                    case Keys.Escape:
                    cmdExit.PerformClick();
                    break;
            }
        }
    }
}
