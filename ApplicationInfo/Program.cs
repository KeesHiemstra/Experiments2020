using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInfo
{
  class Program
  {
    static void Main(string[] args)
    {
      var Name = Assembly.GetExecutingAssembly().GetName().Name;
      var CodeBase = Assembly.GetExecutingAssembly().GetName().CodeBase;
      Console.WriteLine($"Name: {Name}");
      Console.WriteLine($"CodeBase: {CodeBase}");
			Console.WriteLine($"ContentType: {Assembly.GetExecutingAssembly().GetName().ContentType}");
      Console.WriteLine($"FullName: {Assembly.GetExecutingAssembly().GetName().FullName}");
      Console.WriteLine($"VersionCompatibility: {Assembly.GetExecutingAssembly().GetName().VersionCompatibility}");
      Console.WriteLine($"Location: {Assembly.GetExecutingAssembly().Location}");
      Console.WriteLine($"ReflectionOnly: {Assembly.GetExecutingAssembly().ReflectionOnly}");
      Console.WriteLine($"");
      Console.WriteLine($"Version: {Assembly.GetExecutingAssembly().GetName().Version.ToString()}");


			Console.WriteLine();
      string file = Assembly.GetExecutingAssembly().Location;
      Console.WriteLine($"Location: {file.Remove(file.LastIndexOf('\\'))}");

			Console.WriteLine();
      var path = Directory.GetCurrentDirectory();
			Console.WriteLine($"Current path: {path}");

      Console.WriteLine("\nPress any key...");
      Console.ReadKey();
    }
  }
}
