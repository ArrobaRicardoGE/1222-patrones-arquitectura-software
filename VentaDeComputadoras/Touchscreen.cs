using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    class Touchscreen : PeripheralHybrid
    {
        public Touchscreen()
        {
            Manufacturer = "Lenovo";
            Model = "LV-3220"; 
            Price = 4499.99f;
            Connector = "HDMI"; 
            ValidPorts = new int[] { 1, 2, 3 };
            Name = "Touchscreen";
        }
    }
}
