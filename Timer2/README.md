# Timer2

Developing a autoloader of the DayWeathers.

The `CurrentWeathers` is every 10 minutes updated. The `AutoLoad` is triggered every 10 minutes the `LoadDayWeather` to load the data.

Using OneDrive gives some delay and with some extra checks works is okay.

## Added `INotifyPropertyChanged`

Update the `TimeLastWrite` will trigger to screen to update the values. This was not implemented in the origin code.

### Unexpected error in a `TimeSpan`

``` C#
private void StartTimer()
{
	TimeSpan start = TimeLastWrite.AddMinutes(10) - 
		DateTime.Now.ToUniversalTime();
	TimeSpan time = new TimeSpan(0, 10, 0);

	AutoEvent = new AutoResetEvent(false);
	AutoLoad = new Timer(CheckFile, AutoEvent, start, time);
}
```

It gives a negative `TimeSpan` (start), so to be sure you should add at least 1 second.

### Target

KNMI\WeatherMonitor

### Wish list

- [ ] Is a suspend of the computer the `AutoLoad` still working?
