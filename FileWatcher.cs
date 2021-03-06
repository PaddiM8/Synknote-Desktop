using System;
using System.IO;

namespace SynkNote_Desktop
{
   class FileWatcher
   {
      private FileSystemWatcher Watcher = new FileSystemWatcher();
      public void Start(string directory)
      {
         Watcher.Path         = directory;
         Watcher.NotifyFilter = NotifyFilters.LastWrite
                              | NotifyFilters.FileName
                              | NotifyFilters.DirectoryName;
         Watcher.Filter       = "*.*";
         Watcher.EnableRaisingEvents = true;
         Watcher.IncludeSubdirectories = true;

         Watcher.Changed += OnChanged;
         Watcher.Created += OnChanged;
         Watcher.Deleted += OnChanged;
         Watcher.Renamed += OnRenamed;
      }

      private void OnChanged(object source, FileSystemEventArgs e)
      {
         Console.WriteLine($"Changed {e.FullPath}");
      }

      private void OnRenamed(object source, RenamedEventArgs e)
      {
         Console.WriteLine($"Renamed {e.OldFullPath} to {e.FullPath}");
      }
   }
}
