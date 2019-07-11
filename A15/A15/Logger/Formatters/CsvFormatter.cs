using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class CsvLogFormatter : ILogFormatter
    {
        private CsvLogFormatter() { }

        private static CsvLogFormatter _Instance;

        public static CsvLogFormatter Instance => _Instance ?? (_Instance = new CsvLogFormatter());

        public string Header => $"level,date,source,threadId,ProcessId,message,name:value pairs";

        public string Footer => string.Empty;

        public string FileExtention => "log";

        public string Format(LogEntry entry)
        {
            return $"{entry.Level.ToString()},{entry.DateTime.ToString()},{entry.Source.ToString()}," +
                   $"{entry.ThreadId.ToString()},{entry.ProcessId},{entry.Message}," +
                    string.Join(",", entry.NameValuePairs.Select(v => $"'{v.name}':'{v.value}'"));
        }
    }
}
