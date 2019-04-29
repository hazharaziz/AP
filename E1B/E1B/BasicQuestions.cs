using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1
{
    public class BasicQuestions
    {
        /// <summary>
        /// OddSum method returning the sum of the odd numbers of an array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int OddSum(int[] nums)
        {
            int oddSum = 0;

            foreach (int num in nums)
            {
                if (num % 2 != 0)
                {
                    oddSum += num;
                }
            }
            return oddSum;
        }


        /// <summary>
        /// Swap method for integers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Swap method for doubles 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;

        }

        /// <summary>
        /// Swap method for long integers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap(ref long a, ref long b)
        {
            long temp = a;
            a = b;
            b = temp;
        }
    }
}
