using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1
{
    public class Airline
    {
        public string Name;

        public Airline(string name)
        {
            Name = name;
            DB.AddAirline(this);
        }
    }
}
