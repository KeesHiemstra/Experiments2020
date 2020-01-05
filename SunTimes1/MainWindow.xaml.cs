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
using Trinet.Core;

namespace SunTimes1
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      var location = GeographicLocation.Parse("51° 54\' 48.9024\" N, 4° 59\' 58.9812\" E");
      DateTime date = new DateTime(2019, 12, 5);
      var hours = DaylightHours.Calculate(date.Year, date.Month, date.Day, location); ;

      for (int i = 0; i < 35; i++)
      {
        TextBlock dateTextBlock = new TextBlock()
        {
          Text = $"{date.ToString("yyyy-MM-dd")} {hours.SunriseTimeUtc} {hours.SunsetTimeUtc}"
        };
        DateStackPanel.Children.Add(dateTextBlock);

        date = date.AddDays(1);
        hours = DaylightHours.Calculate(date.Year, date.Month, date.Day, location);
      }
    }
  }
}
