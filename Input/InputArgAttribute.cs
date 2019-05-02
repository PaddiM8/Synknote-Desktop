using System;
using System.Reflection;

namespace SynkNote_Desktop 
{
   [AttributeUsage(AttributeTargets.Method)]
   public class InputArgAttribute : Attribute 
   {
      public string Flag            { get; private set; }
      public string AlternativeFlag { get; private set; }
      public InputArgAttribute(string arg, string arg2)
      {
         Flag = arg;
         AlternativeFlag = arg2;
      }
   }
}
