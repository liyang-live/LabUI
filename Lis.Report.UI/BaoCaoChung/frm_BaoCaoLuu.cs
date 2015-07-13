using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;

using LIS.DAL;
using Lis.LoadData;
using Lis.Report.UI.VietDuc;
using Microsoft.VisualBasic;
using newLib;
using SubSonic;
using VNS.Libs;
using AggregateFunction = SubSonic.AggregateFunction;

namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frm_BaoCaoLuu : Form
    {
        #region Fields

        #endregion

        #region Constructor

        public frm_BaoCaoLuu()
        {
            InitializeComponent();
            dtpFromDate.Value = dtpToDate.Value = DateTime.Now;

        }

        #endregion

        #region Form Events

        /// <summary>
        /// Hàm xử lý sự kiện formload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmArchiverReport_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtDepartment = new Select().From(LDepartment.Schema.Name).ExecuteDataSet().Tables[0];
                DataTable dtObjectType = new Select().From(LObjectType.Schema.Name).ExecuteDataSet().Tables[0];
                DataBinding.BindDataCombox(cboDepartment, dtDepartment, LDepartment.Columns.Id,
                                           LDepartment.Columns.SName, "---Tất cả---");
                DataBinding.BindDataCombox(cboObjectType, dtObjectType, LObjectType.Columns.Id,
                                         LObjectType.Columns.SName, "---Tất cả---");
                dtpToDate.PreviewKeyDown += dtpFromDate_PreviewKeyDown;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                Dispose();
            }
        }

        DataTable dtRawResult;

        private void cmdINPHIEU_Click(object sender, EventArgs e)
        {
            try
            {
                //string sTenKhoa = cboDepartment.Text;
                //var dt = new DataTable();
                //dt.Columns.Add("Barcode");
                //dt.Columns.Add("Patient_ID");
                //dt.Columns.Add("Patient_Name");
                //dt.Columns.Add("AGE");
                //dt.Columns.Add("Sex");
                //dt.Columns.Add("Department");
                //dt.Columns.Add("Diagnostic");
                //dt.Columns.Add("AllResult");
                //dt.Columns.Add("Test_Date");

                //LDepartment objDepartment = LDepartment.FetchByID(Utility.Int32Dbnull(cboDepartment.SelectedValue));
                //if (objDepartment != null)
                //    sTenKhoa = Utility.sDbnull(objDepartment.SName, "");


                //if (dtRawResult == null)
                //{
                //    dtRawResult =
                //        SPs.SpRptBaoCaoLuu(dtpFromDate.Value,
                //                           dtpToDate.Value,
                //                           Utility.Int32Dbnull(cboDepartment.SelectedValue), chkPrintAll.Checked).
                //            GetDataSet().Tables[0];
                //    if (dtRawResult.Rows.Count == 0) dtRawResult = null;
                //}
                //if (dtRawResult != null && dtRawResult.Rows.Count <= 0)
                //{
                //    Utility.ShowMsg("Không tồn tại dữ liệu");
                //    return;
                //}
                //bool forVd = SysPara.BarcodeType.ToUpper() == "VIETDUC";
                ////Xử lý các giá trị bình thường
                //Utilities.ProcessNormalResult(ref dtRawResult, "Test_Result", "Normal_Level", "+",
                //                              "+", "-", "flag", forVd);

                //var patientResult = new StringBuilder();

                //dtRawResult.Rows.InsertAt(dtRawResult.NewRow(), 0);
                //dtRawResult.Rows[0]["Patient_ID"] = dtRawResult.Rows[1]["Patient_ID"];
                //dtRawResult.Rows.Add(dtRawResult.NewRow());
                //for (int i = 1; i <= dtRawResult.Rows.Count - 1; i++)
                //{
                //    if (Utility.sDbnull(dtRawResult.Rows[i]["Patient_ID"]) !=
                //        Utility.sDbnull(dtRawResult.Rows[i - 1]["Patient_ID"]))
                //    {
                //        //patientResult.Remove(patientResult.Length - 2, 1);
                //        DataRow newdr = dt.NewRow();
                //        newdr["Patient_ID"] = dtRawResult.Rows[i - 1]["Patient_ID"];
                //        newdr["Barcode"] = dtRawResult.Rows[i - 1]["Barcode"];
                //        newdr["Patient_Name"] = dtRawResult.Rows[i - 1]["Patient_Name"];
                //        newdr["AGE"] = dtRawResult.Rows[i - 1]["AGE"];
                //        newdr["Sex"] = dtRawResult.Rows[i - 1]["Sex"];
                //        newdr["Department"] = dtRawResult.Rows[i - 1]["Department"];
                //        newdr["Diagnostic"] = dtRawResult.Rows[i - 1]["Diagnostic"];
                //        if (dtRawResult.Rows[i - 1]["Test_Date"] != null)
                //            newdr["Test_Date"] = ((DateTime) dtRawResult.Rows[i - 1]["Test_Date"]).ToString("dd/MM/yyyy");
                //        //newdr["Test_Date"] = DateTime.Parse(dtRawResult.Rows[i - 1]["Test_Date"].ToString()).ToString("dd/MM/yyyy");
                //        newdr["AllResult"] = patientResult.ToString();
                //        dt.Rows.Add(newdr);
                //        patientResult = new StringBuilder();
                //    }
                //    if ((Utility.sDbnull(dtRawResult.Rows[i]["TestType_Name"]) !=
                //         Utility.sDbnull(dtRawResult.Rows[i - 1]["TestType_Name"])) |
                //        (Utility.sDbnull(dtRawResult.Rows[i]["Patient_ID"]) !=
                //         Utility.sDbnull(dtRawResult.Rows[i - 1]["Patient_ID"])))
                //    {
                //        patientResult.Append("</p>");
                //        patientResult.Append(string.Format("</p><b>{0}</b>: ",
                //                                           Utility.sDbnull(dtRawResult.Rows[i]["TestType_Name"]).ToUpper
                //                                               ()));
                //    }
                //    string value;
                //    if (Utility.sDbnull(dtRawResult.Rows[i]["flag"]).Trim() == "+")
                //        value = string.Format("<font color=\"red\"><b>{0}({1}) {2};</b></font> ",
                //                              Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                //                              Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                //                              dtRawResult.Rows[i]["Test_result"]);
                //    else if (Utility.sDbnull(dtRawResult.Rows[i]["flag"]).Trim() == "-")
                //        value = string.Format("{0}({1}) {2}; ",
                //                              Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                //                              Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                //                              dtRawResult.Rows[i]["Test_result"]);
                //    else
                //        value = string.Format(
                //            Utility.sDbnull(dtRawResult.Rows[i]["Test_result"]).Trim() != ""
                //                ? "{0} {1};"
                //                : "<i>{0}&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</i> ",
                //            Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                //            dtRawResult.Rows[i]["Test_result"]);

                //    patientResult.Append(value);
                //}

                //dt.AcceptChanges();

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
                var crpt = new VD_crpt_DailyParamTestReport();
                var oForm = new frmPrintPreview("In Báo cáo lưu", crpt, true, true);
                crpt.SetDataSource(dt);
                crpt.DataDefinition.FormulaFields["Formula_1"].Text = "";
                //crpt.SetParameterValue("sTenKhoa", sTenKhoa);
                crpt.SetParameterValue("TongSoBenhNhan", dt.Rows.Count);
                crpt.SetParameterValue("sFromDateToDate", s);
                crpt.SetParameterValue("ParentBranchName", ManagementUnit.gv_sParentBranchName);
                crpt.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                //crpt.SetParameterValue("Address", ManagementUnit.gv_sAddress);
                //crpt.SetParameterValue("sPhone", ManagementUnit.gv_sPhone);
                crpt.SetParameterValue("sPrintDate", dtCreatePrint.Value.ToString("dd/MM/yyyy"));
                oForm.crptViewer.ReportSource = crpt;
                oForm.ShowDialog();
                oForm.Dispose();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void frmArchiverReport_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                 
                case Keys.F4:
                    cmdINPHIEU.PerformClick();
                    break;
                case Keys.Escape:
                    cmdExit.PerformClick();
                    break;
                case Keys.F3:
                    cmdXemBaoCao.PerformClick();
                    break;

            }
        }

        private void dtpFromDate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F4) cmdINPHIEU.PerformClick();
        }

        #endregion

        private DataTable dt;
        /// <summary>
        /// Creates an object wrapper for the sp_RPT_BaoCaoLuu Procedure
        /// </summary>
        public static StoredProcedure SpRptBaoCaoLuu(DateTime? FromDate, DateTime? ToDate, int? DepartmentID, int? ObjectType, bool? AllResult)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("sp_RPT_BaoCaoLuu", DataService.GetInstance("ORM"), "dbo");

            sp.Command.AddParameter("@FromDate", FromDate, DbType.DateTime, null, null);

            sp.Command.AddParameter("@ToDate", ToDate, DbType.DateTime, null, null);

            sp.Command.AddParameter("@DepartmentID", DepartmentID, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@ObjectType", ObjectType, DbType.Int32, 0, 10);

            sp.Command.AddParameter("@AllResult", AllResult, DbType.Boolean, null, null);

            return sp;
        }
        
        private void cmdXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                string sTenKhoa = cboDepartment.Text;
                dt = new DataTable();
                dt.Columns.Add("Barcode");
                dt.Columns.Add("Patient_ID");
                dt.Columns.Add("Patient_Name");
                dt.Columns.Add("AGE");
                dt.Columns.Add("Sex");
                dt.Columns.Add("Department");
                dt.Columns.Add("Insurance_Num");
                dt.Columns.Add("ObjectType");
                dt.Columns.Add("Diagnostic");
                dt.Columns.Add("AllResult");
                dt.Columns.Add("AllResult2");
                dt.Columns.Add("Test_Date");

                LDepartment objDepartment = LDepartment.FetchByID(Utility.Int32Dbnull(cboDepartment.SelectedValue));
                if (objDepartment != null)
                    sTenKhoa = Utility.sDbnull(objDepartment.SName, "");

                
                    dtRawResult =
                                SpRptBaoCaoLuu(dtpFromDate.Value,
                                                   dtpToDate.Value,
                                                   Utility.Int32Dbnull(cboDepartment.SelectedValue), Utility.Int32Dbnull(cboObjectType.SelectedValue), chkPrintAll.Checked).
                                                   GetDataSet().Tables[0];
                    if (dtRawResult.Rows.Count == 0) dtRawResult = null;
               
                if (dtRawResult == null || dtRawResult.Rows.Count <= 0)
                {
                    Utility.ShowMsg("Không tồn tại dữ liệu");
                    cmdINPHIEU.Enabled = false;
                    gridResult.DataSource = dt;
                    return;
                }
                bool forVd = SysPara.BarcodeType.ToUpper() == "VIETDUC";
                //Xử lý các giá trị bình thường
                //Utilities.ProcessNormalResult(ref dtRawResult, "Test_Result", "Normal_Level", "+",
                //                                            "+", "-", "flag", forVd);

                //lablinkhelper.Utilities.ProcessNormalResult(ref dtRawResult, "Test_Result", "Normal_Level", "",
                //                                            "", "", "flag", forVd);
                var patientResult = new StringBuilder();
                var patientResult2 = new StringBuilder();

                dtRawResult.Rows.InsertAt(dtRawResult.NewRow(), 0);
                dtRawResult.Rows[0]["Patient_ID"] = dtRawResult.Rows[1]["Patient_ID"];
                dtRawResult.Rows.Add(dtRawResult.NewRow());
                for (int i = 1; i <= dtRawResult.Rows.Count - 1; i++)
                {
                    if (Utility.sDbnull(dtRawResult.Rows[i]["Patient_ID"]) !=
                        Utility.sDbnull(dtRawResult.Rows[i - 1]["Patient_ID"]))
                    {
                        //patientResult.Remove(patientResult.Length - 2, 1);
                        var newdr = dt.NewRow();
                        newdr["Patient_ID"] = dtRawResult.Rows[i - 1]["Patient_ID"];
                        newdr["Barcode"] = dtRawResult.Rows[i - 1]["Barcode"];
                        newdr["Patient_Name"] = dtRawResult.Rows[i - 1]["Patient_Name"];
                        newdr["AGE"] = dtRawResult.Rows[i - 1]["AGE"];
                        newdr["Sex"] = dtRawResult.Rows[i - 1]["Sex"];
                        //newdr["Insurance_Num"] = dtRawResult.Rows[i - 1]["Insurance_Num"];
                        newdr["Department"] = dtRawResult.Rows[i - 1]["Department"];
                        newdr["Diagnostic"] = dtRawResult.Rows[i - 1]["Diagnostic"];
                        //newdr["ObjectType"] = dtRawResult.Rows[i - 1]["ObjectType"];
                        if (dtRawResult.Rows[i - 1]["Test_Date"] != null)
                            newdr["Test_Date"] =
                                ((DateTime) dtRawResult.Rows[i - 1]["Test_Date"]).ToString("dd/MM/yyyy");
                        //newdr["Test_Date"] = DateTime.Parse(dtRawResult.Rows[i - 1]["Test_Date"].ToString()).ToString("dd/MM/yyyy");
                        newdr["AllResult2"] = patientResult2.ToString();
                        newdr["AllResult"] = patientResult.ToString();
                        dt.Rows.Add(newdr);
                        patientResult2 = new StringBuilder();
                        patientResult = new StringBuilder();
                    }
                    if ((Utility.sDbnull(dtRawResult.Rows[i]["TestType_Name"]) !=
                         Utility.sDbnull(dtRawResult.Rows[i - 1]["TestType_Name"])) |
                        (Utility.sDbnull(dtRawResult.Rows[i]["Patient_ID"]) !=
                         Utility.sDbnull(dtRawResult.Rows[i - 1]["Patient_ID"])))
                    {
                        patientResult2.Append(dtRawResult.Rows[i]["TestType_Name"]+":");
                        patientResult.Append("</p>");
                        patientResult.Append(string.Format("<b>{0}</b>: ",
                                                           Utility.sDbnull(dtRawResult.Rows[i]["TestType_Name"]).ToUpper
                                                               ()));
                    }
                    string value,value2;
                    //if (Utility.sDbnull(dtRawResult.Rows[i]["flag"]).Trim() == "+")
                    //{
                    //    value2 = string.Format("{0} ,{1} , {2}; ",
                    //                          Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                    //                          Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                    //                          dtRawResult.Rows[i]["Test_result"]);
                    //    value = string.Format("<font color=\"red\"><b>{0}({1}) {2};</b></font> ",
                    //  Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                    //  Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                    //  dtRawResult.Rows[i]["Test_result"]);
                    //}
                    //else if (Utility.sDbnull(dtRawResult.Rows[i]["flag"]).Trim() == "-")
                    //{
                    //    value2 = string.Format("{0}, {1}, {2}; ",
                    //                          Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                    //                          Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                    //                          dtRawResult.Rows[i]["Test_result"]);
                    //    value = string.Format("{0}({1}) {2}; ",
                    //                         Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                    //                         Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                    //                         dtRawResult.Rows[i]["Test_result"]);
                    //}
                    //else
                    {
                        value2 = string.Format(
                            Utility.sDbnull(dtRawResult.Rows[i]["Test_result"]).Trim() != ""
                                ? "{0} {1};"
                                : "{0}&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp ", Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                            dtRawResult.Rows[i]["Test_result"]);
                        value = string.Format(
                           Utility.sDbnull(dtRawResult.Rows[i]["Test_result"]).Trim() != ""
                               ? "{0} {1};"
                               : "<i>{0}&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</i> ",
                           Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                           dtRawResult.Rows[i]["Test_result"]);
                    }
                        

                    patientResult.Append(value);
                    patientResult2.Append(value2);
                }
              
                gridResult.DataSource = dt;
                cmdINPHIEU.Enabled = true;
                gridResult.AutoSizeColumns();
                dt.AcceptChanges();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {

        }

    }
}