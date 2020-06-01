using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Directory1
{
  class Program
  {
    public static SortedDictionary<string, string> Rules = new SortedDictionary<string, string>();

    static void Main(string[] args)
    {
      Initialize();
      Show("It is a sorted list");

      Show1("B 10");

      Update1("B 10", "Updated 20");
      Show("Update rule B 10");

      Update2("B 20", "D 10", "Update 30");
      Show("Update rule B 20");

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }

    private static void Update2(string rule, string update, string with)
    {
      Rules.Remove(rule);
      Rules.Add(update, with);
    }

    private static void Update1(string rule, string with)
    {
      Rules[rule] = with;
    }

    private static void Show1(string rule)
    {
      Console.WriteLine($"Show {rule}");
      Console.WriteLine(Rules[rule]);
      Console.WriteLine();
    }

    private static void Show(string message)
    {
      Console.WriteLine(message);
      foreach (var item in Rules)
      {
        Console.WriteLine($"{item.Key}: {item.Value}");
      }
      Console.WriteLine();
    }

    private static void Initialize()
    {
      Rules.Add("A 10", "Rule 10");
      Rules.Add("C 10", "Rule 40");
      Rules.Add("B 10", "Rule 20");
      Rules.Add("B 20", "Rule 30");

    }
  }
}
