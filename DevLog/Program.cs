using CHi.Log;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLog
{
	class Program
	{
		static void Main(string[] args)
		{
			Log.Write("Start DevLog", "This is second line...", "It can be helpful");

			Console.Write("\nPress any key...");
			Console.ReadKey();
		}
	}
}
