using System.Windows;

namespace TimeTalkingClock
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//
		// Implementation of INotifyPropertyChanged is not necessary to update the window
		//

		// "get" is necessary to update the window
		public VisualTime Now { get; } = new VisualTime();

		public MainWindow()
		{
			InitializeComponent();

			// DataContext is necessary to update the window
			DataContext = this;
		}
	}
}
