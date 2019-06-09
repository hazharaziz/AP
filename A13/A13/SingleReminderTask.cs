using System;
using System.Threading;
using System.Threading.Tasks;

namespace EventDelegateThread
{
    public class SingleReminderTask : ISingleReminder
    {
        public int Delay { get; set; }
        public string Msg { get; set; }

        public SingleReminderTask(string msg, int delay)
        {
            Msg = msg;
            Delay = delay;
        }

        Task ReminderTask = null;


        public event Action<string> Reminder;

        public void Start()
        {
            foreach (var func in Reminder.GetInvocationList())
            {
                ReminderTask = new Task(() => func.DynamicInvoke(Msg));
                ReminderTask.Start();
                ReminderTask.Wait();
            }
        }
    }
}