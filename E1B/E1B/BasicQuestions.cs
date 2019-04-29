using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1
{
    public class BasicQuestions
    {
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

        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void Swap(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;

        }

        public static void Swap(ref long a, ref long b)
        {
            long temp = a;
            a = b;
            b = temp;
        }
    }
}
