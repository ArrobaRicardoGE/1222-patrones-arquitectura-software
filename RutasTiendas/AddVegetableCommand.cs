using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasTiendas
{
    public class AddVegetableCommand : OrderCommand
    {
        
        public AddVegetableCommand(Order _order, int _quantity, float _price = 3.5f)
        {
            quantity = _quantity;
            price = _price;
            order = _order;
            name = "Frozen vegetables"; 
        }
        public override void Execute()
        {
            order.AddProduct(1, name, price, quantity);
            order.AddCommand(this); 
        }

        public override void Undo()
        {
            order.RemoveProduct(1, price, quantity); 
        }
    }
}
