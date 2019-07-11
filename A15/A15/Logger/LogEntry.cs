using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Logger
{
    public class LogEntry
    {
        public LogEntry() { }
        public LogEntry(LogSource source, LogLevel level, string message,
            DateTime dateTime, int threadId, int processId,
            params (string name, string value)[] nameValuePairs)
        {
            this.Source = source;
            this.Level = level;
            this.Message = message;
            this.NameValuePairs = nameValuePairs.ToList();
            this.DateTime = dateTime;
            this.ThreadId = threadId;
            this.ProcessId = processId;
        }

        public LogEntry(LogSource source, LogLevel level, string message,
            params (string name, string value)[] nameValuePairs)
            : this(source, level, message, DateTime.Now,
                   Process.GetCurrentProcess().Id,
                   Thread.CurrentThread.ManagedThreadId, 
                   nameValuePairs)
        {}

        public DateTime DateTime { get; set; }
        public LogSource Source { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }

        public int ProcessId { get; set; } 
        public int ThreadId { get; set; } 

        public List<(string name, string value)> NameValuePairs { get; set; }

        public override string ToString() => this.ToString(CsvLogFormatter.Instance);

        public string ToString(ILogFormatter logFormater) => logFormater.Format(this);

        public static LogEntry Scrub(LogEntry entry, IPrivacyScrubber scrubber)
        {
            LogEntry scrubbed = entry.MemberwiseClone() as LogEntry;
            scrubbed.Message = scrubber.Scrub(scrubbed.Message);
            scrubbed.NameValuePairs = scrubbed.NameValuePairs
                .Select(nv => (nv.name, scrubber.Scrub(nv.value)))
                .ToList();
            return scrubbed;
        }
    }
}
