using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.ReadKey();
        }

        public static void AssignPi(out double pi)
        {

            pi = Math.PI;

        }

        public static void Square(ref int x)
        {
            x = x * x;

        }


        public static void Swap(ref int x, ref int y) 
        {
            int temp = x;
            x = y;
            y = temp;

        }

        public static void Sum(out int sum, params int[] n)
        {
            sum = 0;

            foreach (int i in n)
            {
                sum += i;
            }


        }

        public static void Append(ref int[] arr, int n)
        {
            List<int> newArr = new List<int>();

            foreach (int i in arr)
            {
                newArr.Add(i);
            }

            newArr.Add(n);
            arr = newArr.ToArray();
        }

        public static void AbsArray(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Math.Abs(arr[i]);
            }

        }

        public static void ArraySwap(ref int[] arr1, ref int[] arr2)
        {
            if (arr1.Length == arr2.Length)
            {
                int length = arr1.Length;
                int temp;


                for (int i = 0; i < length; i++)
                {
                    temp = arr1[i];
                    arr1[i] = arr2[i];
                    arr2[i] = temp;
                }
            }


            else
            {

                int arr1Length = arr1.Length;
                int arr2Length = arr2.Length;

                if (arr1.Length > arr2.Length)
                {

                    Array.Resize(ref arr2, arr1Length);

                    int temp;

                    for (int i = 0; i < arr2.Length; i++)
                    {
                        temp = arr1[i];
                        arr1[i] = arr2[i];
                        arr2[i] = temp;
                    }

                    Array.Resize(ref arr1, arr2Length);
                }


                else
                {
                    Array.Resize(ref arr1, arr2Length);

                    int temp;

                    for (int i = 0; i < arr1.Length; i++)
                    {
                        temp = arr2[i];
                        arr2[i] = arr1[i];
                        arr1[i] = temp;
                    }

                    Array.Resize(ref arr2, arr1Length);

                }
            }

        }

    }
}
