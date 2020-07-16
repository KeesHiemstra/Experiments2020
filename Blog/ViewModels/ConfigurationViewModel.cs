using Blog.Models;
using Blog.Views;

using Sudoku1.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Blog.ViewModels
{
  public class ConfigurationViewModel
  {
    MainWindow MainV;
    ConfigurationWindow ConfigV;

    public ConfigurationViewModel(MainWindow mainView)
    {
      Log.Write("Open configuration window");
      MainV = mainView;
      ConfigV = new ConfigurationWindow(this, MainV);

      ConfigV.ShowDialog();
    }

    public void SaveConfig()
    {
      ConfigV.DialogResult = true;
    }

    public void CancelConfig()
    {
      ConfigV.DialogResult = false || MainV.Config.IsChanged;
    }

  }
}
