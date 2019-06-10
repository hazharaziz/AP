using System;
using System.Threading;
using System.Threading.Tasks;

namespace EventDelegateThread
{
    public class SingleReminderTask : ISingleReminder
    {
        public int Delay { get; set; }
        public string Msg { get; set; }

        /// <summary>
        /// SingleReminderTask Class Constructor
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="delay"></param>
        public SingleReminderTask(string msg, int delay)
        {
            Msg = msg;
            Delay = delay;
        }

        Task ReminderTask = null;
    
        // Reminder event
        public event Action<string> Reminder;

        /// <summary>
        /// Start Method for invoking the actions
        /// </summary>
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