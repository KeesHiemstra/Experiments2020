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
using TodaysWeather.ModelViews;
using TodaysWeather.ViewModels;
using TodaysWeather.Views;

namespace TodaysWeather
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainViewModel MainVM;// { get; set; }
    public SysTrayForm SysTray;
    public bool CanClose { get; set; } = false;

    public MainWindow()
    {
      Log.Trace("Initializing");
      InitializeComponent();

      MainVM = new MainViewModel(this);

      Log.Write("Application started");
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (!CanClose)
      {
        ShowInTaskbar = !ShowInTaskbar;
        
        e.Cancel = true;
        return;
      }
      SysTray.Close();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      Log.Trace("Start SysTray");
      SysTray = new SysTrayForm(this);
      SysTray.Activate();
      Log.Trace("SysTray activated");
    }

  }
}
