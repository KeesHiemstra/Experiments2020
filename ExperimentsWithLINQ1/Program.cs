using CHi.Extensions;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExperimentsWithLINQ1
{
	class Program
	{
		public static List<Journal> Journals = new List<Journal>();

		static void Main(string[] args)
		{
			LoadJournal(@"%OneDrive%\Data\Journal.csv".TranslatePath());

			//Use only the fallen rain records
			Journals = Journals
				.Where(x => x.Event == "Regen")
				.ToList();

			YearTotals();
			Console.Write("\nPress any key...");
			Console.ReadKey();

			MonthTotals();
			Console.Write("\nPress any key...");
			Console.ReadKey();

			YearMonthTotals();

			Console.Write("\nPress any key...");
			Console.ReadKey();
		}

		private static void YearTotals()
		{
			var year = Journals
				.GroupBy(
					x => x.Time.Year,
					x => decimal.Parse(x.Message),
					(Year, rain) => new
						{
							Key = Year,
							Rain = rain.Sum(x => x)
						}
					);

			Console.WriteLine("Year\tRain");
			Console.WriteLine("----\t----");
			foreach (var item in year)
			{
				Console.WriteLine($"{item.Key}\t{item.Rain}");
			}
		}

		private static void MonthTotals()
		{
			string[] monthName = new string[] { "Tot", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
			var month = Journals
				.Where(x => x.Time >= new DateTime(2020, 01, 01))
				.GroupBy(
					x => (Year: x.Time.Year, Month: x.Time.Month),
					x => decimal.Parse(x.Message),
					(Date, rain) => new
						{
							Key = Date,
							MonthTotals = rain.Sum(x => x)
						}
					);

			Console.WriteLine("Year\tMonth\tRain");
			Console.WriteLine("----\t-----\t----");
			foreach (var item in month)
			{
				Console.WriteLine($"{item.Key.Year}\t{monthName[item.Key.Month]}\t{item.MonthTotals}");
			}
		}

		private static void YearMonthTotals()
		{
			string[] monthName = new string[] { "Tot", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
			var month = Journals
				.Where(x => x.Time >= new DateTime(2018, 01, 01))
				.GroupBy(
					x => (Year: x.Time.Year, Month: x.Time.Month),
					x => decimal.Parse(x.Message),
					(Date, rain) => new
						{
							Key = Date,
							MonthTotals = rain.Sum(x => x)
						}
					)
				.OrderBy(x => x.Key.Month)
				.ThenByDescending(x => x.Key.Year);

			var years = Journals
				.Where(x => x.Time >= new DateTime(2018, 01, 01))
				.GroupBy(
					x => x.Time.Year,
					x => decimal.Parse(x.Message),
					(Year, rain) => new
						{
							Key = Year,
							Rain = rain.Sum(x => x)
						}
					)
				.OrderByDescending(x => x.Key);

			//Header
			Console.Write("\t");
			foreach (var year in years)
			{
				Console.Write($"{year.Key}\t");
			}
			Console.WriteLine();

			Console.Write("Total\t");
			foreach (var year in years)
			{
				Console.Write($"{year.Rain}\t");
			}
			Console.WriteLine();

			//Body
			int colFirst = years.First().Key;
			int colLast = years.Last().Key;
			int col = 0;
			int row = 0;

			foreach (var item in month)
			{
				if (col == 0)
				{
					row++;
					Console.Write($"{monthName[row]}\t");
				}
				col++;

				if (col == 1 && item.Key.Year < colFirst )
				{
					Console.Write("\t");
				}

				Console.Write($"{item.MonthTotals}\t");

				if (item.Key.Year == colLast)
				{
					Console.WriteLine();
					col = 0;
				}
			}

		}

		#region Load the data

		private static void LoadJournal(string path)
		{
			string content;
			using (StreamReader stream = new StreamReader(path))
			{
				content = stream.ReadToEnd();
			};

			ProcessLines(content.Split(new string[] { "\"\r\n\"" },
				StringSplitOptions.RemoveEmptyEntries));
		}

		private static void ProcessLines(string[] lines)
		{
			for (int i = 1; i < lines.Length; i++)
			{
				ProcessLine(lines[i].Split(new string[] { "\";\"" }, StringSplitOptions.None));
			}
		}

		private static void ProcessLine(string[] field)
		{
			Journals.Add(new Journal()
			{
				LogID = int.Parse(field[0]),
				Time = DateTime.Parse(field[1]),
				Event = field[2],
				Message = field[3]
			});
		}

		#endregion

	}

	public class Journal
	{
		public int LogID;
		public DateTime Time;
		public string Event;
		public string Message;
	}

}
