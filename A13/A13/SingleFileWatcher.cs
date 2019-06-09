using System;
using System.IO;

namespace EventDelegateThread
{

    public class SingleFileWatcher: IDisposable
    {
        private FileSystemWatcher Watcher;
        private string FilePath { get; set; }
        /// <summary>
        /// SingleFileWatcher Class Constructor
        /// </summary>
        /// <param name="fileName"></param>
        public SingleFileWatcher(string fileName)
        {
            FilePath = Path.GetDirectoryName(fileName);
            Watcher = new FileSystemWatcher(Path.GetDirectoryName(fileName),Path.GetFileName(fileName));
            Watcher.EnableRaisingEvents = true;
            Watcher.Changed += Watcher_Changed;
        }

        /// <summary>
        /// Watcher_Changed Method combining the changed event to the Watcher.Changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (register != null)
                register();
        }

        /// <summary>
        /// Dispose Method for disposing the files created
        /// </summary>
        public void Dispose()
        {
            Watcher.Dispose();
        }
        
        // register action delegate
        Action register;

        /// <summary>
        /// Register Method for invoking the action when changes occured
        /// </summary>
        /// <param name="notify"></param>
        public void Register(Action notify)
        {
            register += notify;
        }

        /// <summary>
        /// Unregister Method for deleting the changes occured in the files 
        /// </summary>
        /// <param name="notify"></param>
        public void Unregister(Action notify)
        {
            register -= notify;
        }
    }
}