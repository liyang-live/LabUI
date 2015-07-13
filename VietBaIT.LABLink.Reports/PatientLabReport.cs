using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using CrystalDecisions.CrystalReports.Engine;
using Mabry.Windows.Forms.Barcode;
using VietBaIT.CommonLibrary;
using VietBaIT.LABLink.LoadEnvironments;
using Vietbait.Lablink.Model;
using Microsoft.VisualBasic;
namespace VietBaIT.LABLink.Reports
{
    public class PatientLabReport
    {
        public static void InKetQuaHangLoat(DataTable dataTable)
        {

          
        }
        public static void PrintOne(bool Quick, int patientId, string testId, string vBarcodeData)
        {
            try
            {
                var dtForPrinting = new DataTable();
                dtForPrinting = SPs.SpGetTestResultForPrintV2(patientId, "ABC", testId).GetDataSet().Tables[0];
                if (dtForPrinting.Rows.Count <= 0)
                {
                    Utility.ShowMsg("Không có kết quả để in");
                    return;
                }

                if (!dtForPrinting.Columns.Contains("BarcodeImg"))
                    dtForPrinting.Columns.Add("BarcodeImg", typeof (byte[]));

                //Dim arrImage As Byte() = GenerateBarCode(Barcode1)

                //ProcessNormalResult(dtForPrinting);

                var vBarcode = new Barcode();
                vBarcode.Data = vBarcodeData;
                vBarcode.Size = new Size(100, 50);
                vBarcode.Symbology = Barcode.BarcodeSymbologies.Code128;
                byte[] dataBarcode = Utility.GenerateBarCode(vBarcode);
                foreach (DataRow dr in dtForPrinting.Rows)
                {
                    dr["BarcodeImg"] = dataBarcode;
                }
                dtForPrinting.AcceptChanges();

                //ReportDocument crpt = globalModule.GetCrystalReport(vReportType);
                String[] strAsm = SysPara.LabReportAsm.Split(',');
                Assembly vAssembly = Assembly.LoadFrom(strAsm[0]);
                ReportDocument crpt;
                object instance = vAssembly.CreateInstance(strAsm[1]);
                crpt = (ReportDocument) instance;
                // Kiểm tra thông số kết quả bất thường thì sẽ bôi đậm trong phiếu in kq cho lão khoa
                //if (SysPara.IsNormalResult == 1)
                //{
                //    ProcessNormalResult(dtForPrinting);
                //}
                //lablinkhelper.Utilities.UpdateLogotoDatatable(dtForPrinting)
                Utility.UpdateLogotoDatatable(ref dtForPrinting);
                crpt.SetDataSource(dtForPrinting);
                //crpt.DataDefinition.FormulaFields.Item("Formula_1").Text = " ";
                //crpt.SetDataSource(_testAllResult);
                crpt.SetParameterValue("ShowSubReport", 1);
                crpt.SetParameterValue("ShowMainReport", 0);
                crpt.SetParameterValue("ParentBranchName", ManagementUnit.gv_sParentBranchName);
                crpt.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                crpt.SetParameterValue("Address", ManagementUnit.gv_sAddress);
                crpt.SetParameterValue("sPhone", ManagementUnit.gv_sPhone);

                // crpt.SetParameterValue("BSThucHien", VietBaIT.CommonLibrary.globalVariables.Doctors)
                //crpt.SetParameterValue("PhongXN", VietBaIT.CommonLibrary.globalVariables.AssName)
                //thực hiện in phiếu xét nghiệm cho JCLV
                //if (vReportType == 4)
                //{
                //    UpdateData(dtForPrinting);
                //    crpt.SetParameterValue("sCurrentDate", Utility.GetFormatDateTime(DateTime.Now, "dd/MM/yyyy"));
                //    crpt.SetParameterValue("DMY", sGetCurrentDay);
                //}
                //if (vReportType == 2)
                //{
                //    crpt.SetParameterValue("sCurrentDate", VietBaIT.CommonLibrary.Utility.FormatDateTime(System.DateTime.Now));
                //}

                if (!Quick)
                {
                    //Dim objForm As New frmPrintPreview("In kết quả xét nghiệm", crpt, True, True)
                    var objForm =new VietBaIT.LABLink.Reports.frmPrintPreview("In kết quả xét nghiệm", crpt, true, true);
                    objForm.crptViewer.ReportSource = crpt;
                    objForm.ShowDialog();
                    objForm.Dispose();
                }
                else
                {
                    //objForm.crptViewer.ReportSource = crpt;
                    crpt.PrintToPrinter(1, false, 0, 0);
                }
                //mv_DTPatientInfor.AcceptChanges()
                //Utility.DefaultNow(Me)
                //UpdatePrintStatus(testId);
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
    }
}