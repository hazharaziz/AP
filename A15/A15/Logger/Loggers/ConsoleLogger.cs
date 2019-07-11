Tusing System;
using System.Collections.Generic;

namespace Logger
{
    class ConsoleLogger : FileLogger<LockedLogWriter>
    {
        public ConsoleLogger()
            :base(ConsoleLogFormatter.Instance, NullPrivacyScrubber.Instance,
                  LogLevels.All, LogSources.All, Console.Out)
        {}

        public override void Log(LogEntry logEntry)
        {
            Console.ForegroundColor = LogColors[logEntry.Level];
            base.Log(logEntry);
            Console.ResetColor();
        }

        public override void Dispose()
        {}

        protected static Dictionary<LogLevel, ConsoleColor> LogColors = 
            new Dictionary<LogLevel, ConsoleColor>()
        {
            [LogLevel.Debug] = ConsoleColor.White,
            [LogLevel.Error] = ConsoleColor.Red,
            [LogLevel.Warn] = ConsoleColor.Yellow,
            [LogLevel.Info] = ConsoleColor.Cyan
        };
    }
}