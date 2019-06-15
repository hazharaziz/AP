using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E2
{

    public static class Threading
    {
        public static void MakeItFaster(params Action[] actions)
        {
            List<Task> tasks = new List<Task>();

            foreach (var func in actions)
            {
                Task task = new Task(() => func.DynamicInvoke());
                task.Start();
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}