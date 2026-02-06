using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeitorDeCodigoDeBarras
{
    using System.Drawing;

    public static class ScreenCaptureService
    {
        public static Bitmap Capture_old(Rectangle area)
        {
            Bitmap bitmap = new Bitmap(1,1);

            if (area.Width == 0 || area.Height == 0)
            {
               
                return bitmap;
            }
            bitmap = new Bitmap(area.Width, area.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(
                    area.Location,
                    Point.Empty,
                    area.Size,
                    CopyPixelOperation.SourceCopy
                );
            }
            
            return bitmap;
        }

        public static Bitmap Capture(Rectangle area)
        {
            if (area.Width == 0 || area.Height == 0)
                return new Bitmap(1, 1);

            float scaleX, scaleY;
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                scaleX = g.DpiX / 96f;
                scaleY = g.DpiY / 96f;
            }

            // Corrige coordenadas para pixels físicos
            /*
            Rectangle scaledArea = new Rectangle(
                (int)(area.X * scaleX),
                (int)(area.Y * scaleY),
                (int)(area.Width * scaleX),
                (int)(area.Height * scaleY)
            );*/

            Bitmap bitmap = new Bitmap(area.Width, area.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(
                    area.Location,
                    Point.Empty,
                    area.Size,
                    CopyPixelOperation.SourceCopy
                );
            }

            return bitmap;
        }

    }

}
