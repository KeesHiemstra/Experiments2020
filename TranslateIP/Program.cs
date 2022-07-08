using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateIP
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(TranslateToIP("0543d691"));

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }

    private static string TranslateToIP(string input)
    {
      string result = string.Empty;
      if (input.Length != 8)
      {
        return "Invalid length";
      }

      string oct;
      for (int i = 0; i < 4; i++)
      {
        oct = input.Substring(i * 2, 2);
        try
        {
          int value = Int32.Parse(oct, System.Globalization.NumberStyles.HexNumber);
          Console.Write($"{value}.");
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }

      return result;
    }
  }
}
