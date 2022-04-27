using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasTiendas
{
    public class AddBreadCommand : OrderCommand
    {

        public AddBreadCommand(Order _order, int _quantity, float _price = 2.5f)
        {
            quantity = _quantity;
            price = _price;
            order = _order;
            name = "Bread";
        }
        public override void Execute()
        {
            order.AddProduct(3, name, price, quantity);
            order.AddCommand(this);
        }

        public override void Undo()
        {
            order.RemoveProduct(3, price, quantity);
        }
    }
}
