using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using LIS.DAL;
using Lis.LoadData;
using Microsoft.VisualBasic;
using newLib;
using SubSonic;
using VNS.Libs;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using cls_SignInfor = VietBaIT.LABLink.Reports.Class.cls_SignInfor;

namespace VietBaIT.LABLink.Reports
{
    public class CrptBusiness
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

        public CrptBusiness()
        {
            ReportParameterTable.Columns.Add(colType, typeof (string));
            ReportParameterTable.Columns.Add(colName, typeof (string));
            ReportParameterTable.Columns.Add(colValue, typeof (object));
            ReportParameterTable.Rows.Add(vParameterType, "ShowSubReport", 0);
            ReportParameterTable.Rows.Add(vParameterType, "ShowMainReport", 1);
            ReportParameterTable.Rows.Add(vParameterType, "ParentBranchName", ManagementUnit.gv_sParentBranchName);
            ReportParameterTable.Rows.Add(vParameterType, "Address", ManagementUnit.gv_sAddress);
            ReportParameterTable.Rows.Add(vParameterType, "BranchName", ManagementUnit.gv_sBranchName);
            ReportParameterTable.Rows.Add(vParameterType, "sPhone", ManagementUnit.gv_sPhone);
            ReportParameterTable.Rows.Add(vParameterType, "sHotPhone", ManagementUnit.gv_sHotPhone);
            ReportParameterTable.Rows.Add(vParameterType, "sCurrentDate", DateTime.Now.ToString("dd/MM/yyyy"));
            ReportParameterTable.Rows.Add(vParameterType, "PrintDate", printDateTime);
            
            
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
            FormPreviewTitle = "LIS.,";
            StrCode = "";
        }

        public ReportDocument Crpt { get; set; }
        public DataTable ReportSourceTable { get; set; }
        public string FormPreviewTitle { get; set; }
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

      
        public void Print(bool Quick,string printerName)
        {
            try
            {
                if (Crpt == null && !string.IsNullOrEmpty(StrCode))
                {
                    Crpt = GetCrptFromAssembly(StrCode);
                }

                if (ValidData())
                {
                    bool hasSubReport = CheckHasSubReport(Crpt);
                    if (!hasSubReport)
                    {
                        Crpt.SetDataSource(ReportSourceTable);
                        if(Utility.sDbnull(printDateTime) !=null)
                        {
                            Crpt.SetParameterValue("PrintDate",printDateTime);
                        }
                        //if(SysPara.ParamaterReport.ToUpper() == "THANHNHAN")
                        //{
                        //    var sFullName =
                        //        new Select(TblUser.Columns.SFullName).From(TblUser.Schema.Name).Where(
                        //            TblUser.Columns.PkSuid).IsEqualTo(globalVariables.UserName).ExecuteScalar();
                        //    if (sFullName != null)
                        //    {
                        //        Crpt.SetParameterValue("sTenUser", sFullName);
                        //    }
                        //    else
                        //    {
                        //        Crpt.SetParameterValue("sTenUser"," ");
                        //    }
                        //}
                        SetReportParameter(Crpt);
                        var oForm = new VNS.Libs.frmPrintPreview(FormPreviewTitle, Crpt, true, true);
                        
                        oForm.ReportSourceTable = ReportSourceTable;
                        // FieldObject mv_oRptFieldObj = Crpt.ReportDefinition.ReportObjects["Field150181"] as FieldObject;
                        // Crpt.PrintToPrinter();
                        if (Quick)
                        {
                            //mv_oNguoiKy = new VietBaIT.LABLink.Reports.Class.cls_SignInfor(mv_oRptFieldObj, "", Crpt.ToString(), Crpt.DataDefinition.FormulaFields["Formula_1"].Text);
                            mv_oNguoiKy = new cls_SignInfor(Crpt.ToString(), "",ReportSourceTable);
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
                                                   + "FROM   sys_Trinhky With (NOLOCK) \n"
                                                   + "WHERE  ReportName = N'{0}'", Crpt.GetClassName());

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


                        //object objuserName =
                        //    new Select(TblUser.Columns.SFullName).From(TblUser.Schema).Where(TblUser.Columns.PkSuid).
                        //                                          IsEqualTo(globalVariables.UserName).ExecuteScalar();
                        string sql2 = string.Format("SELECT Sys_Users.sFullName \n"
                                                    + "FROM   Sys_Users  WITH (NOLOCK)  \n"
                                                    + "WHERE  Sys_Users.PK_sUID = '{0}'", globalVariables.UserName);

                        var objuserName = new InlineQuery().ExecuteScalar<string>(sql2);

                        string sNguoiDung = objuserName == null ? "" : objuserName;
                        foreach (DataRow row in ReportSourceTable.Rows)
                        {
                            row["ParentBranchName"] = ManagementUnit.gv_sParentBranchName;
                            row["BranchName"] = ManagementUnit.gv_sBranchName;
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
                        if (Quick) Crpt.PrintToPrinter(0, false, 0, 0);
                        else
                        {
                            var oForm = new VNS.Libs.frmPrintPreview(FormPreviewTitle, Crpt, true, true);
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
                DataRow dr = Utility.GetDataRow(PreloadedLists.AssemblyReport,
                                                LAssemblyReport.Columns.AssemblyReportId, ReportCode);
                string sdllName = Utility.sDbnull(dr[LAssemblyReport.Columns.SDLLname]);

                string sAssemblyName = Utility.sDbnull(dr[LAssemblyReport.Columns.SAssemblyName]);

                //Assembly asm = Assembly.LoadFrom(Utility.sDbnull(dr[LAssemblyReport.Columns.SDLLname]));
                return (from type in Assembly.LoadFrom(sdllName).GetTypes()
                        where type.FullName == Utility.sDbnull(sAssemblyName)
                        select (ReportDocument) Activator.CreateInstance(type)).FirstOrDefault();
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