using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace SynkNote_Desktop
{
   class InputHandler
   {
      public void Parse(string[] args)
      {
         var inputMethods = GetInputMethods();
         for (int i = 0; i < args.Length; i++)
         {
            if (args[i].StartsWith("-"))
            {
               string value = "";
               int k = i+1;
               while (!args[k].StartsWith("-") && k < args.Length)
               {
                  value += args[k] + " ";
                  if (k+1 < args.Length) k++;
                  else break;
               }

               ExecuteArg(args[i], value, inputMethods);
               i = k - 1;
            }
         }
      }

      private Dictionary<string, MethodInfo> GetInputMethods() 
      {
         var methods = typeof(Input).GetMethods().Where(m =>
               m.GetCustomAttributes<InputArgAttribute>(false).ToArray().Length > 0);

         var dictionary = new Dictionary<string, MethodInfo>();
         foreach (var method in methods)
         {
            var attribute = (InputArgAttribute)method
               .GetCustomAttributes(typeof(InputArgAttribute), false)[0];

            dictionary.Add(attribute.Flag, method);
            if (attribute.AlternativeFlag != null)
               dictionary.Add(attribute.AlternativeFlag, method);
         }

         return dictionary;
      }

      private void ExecuteArg(string flag, string value,
            Dictionary<string, MethodInfo> inputMethods)
      {
         if (inputMethods.ContainsKey(flag))
         {
            var classInstance = Activator.CreateInstance(
                                     typeof(Input), null);
            inputMethods[flag].Invoke(classInstance, new object[] { value });
         }
      }
   }
}
