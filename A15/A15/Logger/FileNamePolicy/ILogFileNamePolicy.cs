using System.IO;

namespace Logger
{
    public interface ILogFileNamePolicy
    {
        string NextFileName();
    }
}