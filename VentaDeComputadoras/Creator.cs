using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSale
{
    // Abstract creator for the simple factory pattern. 
    abstract class Creator
    {
        public string[] AvailableTypes { get; set; } 
        public abstract Component CreateComponent(string type); 
    }
}
