using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vietbait.Lablink.TestInformation.UI
{
    public class ColorEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (var ofd = new ColorDialog())
            {
                if (value == null) value = "#FFFFFF";
                    ofd.Color = ColorTranslator.FromHtml(value.ToString());
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ColorTranslator.ToHtml(ofd.Color);
                }
            }
            return value;
        }
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            try
            {
                using (var brush = new SolidBrush(ColorTranslator.FromHtml(e.Value.ToString())))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
                e.Graphics.DrawRectangle(Pens.Black, e.Bounds);
            }
            catch (Exception)
            {
            }
        }
    }
}
