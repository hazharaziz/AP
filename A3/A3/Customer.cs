using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Customer
    {
        public string Name { get; set; }

        public City City { get; set; }

        public List<Order> Orders { get; set; }

        public Customer(string customerName, City customerCity, List<Order> customerOrders)
        {
            Name = customerName;
            City = customerCity;
            Orders = customerOrders;
        }

        /// <summary>
        /// this method returns the most ordered product
        /// </summary>
        /// <returns></returns>
        public Product MostOrderedProduct()
        {            
            Dictionary<Product, int> productsCounts = new Dictionary<Product, int>();

            //calculating the number of orders of each product
            foreach (Order order in Orders)
            {
                foreach (Product product in order.Products)
                {
                    productsCounts[product] = Count(product, order);
                }
            }

            List<Product> mostOrderedProducts = new List<Product>();
            int maxCount = Max(productsCounts.Values);
                
            //making a list of most ordered products
            foreach (Product product in productsCounts.Keys)
            {
                if (productsCounts[product] == maxCount)
                {
                    mostOrderedProducts.Add(product);
                }
            }

            return mostOrderedProducts[0];
        }

        private int Max(Dictionary<Product,int>.ValueCollection counts)
        {
            int max = 0;

            foreach (int count in counts)
            {
                if (count > max)
                {
                    max = count;
                }
            }
            return max;
        }

        private int Count(Product product, Order order)
        {
            int count = 0;

            foreach (Product p in order.Products)
            {
                if (p == product)
                {
                    count += 1;
                }
            }

            return count;

        }

        public List<Order> UndeliveredOrders()
        {
            List<Order> undeliveredOrders = new List<Order>();

            foreach (Order order in Orders)
            {
                if (!order.IsDelivered)
                {
                    undeliveredOrders.Add(order);
                }
            }

            return undeliveredOrders;

        }
    }
}