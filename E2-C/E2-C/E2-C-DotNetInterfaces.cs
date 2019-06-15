using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace E2
{
    public static class DotNetInterfaces
    {
        public static IEnumerable<long> GetElapsedTimes(int max = 100)
        {
            Stopwatch stopWatch = new Stopwatch();

            long timesPassed = 0;

            for (int i = 0; i < max + 1; i++)
            {
                stopWatch.Start();
                long t = stopWatch.ElapsedMilliseconds - timesPassed;
                yield return t;
                stopWatch.Stop();
                timesPassed += t;
            }
        }
    }
}