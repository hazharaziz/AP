using System;
using System.Threading;

namespace EventDelegateThread
{
    public class SingleReminderThread : ISingleReminder
    {
        public string Msg { get; set; }
        public int Delay { get; set; }


        public SingleReminderThread(string msg, int delay)
        {
            Msg = msg;
            Delay = delay;
        }

        Thread ReminderThread = null;

        public event Action<string> Reminder;



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