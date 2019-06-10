using System;
using System.Collections.Generic;
using System.Timers;

namespace E2
{
    public class DuplicateNumberDetector
    {
        public List<int> numbers = new List<int>();
        public int count = 0;


        public void AddNumber(int n)
        {
            if (!numbers.Contains(n))
            {
                DuplicateNumberAdded += (d) => numbers.Add(d);
                DuplicateNumberAdded += (d) => count++;
            }
        }

       



        public event Action<int> DuplicateNumberAdded;
    }
}