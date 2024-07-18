using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;
using System.Drawing;

namespace BarcodeApp.Services
{
    public class BarcodeReaderService
    {
        public string ReadBarcode(string filePath)
        {
            var reader = new BarcodeReaderGeneric
            {
                Options = new DecodingOptions
                {
                    PossibleFormats = new[] { BarcodeFormat.CODE_128 }
                }
            };

            using (var bitmap = (Bitmap)Image.FromFile(filePath))
            {
                var source = new BitmapLuminanceSource(bitmap);
                var binarizer = new HybridBinarizer(source);
                var binaryBitmap = new BinaryBitmap(binarizer);
                var result = reader.Decode(source);
                return result?.Text;
            }
        }
    }
}
