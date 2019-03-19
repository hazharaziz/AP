using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Shop
    {
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }

        public Shop(string name, List<Customer> customers)
        {
            Name = name;
            Customers = customers;
        }


        public List<City> CitiesCustomersAreFrom()
        {
            List<City> CustomersCities = new List<City>();

            {
            foreach (Customer customer in Customers)
                CustomersCities.Add(customer.City);
            }

            return CustomersCities;
        }

        public List<Customer> CustomersFromCity(City city)
        {
            List<Customer> customerFromCity = new List<Customer>();

            foreach (Customer customer in Customers)
            {
                if (customer.City == city)
                {
                    customerFromCity.Add(customer);
                }
            }

            return customerFromCity;
        }

        public List<Customer> CustomersWithMostOrders()
        {
            List<int> Counts = new List<int>();

            foreach (Customer customer in Customers)
            {
                Counts.Add(customer.Orders.Count);
            }

            int maxOrders = Max(Counts);
            List<Customer> customersWithMostOrders = new List<Customer>();

            foreach (Customer customer in Customers)
            {
                if (customer.Orders.Count == maxOrders)
                {
                    customersWithMostOrders.Add(customer);
                }
            }

            return customersWithMostOrders;
        }

        private int Max(List<int> counts)
        {
            int max = 0;

            for (int i = 0; i < counts.Count; i++)
            {
                if (counts[i] > max)
                {
                    max = counts[i];
                }
            }
        
            return max;
        }
    }
}