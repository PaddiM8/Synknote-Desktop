using System;
using System.Reflection;

namespace SynkNote_Desktop
{
   public class Options
   {
      [InputArg("-s", "--sync-dir", true)]
      public static string SyncDirectory { get; set; }
   }
}
