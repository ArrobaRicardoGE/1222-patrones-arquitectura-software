using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    class ComponentCreator : Creator
    {
        public ComponentCreator()
        {
            AvailableTypes = new string[] { "Central Unit", "Touchscreen" };
        }
        public override Component CreateComponent(string type)
        {
            if (type == AvailableTypes[0])
                return new CentralUnit();
            if (type == AvailableTypes[1])
                return new Touchscreen();
            throw new Exception(string.Format("Invalid type: {0} for Component", type));
        }
    }
}
