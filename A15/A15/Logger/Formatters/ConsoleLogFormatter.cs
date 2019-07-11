using System;
using System.Linq;

namespace Logger
{
    public class ConsoleLogFormatter : ILogFormatter
    {
        private ConsoleLogFormatter() { }

        private static ConsoleLogFormatter _Instance;

        public static ConsoleLogFormatter Instance => _Instance ?? (_Instance = new ConsoleLogFormatter());

        public string Header => string.Empty;

        public string Footer => string.Empty;

        public string FileExtention => throw new NotImplementedException();

        public string Format(LogEntry entry)
        {
            return $"{entry.Level.ToString()},{entry.Source.ToString()} {entry.Message} " +
                    string.Join(",", entry.NameValuePairs.Select(v => $"'{v.name}':'{v.value}'"));
        }

    }
}