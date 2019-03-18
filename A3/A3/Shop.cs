using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Shop
    {
        public string Name;
        public List<Customer> Customers;

        public Shop(string name, List<Customer> customers)
        {
            //TODO
        }


        public List<City> CitiesCustomersAreFrom()
        {
            //TODO
            return null;
        }

        public List<Customer> CustomersFromCity(City city)
        {
            //TODO
            return null;
        }

        public List<Customer> CustomersWithMostOrders()
        {
            //TODO
            return null;
        }
    }
}