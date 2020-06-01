using CHi.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TodaysWeather.ViewModels;
using Trinet.Core;
using WeatherDemon.Models;

namespace TodaysWeather.ModelViews
{
  public class MainViewModel
  {
    #region [ Fields ]

    private readonly MainWindow MainView;
    private readonly string TodaysWeatersJson = "%OneDrive%\\Data\\DailyWeather\\DayWeather.json".TranslatePath();

    #endregion

    #region [ Properties ]

    public DateTime SunriseTime { get; set; }
    public DateTime SunsetTime { get; set; }
    public static List<DayWeather> TodaysWeather { get; set; } = new List<DayWeather>();

    public decimal? Temperature 
    {
      get 
      {
        if (TodaysWeather.Count == 0)
        {
          return null;
        }
        return TodaysWeather.Last().Temperature;
      }
    } 
    #endregion


    public MainViewModel(MainWindow mainView)
    {
      MainView = mainView;

      RefreshTodaysWeather();
    }

    public void RefreshTodaysWeather()
    {
      CalculateDayLight();
      LoadTodaysWeather();
      GetTodaysWeatherAsync();
    }

    internal void Hide()
    {
      MainView.Hide();
    }

    private void CalculateDayLight()
    {
      //Read the stored Open Weather location json
      GeographicLocation location;
      string jsonPath = "%OneDrive%\\Etc\\DemonOpenWeather.json".TranslatePath();
      using (StreamReader stream = File.OpenText(jsonPath))
      {
        string json = stream.ReadToEnd();
        location = JsonConvert.DeserializeObject<GeographicLocation>(json);
      }

      DaylightHours daylight = DaylightHours.Calculate(DateTime.Now.Date.AddHours(2), location);
      SunriseTime = daylight.SunriseUtc.Value.LocalDateTime.ToLocalTime();
      SunsetTime = daylight.SunsetUtc.Value.LocalDateTime.ToLocalTime();
    }

    private void LoadTodaysWeather()
    {
      if (File.Exists(TodaysWeatersJson))
      {
        using (StreamReader stream = File.OpenText(TodaysWeatersJson))
        {
          string json = stream.ReadToEnd();
          TodaysWeather = JsonConvert.DeserializeObject<List<DayWeather>>(json);
        }
      }
    }

    private void GetTodaysWeatherAsync()
    {
      try
      {
        TodaysWeathers todays = new TodaysWeathers();
        TodaysWeather.Add(todays.DayWeather);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
  }
}
