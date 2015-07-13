using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public class HisLisProperties
    {
        [Browsable(true), ReadOnly(false), Category("HIS Config"),
         Description("Tên máy chủ"),
         DisplayName("Database Server")]
        public string HisServer { get; set; }

        [Browsable(true), ReadOnly(false), Category("HIS Config"),
         Description("Tên đăng nhập"),
         DisplayName("User ID")]
        public string HisUserId { get; set; }

        [Browsable(true), ReadOnly(false), Category("HIS Config"),
         Description("Mật Khẩu"),
         DisplayName("Password")]
        public string HisPassword { get; set; }

        [Browsable(true), ReadOnly(false), Category("HIS Config"),
         Description("Tên CSDL"),
         DisplayName("DataBase")]
        public string HisDataBase { get; set; }

        [Browsable(true), ReadOnly(false), Category("UI Config"),
         Description("Hỏi khi xóa dữ liệu"),
         DisplayName("Ask when delete")]
        public bool AskWhenDelete { get; set; }

        [Browsable(true), ReadOnly(false), Category("Barcode"),
         Description("Chọn tên máy in"),
         DisplayName("Barcode Printer Name")]
        public string BarcodePrinterName { get; set; }

    }
}
