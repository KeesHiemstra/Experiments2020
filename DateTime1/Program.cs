using System;
using System.Diagnostics;

namespace DateTime1
{
  class Program
  {
    static void Main(string[] args)
    {
      DateTime dateUtc = DateTime.UtcNow;
      DateTime dateLocal = DateTime.Now;

      Console.WriteLine($"{dateLocal}:\t{dateLocal - dateUtc}");

      int day = 28;
      DateTime dateTime = new DateTime(2020, 3, day, 12, 0, 0, DateTimeKind.Utc);

      for (int i = 0; i < 7; i++)
      {
        Debug.Assert(dateTime.IsDaylightSavingTime(), "Daylight saving time");
        Console.WriteLine(dateTime.AddDays(i).ToLocalTime());
      }

      Console.WriteLine("\nPrint any key...");
      Console.ReadKey();
    }
  }
}
