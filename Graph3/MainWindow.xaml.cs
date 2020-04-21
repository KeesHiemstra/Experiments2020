using Graph3.ViewModels;
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

namespace Graph3
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public VisualTemperature visualTemperature { get; set; }

    public MainWindow()
    {
      InitializeComponent();

      visualTemperature = new VisualTemperature("%OneDrive%\\Data\\DailyWeather\\DayWeather.json");

      VisualGrid.Children.Add(visualTemperature.CreateVisualTemperature());
    }
  }
}
