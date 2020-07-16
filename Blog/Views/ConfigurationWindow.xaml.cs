using Blog.ViewModels;

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
using System.Windows.Shapes;

namespace Blog.Views
{
  /// <summary>
  /// Interaction logic for ConfigurationWindow.xaml
  /// </summary>
  public partial class ConfigurationWindow : Window
  {
    private MainWindow MainV;
    private ConfigurationViewModel ConfigVM;

    public ConfigurationWindow(ConfigurationViewModel configVM, MainWindow mainV)
    {
      InitializeComponent();

      MainV = mainV;

      Left = mainV.Left + 20;
      Top = mainV.Top + 20;
      DataContext = mainV.Config;

      ConfigVM = configVM;
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      MainV.Config.IsChanged = true;
      MainV.Config.FileName = MainV.Config.BlogFileSave();
      ConfigVM.SaveConfig();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
      ConfigVM.CancelConfig();
    }
  }
}
