using System;
using System.Collections.Generic;
using System.IO;

namespace E2
{
    public class FullName
    {
        public string FirstName;
        public string LastName;

        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object other)
        {
            FullName fullName = (FullName)other;
            if (FirstName == fullName.FirstName && LastName == fullName.LastName)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            var hashCode = FirstName.GetHashCode() ^ LastName.GetHashCode();
            return hashCode;
        }
    }


    public static class Basics
    {
        public static int CalculateSum(string expression)
        {
            string[] numbers = expression.Split('+');
            try
            {
                if (!CalculateSumDataValidation(expression))
                {
                    throw new InvalidDataException();

                }
                else if (!CalculateSumFormatValidation(expression))
                {
                    throw new FormatException();
                }
                else
                {
                    int[] nums = Array.ConvertAll(numbers, int.Parse);
                    int sum = 0;

                    foreach (int num in nums)
                        sum += num;
                    return sum;
                }
            }
            catch (InvalidDataException) { throw; }
            catch (FormatException) { throw; }
        }

        public static bool CalculateSumFormatValidation(string expression)
        {
            string[] numbers = expression.Split('+');
            bool format = true;
            foreach (string str in numbers)
                foreach (char ch in str)
                    if (!char.IsDigit(ch))
                        format = false;
            return format;
        }

        public static bool CalculateSumDataValidation(string expression)
        {
            string[] numbers = expression.Split('+');
            bool valid = true;
            foreach (string str in numbers)
            {
                if (str == string.Empty)
                {
                    valid = false;
                    break;
                }
            }
            return valid;
        }

        public static bool TryCalculateSum(string expression, out int value)
        {
            string[] numbers = expression.Split('+');

            bool result = true;

            if (!CalculateSumDataValidation(expression) ||
                !CalculateSumFormatValidation(expression))
            {
                value = 0;
                result = false;
            }
            else
            {
                int[] nums = Array.ConvertAll(numbers, int.Parse);
                int sum = 0;

                foreach (int num in nums)
                    sum += num;
                value = sum;
                result = true;
            }
            return result;
        }

        /// <summary>
        /// {\displaystyle 1\,-\,{\frac {1}{3}}\,+\,{\frac {1}{5}}\,-\,{\frac {1}{7}}\,+\,{\frac {1}{9}}\,-\,\cdots \,=\,{\frac {\pi }{4}}.}
        /// </summary>
        /// <returns></returns>
        public static int PIPrecision()
        {
            throw new NotImplementedException();
        }

        public static int Fibonacci(this int n)
        {
            List<int> fibonacci = new List<int>() { 1, 2 };
            if (fibonacci.Contains(n))
            {
                return fibonacci[n - 1];
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        public static void RemoveDuplicates<T>(ref T[] list)
        {
            List<T> newList = new List<T>();
            foreach (var item in list)
            {
                if (!Contains(newList, item))
                    newList.Add(item);
            }
            list = newList.ToArray();
        }

        private static bool Contains<T>(List<T> list, T lookup)
        {
            
            foreach (var item in list)
                if (item.Equals(lookup))
                    return true;
            return false;
        }

        

    }
}