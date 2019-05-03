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
         var inputProperties = GetInputProperties();
         var flags = new List<string>();

         // Loop through every "word"
         for (int i = 0; i < args.Length; i++)
         {
            if (args[i].StartsWith("-")) // Find flags
            {
               string value = "";
               int k = i+1;
               flags.Add(args[i]);

               while (!args[k].StartsWith("-") && k < args.Length) // Get flag value 
               {
                  value += args[k];
                  if (k < args.Length - 2 && !args[k+1].StartsWith("-"))
                  {
                     value += " ";
                     k++;
                  } else break;
               }

               // Set the equivalent option to the value
               SetOption(args[i], value, inputProperties);
               i = k - 1;
            }
         }

         // Make sure all required properties are specified
         foreach (var itemProperty in inputProperties)
         {
            var attribute = itemProperty.Value.Attribute;
            bool flagIsUsed = flags.Contains(attribute.Flag) ||
                              flags.Contains(attribute.AlternativeFlag);
            if (attribute.Required && !flagIsUsed)
            {
               Console.WriteLine($"You have to specify the {attribute.Flag} option.");
               ShowHelp(inputProperties);
            }
         }
      }

      public void ShowHelp(Dictionary<string, InputProperty> inputProperties = null)
      {
         /* Get input properties if not specified
         if (inputProperties == null) inputProperties = GetInputProperties();

         foreach (var (inputProperty, i) in inputProperties.WithIndex())
         {
            //Console.Write($"\n{inputProperty.Key}");
         }*/

         Environment.Exit(1);
      }

      private Dictionary<string, InputProperty> GetInputProperties()
      {
         // Get available properties with the InputArg attribute
         var properties = typeof(Options).GetProperties().Where(m =>
               m.GetCustomAttributes<InputArgAttribute>(false).ToArray().Length > 0);

         var dictionary = new Dictionary<string, InputProperty>();
         foreach (var property in properties)
         {
            // Get the attribute assigned to the property
            var attribute = (InputArgAttribute)property
               .GetCustomAttributes(typeof(InputArgAttribute), false)[0];
            var inputProperty = new InputProperty
            (
               property,
               attribute
            );

            dictionary.Add(attribute.Flag, inputProperty);

            if (attribute.AlternativeFlag != null)
               dictionary.Add(attribute.AlternativeFlag, inputProperty);
         }

         return dictionary;
      }

      private void SetOption(string flag, string value,
            Dictionary<string, InputProperty> inputProperties)
      {
         if (inputProperties.ContainsKey(flag))
         {
            var classInstance = Activator.CreateInstance(
                  typeof(Options), null);
            inputProperties[flag].Property.SetValue(classInstance, value, null);
         }
      }
   }
}
