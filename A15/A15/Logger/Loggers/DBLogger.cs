namespace Logger
{
    public class DBLogger<T> : ILogger
    {
        private PrivacyScrubber Scrubber;
        private string ConnString;

        public DBLogger(PrivacyScrubber scrubber, string connString)
        {
            this.Scrubber = scrubber;
            this.ConnString = connString;
        }

        public void Debug(LogSource source, string message, params (string name, string value)[] nameValuePairs) { }

        public void Dispose() {}

        public void Error(LogSource source, string message, params (string name, string value)[] nameValuePairs) {}

        public void Info(LogSource source, string message, params (string name, string value)[] nameValuePairs) {}
    
        public void Log(LogEntry logEntry) {}

        public void Log(LogSource source, LogLevel level, string message, params (string name, string value)[] nameValuePairs) {}

        public void Warn(LogSource source, string message, params (string name, string value)[] nameValuePairs) {}
    }
}