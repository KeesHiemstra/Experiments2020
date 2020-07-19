using Microsoft.Win32;

using System;

namespace OnPowerChange1
{
  class Program
  {
    static void Main(string[] args)
    {
      Test();

      Console.Write("\nPress any key...");
      Console.ReadKey();
    }

    private static void Test()
    {
      SystemEvents.PowerModeChanged += OnPowerChange;
    }

    private static void OnPowerChange(object sender, PowerModeChangedEventArgs e)
    {
      switch (e.Mode)
      {
        case PowerModes.Resume:
          Console.WriteLine("Resume");
          break;
        case PowerModes.StatusChange:
          Console.WriteLine("StatusChange");
          break;
        case PowerModes.Suspend:
          Console.WriteLine("Suspend");
          break;
        default:
          Console.WriteLine("Default");
          break;
      }
    }
  }
}
