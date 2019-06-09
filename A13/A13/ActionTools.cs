using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System;

namespace EventDelegateThread
{
    public static class ActionTools
    {
        private static object locker = new object();

        public static long CallSequential(params Action[] actions)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            foreach (var func in actions)
            {
                Task t = new Task(func);
                t.Start();
                t.Wait();
            }
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;

        }

        public static long CallParallel(params Action[] actions)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            Task[] tasks = new Task[actions.Length];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(actions[i]);
            }
            Task.WaitAll(tasks);
            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;

        }

        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            lock (locker)
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (var func in actions)
                    {
                        Task t = new Task(func);
                        t.Start();
                        t.Wait();
                    }
                }
            }

            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;
        }


        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            foreach (var func in actions)
            {
                await Task.Run(func);
            }

            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;

        }

        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            Task[] tasks = new Task[actions.Length];

            for (int i = 0; i < actions.Length; i++)
            {
                tasks[i] = Task.Run(actions[i]);
            }

            await Task.WhenAll(tasks);
            stopWatch.Stop();
            return stopWatch.ElapsedMilliseconds;
            

        }

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {
            Stopwatch stopWatch = new Stopwatch();

            long a = 0;
            
            foreach (var func in actions)
            {
                a += await Task.Run(() => CallParallelThreadSafe(count, func));
            }

            stopWatch.Stop();
            return a;


        }
    }
}