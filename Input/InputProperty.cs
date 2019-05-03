using System;
using System.Reflection;

namespace SynkNote_Desktop
{
   class InputProperty
   {
      public readonly PropertyInfo      Property;
      public readonly InputArgAttribute Attribute;

      public InputProperty(PropertyInfo property, InputArgAttribute attribute) 
      {
         this.Property  = property;
         this.Attribute = attribute;
      }
   }
}
