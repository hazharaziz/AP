using System.IO;

namespace Logger
{
    public abstract class LogFileNamePolicy : ILogFileNamePolicy
    {
        public string LogExt { get; set; }
        public string LogDir { get; }
        public string LogPrefix { get; }
        public LogFileNamePolicy(string logDir, string logPrefix, string logExt)
        {
            this.LogDir = logDir;
            this.LogPrefix = logPrefix;
            this.LogExt = logExt;
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);
        }
        public abstract string NextFileName();
    }
}