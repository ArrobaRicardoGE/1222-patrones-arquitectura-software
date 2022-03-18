using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    class Mouse : PeripheralInput
    {
        public Mouse()
        {
            Manufacturer = "Logitech";
            Model = "G305";
            Price = 799f;
            Connector = "Wireless USB";
            ValidPorts = new int[] { 1, 2 };
            Name = "Mouse"; 
        }
    }
}
