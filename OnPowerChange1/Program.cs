using Microsoft.Win32;

using System;
using System.Security.AccessControl;
using System.Threading;

namespace OnPowerChange1
{
  class Program
  {
    public Timer Timer;

    static void Main(string[] args)
    {
      Log("Starting OnPowerChange1");
      Test();

      //Timer = new Timer()

      ConsoleKeyInfo key;
			do
			{
        key = Console.ReadKey();
			} while (key.Key != ConsoleKey.Q);
    }

    private static void Log(string message)
		{
			Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.ffffff} {message}");
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
          Log("Resume");
          break;
        case PowerModes.StatusChange:
          Log("StatusChange");
          break;
        case PowerModes.Suspend:
          Log("Suspend");
          break;
      }
    }
  }
}
