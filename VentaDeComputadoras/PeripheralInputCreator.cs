using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    // Concrete creator. Handles the creation of input peripherals. 
    class PeripheralInputCreator : Creator
    {
        public PeripheralInputCreator()
        {
            AvailableTypes = new string[] { "Keyboard", "Mouse", "Drawing Tablet" }; 
        }
        public override Component CreateComponent(string type)
        {
            if (type == AvailableTypes[0])
                return new Keyboard();
            if (type == AvailableTypes[1])
                return new Mouse();
            if (type == AvailableTypes[2])
                return new DrawingTablet();
            throw new Exception(string.Format("Invalid type: {0} for Peripheral Input", type)); 
        }
    }
}
