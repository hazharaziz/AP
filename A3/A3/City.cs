using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class City
    {
        public string name;

        public City(string cityName)
        {
            name = cityName;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}