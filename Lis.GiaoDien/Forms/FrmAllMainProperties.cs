using System.ComponentModel;
using System.Drawing.Design;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public class FrmAllMainProperties
    {
        private const string ResultColor = "Result Color";

        public FrmAllMainProperties()
        {
            NormalColor = "#000000";
            LowColor = "#000000";
            HighColor = "#000000";
            TieuDeInPhieuChiDinh = "Phiếu in chỉ định xét nghiệm";
            TieuDeInPhieuKq = "Phiếu kết quả";
            ChieuCao = 100;
            ChieuRong = 80;
            SoTemp = 2;
            CanGiua = 10;
            CanLe = 0;
            CanTraiPhai = 1;
            SoLuongIn = 1;
            CanTop = 0;
            TieuDeInXNKhac = "IN XN KHAC";
        }

        // private const string Config = "Config Hide";
        // private const string ResultFont = "Result Font";
        [Browsable(true), ReadOnly(false), Category(ResultColor),
         Description("Màu của kết quả bình thường"),
         DisplayName("Kết quả bình thường"),
         Editor(typeof (ColorEditor), typeof (UITypeEditor))]
        public string NormalColor { get; set; }

        [Browsable(true), ReadOnly(false), Category(ResultColor),
         Description("Màu của kết quả nằm dưới ngưỡng trung bình"),
         DisplayName("Kết quả thấp"),
         Editor(typeof (ColorEditor), typeof (UITypeEditor))]
        public string LowColor { get; set; }

        [Browsable(true), ReadOnly(false), Category(ResultColor),
         Description("Màu của kết quả nằm trên ngưỡng trung bình"),
         DisplayName("Kết quả cao"),
         Editor(typeof (ColorEditor), typeof (UITypeEditor))]
        public string HighColor { get; set; }

        [Browsable(true), ReadOnly(false), Category("Tiêu đề"),
         Description("Hiển thị tiêu đề in phiếu chỉ định"),
         DisplayName("Tiêu đề in phiếu chỉ định")]
        public string TieuDeInPhieuChiDinh { get; set; }
        [Browsable(true), ReadOnly(false), Category("Tiêu đề"),
       Description("Hiển thị tiêu đề in phiếu kết quả"),
       DisplayName("Tiêu đề in phiếu kết quả")]
        public string TieuDeInPhieuKq { get; set; }
        [Browsable(true), ReadOnly(false), Category("Hide Config"),
         Description(" Cho phép hiển thị tab"),
         DisplayName("Hiện thị Tab cập nhật kết quả")]
        public bool TabCapNhapKetQua { get; set; }

        [Browsable(true), ReadOnly(false), Category("Hide Config"),
         Description(" Cho phép hiển thị tab"),
         DisplayName("Hiện thị Tab xử lý dữ liệu")]
        public bool TabXulyDL { get; set; }

        [Browsable(true), ReadOnly(false), Category("Hide Config"),
         Description(" Cho phép hiển thị cột Ngày có KQ"),
         DisplayName("Hiện thị cột Ngày có KQ")]
        public bool ResultDateColumn { get; set; }

        [Browsable(true), ReadOnly(false), Category("Config Barcode"),
       Description("Chiều rộng"),
       DisplayName("Chiều rộng")]
        public int ChieuRong { get; set; }
        [Browsable(true), ReadOnly(false), Category("Config Barcode"),
      Description("Chiều Cao"),
      DisplayName("Chiều Cao")]
        public int ChieuCao { get; set; }
        [Browsable(true), ReadOnly(false), Category("Config Barcode"),
    Description("Căn lề"),
    DisplayName("Căn lề"),]
        public int CanLe { get; set; }
        [Browsable(true), ReadOnly(false), Category("Config Barcode"),
  Description("Căn Giữa"),
  DisplayName("Căn Giữa"),]
        public int CanGiua { get; set; }
        [Browsable(true), ReadOnly(false), Category("Config Barcode"),
Description("Số tem in"),
DisplayName("Số tem in"),]
        public int SoTemp { get; set; }
        [Browsable(true), ReadOnly(false), Category("Config Barcode"),
Description("Căn trái phải"),
DisplayName("Căn trái phải"),]
        public int CanTraiPhai { get; set; }
        [Browsable(true), ReadOnly(false), Category("Config Barcode"),
Description("Số bản copy"),
DisplayName("Số bản copy"),]
        public int SoLuongIn { get; set; }
        [Browsable(true), ReadOnly(false), Category("Config Barcode"),
Description("Top"),
DisplayName("Top"),]
        public int CanTop { get; set; }
        [Browsable(true), ReadOnly(false), Category("Tiêu đề"),
Description("Tieu de in XN Khac"),
DisplayName("Tieu de in XN Khac"),]
        public string TieuDeInXNKhac { get; set; }
    }
}