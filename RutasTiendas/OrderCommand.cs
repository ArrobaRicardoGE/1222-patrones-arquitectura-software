using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasTiendas
{
    public abstract class OrderCommand
    {
        protected Order order;
        protected int quantity;
        protected float price;
        protected string name; 
        public abstract void Execute();
        public abstract void Undo(); 
    }
}
