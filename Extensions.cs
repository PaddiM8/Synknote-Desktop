using System;
using System.Linq;
using System.Collections.Generic;

namespace SynkNote_Desktop
{
   static class Extensions
   {
      public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
         => self.Select((item, index) => (item, index));
   }
}
