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

        public Product MostOrderedProduct()
        {
            HashSet<Product> products = new HashSet<Product>();
            Dictionary<Product, int> productsCounts = new Dictionary<Product, int>();

            foreach (Order order in Orders)
            {
                foreach (Product product in order.Products)
                {
                    products.Add(product);
                }
            }

            foreach (Product product in products)
            {
                productsCounts[product] = 0;
            }

            foreach (Order order in Orders)
            {
                foreach (Product product in order.Products)
                {
                    productsCounts[product] += Count(product, order);
                }
            }

            Dictionary<Product, int>.ValueCollection Counts = productsCounts.Values;
            int maxCount = Max(Counts);
            List<Product> mostOrderedProducts = new List<Product>();

            foreach (KeyValuePair<Product, int> kvp in productsCounts)
            {
                if (kvp.Value == maxCount)
                {
                    mostOrderedProducts.Add(kvp.Key);
                }
            }

            Random rand = new Random();
            Product mostOrderedProduct = mostOrderedProducts[rand.Next(0, mostOrderedProducts.Count - 1)];

            return mostOrderedProduct;
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