using System;
using System.IO;

namespace Logger
{
    public class TimeBasedLogFileName : LogFileNamePolicy
    {
        public TimeBasedLogFileName(string logDir, string logPrefix, string logExt) 
            : base(logDir, logPrefix, logExt)
        {}

        public override string NextFileName() =>
            Path.Combine(LogDir, 
                $"{LogPrefix}_{DateTime.Now.ToString("yy-MM-dd_HH-mm-ss")}.{LogExt}");
    }
}