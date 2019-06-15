using System;
using System.Collections.Generic;
using System.Timers;

namespace E2
{
    public class DuplicateNumberDetector
    {
        HashSet<int> set { get; set; }

        public DuplicateNumberDetector()
        {
            set = new HashSet<int>();
        }

        public event Action<int> DuplicateNumberAdded;

        public void AddNumber(int n)
        {
            if (!set.Contains(n))
                set.Add(n);
            else
                DuplicateNumberAdded(n);
        }
    }
}