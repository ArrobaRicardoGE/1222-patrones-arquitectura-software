using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasTiendas
{
    abstract class QRCodeGenerator
    {
        public abstract void GenerateQR(string data, string route);
        public abstract string ReadQR(string path); 
    }
}
