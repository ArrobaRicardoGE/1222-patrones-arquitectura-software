using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasTiendas
{
    public class AddSodaCommand : OrderCommand
    {

        public AddSodaCommand(Order _order, int _quantity, float _price = 0.95f)
        {
            quantity = _quantity;
            price = _price;
            order = _order;
            name = "Sodas";
        }
        public override void Execute()
        {
            order.AddProduct(2, name, price, quantity);
            order.AddCommand(this);
        }

        public override void Undo()
        {
            order.RemoveProduct(2, price, quantity);
        }
    }
}
