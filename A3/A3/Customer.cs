using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Customer
    {
        public string Name;
        public City City;
        public List<Order> Orders;

        public Customer(string name, City city, List<Order> orders)
        {
            //TODO
        }

        public Product MostOrderedProduct()
        {
            //TODO
            return null;
        }

        public List<Order> UndeliveredOrders()
        {
            //TODO
            return null;
        }
    }
}