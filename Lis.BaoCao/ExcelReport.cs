using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX.Export;
using VNS.Libs;

namespace VietBaIT.LABLink.Reports
{
    public class ExcelReport
    {
        public static void ExportGridEx(Janus.Windows.GridEX.GridEX gridEx )
        {
            Stream sw = null;
            try
            {
                var sd = new SaveFileDialog { Filter = "Excel File (*.xml)|*.xml" };
                if (sd.ShowDialog() == DialogResult.OK)
                {
                    //sw = new FileStream(sd.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    sw = new FileStream(sd.FileName, FileMode.Create);
                    GridEXExporter grdListExporter = new GridEXExporter();
                    grdListExporter.IncludeExcelProcessingInstruction = true;
                    grdListExporter.IncludeFormatStyle = true;
                    grdListExporter.IncludeHeaders = true;
                    grdListExporter.GridEX = gridEx;
                    grdListExporter.Export(sw);
                    Utility.ShowMsg("Xuất dữ liệu thành công");
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}
