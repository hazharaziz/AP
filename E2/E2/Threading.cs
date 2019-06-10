using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E2
{

    public static class Threading
    {
        public static void MakeItFaster(params Action[] actions)
        {
            Task[] tasks = new Task[actions.Length];

            for (int i = 0; i < actions.Length; i++)
            {
                tasks[i] = Task.Run(() => actions[i].DynamicInvoke());
            }
            Task.WaitAll(tasks);

        }
    }
}