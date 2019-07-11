using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Logger
{
    public class FileLogger<_WriterGuard> : ILogger
        where _WriterGuard: GuardedLogWriter, new()
    {
        protected _WriterGuard WriterGuardFactory => new _WriterGuard();
        protected FileLogger(
            ILogFormatter logFormatter,
            IPrivacyScrubber privacyScrubber,
            HashSet<LogLevel> logLevelFilter,
            HashSet<LogSource> logSourceFilter,
            TextWriter logWriter)
        {
            this.LogFormatter = logFormatter;
            this.PrivacyScrubber = privacyScrubber;
            this.GaurdedWriter = WriterGuardFactory.CreateInstance(logWriter);
            this.LogLevelFilter = logLevelFilter;
            this.LogSourceFilter = logSourceFilter;
            GaurdedWriter.WriteLine(this.LogFormatter.Header);
        }
        public FileLogger(
            ILogFormatter logFormatter,
            IPrivacyScrubber privacyScrubber,
            ILogFileNamePolicy logfileNamePolicy,
            HashSet<LogLevel> logLevelFilter,
            HashSet<LogSource> logSourceFilter,
            bool append) : this (
                logFormatter, 
                privacyScrubber,
                logLevelFilter,
                logSourceFilter,
                new StreamWriter(logfileNamePolicy.NextFileName(), append))            
        {}

        public virtual void Debug(LogSource source, string message, params (string name, string value)[] nameValuePairs)
            => Log(new LogEntry(source, LogLevel.Debug, message, nameValuePairs));

        public virtual void Error(LogSource source, string message, params (string name, string value)[] nameValuePairs)
            => Log(new LogEntry(source, LogLevel.Error, message, nameValuePairs));

        public virtual void Info(LogSource source, string message, params (string name, string value)[] nameValuePairs)
            => Log(new LogEntry(source, LogLevel.Info, message, nameValuePairs));

        public virtual void Warn(LogSource source, string message, params (string name, string value)[] nameValuePairs)
            => Log(new LogEntry(source, LogLevel.Warn, message, nameValuePairs));

        public virtual void Log(LogSource source, LogLevel level, string message, params (string name, string value)[] nameValuePairs)
            => Log(new LogEntry(source, level, message, nameValuePairs));

        public virtual void Log(LogEntry logEntry)
        {
            if (!LogLevelFilter.Contains(logEntry.Level) || !LogSourceFilter.Contains(logEntry.Source))
                return;

            LogEntry scrubbed = LogEntry.Scrub(logEntry, this.PrivacyScrubber);
            GaurdedWriter.WriteLine(this.LogFormatter.Format(scrubbed));
        }

        public virtual void Dispose()
        {
            this.GaurdedWriter.WriteLine(this.LogFormatter.Footer);
            this.GaurdedWriter.Dispose();
        }

        protected IPrivacyScrubber PrivacyScrubber;
        protected ILogFormatter LogFormatter;
        protected GuardedLogWriter GaurdedWriter;
        protected HashSet<LogLevel> LogLevelFilter;
        protected HashSet<LogSource> LogSourceFilter;
    }
}