using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasTiendas
{
    public class CreateQRCommand : OrderCommand
    {
        private QRCodeGenerator qr;
        private string path, originalFilename;
        private Order backup; 
        public CreateQRCommand(Order _order, string _path, string _originalFilename)
        {
            qr = new IronBarCodeAdapter();
            path = _path;
            originalFilename = _originalFilename; 
            order = _order;
            backup = null; 
        }
        public override void Execute()
        {
            backup = qr.ReadQR(originalFilename);
            qr.GenerateQR(order, path + $"\\order_{order.idStore.ToString().PadLeft(2, '0')}");
            order.AddCommand(this);
        }

        public override void Undo()
        {
            qr.GenerateQR(backup, path + $"\\order_{backup.idStore.ToString().PadLeft(2, '0')}"); 
        }
    }
}
