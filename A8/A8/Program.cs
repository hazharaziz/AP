using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8
{
    public class Program
    {
        static void Main(string[] args)
        {
            DateTime c = new DateTime(2010, 3, 1);
            DateTime d = new DateTime(2012, 2, 15);
            DateTime e = new DateTime(2014, 2, 15);
            DateTime f = new DateTime(2014, 2, 15);


            Human h1 = new Human("sdm", "asjdnsnkd", c, 20);
            Human h2 = new Human("dkndks", "dcnjdcn", d, 30);
            Human h3 = new Human("slcmk", "sdks", e, 40);
            Human h4 = new Human("slcmk", "sdks", e, 40);
            //Console.WriteLine(h3 == h4);
            //Console.WriteLine(h3.Equals(h4));

            Console.ReadKey();
        }
    }
}
