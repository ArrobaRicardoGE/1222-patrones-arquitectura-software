using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    class InkjetPrinter : PeripheralOutput
    {
        public InkjetPrinter()
        {
            Manufacturer = "Hewlett Packard";
            Model = "HP-IJ3003";
            Price = 3000.00f;
            ValidPorts = new int[] { 4 };
            Name = "Inkjet Printer";
        }
    }
}
