using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZXing;


namespace LeitorDeCodigoDeBarras
{

    public static class BarcodeReaderService
    {
        public static string ReadFromBitmap(Bitmap bitmap)
        {
            var reader = new BarcodeReader
            {
                AutoRotate = true
            };

           // reader.Options.TryInverted = true;

            var result = reader.Decode(bitmap);
            return result != null ? result.Text : null;
        }
    }
}
