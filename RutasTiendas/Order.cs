using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasTiendas
{
    public class Order
    {
        public int idStore { get; set; }
        public string storeName { get; set; }
        public List<Product> products { get; set; }

        private Stack<OrderCommand> _history;

        public Order()
        {
            products = new List<Product>();
            _history = new Stack<OrderCommand>();
        }

        public void ResetOrder()
        {
            products = new List<Product>();
            _history = new Stack<OrderCommand>();
        }

        public void AddProduct(int id, string name, float price, int quantity)
        {
            products.Add(new Product(id, name, price, quantity));
        }
        
        public void RemoveProduct(int id, float price, int quantity)
        {
            foreach (var product in products)
            {
                if(product.idProduct == id && product.price == price && product.quantity == quantity)
                {
                    products.Remove(product);
                    return; 
                }
            }
        }

        public void AddCommand(OrderCommand cmd)
        {
            _history.Push(cmd);
        }

        public void Undo()
        {
            var cmd = _history.Peek();
            if (cmd == null) return;
            _history.Pop();
            cmd.Undo(); 
        }
    }

    public class Product
    {
        public Product(int _id, string _name, float _price, int _quantity)
        {
            idProduct = _id;
            name = _name;
            price = _price;
            quantity = _quantity;
        }
        public int idProduct { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
    }
}

