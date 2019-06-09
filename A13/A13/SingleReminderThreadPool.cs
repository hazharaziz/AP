using System;
using System.Threading;

namespace EventDelegateThread
{
    public class SingleReminderThreadPool : ISingleReminder
    {
        public int Delay { get; set; }
        public string Msg { get; set; }

        public SingleReminderThreadPool(string msg, int delay)
        {
            Msg = msg;
            Delay = delay;
        }

        public event Action<string> Reminder;

        public void Start()
        {
            foreach (var func in Reminder.GetInvocationList())
            {
                ThreadPool.QueueUserWorkItem((o) => func.DynamicInvoke((string)o),Msg);
            }
        }
    }
}