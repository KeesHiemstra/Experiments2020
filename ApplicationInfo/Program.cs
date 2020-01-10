using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInfo
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
      Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
      Console.WriteLine($"Version: {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()}");

      Console.WriteLine("\nPress any key...");
      Console.ReadKey();
    }
  }
}
