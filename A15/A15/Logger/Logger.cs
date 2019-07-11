using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Logger : ILogger
    {
        public delegate void OnLogEventDelegate(LogEntry entry);

        public event OnLogEventDelegate OnLog;

        public static List<ILogger> Loggers { get; } = new List<ILogger>();

        private static Logger _Instance = null;

        public static Logger Instance => _Instance ?? (_Instance = new Logger());

        private Logger()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler((o,e) => this.Dispose());
        }

        public void Debug(LogSource source, string message, params (string name, string value)[] nameValuePairs)
            => this.Log(new LogEntry(source, LogLevel.Debug, message, nameValuePairs));
        1
        public void Error(LogSource source, string message, params (string name, string value)[] nameValuePairs)
            => this.Log(new LogEntry(source, LogLevel.Error, message, nameValuePairs));

        public void Info(LogSource source, string message, params (string name, string value)[] nameValuePairs)
            => this.Log(new LogEntry(source, LogLevel.Info, message, nameValuePairs));

        public void Warn(LogSource source, string message, params (string name, string value)[] nameValuePairs)
            => this.Log(new LogEntry(source, LogLevel.Warn, message, nameValuePairs));

        public void Log(LogSource source, LogLevel level, string message, params (string name, string value)[] nameValuePairs)
            => this.Log(new LogEntry(source, level, message, nameValuePairs));

        public void Log(LogEntry logEntry)
        {
            Loggers.ForEach(logger => logger.Log(logEntry));
            OnLog?.Invoke(logEntry);
        }

        public void Dispose()
            => Loggers?.ForEach(logger => logger.Dispose());
    }
}
