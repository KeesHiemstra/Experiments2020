using CHi.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WeatherDemon.Models;

namespace Graph2.ViewModels
{
  public class MainViewModel
  {
    #region [ Fields ]

    private MainWindow MainView;

    #endregion [ Fields ]

    #region [ Properties ]

    public List<DayWeather> TodayWeather { get; set; }

    #endregion

    #region [ Construction ]

    public MainViewModel(MainWindow mainView)
    {
      MainView = mainView;
      PaintTemperature();
    }

    #endregion [ Construction ]

    private void PaintTemperature()
    {
      string jsonPath = "%OneDrive%\\Data\\DailyWeather\\DayWeather.json".TranslatePath(); 
      using (StreamReader stream = File.OpenText(jsonPath))
      {
        string json = stream.ReadToEnd();
        TodayWeather = JsonConvert.DeserializeObject <List<DayWeather>>(json);
			}
    }
  }
}