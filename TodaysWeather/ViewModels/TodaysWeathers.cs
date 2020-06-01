using CHi.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodaysWeather.Models;
using WeatherDemon.Models;

namespace TodaysWeather.ViewModels
{
  public class TodaysWeathers
  {
    #region [ Fields ]

    readonly string OpenWeatherAccessPath = "%OneDrive%\\Etc\\DemonOpenWeather.json".TranslatePath();

    #endregion

    #region [ Properties ]

    public DayWeather DayWeather { get; private set; } = new DayWeather();

    #endregion

    public TodaysWeathers()
    {
      GetTodaysWeatherAsync();
    }

    public async Task<DayWeather> GetTodaysWeatherAsync()
    {
      await GetDayWeather();
      return DayWeather;
    }

    private async Task GetDayWeather()
    {
      OpenWeatherAccess access = new OpenWeatherAccess();
      if (File.Exists(OpenWeatherAccessPath))
      {
        using (StreamReader stream = File.OpenText(OpenWeatherAccessPath))
        {
          string json = stream.ReadToEnd();
          access = JsonConvert.DeserializeObject<OpenWeatherAccess>(json);
        }
      }

      string url = $"http://api.openweathermap.org/data/2.5/weather?" +
        $"lat={access.Latitude}&" +
        $"lon={access.Longitude}&" +
        $"appid={access.AppID}&" +
        $"lang={access.Language}";

      HttpClient http = new HttpClient();
      HttpResponseMessage httpRespond =
        await http.GetAsync(url);
      string httpResult = await httpRespond.Content.ReadAsStringAsync();

      OpenWeather openWeather = JsonConvert.DeserializeObject<OpenWeather>(httpResult);
      ConvertDayWeather(openWeather);
    }

    private void ConvertDayWeather(OpenWeather openWeather)
    {

      DayWeather.Time = openWeather.dt.ConvertUnixTimeToDate();
      DayWeather.Temperature = openWeather.main.temp.ToCelsius();
      DayWeather.Pressure = openWeather.main.pressure;
      DayWeather.Humidity = openWeather.main.humidity;
      DayWeather.Visibility = openWeather.visibility;
      DayWeather.WindSpeed = openWeather.wind.speed.ToKmPerHour();

    }

    public void Dispose()
    {
    }


  }
}
