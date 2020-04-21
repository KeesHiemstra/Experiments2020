using Microsoft.Win32;
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

namespace Events
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public SysTrayForm SysTray;
    public bool CanClose { get; set; } = false;

    public MainWindow()
    {

      InitializeComponent();
      Log("Initialized");

      SysTray = new SysTrayForm(this);
      SysTray.Activate();
      Log("SysTray is active");

      Focus();
      //Log($"Focus: {IsFocused}");
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      Log("Loaded Events");

      SystemEvents.PowerModeChanged += OnPowerChange;
    }

    private void OnPowerChange(object sender, PowerModeChangedEventArgs e)
    {
      Log(e.Mode.ToString());
    }

    private void Log(string Message)
    {
      TextBlock textBlock = new TextBlock()
      {
        Text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fffff} {Message}",
      };
      LogStackPanel.Children.Add(textBlock);

      string LogFileName = Assembly.GetEntryAssembly().Location.Replace(".exe", ".log");
      using (StreamWriter stream = new StreamWriter(LogFileName, true))
      {
        stream.WriteLine(textBlock.Text);
      }

    }

    private void Window_LostFocus(object sender, RoutedEventArgs e)
    {
      Log($"Window focus has lost, {this.Visibility}");
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      Log($"Application will be closed, {this.Visibility}");
      if (!CanClose)
      {
        this.ShowInTaskbar = !this.ShowInTaskbar;
        Visibility = Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        e.Cancel = true;
        return;
      }
      SysTray.Close();

    }

    private void Window_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      Log($"Focus {this.Visibility}");
    }

    private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      Log($"Window {this.Visibility}");
    }
  }

}
