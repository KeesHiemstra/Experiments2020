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
using System.Windows.Threading;

namespace Timer2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public DateTime CurrentTime { get; set; } = DateTime.Now;
    public DispatcherTimer timer = new DispatcherTimer();

    public MainWindow()
    {
      InitializeComponent();

      DataContext = this;

      timer.Tick += Timer_Tick;

      StartTimer();
    }

    public void Timer_Tick(object sender, EventArgs e)
    {
      CurrentTimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
    }

    public void StartTimer()
    {
      timer.Interval = TimeSpan.FromMilliseconds(60000);
      timer.IsEnabled = true;
    }
  }
}
