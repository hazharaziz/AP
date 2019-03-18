using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Product
    {
        public string name = null;
        public float price;

        public Product(string productName, float productPrice)
        {
            name = productName;
            price = productPrice;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
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