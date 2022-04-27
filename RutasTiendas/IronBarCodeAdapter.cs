using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronBarCode;
using System.Text.Json;

namespace RutasTiendas
{
    public class IronBarCodeAdapter : QRCodeGenerator
    {
        public void GenerateQR(Order data, string filename)
        {
            BarcodeWriter.CreateBarcode(JsonSerializer.Serialize(data), BarcodeWriterEncoding.QRCode).SaveAsJpeg($"{filename}.jpg");
        }

        public Order ReadQR(string filename)
        {
            BarcodeResult Result = BarcodeReader.QuicklyReadOneBarcode(filename);
            if (Result != null) return JsonSerializer.Deserialize<Order>(Result.Text);
            throw new Exception("Invalid QR code");
        }
    }
}
