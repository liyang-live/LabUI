using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using LIS.DAL;
using Mabry.Windows.Forms.Barcode;
using Vietbait.Lablink.TestInformation.UI;
using VNS.Libs;
using System.Drawing;

namespace Lis.LoadData
{
    public class BarcodeInfo
    {
        public BarcodeInfo()
        {
            BarcodeData = "";
            BarcodeData2 = "";
            InsuranceNum = "";
            Sex = 1;
            PatientName = "";
            Tag = "";
            DisplayData = true;
            BarcodeSize = new Size(2000, 1000);
            BarcodeFontSize = 190;
            BarcodeFont = new Font("Arial", BarcodeFontSize, FontStyle.Bold, GraphicsUnit.Point, 0);
            BarcodeSymbology = Barcode.BarcodeSymbologies.Code128;
            NumberOfCopies = 1;
        }

        public string BarcodeData { get; set; }
        public string BarcodeData2 { get; set; }
        public string InsuranceNum { get; set; }
        public int Sex { get; set; }
        public string Dob { get; set; }
        public int Yearbirth { get; set; }
        public string PatientName { get; set; }
        public string Tag { get; set; }
        public bool DisplayData { get; set; }
        public Font BarcodeFont { get; set; }
        public float BarcodeFontSize { get; set; }
        public Barcode.BarcodeSymbologies BarcodeSymbology { get; set; }
        public Size BarcodeSize { get; set; }
        public int NumberOfCopies { get; set; }
        public string Department { get; set; }
        public string Room { get; set; }
        public string TestTypeName { get; set; }
        public DateTime Date { get; set; }

        public static string GetBarcodeForPatient(int patientId, int testTypeId, string intOrder)
        {
            try
            {
                string vBarcode = null;
                vBarcode = SPs.SpGetMaxBarcodeV2(testTypeId, patientId, 0, "").GetDataSet().Tables[0].Rows[0][0].ToString();

                //Dim vBarcode As String = Convert.ToString(SPs.SpGetMaxBarcodeV2(testTypeId, patientId, 0, Utility.sDbnull(grdPatientList.GetValue("Barcode").ToString().Substring(0, 6), "")).GetDataSet().Tables(0)(0)(0))
                if (vBarcode != "-1")
                {
                    vBarcode = (Utility.Int64Dbnull(vBarcode) + 1).ToString(CultureInfo.InvariantCulture);
                }

                if (vBarcode.Length == 12)
                {
                    vBarcode = vBarcode.Remove(6, 2);
                }
                if (SysPara.BarcodeDigit == 12)
                {
                    vBarcode = vBarcode.Insert(6, intOrder.PadLeft(2, '0'));
                }
                return vBarcode;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                return "-1";
            }
        }

        public static Barcode CreateNewBarcode(string vBarcodeData)
        {
            try
            {
                var vBarcode = new Barcode();
                vBarcode.Data = vBarcodeData;
                vBarcode.Size = new Size(600, 300);
                //vBarcode.Font = new Font("Arial", 44, FontStyle.Regular, GraphicsUnit.Point, 0); 
                vBarcode.Font = new Font("Arial", 44, FontStyle.Regular, GraphicsUnit.Point, 0);
                vBarcode.Symbology = Barcode.BarcodeSymbologies.Code128;
                return vBarcode;
            }
            catch (Exception)
            {
                var vBarcode = new Barcode();
                vBarcode.Data = "0000000000";
                vBarcode.Size = new Size(600, 300);
                vBarcode.Font = new Font("Arial", 44, FontStyle.Regular, GraphicsUnit.Point, 0);
                vBarcode.Symbology = Barcode.BarcodeSymbologies.Code128;
                return vBarcode;
            }
        }
    }
}