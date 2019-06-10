using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string s = "1+";
            Console.WriteLine(s.Split('+')[0]);
            Console.ReadKey();
        }
    }
}
