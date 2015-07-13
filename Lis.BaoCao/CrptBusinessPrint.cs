using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using LIS.DAL;
using Microsoft.VisualBasic;
using SubSonic;
using Vietbait.Lablink.TestInformation.UI;
using VNS.Libs;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
//using cls_SignInfor = VietBaIT.LABLink.Reports.Class.cls_SignInfor;
using cls_SignInfor_new =VNS.Libs.cls_SignInfor;

namespace VietBaIT.LABLink.Reports
{
    public class CrptBusinessPrint
    {
        private readonly DataTable ReportParameterTable = new DataTable();
        private string colName = "Name";
        private string colType = "Type";
        private string colValue = "Value";
        private cls_SignInfor mv_oNguoiKy;
        private string vFormulaFieldsType = "FormulaFields";
        private string vParameterType = "Parameter";
        public static DateTime printDateTime;
        public static List<int> testTypeList = new List<int>();
        private ReportDocument mv_oRptDoc;
            private CrystalReportViewer mv_oViewDoc;
           private readonly bool mv_bSetContent = true;
                private TextObject mv_oRptText;
       //  public string crptTrinhKyName { get; set; }
        private FieldObject mv_oRptFieldObj;

        public CrptBusinessPrint()
        {
            ReportParameterTable.Columns.Add(colType, typeof (string));
            ReportParameterTable.Columns.Add(colName, typeof (string));
            ReportParameterTable.Columns.Add(colValue, typeof (object));
            ReportParameterTable.Rows.Add(vParameterType, "ShowSubReport", 0);
            ReportParameterTable.Rows.Add(vParameterType, "ShowMainReport", 1);
            ReportParameterTable.Rows.Add(vParameterType, "ParentBranchName", globalVariables.ParentBranch_Name);
            ReportParameterTable.Rows.Add(vParameterType, "Address", globalVariables.Branch_Email);
            ReportParameterTable.Rows.Add(vParameterType, "BranchName", globalVariables.Branch_Name);
            ReportParameterTable.Rows.Add(vParameterType, "sPhone", globalVariables.Branch_Phone);
            ReportParameterTable.Rows.Add(vParameterType, "sHotPhone", globalVariables.Branch_Phone);
            ReportParameterTable.Rows.Add(vParameterType, "sCurrentDate", DateTime.Now.ToString("dd/MM/yyyy"));
            ReportParameterTable.Rows.Add(vParameterType, "PrintDate", printDateTime);
            ReportParameterTable.Rows.Add(vParameterType, "sTenBacSyChiDinh","");
            ReportParameterTable.Rows.Add(vParameterType, "sBacSyChiDinh", "");
            ReportParameterTable.Rows.Add(vParameterType, "sTenUser", "");
            //SqlQuery query = new Select(TblUser.Columns.SFullName).From(TblUser.Schema.Name + " WITH (NOLOCK) ").Where(TblUser.Columns.PkSuid).
            //    IsEqualTo(globalVariables.UserName);
            //SqlQuery query = new Select(TblUser.Columns.SFullName).From(TblUser.Schema.Name).Where(TblUser.Columns.PkSuid).
            //    IsEqualTo(globalVariables.UserName);
            //object userName = query.ExecuteScalar();

            string sql = string.Format("SELECT Sys_Users.sFullName \n"
           + "FROM   Sys_Users  WITH (NOLOCK)  \n"
           + "WHERE  Sys_Users.PK_sUID = '{0}'", globalVariables.UserName);

           var userName = new InlineQuery().ExecuteScalar<string>(sql);

            ReportParameterTable.Rows.Add(vParameterType, "Nguoidung", userName == null ? "" : userName.ToString());
            ReportParameterTable.Rows.Add(vParameterType, "DMY",
                                          string.Format("Ngày {0} tháng {1} năm {2}", DateTime.Now.Day,
                                                        DateTime.Now.Month, DateTime.Now.Year));
            ReportParameterTable.Rows.Add(vFormulaFieldsType, "Formula_1", Strings.Chr(34) +
                                                                           "        NGƯỜI LẬP BÁO CÁO                                                           NGƯỜI XÁC NHẬN                "
                                                                               .Replace("#$X$#",
                                                                                        Strings.Chr(34) + "&Chr(13)&" +
                                                                                        Strings.Chr(34)) +
                                                                           Strings.Chr(34));
            FormPreviewTitle = "VietBaIT JSC.,";
            StrCode = "";
        }

