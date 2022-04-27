using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasTiendas
{
    public class RouteSimulator
    {
        private List<Order> orders;
        private Dictionary<int, int> trucks; 

        public RouteSimulator()
        {
            orders = new List<Order>();
            trucks = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 }, { 3, 0 } };
        }

        public void AddOrder(Order order)
        {
            orders.Add(order); 
        }

        public void SetTruckQuantity(int id, int quantity)
        {
            trucks[id] = quantity; 
        }

        public Dictionary<int, int> SimulateRoute()
        {
            var amounts = trucks.ToDictionary(entry => entry.Key, entry => entry.Value);
            foreach (var order in orders)
            {
                foreach(var product in order.products)
                {
                    amounts[product.idProduct] -= product.quantity;
                    if (amounts[product.idProduct] < 0) throw new Exception(product.name); 
                }
            }
            return amounts; 
        }

        public List<Order> GetRoute()
        {
            SimulateRoute();
            orders.Sort(CompareOrders);
            return orders; 
        }

        private static int CompareOrders(Order x, Order y)
        {
            float revx = 0f, revy = 0f; 
            foreach(var product in x.products)
                revx += product.price * product.quantity;
            foreach (var product in y.products)
                revy += product.price * product.quantity;
            if (revx == revy) return 0;
            if (revx > revy) return -1;
            return 1; 
        }
    }
}
