using CHi.Extensions;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;

using Timer2;

using WeatherMonitor.ViewModels;

namespace WeatherMonitor.Models
{
	public class DayWeathers : INotifyPropertyChanged
	{

		#region [ Fields ]
		private MainWindow View;

		private readonly string DayWeatherJsonPath = "%OneDrive%\\Data\\DailyWeather".TranslatePath();
		private readonly string JsonFile;
		private AutoResetEvent AutoEvent;
		private Timer AutoLoad;
		private int DelayAutoLoad = 10;
		private bool IsEvaluateDelay = false;

		private DateTime timeLastWrite;

		#endregion

		#region [ Properties ]

		public List<DayWeather> Weathers { get; set; } = new List<DayWeather>();
		public DateTime Date { get; set; }
		public DateTime TimeLastWrite
		{ 
			get => timeLastWrite;
			set
			{
				if (timeLastWrite != value)
				{
					timeLastWrite = value;
					NotifyPropertyChanged("");
				}
			}
		}
		public DateTime TimeMin { get; set; }
		public DateTime TimeMax { get; set; }
		public decimal TemperatureMin { get; set; }
		public decimal TemperatureMax { get; set; }

		#endregion

		#region [ Construction ]

		public DayWeathers(MainWindow mainView)
		{
			View = mainView;
			Date = DateTime.Now.Date;
			JsonFile = $"{DayWeatherJsonPath}\\DayWeather.json";
			LoadDayWeather(JsonFile);
			//Start only the timer with current weather
			StartTimer();
		}

		public DayWeathers(DateTime date)
		{
			Date = date.Date;
			LoadDayWeather($"{DayWeatherJsonPath}\\DayWeather_{date:yyyy-MM-dd}.json");
		}

		#endregion

		#region [ Public methods ]

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		private void LoadDayWeather(string jsonFile)
		{
			if (File.Exists(jsonFile))
			{
				FileInfo info = new FileInfo(jsonFile);

				if (info.LastWriteTimeUtc > TimeLastWrite)
				{
					if (IsEvaluateDelay)
					{
						Log.Write($"Passed evaluate delay period, delay: {DelayAutoLoad} seconds");
						AutoLoad.Change(new TimeSpan(0, 10, 0), new TimeSpan(0, 10, 0));
						IsEvaluateDelay = false;
					}

					using (StreamReader stream = File.OpenText(jsonFile))
					{
						string json = stream.ReadToEnd();
						Weathers = JsonConvert.DeserializeObject<List<DayWeather>>(json)
							.Where(x => x.Time >= Date)
							.ToList();
					}

					TimeMin = Weathers.Min(x => x.Time);
					TimeMax = Weathers.Max(x => x.Time);
					TemperatureMin = Weathers.Min(x => x.Temperature);
					TemperatureMax = Weathers.Max(x => x.Temperature);

					TimeLastWrite = info.LastWriteTimeUtc;
					Log.Write("Loaded current Weathers file");
				}
				else
				{
					Log.Write($"Evaluate delay: Added 10 second");
					AutoLoad.Change(new TimeSpan(0, 0, 10), new TimeSpan(0, 0, 10));
					DelayAutoLoad += 10;
					IsEvaluateDelay = true;
				}
			}
		}

		private void StartTimer()
		{
			TimeSpan start = TimeLastWrite.AddMinutes(10).AddSeconds(DelayAutoLoad) - 
				DateTime.Now.ToUniversalTime();
			TimeSpan time = new TimeSpan(0, 10, 0);

			AutoEvent = new AutoResetEvent(false);
			AutoLoad = new Timer(CheckFile, AutoEvent, start, time);
			Log.Write($"CheckFile will be started at {DateTime.Now + start}");
		}

		private void CheckFile(Object stateInfo)
		{
			LoadDayWeather(JsonFile);
		}
	}
}
