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
            for(int i = 0; i < products.Count; i++)
            {
                if (products[i].idProduct == id && products[i].price == price)
                {
                    products[i].quantity = quantity;
                    return; 
                }
            }
            products.Add(new Product(id, name, price, quantity));
        }
        
        public void RemoveProduct(int id, float price, int quantity)
        {
            for(int i = 0; i < products.Count; i++)
            {
                if(products[i].idProduct == id && products[i].price == price)
                {
                    products[i].quantity -= quantity;
                    if (products[i].quantity == 0) products.RemoveAt(i);
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

        public void ToQR(string path)
        {
            QRCodeGenerator qr = new IronBarCodeAdapter();
            qr.GenerateQR(this, path + $"\\order_{idStore.ToString().PadLeft(2, '0')}");
        }

        public int GetQuantityForID(int productID)
        {
            int ans = 0; 
            foreach(var product in products)
            {
                if (product.idProduct == productID) ans += product.quantity; 
            }
            return ans; 
        }

        public float GetRevenue()
        {
            float revenue = 0f;
            foreach (var product in products)
            {
                revenue += product.quantity * product.price;
            }
            return revenue; 
        }
    }

    public class Product
    {
        public Product(int idProduct, string name, float price, int quantity)
        {
            this.idProduct = idProduct;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
        public int idProduct { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public float price { get; set; }
    }
}

