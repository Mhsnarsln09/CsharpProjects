using ZXing;
using ZXing.Common;
using System.Drawing;
using System.Drawing.Imaging;
using BarcodeApp.Models;

namespace BarcodeApp.Services
{
    public class BarcodeGenerator
    {
        public void GenerateBarcode(BarcodeData data)
        {
            var writer = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Width = 300,
                    Height = 100
                }
            };

            var pixelData = writer.Write(data.Content);

            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))
            {
                var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), 
                                                 ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
                try
                {
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }
                bitmap.Save(data.FilePath, ImageFormat.Png);
            }
        }
    }
}
