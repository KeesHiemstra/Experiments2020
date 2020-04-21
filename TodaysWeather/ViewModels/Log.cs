using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TodaysWeather.ViewModels
{
  public static class Log
  {
    public enum LogType { Error, Warning, Info, Debug, Trace }
    static string[] LogTypeNames = new string[5];

    static string LogFile = $".\\{Assembly.GetExecutingAssembly().GetName().Name}.log";

    public static void Write(string message, LogType logType = LogType.Info)
    {
      LogTypeNames[0] = "Error";
      LogTypeNames[1] = "Warn ";
      LogTypeNames[2] = "     ";
      LogTypeNames[3] = "Debug";
      LogTypeNames[4] = "Trace";

      string result = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {LogTypeNames[(int)logType]} {message}";
      using (StreamWriter stream = new StreamWriter(LogFile, true))
      {
        stream.WriteLine(result);
      }
    }

    public static void Debug(string message)
    {
      Write(message, LogType.Debug);
    }

    public static void Trace(string message)
    {
      Write(message, LogType.Trace);
    }
  }
}
