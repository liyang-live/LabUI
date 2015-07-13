using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LIS.DAL;
using SubSonic;
using VNS.Libs;

namespace Vietbait.Lablink.TestInformation.UI
{
    public class SysPara
    {
        private static DataTable dtSystemParameters = GetSystemParametersTable();

        public static int AutoGenerateBarcode =
            Utility.Int32Dbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "AUTOGENERATEBARCODE"), 0);

        public static int AllowSameTestTypeInDay =
            Utility.Int32Dbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "AllowSameTestTypeInDay"), 0);

        /// <summary>
        /// Sử dụng ngày đăng ký để tạo barcode xét nghiệm cho bệnh nhân
        /// </summary>
        public static int UseRegDateToGenerateBarcode =
            Utility.Int32Dbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "USEREGDATETOGENERATEBARCODE"), 0);

        /// <summary>
        /// Sử dụng ngày đăng ký để tạo barcode xét nghiệm cho bệnh nhân
        /// </summary>
        public static string ShowHideReportHeader =
             Utility.sDbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "SHOWANDHIDEREPORTHEADER"), "SHOW");


        /// <summary>
        /// Sử dụng 1 barcode duy nhất cho bệnh nhân
        /// </summary>
        public static int UseOneBarcodeForPatient =
            Utility.Int32Dbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "USEONEBARCODEFORPATIENT"), 0);


        public static int BarcodeDigit =
            Utility.Int32Dbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "BARCODEDIGIT"), 10);

        public static int ReportType =
            Utility.Int32Dbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "REPORTTYPE"), 0);

        public static int ReportType2 =
            Utility.Int32Dbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "REPORTTYPE_2"), ReportType);

        public static int AutoGeneratePatient =
            Utility.Int32Dbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "AUTOGENERATEPATIENT"), 0);

        public static int IsNormalResult =
            Utility.Int32Dbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "ISNORMALRESULT"), 1);

        public static string BarcodeType =
            Utility.sDbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "BARCODETYPE"), "NHTD");

        public static int BarcodePrintDigit =
            Utility.Int32Dbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "BARCODEPRINTDIGIT"), BarcodeDigit);

        public static string FlowSend =
            Utility.sDbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "FLOWSEND"), "PID");

        public static string LabReportAsm =
            Utility.sDbnull(
                GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                        SysSystemParameter.Columns.SValue, "LABREPORTASM"));
        public static string SendResult =
          Utility.sDbnull(
              GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                      SysSystemParameter.Columns.SValue, "SENDRESULT"));
        public static string ParamaterReport =
         Utility.sDbnull(
             GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                     SysSystemParameter.Columns.SValue, "REPORT"));
        public static int ReportUpdateDelete =
         Utility.Int32Dbnull(
             GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                     SysSystemParameter.Columns.SValue, "REPORTUPDATEDELETE"));
        public static int AutoFillByCmt =
         Utility.Int32Dbnull(
             GetValueDatatableColumn(dtSystemParameters, SysSystemParameter.Columns.SName,
                                     SysSystemParameter.Columns.SValue, "AUTOFILLBYCMT"));


        private static object GetValueDatatableColumn(DataTable dt, String SearchColumn, String ValueColumn, Object sValue)
        {
            try
            {
                return (from DataRow dr in dt.Rows
                        where dr[SearchColumn].ToString().Trim().ToUpper() == sValue.ToString().Trim().ToUpper()
                        select dr[ValueColumn]).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }

        }

        private static DataTable GetSystemParametersTable()
        {
            try
            {
                return new Select().From(SysSystemParameter.Schema.Name).ExecuteDataSet().Tables[0];
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}