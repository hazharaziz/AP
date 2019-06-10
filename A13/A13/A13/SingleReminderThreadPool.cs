using System;
using System.Threading;

namespace EventDelegateThread
{
    public class SingleReminderThreadPool : ISingleReminder
    {
        public int Delay { get; set; }
        public string Msg { get; set; }

        /// <summary>
        /// SingleReminderThreadPool Class Constructor
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="delay"></param>
        public SingleReminderThreadPool(string msg, int delay)
        {
            Msg = msg;
            Delay = delay;
        }

        // Reminder action
        public event Action<string> Reminder;

        /// <summary>
        /// Start Method for invoking the actions
        /// </summary>
        public void Start()
        {
            foreach (var func in Reminder.GetInvocationList())
            {
                ThreadPool.QueueUserWorkItem((o) => func.DynamicInvoke((string)o),Msg);
            }
        }
    }
}