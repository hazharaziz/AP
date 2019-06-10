using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace E2
{
    public static class DotNetInterfaces
    {
        public static IEnumerable<long> GetElapsedTimes(int max=100)
        {
            List<long> resultList = new List<long>();

            Stopwatch stopWatch = Stopwatch.StartNew();

            for (int i = 0; i < max; i++)
            {
                resultList.Add(stopWatch.ElapsedMilliseconds - i);
            }

            stopWatch.Stop();

            return resultList;
        }
    }
}