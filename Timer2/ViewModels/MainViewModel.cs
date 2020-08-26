using WeatherMonitor.Models;

namespace Timer2.ViewModels
{
	public class MainViewModel
	{
    MainWindow MainView;

    public DayWeathers CurrentWeathers { get; set; }

    public MainViewModel(MainWindow mainView)
    {
      MainView = mainView;
    }

		internal void Loaded()
		{
      CurrentWeathers = new DayWeathers(MainView);
    }
  }
}
