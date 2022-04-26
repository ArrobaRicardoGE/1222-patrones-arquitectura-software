using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronBarCode;

namespace RutasTiendas
{
    class IronBarCodeAdapter : QRCodeGenerator
    {
        public override void GenerateQR(string data, string filename)
        {
            BarcodeWriter.CreateBarcode(data, BarcodeWriterEncoding.QRCode).SaveAsJpeg($"{filename}.jpg");
        }

        public override string ReadQR(string path)
        {
            BarcodeResult Result = BarcodeReader.QuicklyReadOneBarcode(path);
            if (Result != null) return Result.Text;
            throw new Exception("Invalid QR code"); 
        }
    }
}
