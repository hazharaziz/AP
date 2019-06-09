using System;
using System.IO;

namespace EventDelegateThread
{
    public enum ObserverType { Create, Delete }

    public class DirectoryWatcher : IDisposable
    {
        private FileSystemWatcher Watcher;
        public string FilePath { get; set; }

        /// <summary>
        /// DirectoryWatcher Class Constructor
        /// </summary>
        /// <param name="filePath"></param>
        public DirectoryWatcher(string filePath)
        {
            FilePath = filePath;
            Watcher = new FileSystemWatcher(filePath);
            Watcher.EnableRaisingEvents = true;
            Watcher.Created += Watcher_Created;
            Watcher.Deleted += Watcher_Deleted;
        }

        /// <summary>
        /// Watcher_Deleted Method combining the deleted event to Watcher.Deleted event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            deleteFile(e.FullPath);
        }

        /// <summary>
        /// Watcher_Created Method combining the created event to Watcher.Created event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            createFile(e.FullPath);
        }

        // createFile delegate
        Action<string> createFile;

        // deleteFile delegate
        Action<string> deleteFile;

        /// <summary>
        /// Dispose Method for disposing the Watcher
        /// </summary>
        public void Dispose()
        {
            Watcher.Dispose();
        }

        /// <summary>
        /// Register Method
        /// </summary>
        /// <param name="notifyMe"></param>
        /// <param name="type"></param>
        public void Register(Action<string> notifyMe, ObserverType type)
        {
            if (type == ObserverType.Create)
                createFile += notifyMe;
            else
                deleteFile += notifyMe;
        }
        

        public void Unregister(Action<string> notifyMe, ObserverType type)
        {
            if (type == ObserverType.Create)
                createFile -= notifyMe;
            else
                deleteFile -= notifyMe;
        }
    }
}