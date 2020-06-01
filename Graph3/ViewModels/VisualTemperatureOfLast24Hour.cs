﻿using CHi.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Trinet.Core;
using WeatherDemon.Models;

namespace Graph3.ViewModels
{
	public class VisualTemperatureOfLast24Hour
	{
		#region [ Fields ]
		List<DayWeather> weather { get; set; }

		static Canvas graph = new Canvas() 
		{ 
			Background = Brushes.LightGray,
			Width = 400,
			Height = 250,
		};
		//Temperature graph area
		double MarginLeft;
		double MarginBottom;
		//TimeLine (X axis)
		double TimeLineStr;
		double TimeLineFin;
		double TimeLineScale;

		//TemperatureLine (Y axis)
		double TempLineStr;
		double TempLineScale;

		//TimeLine time points
		DateTime DateStr;
		DateTime DateFin;

		decimal TempMin;
		decimal TempMax;
		#endregion

		public VisualTemperatureOfLast24Hour(string path)
		{
			weather = new List<DayWeather>();
			string jsonPath = path.TranslatePath();
			using (StreamReader stream = File.OpenText(jsonPath))
			{
				string json = stream.ReadToEnd();
				weather = JsonConvert.DeserializeObject<List<DayWeather>>(json);
			}

			CalculateConstants();
		}

		private void CalculateConstants()
		{
			MarginLeft = 20;
			MarginBottom = 20;

			TimeLineStr = MarginLeft;
			TimeLineFin = graph.Width;

			TempLineStr = graph.Height - MarginBottom;

			DateStr = weather.Min(x => x.Time);
			DateFin = weather.Max(x => x.Time);

			TimeLineScale = (TimeLineFin - TimeLineStr) / (int)(DateFin - DateStr).TotalMinutes;

			TempMin = Math.Floor(weather.Min(x => x.Temperature) - (decimal)0.25);
			TempMax = Math.Ceiling(weather.Max(x => x.Temperature) + (decimal)0.25);
			TempLineScale = (TempLineStr) / (double)(TempMax - TempMin);
		}

		public Canvas CreateVisualTemperature()
		{
			AddDaylight();
			AddAxis();
			AddTemperatures();
			AddTemperaturesMilestones();

			return graph;
		}

		private void AddDaylight()
		{
			//Temperature graph area
			Rectangle area = new Rectangle()
			{
				Width = graph.Width - MarginLeft,
				Height = graph.Height - MarginBottom + 1,
				Fill = Brushes.LightSlateGray,
			};
			graph.Children.Add(area);
			Canvas.SetLeft(area, MarginLeft);

			//Read the stored Open Weather location json
			GeographicLocation location;
			string jsonPath = "%OneDrive%\\Etc\\DemonOpenWeather.json".TranslatePath(); 
			using (StreamReader stream = File.OpenText(jsonPath))
			{
				string json = stream.ReadToEnd();
				location = JsonConvert.DeserializeObject <GeographicLocation>(json);
			}

			DateTime date = DateStr.Date.AddHours(2);

			//Calculate the daylight times
			do
			{
				DaylightHours daylight = DaylightHours.Calculate(date, location);
				DateTime sunriseTime = daylight.SunriseUtc.Value.LocalDateTime.ToLocalTime();
				DateTime sunsetTime = daylight.SunsetUtc.Value.LocalDateTime.ToLocalTime();

				if (sunsetTime > DateStr)
				{
					if (sunriseTime < DateStr)
					{
						sunriseTime = DateStr;
					}

				}

				if (sunsetTime > DateFin)
				{
					sunsetTime = DateFin;
				}

				if (sunriseTime < sunsetTime)
				{
					area = new Rectangle()
					{
						Width = ((sunsetTime - sunriseTime).TotalMinutes * TimeLineScale),
						Height = TempLineStr - 1,
						Fill = Brushes.LightCyan,
					};
					graph.Children.Add(area);
					Canvas.SetLeft(area, TimeLineStr + (sunriseTime - DateStr).TotalMinutes * TimeLineScale);
				}

				date = date.AddDays(1);
			} while (date.Date == weather.Max(x => x.Time).Date);

		}

