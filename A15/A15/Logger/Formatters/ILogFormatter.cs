using System;
using System.Linq;

namespace Logger
{
    public interface ILogFormatter
    {
        string Header { get; }
        string Footer { get; }
        string Format(LogEntry entry);    
        string FileExtention { get; }
    }
}