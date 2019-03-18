using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Order
    {
        public List<Product> Products;
        public bool IsDelivered;

        public Order(List<Product> products, bool isDelivered)
        {
        }

        public float CalculateTotalPrice()
        {
            //TODO
            return -1;
        }
    }
}