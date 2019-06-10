using System;
using System.Threading;

namespace EventDelegateThread
{
    public class SingleReminderThread : ISingleReminder
    {
        public string Msg { get; set; }
        public int Delay { get; set; }

        /// <summary>
        /// SingeleReminderThread Class Constructor
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="delay"></param>
        public SingleReminderThread(string msg, int delay)
        {
            Msg = msg;
            Delay = delay;
        }

        Thread ReminderThread = null;

        // Reminder action
        public event Action<string> Reminder;

        /// <summary>
        /// Start Method for invoking the actions
        /// </summary>
        public void Start()
        {
            foreach (var func in Reminder.GetInvocationList())
            {
                ReminderThread = new Thread(() => func.DynamicInvoke(Msg));
                ReminderThread.Start();
                ReminderThread.Join();
            }
        }
    }
}