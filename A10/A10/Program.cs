using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3 };
            int[] b = { 3, 4, 5 };

            int[] c = new int[3];

            for (int i = 0; i < a.Length; i++)
            {
                c[i] = a[i] + b[i];
            }

            


            Console.ReadKey();
        }

        
    }
}
