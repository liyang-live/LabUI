using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using Lis.BaoCao.VietDuc;
using newLib;
using SubSonic;

using VNS.Libs;

namespace VietBaIT.LABLink.Reports.Form_GTVT
{
    public partial class frm_GTVT_BAOCAO_TRUC : Form
    {
        public frm_GTVT_BAOCAO_TRUC()
        {
            InitializeComponent();
        }

        private void frm_GTVT_BAOCAO_TRUC_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    cmdPrint.PerformClick();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    cmdCancel.PerformClick();
                }
            }
            catch (Exception)
            {
                Utility.ShowMsg("Lỗi");
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private StoredProcedure BaoCaoSoTruc(DateTime? pFromDate, DateTime? pToDate)
        {
            var sp = new StoredProcedure("GTVT_BAOCAO_SOTRUC", DataService.GetInstance("ORM"), "dbo");
            sp.Command.AddParameter("@FromDate", pFromDate, DbType.DateTime, null, null);
            sp.Command.AddParameter("@ToDate", pToDate, DbType.DateTime, null, null);
            return sp;
        }

        private DataTable dtRawResult;
        private DataTable dt;

        private void LayDuLieu()
        {
            try
            {
                dt = new DataTable();
                dt.Columns.Add("Barcode");
                dt.Columns.Add("Patient_ID");
                dt.Columns.Add("Patient_Name");
                dt.Columns.Add("AGE");
                dt.Columns.Add("Sex");
                dt.Columns.Add("Department");
                dt.Columns.Add("Insurance_Num");
                dt.Columns.Add("Diagnostic");
                dt.Columns.Add("AllResult");
                dt.Columns.Add("AllResult2");
                dt.Columns.Add("Test_Date");

                dtRawResult = BaoCaoSoTruc(dtpFromDate.Value, dtpToDate.Value).GetDataSet().Tables[0];

              //  bool forVd = SysPara.BarcodeType.ToUpper() == "VIETDUC";
                //Xử lý các giá trị bình thường
                //Utilities.ProcessNormalResult(ref dtRawResult, "Test_Result", "Normal_Level", "+",
                //                              "+", "-", "flag", forVd);
                //Utilities.ProcessNormalResult(ref dtRawResult, "Test_Result", "Normal_Level", "",
                //                            "", "", "flag", forVd);
                var patientResult = new StringBuilder();
                var patientResult2 = new StringBuilder();

                dtRawResult.Rows.InsertAt(dtRawResult.NewRow(), 0);
                dtRawResult.Rows[0]["Patient_ID"] = Utility.sDbnull(dtRawResult.Rows[1]["Patient_ID"]);
                dtRawResult.Rows.Add(dtRawResult.NewRow());
                for (int i = 1; i <= dtRawResult.Rows.Count - 1; i++)
                {
                    if (Utility.sDbnull(dtRawResult.Rows[i]["Patient_ID"]) !=
                        Utility.sDbnull(dtRawResult.Rows[i - 1]["Patient_ID"]))
                    {
                        //patientResult.Remove(patientResult.Length - 2, 1);
                        var newdr = dt.NewRow();
                        newdr["Patient_ID"] = Utility.sDbnull(dtRawResult.Rows[i - 1]["Patient_ID"]);
                        newdr["Barcode"] = Utility.sDbnull(dtRawResult.Rows[i - 1]["Barcode"]);
                        newdr["Patient_Name"] = Utility.sDbnull(dtRawResult.Rows[i - 1]["Patient_Name"]);
                        newdr["AGE"] = Utility.Int32Dbnull(dtRawResult.Rows[i - 1]["AGE"]);
                        newdr["Sex"] = Utility.sDbnull(dtRawResult.Rows[i - 1]["Sex"]);
                        newdr["Insurance_Num"] = Utility.sDbnull(dtRawResult.Rows[i - 1]["Insurance_Num"]);
                        newdr["Department"] = Utility.sDbnull(dtRawResult.Rows[i - 1]["Department"]);
                        newdr["Diagnostic"] = Utility.sDbnull(dtRawResult.Rows[i - 1]["Diagnostic"]);
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
                        patientResult2.Append(dtRawResult.Rows[i]["TestType_Name"] + ":");
                        patientResult.Append("</p>");
                        patientResult.Append(string.Format("<b>{0}</b>: ",
                                                           Utility.sDbnull(dtRawResult.Rows[i]["TestType_Name"]).ToUpper
                                                               ()));
                    }
                    string value, value2;
                    if (Utility.sDbnull(dtRawResult.Rows[i]["flag"]).Trim() == "+")
                    {
                        value2 = string.Format("{0} ,{1} , {2}; ",
                                               Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                                               Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                                               dtRawResult.Rows[i]["Test_result"]);
                        value = string.Format("<font color=\"red\"><b>{0}({1}) {2};</b></font> ",
                                              Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                                              Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                                              dtRawResult.Rows[i]["Test_result"]);
                    }
                    else if (Utility.sDbnull(dtRawResult.Rows[i]["flag"]).Trim() == "-")
                    {
                        value2 = string.Format("{0}, {1}, {2}; ",
                                               Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                                               Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                                               dtRawResult.Rows[i]["Test_result"]);
                        value = string.Format("{0}({1}) {2}; ",
                                              Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
                                              Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                                              dtRawResult.Rows[i]["Test_result"]);
                    }
                    else
                    {
                        value2 = string.Format(
                            Utility.sDbnull(dtRawResult.Rows[i]["Test_result"]).Trim() != ""
                                ? "{0} {1};"
                                : "{0}&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp ",
                            Utility.sDbnull(dtRawResult.Rows[i]["Test_Name"]),
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
            }
            catch (Exception)
            {
                Utility.ShowMsg("Không thể kết nối đến CSDL", "Thông Báo", MessageBoxIcon.Error);
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            try
            {
                LayDuLieu();
                if (dt.Rows.Count<=0 || dtRawResult == null)
                {
                    Utility.ShowMsg("Không có dữ liệu để báo cáo");
                }
                else
                {
                    string s = "";
                    if (dtpFromDate.Value.Date == dtpToDate.Value.Date)
                    {
                        s = string.Format("{0}Ngày {1}", s, dtpFromDate.Value.ToString("dd/MM/yyyy"));
                    }
                    else
                    {
                        s = string.Format("{0}{1}", s,
                                          string.Format("Từ ngày {0} đến ngày {1}",
                                                        dtpFromDate.Value.ToString("dd/MM/yyyy"),
                                                        dtpToDate.Value.ToString("dd/MM/yyyy")));
                    }
                    var crpt = new VD_crpt_DailyParamTestReport();
                    var oForm = new frmPrintPreview("In Báo cáo lưu", crpt, true, true);
                    crpt.SetDataSource(dt);
                    crpt.DataDefinition.FormulaFields["Formula_1"].Text = "";
                    crpt.SetParameterValue("sFromDateToDate", s);
                    crpt.SetParameterValue("TongSoBenhNhan", dt.Rows.Count);
                    crpt.SetParameterValue("ParentBranchName", ManagementUnit.gv_sParentBranchName);
                    crpt.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                    crpt.SetParameterValue("sPrintDate", dtpDatePrint.Value.ToString("dd/MM/yyyy"));
                    oForm.crptViewer.ReportSource = crpt;
                    oForm.ShowDialog();
                    oForm.Dispose();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi" + ex, "Thông Báo", MessageBoxIcon.Warning);
            }
        }
    }
}