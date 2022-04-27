﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasTiendas
{
    public interface QRCodeGenerator
    {
        public void GenerateQR(Order data, string filename);
        public string ReadQR(string filename); 
    }
}