        public ReportDocument Crpt { get; set; }
        public DataTable ReportSourceTable { get; set; }
        public  string FormPreviewTitle { get; set; }
        public string StrCode { get; set; }
              

        public void AddParameter(string ParameterName, object ParameterValue)
        {
            try
            {
                ReportParameterTable.Rows.Add(vParameterType, ParameterName, ParameterValue);
            }
            catch (Exception)
            {
            }
        }

        public void AddFormulaField(string ParameterName, object ParameterValue)
        {
            try
            {
                ReportParameterTable.Rows.Add(vFormulaFieldsType, ParameterName, ParameterValue);
            }
            catch (Exception)
            {
            }
        }
       // public string path = string.Format("{0}{1}", globalVariables.gv_PathReport_BHYT, "NoiTiet_A5_General_crpt_DetailTestReport_ALL_New.rpt");
        public DateTime NGAY = Utility.getSysDate();
        public VNS.Libs.frmPrintPreview _oForm;

        public void Print(bool Quick,string printerName)
        {
            string path = "";// =SystemReports.GetPathReport(StrCode);
            try
            {
                if (Crpt == null && !string.IsNullOrEmpty(StrCode))
                {
                  
                    ReportDocument crptDocument=new ReportDocument();
                    crptDocument.Load(path);
                    Crpt = crptDocument; //GetCrptFromAssembly(StrCode);
                   // Crpt = GetCrptFromAssembly(StrCode);
                }

                if (ValidData())
                {
                    bool hasSubReport = CheckHasSubReport(Crpt);
                    var oForm = new frmPrintPreview("Phiếu KQ Xét nghiệm", Crpt, true, ReportSourceTable.Rows.Count <= 0 ? false : true);
                    oForm.crptTrinhKyName = Path.GetFileName(path);
                    if (!hasSubReport)
                    {
                        Crpt.SetDataSource(ReportSourceTable);
                        SetReportParameter(Crpt);
                       // var oForm = new frmPrintPreview(FormPreviewTitle, Crpt, true, true);
                 
                     
                    if (SysPara.ParamaterReport != null)
                        {
                            if (SysPara.ParamaterReport == "THANHNHAN")
                            {
                                var patientId = Utility.Int32Dbnull(ReportSourceTable.Rows[0]["Patient_ID"]);
                                var dtAssignDoctor =
                                    new Select(TTestInfo.Columns.AssignId, LUser.Columns.UserName).From(TTestInfo.Schema.Name).InnerJoin
                                        (LUser.UserIdColumn, TTestInfo.AssignIdColumn).Where(TTestInfo.Columns.PatientId).IsEqualTo(patientId).And(TTestInfo.Columns.TestTypeId).In(testTypeList).ExecuteDataSet().Tables[0];

                                if (dtAssignDoctor.Rows.Count > 0)
                                {

                                    Crpt.SetParameterValue("sBacSyChiDinh", "BÁC SỸ CHỈ ĐỊNH");
                                    Crpt.SetParameterValue("sTenBacSyChiDinh", Utility.sDbnull(dtAssignDoctor.Rows[0]["User_Name"]));
                                }
                                //else
                                //{
                                //    Crpt.SetParameterValue("sBacSyChiDinh", "");
                                //    Crpt.SetParameterValue("sTenBacSyChiDinh", "");
                                //}

                                var sFullName =
                                    new Select(SysUser.Columns.SFullName).From(SysUser.Schema.Name).Where(SysUser.Columns.PkSuid)
                                        .IsEqualTo(globalVariables.UserName).ExecuteScalar();
                                if (!string.IsNullOrEmpty(Utility.sDbnull(sFullName)))
                                {
                                    Crpt.SetParameterValue("sTenUser", sFullName);
                                }
                                //else
                                //{
                                //    Crpt.SetParameterValue("sTenUser","");
                                //}
                            }
                        }

                        oForm.crptViewer.ReportSource = Crpt;
                        // FieldObject mv_oRptFieldObj = Crpt.ReportDefinition.ReportObjects["Field150181"] as FieldObject;
                        // Crpt.PrintToPrinter();
                        if (Quick)
                        {
                            //    mv_oNguoiKy = new VietBaIT.LABLink.Reports.Class.cls_SignInfor(mv_oRptFieldObj, "", Crpt.ToString(), Crpt.DataDefinition.FormulaFields["Formula_1"].Text);
                            //  mv_oNguoiKy = new cls_SignInfor(Crpt.ToString(), "", ReportSourceTable);
                            //  mv_oNguoiKy = newcls_SignInfor(string.IsNullOrEmpty(oForm.crptTrinhKyName) , Crpt.ToString(),oForm.crptTrinhKyName, "", "");
                            mv_oNguoiKy = new cls_SignInfor_new(string.IsNullOrEmpty(oForm.crptTrinhKyName) ? oForm.crptTrinhKyName : oForm.crptTrinhKyName, "");
                            //      mv_oNguoiKy = newcls_SignInfor(" ", "", Crpt, ReportSourceTable);
                            //chkPrint_CheckedChanged(chkPrint, New System.EventArgs)
                            if (mv_oNguoiKy._TonTai)
                            {
                                Crpt.DataDefinition.FormulaFields["Formula_1"].Text = Strings.Chr(34) +
                                                                                      mv_oNguoiKy.mv_NOI_DUNG.Replace(
                                                                                          "&NHANVIEN",
                                                                                          globalVariables.UserName)
                                                                                          .Replace("\t",
                                                                                              Strings.Chr(34) +
                                                                                              "&Chr(13)&" +
                                                                                              Strings.Chr(34)) +
                                                                                      Strings.Chr(34);
                            }
                            else
                            {
                                Crpt.DataDefinition.FormulaFields["Formula_1"].Text = "";
                            }
                            Crpt.PrintOptions.PrinterName = printerName;
                            Crpt.PrintToPrinter(0, true, 0, 0);
                            Crpt.Dispose();
                            CleanTemporaryFolders();
                        }
                        else
                        {
                            oForm.ShowDialog();
                            oForm.Dispose();
                        }
                    }
                    else
                    {
                        //DataTable dt = new Select().From(TblTrinhky.Schema.Name).Where(TblTrinhky.Columns.ReportName).
                        //                            IsEqualTo(Crpt.GetClassName()).ExecuteDataSet().Tables[0];

                        string sql = string.Format("SELECT * \n"
                                                   + "FROM   Sys_Trinhky With (NOLOCK) \n"
                                                   + "WHERE  ReportName = N'{0}'", oForm.crptTrinhKyName);

                        var x = new InlineQuery().ExecuteAsCollection<SysTrinhkyCollection>(sql);

                        if (x.Count > 0)
                            Utility.GetDataRow(ReportParameterTable, colName, "Formula_1")[colValue] = Strings.Chr(34) +
                                                                                                       Utility.sDbnull(
                                                                                                           x[0]
                                                                                                               .ObjectContent) +
                                                                                                       Strings.Chr(34);

                        Crpt.SetDataSource(ReportSourceTable);
                        SetReportParameter(Crpt);
                        if (!ReportSourceTable.Columns.Contains("ParentBranchName"))
                            ReportSourceTable.Columns.Add("ParentBranchName");
                        if (!ReportSourceTable.Columns.Contains("BranchName"))
                            ReportSourceTable.Columns.Add("BranchName");

                        DataTable dtHematology = ReportSourceTable.Clone();
                        DataTable dtOther = ReportSourceTable.Clone();
                        DataTable dtImages = ReportSourceTable.Clone();
                           string sql2 = string.Format("SELECT Sys_Users.sFullName \n"
                                                    + "FROM   Sys_Users  WITH (NOLOCK)  \n"
                                                    + "WHERE  Sys_Users.PK_sUID = '{0}'", globalVariables.UserName);

                        var objuserName = new InlineQuery().ExecuteScalar<string>(sql2);

                        string sNguoiDung = objuserName == null ? "" : objuserName;
                        foreach (DataRow row in ReportSourceTable.Rows)
                        {
                            row["ParentBranchName"] = globalVariables.ParentBranch_Name;
                            row["BranchName"] = globalVariables.Branch_Name;
                            row["Nguoidung"] = sNguoiDung;

                            if (row["isHematology"].ToString() == "1")
                            {
                                if (row["Data_Sequence"].ToString().Contains("-"))
                                {
                                    string pvSImgPath = row["Test_Result"].ToString();
                                    if (File.Exists(pvSImgPath))
                                    {
                                        //row["BarcodeImg"] = Utility.bytGetImage(pvSImgPath);
                                        var bitmap = new Bitmap(pvSImgPath);
                                        Invert(ref bitmap);
                                        row["BarcodeImg"] = Utility.ConvertImageToByteArray(bitmap, ImageFormat.Tiff);
                                        dtImages.ImportRow(row);
                                    }
                                }
                                else dtHematology.ImportRow(row);
                            }
                            else dtOther.ImportRow(row);
                        }

                        // đẹt me lam rieng cho noi tiet to su bo no(.)

                        // cho cai kho A5
                        if (StrCode == "A5")
                        {
                            
                            
                            Crpt.Subreports["NoiTiet_A5_General_crpt_DetailTestReport_ALL_New_Sub_Hematology_Images.rpt"
                                ].SetDataSource(dtImages);
                            Crpt.Subreports["NoiTiet_A5_General_crpt_DetailTestReport_ALL_New_Sub_Hematology.rpt"]
                                .SetDataSource(dtHematology);
                            Crpt.Subreports["NoiTiet_A5_General_crpt_DetailTestReport_ALL_New_Sub_Other.rpt"]
                                .SetDataSource(dtOther);
                            SetReportParameter(
                                Crpt.Subreports["NoiTiet_A5_General_crpt_DetailTestReport_ALL_New_Sub_Other.rpt"]);
                            SetReportParameter(
                                Crpt.Subreports["NoiTiet_A5_General_crpt_DetailTestReport_ALL_New_Sub_Hematology.rpt"]);
                            //Crpt.SetParameterValue("PrintDate", printDateTime, Crpt.Subreports["NoiTiet_A5_General_crpt_DetailTestReport_ALL_New_Sub_Hematology.rpt"].Name);
                            //Crpt.SetParameterValue("PrintDate", printDateTime, Crpt.Subreports["NoiTiet_A5_General_crpt_DetailTestReport_ALL_New_Sub_Other.rpt"].Name);
                            
                            SetReportParameter(Crpt);
                        }
                            // cho cai kho A4
                        else if (StrCode == "A4")
                        {
                            SetReportParameter(
                                Crpt.Subreports["NoiTiet_A4_General_crpt_DetailTestReport_ALL_New_Sub_Other.rpt"]);
                            SetReportParameter(
                                Crpt.Subreports["NoiTiet_A4_General_crpt_DetailTestReport_ALL_New_Sub_Hematology.rpt"]);
                            
                            Crpt.Subreports["NoiTiet_A4_General_crpt_DetailTestReport_ALL_New_Sub_Hematology_Images.rpt"
                                ].SetDataSource(dtImages);
                            Crpt.Subreports["NoiTiet_A4_General_crpt_DetailTestReport_ALL_New_Sub_Hematology.rpt"]
                                .SetDataSource(dtHematology);
                            Crpt.Subreports["NoiTiet_A4_General_crpt_DetailTestReport_ALL_New_Sub_Other.rpt"]
                                .SetDataSource(dtOther);
                            SetReportParameter(Crpt);
                            //  Crpt.SetParameterValue("Nguoidung", sNguoiDung);
                        }
                            //neu deo khai bao A4 hay A5 thi mac dinh lay cai nay nhung pai dung cai bao cao ko an cut no chay dc.
                        else if (StrCode == "LABREPORT")
                        {
                            SetReportParameter(
                                Crpt.Subreports["NoiTiet_A4_General_crpt_DetailTestReport_ALL_New_Sub_Other.rpt"]);
                            SetReportParameter(
                                Crpt.Subreports["NoiTiet_A4_General_crpt_DetailTestReport_ALL_New_Sub_Hematology.rpt"]);
                            Crpt.Subreports["NoiTiet_A4_General_crpt_DetailTestReport_ALL_New_Sub_Hematology_Images.rpt"
                                ].SetDataSource(dtImages);
                            Crpt.Subreports["NoiTiet_A4_General_crpt_DetailTestReport_ALL_New_Sub_Hematology.rpt"]
                                .SetDataSource(dtHematology);
                            Crpt.Subreports["NoiTiet_A4_General_crpt_DetailTestReport_ALL_New_Sub_Other.rpt"]
                                .SetDataSource(dtOther);
                            SetReportParameter(Crpt);
                        }
                      //  if (Quick) Crpt.PrintToPrinter(0, false, 0, 0);
                        if (Quick)
                        {
                            //    mv_oNguoiKy = new VietBaIT.LABLink.Reports.Class.cls_SignInfor(mv_oRptFieldObj, "", Crpt.ToString(), Crpt.DataDefinition.FormulaFields["Formula_1"].Text);
                            //  mv_oNguoiKy = new cls_SignInfor(Crpt.ToString(), "", ReportSourceTable);
                            //  mv_oNguoiKy = newcls_SignInfor(string.IsNullOrEmpty(oForm.crptTrinhKyName) , Crpt.ToString(),oForm.crptTrinhKyName, "", "");
                            mv_oNguoiKy =
                                new cls_SignInfor_new(
                                    string.IsNullOrEmpty(oForm.crptTrinhKyName)
                                        ? oForm.crptTrinhKyName
                                        : oForm.crptTrinhKyName, "");
                            //      mv_oNguoiKy = newcls_SignInfor(" ", "", Crpt, ReportSourceTable);
                            //chkPrint_CheckedChanged(chkPrint, New System.EventArgs)
                            if (mv_oNguoiKy._TonTai)
                            {
                                Crpt.DataDefinition.FormulaFields["Formula_1"].Text = Strings.Chr(34) +
                                                                                      mv_oNguoiKy.mv_NOI_DUNG.Replace(
                                                                                          "&NHANVIEN",
                                                                                          globalVariables.UserName)
                                                                                          .Replace("\t",
                                                                                              Strings.Chr(34) +
                                                                                              "&Chr(13)&" +
                                                                                              Strings.Chr(34)) +
                                                                                      Strings.Chr(34);
                            }
                            else
                            {
                                Crpt.DataDefinition.FormulaFields["Formula_1"].Text = "";
                            }

                            Crpt.PrintOptions.PrinterName = printerName;
                            Crpt.PrintToPrinter(0, true, 0, 0);
                            Crpt.Dispose();
                            CleanTemporaryFolders();
                        }
                        else
                        {
                          //  var oForm = newfrmPrintPreview("Phiếu KQ Xét nghiệm", Crpt, true, ReportSourceTable.Rows.Count <= 0 ? false : true);
                         //   oForm.crptTrinhKyName = Path.GetFileName(path);
                       
                            oForm.ShowDialog();
                            oForm.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }


        private void EmptyFolderContents(string folderName)
        {
            foreach (var folder in Directory.GetDirectories(folderName))
            {
                try
                {
                   
                    Directory.Delete(folder, true);
                }
                catch (Exception excep)
                {
                    System.Diagnostics.Debug.WriteLine(excep);
                }
            }
            foreach (var file in Directory.GetFiles(folderName))
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception excep)
                {
                    System.Diagnostics.Debug.WriteLine(excep);
                }
            }
        }

        private void CleanTemporaryFolders()
        {
            try
            {
                String tempFolder = Environment.ExpandEnvironmentVariables("%TEMP%");
                // String recent = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + "\\Recent";
                // String prefetch = Environment.ExpandEnvironmentVariables("%SYSTEMROOT%") + "\\Prefetch";
                EmptyFolderContents(tempFolder);
                // EmptyFolderContents(recent);
                // EmptyFolderContents(prefetch);
            }
            catch (Exception)
            {


            }

        }


        private bool CheckHasSubReport(ReportDocument crReportDocument)
        {
            try
            {
                Sections crSections; // = default(Sections);
                //Section crSection = default(Section);
                SubreportObject crSubreportObject;

                crSections = crReportDocument.ReportDefinition.Sections;
                foreach (object crSection in crSections)
                {
                    ReportObjects crReportObjects = ((Section) crSection).ReportObjects;
                    foreach (object crReportObject in crReportObjects)
                    {
                        if (((ReportObject) crReportObject).Kind == ReportObjectKind.SubreportObject) return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SetReportParameter(ReportDocument currentCrpt)
        {
            foreach (DataRow dr in ReportParameterTable.Rows)
            {
                if (Utility.sDbnull(dr[colType]) == vParameterType)
                    try
                    {
                        if (!currentCrpt.IsSubreport)
                        {
                            currentCrpt.SetParameterValue(Utility.sDbnull(dr[colName]), dr[colValue]);
                        }
                        else
                        {
                            Crpt.SetParameterValue(Utility.sDbnull(dr[colName]), dr[colValue], currentCrpt.Name);
                        }
                    }
                    catch (Exception)
                    {
                    }
                else if (Utility.sDbnull(dr[colType]) == vFormulaFieldsType)
                {
                    try
                    {
                        currentCrpt.DataDefinition.FormulaFields[Utility.sDbnull(dr[colName])].Text =
                            Utility.sDbnull(dr[colValue]);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private bool ValidData()
        {
            try
            {
                if (Crpt == null)
                {
                    Utility.ShowMsg("Báo cáo chưa được khai báo");
                    return false;
                }
                if (ReportSourceTable == null | ReportSourceTable.Rows.Count <= 0)
                {
                    Utility.ShowMsg("Không có dữ liệu để in");
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

      
        public static ReportDocument GetCrptFromAssembly(string ReportCode)
        {
            try
            {
                ReportDocument crpt = new ReportDocument();
                string path = "";//SystemReports.GetPathReport(ReportCode);
                DataTable sysReporTable = new Select().From(SysReport.Schema.Name).ExecuteDataSet().Tables[0];
                DataRow drvRow= Utility.GetDataRow(sysReporTable, SysReport.Columns.MaBaocao, ReportCode);
                string sName = Utility.sDbnull(drvRow[SysReport.Columns.FileChuan]);
                crpt.Load(path);
                return crpt;

            }
            catch (Exception)
            {
                return null;
            }
        }

        //private unsafe void Invert(Bitmap bmp)
        //{
        //    int w = bmp.Width, h = bmp.Height;
        //    BitmapData data = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

        //    int* bytes = (int*)data.Scan0;
        //    for (int i = w * h - 1; i >= 0; i--)
        //        bytes[i] = ~bytes[i];
        //    bmp.UnlockBits(data);
        //}
        private static void Invert(ref Bitmap bmp)
        {
            try
            {
                Bitmap temp = bmp;
                var bmap = (Bitmap) temp.Clone();
                for (int i = 0; i < bmap.Width; i++)
                {
                    for (int j = 0; j < bmap.Height; j++)
                    {
                        Color c = bmap.GetPixel(i, j);
                        bmap.SetPixel(i, j,
                                      Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                    }
                }
                bmp = (Bitmap) bmap.Clone();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}