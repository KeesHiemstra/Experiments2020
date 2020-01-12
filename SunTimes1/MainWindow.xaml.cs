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
      DateTime date = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Local);
      var hours = DaylightHours.Calculate(date, location);
      TimeSpan time = new TimeSpan();

      for (int i = 0; i < 366; i++)
      {
        time += (hours.SunsetTimeUtc.Value - hours.SunriseTimeUtc.Value);

        date = date.AddDays(1);
        hours = DaylightHours.Calculate(date, location);
      }

      TextBlock textBlock = new TextBlock()
      {
        Text = time.ToString()
      };

      DateStackPanel.Children.Add(textBlock);

      TextBlock textBlock1 = new TextBlock()
      {
        //Text = time.TotalDays().ToString()
      };

      DateStackPanel.Children.Add(textBlock1);
    }
}
}
