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
            DateTime c = new DateTime(2015, 3, 1);
            DateTime d = new DateTime(2021, 2, 15);
            Human a = new Human("sd", "skdn", d, 50);
            Human b = new Human("sjdb", "sjbsdd", c, 70);

            Human child = a + b;
            Console.WriteLine(child.FirstName);

            Console.ReadKey();
        }
    }
}
