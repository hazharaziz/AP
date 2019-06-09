using System;
using System.IO;

namespace EventDelegateThread
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        private FileSystemWatcher Watcher;
        public string FilePath { get; set; }

        public DirectoryWatcher(string filePath)
        {
            FilePath = filePath;
            Watcher = new FileSystemWatcher(Path.GetDirectoryName(filePath));
        }

        public void Dispose()
        {
            Watcher.Dispose();
        }

        public void Register(Action<string> notifyMe, ObserverType create)
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
                notifyMe(Path.Combine(FilePath, $"{random.Next(10000, 99999)}.txt"));
        }

        public void Unregister(Action<string> notifyMe, ObserverType delete)
        {
            
        }
    }
}