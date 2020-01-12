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
      DateTime today = DateTime.Now.AddDays(2).Date;
      var hours = DaylightHours.Calculate(today, location);
      TimeSpan time = new TimeSpan();

      TextBlock textBlock = new TextBlock()
      {
        Text = $"Opkomst: {hours.SunriseUtc.Value.LocalDateTime}\nOndergang: {hours.SunsetUtc.Value.LocalDateTime}"
      };

      DateStackPanel.Children.Add(textBlock);

    }
}
}
