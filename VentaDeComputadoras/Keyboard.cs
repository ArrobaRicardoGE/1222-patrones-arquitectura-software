using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    class Keyboard : PeripheralInput
    {
        public Keyboard()
        {
            Manufacturer = "Kemove";
            Model = "Snowfox";
            Price = 1399f;
            Connector = "USB-C"; 
            ValidPorts = new int[] { 2, 3, 5};
            Name = "Keyboard"; 
        }
    }
}
