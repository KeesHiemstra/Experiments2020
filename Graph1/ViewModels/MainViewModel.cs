using CHi.Extensions;
using Graph1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graph1.ViewModels
{
  public class MainViewModel
  {

    MainWindow MainView;

    public List<DailyReport> Daily { get; set; } = new List<DailyReport>();

    public MainViewModel(MainWindow mainView)
    {

      MainView = mainView;

      PaintGraphic();

    }

    internal void PaintGraphic()
    {

      using (StreamReader stream = File.OpenText("%OneDrive%\\Tmp\\Data.json".TranslatePath()))
      {
        string json = stream.ReadToEnd();
        Daily = JsonConvert.DeserializeObject<List<DailyReport>>(json);
      }
      //CreateTemperatureGraphic(Daily);

      MainView.Anchor1.Child = CreateTemperatureGraphic(Daily);

    }

    private Canvas CreateTemperatureGraphic(List<DailyReport> daily)
    {

      decimal? minTemperature = daily
        .Min(x => x.TN);
      decimal? maxTemperature = daily
        .Max(x => x.TX);

      Canvas canvas = new Canvas();
      CreateAxis(canvas, daily.Count);

      return canvas;

    }

    private Canvas CreateAxis(Canvas canvas, int numberOfDays)
    {

      double AxisWidth = 400;
      double DayWidth = AxisWidth / numberOfDays;
     

      //X axis
      Line line = new Line()
      {
        X1 = 0,
        Y1 = 100,
        X2 = AxisWidth,
        Y2 = 100,
        StrokeThickness = 0.5,
        Stroke = Brushes.Black
      };
      canvas.Children.Add(line);

      //Y axis
      line = new Line()
      {
        X1 = 0,
        Y1 = 0,
        X2 = 0,
        Y2 = 200,
        StrokeThickness = 0.5,
        Stroke = Brushes.Black
      };
      canvas.Children.Add(line);

      for (int i = 1; i < numberOfDays; i++)
      {
        line = new Line()
        {
          X1 = DayWidth * i,
          Y1 = 95,
          X2 = DayWidth * i,
          Y2 = 105,
          StrokeThickness = 0.5,
          Stroke = Brushes.Black
        };
        canvas.Children.Add(line);
      }

      return canvas;

    }
  }
}
