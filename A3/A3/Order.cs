using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Order
    {
        public List<Product> products;
        public bool isDelivered;

        public Order(List<Product> productsList, bool isDeliveredProduct)
        {
            products = productsList;
            isDelivered = isDeliveredProduct;

        }

        public List<Product> Products
        {
            get { return products;}
            set { products = value; }
        }

        public bool IsDelivered
        {
            get { return isDelivered; }
            set { isDelivered = value; }
        }



        public float CalculateTotalPrice()
        {
            float totalPrice = 0;

            foreach (Product p in products)
            {
                totalPrice += p.Price;
            }

            return totalPrice;
        }
    }
}