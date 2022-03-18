using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    // Base product class. There was no need to make it abstract, but it has a virtual method
    // which is overriden by the derived classes. 
    class Component
    {
        protected string Manufacturer { get; set; }
        protected string Model { get; set; }
        public float Price { get; set; }

        protected string Name { get; set; }


        public virtual string Describe()
        {
            return string.Format("Name: {0}\nManufacturer: {1}\nModel: {2}\nPrice: {3:c}", Name, Manufacturer, Model, Price); 
        }
    }
}
