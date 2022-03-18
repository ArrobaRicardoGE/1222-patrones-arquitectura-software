using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    class PeripheralOutputCreator : Creator
    {
        public PeripheralOutputCreator()
        {
            AvailableTypes = new string[] { "Monitor", "Inkjet Printer", "Laser Printer" };
        }
        public override Component CreateComponent(string type)
        {
            if (type == AvailableTypes[0])
                return new Monitor();
            if (type == AvailableTypes[1])
                return new InkjetPrinter();
            if (type == AvailableTypes[2])
                return new LaserPrinter();
            throw new Exception(string.Format("Invalid type: {0} for Peripheral Output", type));
        }
    }
}
