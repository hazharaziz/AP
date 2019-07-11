using System;
using System.IO;

namespace Logger
{
    public abstract class GuardedLogWriter: IDisposable
    {
        public abstract void WriteLine(string line);

        public abstract void Dispose();

        public GuardedLogWriter(TextWriter writer) => this.Writer = writer;
        public GuardedLogWriter() { }

        public abstract GuardedLogWriter CreateInstance(TextWriter writer);

        protected TextWriter Writer { get; }
    }
}