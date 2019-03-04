using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A0
{
    public class Program
    {
        static void Main(string[] args)
        {



        }

        public static long Add(long n1, long n2)
        {
            return n1 + n2;

        }

        public static long Subtract(long n1, long n2)
        {
            return n1 - n2;

        }

        public static long Product(long n1, long n2)
        {
            return n1 * n2;

        }

        public static double Divide(double n1, double n2)
        {
            return n1 / n2;

        }

        public static double Sqrt(double n1)
        {
            return Math.Sqrt(n1);


        }

        public static long factorial(long n)
        {
            /*
            if (n == 0 && n == 1)
            {
                return 1;
            }
            
            else
            {
                return n * factorial(n - 1);
            }
            */

            long factorial = 1;

            for (long i = n; i > 0; i--)
            {
                factorial *= i;

            }

            return factorial;
        }


        public static long Negate(long n)
        {
            return -n;

        }

        public static long Square(long n)
        {
            return n * n;
        }
    }


}
