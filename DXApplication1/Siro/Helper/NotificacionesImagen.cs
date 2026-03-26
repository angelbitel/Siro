using DevExpress.XtraLayout;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Siro.Helper
{
    internal static class NotificacionesImagen
    {
        internal static List<string> Errores { get; set; }
        internal static void BlankMesageControl(LayoutControlItem[] layoutControllItems)
        {
            layoutControllItems.ToList().ForEach(f =>
            {
                f.ImageOptions.Image = null;
                f.OptionsToolTip.ToolTip = null;
            });

            if (Errores == null)
                Errores = new List<string>();
        }
        private static Bitmap ResizeBitmap(Bitmap sourceBitmap, int newWidth, int newHeight)
        {
            Bitmap resizedBitmap = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(resizedBitmap))
            {
                g.DrawImage(sourceBitmap, 0, 0, newWidth, newHeight);
            }
            return resizedBitmap;
        }
        internal static void SetMessageLayaoutControlItem(LayoutControlItem layoutControlItem, string msg)
        {
            layoutControlItem.ImageOptions.Image = ResizeBitmap(Properties.Resources.warning, 15, 15);
            layoutControlItem.OptionsToolTip.ToolTip = msg;
            if (Errores == null)
                Errores = new List<string>();
            Errores.Add(msg);
        }
    }
}
