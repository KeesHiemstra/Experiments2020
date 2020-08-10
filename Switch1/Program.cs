using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch1
{
  class Program
  {
    static void Main(string[] args)
    {
      object value = null;
      string output = null;
      switch (value)
      {
        case Array { Length: 1 } vals:
          output += "1";
          break;
        case Array vals when 4 <= vals.Length && vals.Length <= 6:
          output += "";
          break;
        case null:
          output += "null";
          break;
        default:
          break;
      }

      int? val = null;
      output = val switch
      {
        1 => "A",
        null => "X",
        _ => "@",
      };

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }
  }
}
