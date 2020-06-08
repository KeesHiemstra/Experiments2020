using Graph4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Graph4
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public VisualTemperatureOfLast24Hour VisualTemperature { get; set; }

    public MainWindow()
    {
      InitializeComponent();

      VisualTemperature = new VisualTemperatureOfLast24Hour("%OneDrive%\\Data\\DailyWeather\\DayWeather_2020-06-06.json");

      VisualGrid.Children.Add(VisualTemperature.CreateVisualTemperature());
    }
  }
}
