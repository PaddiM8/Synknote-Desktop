using System;

namespace SynkNote_Desktop
{
   class Program
   {
      static void Main(string[] args)
      {
         new InputHandler().Parse(args);
         var fileWatcher = new FileWatcher();
         fileWatcher.Start(Options.SyncDirectory);

         Console.WriteLine(Options.SyncDirectory);
         Console.WriteLine("Watching file system... Press 'q' to quit.");
         Console.ReadKey();
      }
   }
}
