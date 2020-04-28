using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodaysWeather.ModelViews
{
  public class MainViewModel
  {
    private MainWindow MainView;

    public MainViewModel(MainWindow mainView)
    {
      MainView = mainView;
    }

    internal void Hide()
    {
      MainView.Hide();
    }
  }
}
