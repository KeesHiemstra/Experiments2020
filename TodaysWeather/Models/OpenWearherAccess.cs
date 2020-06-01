using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodaysWeather.Models
{
  internal class OpenWeatherAccess
  {
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string AppID { get; set; }
    public string Language { get; set; }
  }
}