		private void AddAxis()
		{
			//Time axis (X axis)
			graph.Children.Add(new Line()
			{
				X1 = TimeLineStr,
				Y1 = graph.Height - MarginBottom,
				X2 = TimeLineFin,
				Y2 = graph.Height - MarginBottom,
				StrokeThickness = 1,
				Stroke = Brushes.Blue,
			});

			//Time scale (hour)
			DateTime time = DateStr.AddMinutes(60 - DateStr.Minute);
			while (time < DateFin)
			{
				graph.Children.Add(new Line()
				{
					X1 = TimeLineStr + (time - DateStr).TotalMinutes * TimeLineScale,
					Y1 = graph.Height - MarginBottom,
					X2 = TimeLineStr + (time - DateStr).TotalMinutes * TimeLineScale,
					Y2 = graph.Height - MarginBottom + 3,
					StrokeThickness = 1,
					Stroke = Brushes.Blue,
				});

				if (time.Hour % 6 == 0)
				{
					TextBlock text = new TextBlock()
					{
						Text = time.Hour.ToString(),
						FontSize = 9,
					};
					graph.Children.Add(text);
					Canvas.SetLeft(text, TimeLineStr + (time - DateStr).TotalMinutes * TimeLineScale - 2);
					Canvas.SetTop(text, TempLineStr + 7);
				}

				time = time.AddHours(1);
			}

			//Temperature axis (Y axis)
			graph.Children.Add(new Line()
			{
				X1 = MarginLeft,
				Y1 = 0,
				X2 = MarginLeft,
				Y2 = graph.Height - MarginBottom,
				StrokeThickness = 1,
				Stroke = Brushes.Blue,
			});

			//Temperature scale (degreed)
			for (int i = (int)TempMin; i < (int)TempMax; i++)
			{
				graph.Children.Add(new Line()
				{
					X1 = TimeLineStr - 3,
					Y1 = TempLineStr - ((i - (int)TempMin) * TempLineScale),
					X2 = TimeLineStr,
					Y2 = TempLineStr - ((i - (int)TempMin) * TempLineScale),
					StrokeThickness = 1,
					Stroke = Brushes.Blue,
				});

				if ((i % 5) == 0)
				{
					TextBlock text = new TextBlock()
					{
						Text = i.ToString(),
						FontSize = 9,
					};
					graph.Children.Add(text);
					Canvas.SetLeft(text, TimeLineStr - 7 - 10);
					Canvas.SetTop(text, TempLineStr - ((i - (int)TempMin) * TempLineScale) - 7);
				}
			}
		}

		private void AddTemperatures()
		{
			decimal tempStr = weather[0].Temperature;
			decimal tempFin;
			TimeSpan timeStr = weather[0].Time - DateStr;
			TimeSpan timeFin;
			for (int i = 0; i < weather.Count; i++)
			{
				tempFin = weather[i].Temperature;
				timeFin = weather[i].Time - DateStr;

				graph.Children.Add(new Line() 
				{
					X1 = TimeLineStr + timeStr.TotalMinutes * TimeLineScale,
					Y1 = TempLineStr - (double)(tempStr - TempMin) * TempLineScale,
					X2 = TimeLineStr + timeFin.TotalMinutes * TimeLineScale,
					Y2 = TempLineStr - (double)(tempFin - TempMin) * TempLineScale,
					StrokeThickness = 1,
					Stroke = Brushes.Black,
				});

				Rectangle area = new Rectangle()
				{
					Width = 4,
					Height = 4,
					Fill = Brushes.Transparent,
					ToolTip = $"time: {weather[i].Time:dd HH:mm}\ntemp: {weather[i].Temperature}\u00b0C",
				};
				graph.Children.Add(area);
				Canvas.SetLeft(area, TimeLineStr + timeStr.TotalMinutes * TimeLineScale - 2);
				Canvas.SetTop(area, TempLineStr - (double)(tempStr - TempMin) * TempLineScale - 2);

				tempStr = tempFin;
				timeStr = timeFin;
			}
		}

		private void AddTemperaturesMilestones()
		{
			//Minimum temperature
			graph.Children.Add(new Line()
			{
				X1 = TimeLineStr,
				Y1 = TempLineStr - (double)(weather.Min(x => x.Temperature) - TempMin) * TempLineScale,
				X2 = TimeLineStr + (weather.Last().Time - DateStr).TotalMinutes * TimeLineScale,
				Y2 = TempLineStr - (double)(weather.Min(x => x.Temperature) - TempMin) * TempLineScale,
				StrokeThickness = 0.5,
				Stroke = Brushes.Green,
			});

			//Maximum temperature
			graph.Children.Add(new Line()
			{
				X1 = TimeLineStr,
				Y1 = TempLineStr - (double)(weather.Max(x => x.Temperature) - TempMin) * TempLineScale,
				X2 = TimeLineStr + (weather.Last().Time - DateStr).TotalMinutes * TimeLineScale,
				Y2 = TempLineStr - (double)(weather.Max(x => x.Temperature) - TempMin) * TempLineScale,
				StrokeThickness = 0.5,
				Stroke = Brushes.Green,
			});

			//Current temperature
			graph.Children.Add(new Line()
			{
				X1 = TimeLineStr,
				Y1 = TempLineStr - (double)(weather.Last().Temperature - TempMin) * TempLineScale,
				X2 = TimeLineStr + (weather.Last().Time - DateStr).TotalMinutes * TimeLineScale,
				Y2 = TempLineStr - (double)(weather.Last().Temperature - TempMin) * TempLineScale,
				StrokeThickness = 0.5,
				Stroke = Brushes.Blue,
			});

		}

	}
}