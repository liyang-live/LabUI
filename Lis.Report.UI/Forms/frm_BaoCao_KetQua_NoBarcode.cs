using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CrystalDecisions.CrystalReports.Engine;
using Janus.Windows.GridEX;
using LIS.DAL;
using Lis.LoadData;
using Lis.Report.UI;
using Lis.Report.UI.Reports;
using newLib;
using SubSonic;



using VNS.Libs;

using System.Windows.Forms;

using AggregateFunction = SubSonic.AggregateFunction;

namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frm_BaoCao_KetQua_NoBarcode : Form
    {
        public frm_BaoCao_KetQua_NoBarcode()
        {
            InitializeComponent();
        }
        #region Fiel
        private DataTable dt;
        DataTable dtRawResult;
        #endregion
        #region Method
        private  void LoadCombobox()
        {
            SqlQuery sqlQuery =
                new Select(TTestTypeList.Columns.TestTypeId, TTestTypeList.Columns.TestTypeName).From(
                    TTestTypeList.Schema);
            DataTable testType = sqlQuery.ExecuteDataSet().Tables[0];
            DataBinding.BindDataCombox(cboTestType, testType, TTestTypeList.Columns.TestTypeId,
                                       TTestTypeList.Columns.TestTypeName, "-----Chọn loại xét nghiệm-----");
        }

        private  void PrintData()
        {
            try
            {
                string pFromBarcode = dtpDatePrintFrom.Value.ToString("yyMMdd") + txtFromBarcode.Text.Trim().PadLeft(4, '0') +
                                      ".NB";
                string pToDate = dtpDatePrintFrom.Value.ToString("yyMMdd") + txtToBarcode.Text.Trim().PadLeft(4, '0') +
                                 ".NB";
                dt = new DataTable();
                dt.Columns.Add("Barcode");
                dt.Columns.Add("Patient_ID");
                dt.Columns.Add("Patient_Name");
                dt.Columns.Add("AllResult");
                dt.Columns.Add("AllResult2");
                dt.Columns.Add("Test_Date");
                dtRawResult =
                    SPs.GtvtBaoCaoLuuNoBarCode(Utility.sDbnull(pFromBarcode),
                                               Utility.sDbnull(pToDate),
                                               Utility.Int16Dbnull(cboTestType.SelectedValue)).
                        GetDataSet().Tables[0];
                bool forVd = SysPara.BarcodeType.ToUpper() == "VIETDUC";
                //Xử lý các giá trị bình thường
                //Utilities.ProcessNormalResult(ref dtRawResult, "Test_Result", "Normal_Level", "+",
                //                              "+", "-", "flag", forVd);
                lablinkhelper.Utilities.ProcessNormalResult(ref dtRawResult, "Test_Result", "Normal_Level", "",
                                           "", "", "flag", forVd);

                var patientResult = new StringBuilder();
                var patientResult2 = new StringBuilder();

                if (dtRawResult.Rows.Count > 0)
                {
                    dtRawResult.Rows.InsertAt(dtRawResult.NewRow(), 0);
                    dtRawResult.Rows[0]["Patient_ID"] = Utility.sDbnull(dtRawResult.Rows[1]["Patient_ID"]);
                    //dtRawResult.Rows[0]["Patient_Name"] = Utility.sDbnull(dtRawResult.Rows[1]["Patient_Name"]);
                 
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
                            if (dtRawResult.Rows[i - 1]["Test_Date"] != null)
                                newdr["Test_Date"] =
                                    ((DateTime)dtRawResult.Rows[i - 1]["Test_Date"]).ToString("dd/MM/yyyy");
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
                                                   Utility.sDbnull(dtRawResult.Rows[i]["Para_Name"]),
                                                   Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                                                   dtRawResult.Rows[i]["Test_result"]);
                            value = string.Format("<font color=\"red\"><b>{0}({1}) {2};</b></font> ",
                                                  Utility.sDbnull(dtRawResult.Rows[i]["Para_Name"]),
                                                  Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                                                  dtRawResult.Rows[i]["Test_result"]);
                        }
                        else if (Utility.sDbnull(dtRawResult.Rows[i]["flag"]).Trim() == "-")
                        {
                            value2 = string.Format("{0}, {1}, {2}; ",
                                                   Utility.sDbnull(dtRawResult.Rows[i]["Para_Name"]),
                                                   Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                                                   dtRawResult.Rows[i]["Test_result"]);
                            value = string.Format("{0}({1}) {2}; ",
                                                  Utility.sDbnull(dtRawResult.Rows[i]["Para_Name"]),
                                                  Utility.sDbnull(dtRawResult.Rows[i]["flag"]),
                                                  dtRawResult.Rows[i]["Test_result"]);
                        }
                        else
                        {
                            value2 = string.Format(
                                Utility.sDbnull(dtRawResult.Rows[i]["Test_result"]).Trim() != ""
                                    ? "{0} {1};"
                                    : "{0}&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp ",
                                Utility.sDbnull(dtRawResult.Rows[i]["Para_Name"]),
                                dtRawResult.Rows[i]["Test_result"]);
                            value = string.Format(
                                Utility.sDbnull(dtRawResult.Rows[i]["Test_result"]).Trim() != ""
                                    ? "{0} {1};"
                                    : "<i>{0}&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</i> ",
                                Utility.sDbnull(dtRawResult.Rows[i]["Para_Name"]),
                                dtRawResult.Rows[i]["Test_result"]);
                        }


                        patientResult.Append(value);
                        patientResult2.Append(value2);
                    }
                }
             //   int testTypeID = Utility.Int32Dbnull(Utilities.GetPropertyValue(cboTestType, "SelectedValue"), -1);
                //dt = new DataTable();
                //dt.Columns.Add("Patient_ID");
                //dt.Columns.Add("Barcode");
                //dt.Columns.Add("Test_Date");
                //dt.Columns.Add("AllResult");
                //dtRawResult =
                //    SPs.GtvtBaoCaoLuuNoBarCode(Utility.sDbnull(pFromBarcode),
                //                               Utility.sDbnull(pToDate),
                //                               Utility.Int16Dbnull(cboTestType.SelectedValue)).
                //        GetDataSet().Tables[0];
                //var patientResult = new StringBuilder();
                //dtRawResult.Rows.InsertAt(dtRawResult.NewRow(), 0);
                //dtRawResult.Rows[0]["Patient_ID"] = dtRawResult.Rows[1]["Patient_ID"];
                //dtRawResult.Rows.Add(dtRawResult.NewRow());
                //for (int i = 1; i <= dtRawResult.Rows.Count - 1; i++)
                //{
                //    if (Utility.sDbnull(dtRawResult.Rows[i]["Patient_ID"]) !=
                //        Utility.sDbnull(dtRawResult.Rows[i - 1]["Patient_ID"]))
                //    {
                //        var newdr = dt.NewRow();
                //        newdr["Patient_ID"] = dtRawResult.Rows[i - 1]["Patient_ID"];
                //        newdr["Barcode"] = dtRawResult.Rows[i - 1]["Barcode"];
                //        newdr["Test_Date"] = dtRawResult.Rows[i - 1]["Test_Date"];
                //        newdr["AllResult"] = patientResult.ToString();
                //        dt.Rows.Add(newdr);
                //        patientResult = new StringBuilder();
                //    }
                //    string value;
                //    value = string.Format(
                //        Utility.sDbnull(dtRawResult.Rows[i]["Test_result"]).Trim() != ""
                //            ? "{0} {1}; "
                //            : "{0} ",
                //        Utility.sDbnull(dtRawResult.Rows[i]["Para_Name"]),
                //        dtRawResult.Rows[i]["Test_result"]);
                //    patientResult.Append(value);
                //}
            }
          
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi"+ ex, "Thông báo", MessageBoxIcon.Warning);
                
            }
                
          
        }
        #endregion
        #region event Form
        private void frm_BaoCao_KetQua_NoBarcode_Load(object sender, EventArgs e)
        {
            LoadCombobox();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            PrintData();
            try
            {
                if(dt.Rows.Count<=0)
                {
                    Utility.ShowMsg("Không có dữ liệu để báo cáo","Thông Báo",MessageBoxIcon.Information);
                }
                else
                { 
                    string s = "";
                    if(cboTestType.SelectedValue.ToString() =="-1")
                    {
                        s = "TẤT CẢ CÁC LOẠI XÉT NGHIỆM";
                    }
                    else
                    {
                        s = string.Format("XÉT NGHIỆM {0}", cboTestType.SelectedText.ToUpper());
                    }
                    var crpt = new Crpt_BaoCaoLuu_NoBarcode();
                    var oForm = new frmPrintPreview("In Báo cáo lưu", crpt, true, true);
                    crpt.SetDataSource(dt);
                    crpt.DataDefinition.FormulaFields["Formula_1"].Text = "";
                    crpt.SetParameterValue("TongBenhNhan", dt.Rows.Count);
                    crpt.SetParameterValue("TestType_Name",s );
                    crpt.SetParameterValue("ParentBranchName", ManagementUnit.gv_sParentBranchName);
                    crpt.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                    crpt.SetParameterValue("sCurrentDate", dtpDatePrintFrom.Value);
                    oForm.crptViewer.ReportSource = crpt;
                    oForm.ShowDialog();
                    oForm.Dispose();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi" + ex,"Thông báo",MessageBoxIcon.Warning);
            }
        }
       
        private void frm_BaoCao_KetQua_NoBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    btnPrint.PerformClick();
                    break;
                case Keys.F5:
                    btnExportExcel.PerformClick();
                    break;
                case Keys.Escape:
                    btnCancel.PerformClick();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
  
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string pFromBarcode = dtpDatePrintFrom.Value.ToString("yyMMdd") + txtFromBarcode.Text.Trim().PadLeft(4, '0') +
                                  ".NB";
            string pToDate = dtpDatePrintFrom.Value.ToString("yyMMdd") + txtToBarcode.Text.Trim().PadLeft(4, '0') +
                             ".NB";
            int testTypeID = Utility.Int32Dbnull(Utility.GetPropertyValue(cboTestType, "SelectedValue"), -1);
            dtRawResult =
                SPs.GtvtBaoCaoLuuNoBarCode(Utility.sDbnull(pFromBarcode),
                                           Utility.sDbnull(pToDate),
                                           testTypeID).
                    GetDataSet().Tables[0];
            var dataTable = new DataTable();
            dataTable = lablinkhelper.Utilities.GetInversedDataTable(dtRawResult, "Para_Name", "Barcode", "Test_Result", "", false);
            if (dataTable.Rows.Count <= 0)
            {
                Utility.ShowMsg("Không tìm thấy kết quả !");
                return;
            }

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                GridEXColumn grdCol = new GridEXColumn(dataTable.Columns[i].ColumnName);
                grdAllPatientInfoAndResult.RootTable.Columns.Add(grdCol);
                //grdAllPatientInfoAndResult.RootTable.Columns[grdCol.Key].AggregateFunction = AggregateFunction.Count;
            }
            // grdAllPatientInfoAndResult.RootTable.Columns["Patient_ID"].Visible = false;
            //SetPropertiesCol("Barcode", "Barcode");
            // SetPropertiesCol("Test_Date", "Ngày Xét Nghiệm");
            // SetPropertiesCol("TestType_Name", "Loại XN");
            grdAllPatientInfoAndResult.DataSource = dataTable;
            grdAllPatientInfoAndResult.AutoSizeColumns();
            ExcelReport.ExportGridEx(grdAllPatientInfoAndResult);

        }
        private void SetPropertiesCol(string colName, string colCaption)
        {
            if (!dtRawResult.Columns.Contains(colName))
                return;
            grdAllPatientInfoAndResult.RootTable.Columns[colName].Caption = colCaption;
            grdAllPatientInfoAndResult.RootTable.Columns[colName].AutoSizeMode = ColumnAutoSizeMode.AllCellsAndHeader;
            grdAllPatientInfoAndResult.RootTable.Columns[colName].FilterRowComparison = ConditionOperator.Contains;
            //grdAllPatientInfoAndResult.RootTable.Columns[colName].AggregateFunction = AggregateFunction.None;

        }
        #endregion
    }
}
