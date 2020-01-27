using CHi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraPathExtension
{
  class Program
  {
    static void Main(string[] args)
    {

      string Test1 = "%OneDrive%\\Whatever.txt";
      string Test2 = "C:\\Users\\chi\\OneDrive\\Whatever.txt";

      Console.WriteLine($"From OneDrive ({Test1}) to path = '{Test1.TranslatePath()}' " +
        $"=> {Test2 == Test1.TranslatePath()}");
      Console.WriteLine();
      Console.WriteLine($"From path ({Test2}) to OneDrive = '{Test2.SavePath()}' " +
        $"=> {Test1 == Test2.SavePath()}");

      Console.Write("\nPress any key...");
      Console.ReadKey();

    }
  }
}
