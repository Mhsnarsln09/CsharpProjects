using BarcodeApp.Services;
using BarcodeApp.Models;

class Program
{
    static void Main(string[] args)
    {
        var barcodeData = new BarcodeData
        {
            Content = "SampleBarcode12345",
            FilePath = "barcode.png"
        };

        var barcodeGenerator = new BarcodeGenerator();
        barcodeGenerator.GenerateBarcode(barcodeData);

        var barcodeReader = new BarcodeReaderService();
        var readContent = barcodeReader.ReadBarcode(barcodeData.FilePath);

        Console.WriteLine($"Read Barcode Content: {readContent}");
    }
}
