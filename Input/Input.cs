using System;
using System.Reflection;

namespace SynkNote_Desktop
{
   public class Input
   {
      [InputArg("-s", "--sync-dir")]
      public static void SyncDirectory(string location) 
      {
         Console.WriteLine(location);
      }
   }
}
