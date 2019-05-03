using System;
using System.Reflection;

namespace SynkNote_Desktop 
{
   [AttributeUsage(AttributeTargets.Property)]
   public class InputArgAttribute : Attribute 
   {
      public string Flag            { get; private set; }
      public string AlternativeFlag { get; private set; }
      public bool   Required        { get; private set; }

      public InputArgAttribute(string arg, string arg2, bool required = false)
      {
         Flag = arg;
         AlternativeFlag = arg2;
         this.Required = required;
      }
   }
}
