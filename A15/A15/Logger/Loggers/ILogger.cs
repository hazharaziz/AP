using System;
using System.Collections.Generic;

namespace Logger
{
    public enum LogSource { UI, Server, Client, Common }

    public static class LogSources
    {
        public static HashSet<LogSource> All = new HashSet<LogSource>() { LogSource.Client, LogSource.UI, LogSource.Common, LogSource.Server};
        public static HashSet<LogSource> Create(params LogSource[] sources) => new HashSet<LogSource>(sources);
    }


    public enum LogLevel { Debug, Info, Warn, Error }

    public static class LogLevels
    {
        public static HashSet<LogLevel> All = new HashSet<LogLevel>() { LogLevel.Debug, LogLevel.Info, LogLevel.Warn, LogLevel.Error };
        public static HashSet<LogLevel> DebugOnly = new HashSet<LogLevel>() { LogLevel.Debug };
        public static HashSet<LogLevel> ErrorOnly = new HashSet<LogLevel>() { LogLevel.Error };
        public static HashSet<LogLevel> WarnError = new HashSet<LogLevel>() { LogLevel.Error, LogLevel.Warn };
        public static HashSet<LogLevel> AllButDebug = new HashSet<LogLevel>() { LogLevel.Info, LogLevel.Warn, LogLevel.Error };
        public static HashSet<LogLevel> Create(params LogLevel[] levels) => new HashSet<LogLevel>(levels);
    }

    public interface ILogger: IDisposable
    {
        void Log(LogEntry logEntry);
        void Log(LogSource source, LogLevel level, string message,
            params (string name, string value)[] nameValuePairs);
        void Debug(LogSource source, string message,
            params (string name, string value)[] nameValuePairs);
        void Warn(LogSource source, string message,
            params (string name, string value)[] nameValuePairs);
        void Info(LogSource source, string message,
            params (string name, string value)[] nameValuePairs);
        void Error(LogSource source, string message,
            params (string name, string value)[] nameValuePairs);
    }
}