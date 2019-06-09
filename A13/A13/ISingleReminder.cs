using System;

namespace EventDelegateThread
{
    public interface ISingleReminder
    {
        int Delay { get; }
        string Msg { get; }
        event Action<string> Reminder;
        void Start();
    }
}