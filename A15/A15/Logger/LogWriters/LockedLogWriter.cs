using System;
using System.IO;

namespace Logger
{
    public class LockedLogWriter : GuardedLogWriter
    {
        public LockedLogWriter() { }
        public LockedLogWriter(TextWriter writer) : base(writer) { }

        public override GuardedLogWriter CreateInstance(TextWriter writer)
            => new LockedLogWriter(writer);

        public override void Dispose()
        {
            lock (this)
            {
                Writer.Dispose();
            }
        }

        public override void WriteLine(string line)
        {
            lock (this)
            {
                Writer.WriteLine(line);
                Writer.Flush();
            }
        }

    }
}