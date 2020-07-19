using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteTally
{
  class Program
  {
    static void Main(string[] args)
    {
      int newNumber = 20;
      string TallyName = $"Name {newNumber:000}";
      Console.WriteLine(TallyName);

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }
  }
}
