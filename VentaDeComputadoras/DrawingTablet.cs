using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    class DrawingTablet : PeripheralInput
    {
        public DrawingTablet()
        {
            Manufacturer = "Wacom";
            Model = "CTL400LW";
            Price = 1949f;
            Connector = "Bluetooth";
            ValidPorts = new int[] { 1, 2, 3 };
            Name = "Drawing Tablet";
        }
    }
}
