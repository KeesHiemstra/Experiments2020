﻿using System;

namespace WeatherDemon.Models
{
  public class DayWeather
  {
    public DateTime Time { get; set; }
    public decimal Temperature { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
    public int Visibility { get; set; }
    public decimal WindSpeed { get; set; }
  }
}
