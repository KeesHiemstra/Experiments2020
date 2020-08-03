using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer1
{
  public class Program
  {
    public static void Main()
    {
      CLog("Start Timer1.Main()");

      Program ex = new Program();
      ex.StartTimer(2000);

      CLog("Finish Timer1.Main()");

      Console.WriteLine("\nPress any key...");
      Console.ReadKey();

    }

    public void StartTimer(int dueTime)
    {
      CLog("Timer is started");
      //The Start time is started directly and then repeated after 2 seconds.
      Timer t = new Timer(new TimerCallback(TimerProc));
      t.Change(0, dueTime);
    }

    private void TimerProc(object state)
    {
      // The state object is the Timer object.
      Timer t = (Timer)state;
      CLog("The timer callback executes.");
    }


    public static void CLog(string Message)
    {
      Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {Message}");
    }
  }
}
