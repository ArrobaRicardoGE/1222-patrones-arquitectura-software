using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    class Monitor : PeripheralOutput
    {
        public Monitor()
        {
            Manufacturer = "Samsung";
            Model = "SM-3009";
            Price = 2759.99f;
            ValidPorts = new int[] { 4, 5, 6 };
            Name = "Monitor"; 
        }
    }
}
