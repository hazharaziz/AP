using System;
using System.Collections.Generic;
using System.Timers;

namespace E2
{
    public class DuplicateNumberDetector
    {
        public void AddNumber(int n)
        {
            DuplicateNumberAdded += DuplicateNumberDetector_DuplicateNumberAdded;
        }

        private void DuplicateNumberDetector_DuplicateNumberAdded(int n)
        {
            DuplicateNumberAdded(n);
        }

        public event Action<int> DuplicateNumberAdded;
    }
}