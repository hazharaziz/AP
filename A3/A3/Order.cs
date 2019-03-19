using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Order
    {
        public List<Product> Products { get; set; }
        public bool IsDelivered { get; set; }

        public Order(List<Product> productsList, bool isDeliveredProduct)
        {
            Products = productsList;
            IsDelivered = isDeliveredProduct;

        }

        public float CalculateTotalPrice()
        {
            float totalPrice = 0;

            foreach (Product p in Products)
            {
                totalPrice += p.Price;
            }

            return totalPrice;
        }
    }
}