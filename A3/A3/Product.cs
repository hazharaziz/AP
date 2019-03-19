using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Product
    {
        public string Name { get; set; }
        public float price;
        
        public Product(string productName, float productPrice)
        {
            Name = productName;
            Price = productPrice;
        }

        public float Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }

    }
}