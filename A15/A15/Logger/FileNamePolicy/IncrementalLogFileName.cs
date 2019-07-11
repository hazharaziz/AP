using System.IO;
using System.Linq;

namespace Logger
{
    public class IncrementalLogFileName : LogFileNamePolicy
    {
        public IncrementalLogFileName(string logDir, string logPrefix, string logExt) 
            : base(logDir, logPrefix, logExt)
        { }

        public override string NextFileName() => 
            Path.Combine(LogDir, 
                $"{LogPrefix}_{(LastLogNumber+1).ToString("0000")}.{LogExt}");

        protected int LastLogNumber
        {
            get
            {
                string[] files = Directory.GetFiles(this.LogDir, $"{LogPrefix}_*.{LogExt}");
                return files.Length == 0 ? -1 :
                       files.Select(f => f.Substring(0, f.Length - LogExt.Length - 1)
                                          .Substring(f.LastIndexOf('_') + 1))
                            .Max(n => int.Parse(n));
            }
        }

    }
}