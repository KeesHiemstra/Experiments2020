using System;
using System.IO;
using System.Reflection;

namespace Sudoku1.ViewModels
{
  public static class Log
  {
    static readonly string LogFile = $".\\{Assembly.GetExecutingAssembly().GetName().Name}.log";
    static bool EmptyLine = true && File.Exists(LogFile);

    public static void Write(string message)
    {
      string Message = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}";
      using (StreamWriter stream = new StreamWriter(LogFile, true))
      {
        if (EmptyLine)
        {
          Message = $"\r\n{Message}";
          EmptyLine = false;
        }
        stream.WriteLine(Message);
      }
    }

    public static void DeleteLog()
    {
      if (File.Exists(LogFile))
      {
        File.Delete(LogFile);
      }
    }
  }
}
