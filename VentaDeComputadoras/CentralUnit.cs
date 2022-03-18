using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    // Concrete product used by PeripheralComponentCreator.
    class CentralUnit : Component
    {
        public CentralUnit()
        {
            Manufacturer = "Lenovo";
            Model = "YKM2022-1";
            Price = 7499f;
            Name = "Central Unit";
        }

        public override string Describe()
        {
            return base.Describe() + "\nType: Central Unit";
        }
    }
}
