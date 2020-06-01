using CHi.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using TodaysWeather.Models;
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
    public MainViewModel MainVM { get; set; }
    public SysTrayForm SysTray;
    public Settings Settings { get; set; } = new Settings();

    readonly string SettingsPath = $".\\{Assembly.GetExecutingAssembly().GetName().Name}.json";

    public MainWindow()
    {
      Log.Trace("Initializing");
      InitializeComponent();

      MainVM = new MainViewModel(this);

      Log.Write("Application started");

      LoadSettings();

      DataContext = this;
    }

    private void LoadSettings()
    {
      using (StreamReader stream = File.OpenText(SettingsPath))
      {
        string json = stream.ReadToEnd();
        Settings = JsonConvert.DeserializeObject<Settings>(json);
      }

      CanCloseWindowMenu.IsChecked = Settings.CanCloseWindow;

      Log.Trace("Settings loaded");
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (!Settings.CanCloseWindow)
      {
        ShowInTaskbar = !ShowInTaskbar;
        e.Cancel = true;
        MainVM.Hide();
        return;
      }
      SysTray.Close();

      string json = JsonConvert.SerializeObject(Settings, Formatting.Indented);
      using (StreamWriter stream = new StreamWriter(SettingsPath))
      {
        stream.Write(json);
      }
      Log.Trace("Settings saved");
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      Log.Trace("Start SysTray");
      SysTray = new SysTrayForm(this);
      SysTray.Activate();
      Log.Trace("SysTray activated");
    }

    private void ExitMain_Click(object sender, RoutedEventArgs e)
    {
      SysTray.Close();
      Application.Current.Shutdown();
    }
  }
}
