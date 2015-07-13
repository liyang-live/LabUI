using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Lis.BaoCao.Reports;
using LIS.DAL;
using newLib;
using SubSonic;



using VNS.Libs;

using AggregateFunction = SubSonic.AggregateFunction;

namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frm_DanhSachBenhNhan_TestType : Form
    {
        public frm_DanhSachBenhNhan_TestType()
        {
            InitializeComponent();
        }
        private DataTable dt;
        DataTable dtRawResult;
     private DataTable BC_DS_TestType;
     private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

     private void frm_DanhSachBenhNhan_TestType_Load(object sender, EventArgs e)
     {
         try
         {
             DataTable TestType = new Select().From(TTestTypeList.Schema.Name).ExecuteDataSet().Tables[0];
             DataBinding.BindDataCombox(cboTestType,TestType,TTestTypeList.Columns.TestTypeId,
                                        TTestTypeList.Columns.TestTypeName,"----Chọn Xét Nghiệm ----");
         }
         catch (Exception ex)
         {
             Utility.ShowMsg(ex.ToString());
         }
     
     }
        private StoredProcedure BaocaoDSBNtheoTestType(DateTime? pFromDate, DateTime? pToDate, string testType)
        {
            SubSonic.StoredProcedure sp = new StoredProcedure("spBaoCao_DSBN_TestType", DataService.GetInstance("ORM"),"dbo");
            sp.Command.AddParameter("@pFromDate", pFromDate,DbType.DateTime,null,null);
            sp.Command.AddParameter("@pToDate", pToDate,DbType.DateTime,null,null);
            sp.Command.AddParameter("@testType",testType,DbType.String,null,null);
            return sp;
        }
     
     private void cmdReport_Click(object sender, EventArgs e)
     {
            try
            {
                dt = new DataTable();
                dt.Columns.Add("Patient_ID");
                dt.Columns.Add("Patient_Name");
                dt.Columns.Add("AGE");
                dt.Columns.Add("Sex");
                dt.Columns.Add("Department");
                dt.Columns.Add("Insurance_Num");
                dt.Columns.Add("Address");
                dt.Columns.Add("Diagnostic");
                dt.Columns.Add("AllResult");
                dtRawResult = BaocaoDSBNtheoTestType(dtpFromDate.Value,
                                                   dtpToDate.Value,
                                                  cboTestType.SelectedValue.ToString()).
                                                   GetDataSet().Tables[0];
                if (dtRawResult.Rows.Count <= 0)
                {
                    Utility.ShowMsg("Không tồn tại dữ liệu");
                    gridResult.DataSource = dt;
                    btnPrint.Enabled = false;
                    dt.AcceptChanges();
                    return;
                }
                var patientResult = new StringBuilder();
                dtRawResult.Rows.InsertAt(dtRawResult.NewRow(), 0);
                dtRawResult.Rows[0]["Patient_ID"] = dtRawResult.Rows[1]["Patient_ID"];
                dtRawResult.Rows.Add(dtRawResult.NewRow());
                for (int i = 1; i <= dtRawResult.Rows.Count - 1; i++)
                {
                    if (Utility.sDbnull(dtRawResult.Rows[i]["Patient_ID"]) !=
                        Utility.sDbnull(dtRawResult.Rows[i - 1]["Patient_ID"]))
                    {
                      var newdr = dt.NewRow();
                        newdr["Patient_ID"] = dtRawResult.Rows[i - 1]["Patient_ID"];
                        newdr["Patient_Name"] = dtRawResult.Rows[i - 1]["Patient_Name"];
                        newdr["AGE"] = dtRawResult.Rows[i - 1]["AGE"];
                        newdr["Sex"] = dtRawResult.Rows[i - 1]["Sex"];
                        newdr["Address"] = dtRawResult.Rows[i - 1]["Address"];
                        newdr["Insurance_Num"] = dtRawResult.Rows[i - 1]["Insurance_Num"];
                        newdr["Department"] = dtRawResult.Rows[i - 1]["Department"];
                        newdr["Diagnostic"] = dtRawResult.Rows[i - 1]["Diagnostic"];
                        newdr["AllResult"] = patientResult.ToString();
                        dt.Rows.Add(newdr);
                        patientResult = new StringBuilder();
                    }
                    string value;
                    value = string.Format(
                           Utility.sDbnull(dtRawResult.Rows[i]["Test_result"]).Trim() != ""
                               ? "{0} {1}; "
                               : "{0} ",
                           Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                           dtRawResult.Rows[i]["Test_result"]);
                    patientResult.Append(value);
                }
                if(dt.Rows.Count<=0)
                {
                    Utility.ShowMsg("Không có dữ liệu để báo cáo");
                    dt.AcceptChanges();
                    gridResult.Refresh();
                }
                else
                {
                    gridResult.DataSource = dt;
                    btnPrint.Enabled = true;
                    gridResult.AutoSizeColumns();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
     }

     private void btnPrint_Click(object sender, EventArgs e)
     {
         try
         {
                  string s ="";
                if (dtpFromDate.Value.Date == dtpToDate.Value.Date)
                {
                    s = string.Format("{0}Ngày {1}", s, dtpFromDate.Value.ToString("dd/MM/yyyy"));
                }
                else
                {
                    s = string.Format("{0}{1}", s,
                                      string.Format("Thời gian từ ngày {0} đến ngày {1}", dtpFromDate.Value.ToString("dd/MM/yyyy"),
                                                    dtpToDate.Value.ToString("dd/MM/yyyy")));
                }
                var crpt = new Crp_DSBN_TestType();
                var oForm = new frmPrintPreview("In Báo cáo lưu", crpt, true, true);
                crpt.SetDataSource(dt);
                crpt.DataDefinition.FormulaFields["Formula_1"].Text = "";
                crpt.SetParameterValue("TongBenhNhan", dt.Rows.Count);
                crpt.SetParameterValue("TestType_Name",cboTestType.Text.ToUpper());
                crpt.SetParameterValue("strFromDateToDate", s);
                crpt.SetParameterValue("ParentBranchName", ManagementUnit.gv_sParentBranchName);
                crpt.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                crpt.SetParameterValue("sCurrentDate", dtCreatePrint.Value);
                oForm.crptViewer.ReportSource = crpt;
                oForm.ShowDialog();
                oForm.Dispose();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
     }

     private void cmdCancel_Click_1(object sender, EventArgs e)
     {
         Close();
     }

     private void frm_DanhSachBenhNhan_TestType_KeyDown(object sender, KeyEventArgs e)
     {
         switch (e.KeyCode)
         {
             case Keys.F3:
                 cmdReport.PerformClick();
                 break;
             case Keys.F4:
                 btnPrint.PerformClick();
                 break;
             case Keys.Escape:
                 cmdCancel.PerformClick();
                 break;
         }
     }
    }
}
