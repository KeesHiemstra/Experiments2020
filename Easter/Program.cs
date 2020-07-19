using Holidays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easter
{
  class Program
  {
    static void Main(string[] args)
    {
      for (int year = 1968; year < 2021; year++)
      {
        Console.WriteLine(ChristianHolidays.EasterSunday(year));
      }

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }
  }
}
