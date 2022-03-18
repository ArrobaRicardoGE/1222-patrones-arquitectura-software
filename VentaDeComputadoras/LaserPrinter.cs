using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    class LaserPrinter : PeripheralOutput
    {
        public LaserPrinter()
        {
            Manufacturer = "Hewlett Packard";
            Model = "HP-LP4456";
            Price = 4999.99f;
            ValidPorts = new int[] { 4, 6 };
            Name = "Laser Printer";
        }
    }
}
