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

      VisualTemperatures visualTemperatures = new VisualTemperatures(Daily);
      MainView.Anchor1.Child = visualTemperatures.CreateTemperatureGraphic();

    }


  }
}
