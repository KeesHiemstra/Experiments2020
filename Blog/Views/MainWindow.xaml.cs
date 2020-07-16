using Blog.Models;
using Blog.ViewModels;

using Newtonsoft.Json;

using Sudoku1.ViewModels;

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

namespace Blog
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private readonly string ConfigFile = $".\\{Assembly.GetExecutingAssembly().GetName().Name}.json";
    public Configuration Config { get; set; }
    public MainViewModel MainVM { get; set; }

    public MainWindow()
    {
      InitializeComponent();

      Config = new Configuration();
      LoadConfiguration();

      Left = Config.Left;
      Top = Config.Top;
      Width = Config.Width;
      Height = Config.Height;
      Title = Config.Title;

      MainVM = new MainViewModel(this);
    }

    #region [ Command Exit ]

    private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void ExitCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

    #endregion

    #region [ Command Configuration ]

    private void ConfigurationCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void ConfigurationCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      MainVM.ShowConfiguration();
    }

    #endregion

    #region [ Command New ]

    private void NewBlogCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = !string.IsNullOrEmpty(Config.FileName);
    }

    private void NewBlogCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      MainVM.NewBlog();
    }

    #endregion

    private void LoadConfiguration()
    {
      if (File.Exists(ConfigFile))
      {
        using (StreamReader stream = File.OpenText(ConfigFile))
        {
          string json = stream.ReadToEnd();
          Config = JsonConvert.DeserializeObject<Configuration>(json);
        }
        Log.Write($"Loaded '{ConfigFile}'");
      }
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (Config.IsChanged)
      {
        Log.Write($"Save {ConfigFile}");
        string json = JsonConvert.SerializeObject(Config, Formatting.Indented);
        using (StreamWriter stream = new StreamWriter(ConfigFile))
        {
          stream.Write(json);
        }
      }
    }

    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      Config.Width = Width;
      Config.Height = Height;
    }

    private void Window_LocationChanged(object sender, EventArgs e)
    {
      Config.Left = Left;
      Config.Top = Top;
    }
  }
}
