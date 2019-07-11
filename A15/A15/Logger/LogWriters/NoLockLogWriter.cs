using System.IO;

namespace Logger
{
    public class NoLockLogWriter : GuardedLogWriter
    {
        public NoLockLogWriter() { }

        public NoLockLogWriter(TextWriter writer) : base(writer) {}

        public override GuardedLogWriter CreateInstance(TextWriter writer) => new NoLockLogWriter(writer);

        public override void Dispose() => this.Writer.Dispose();

        public override void WriteLine(string line) => this.Writer.WriteLine(line);
    }
}