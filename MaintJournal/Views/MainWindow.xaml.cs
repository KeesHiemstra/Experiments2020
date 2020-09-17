using CHi.Log;
using MaintJournal.ViewModels;
using System;
using System.Collections.Generic;
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

namespace MaintJournal
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private MainViewModel VM;
		
		public MainWindow()
		{
			InitializeComponent();
			Log.Write("Started Journal");
			string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			Title = $"Journal ({version})";

			VM = new MainViewModel(this);
			DataContext = VM;
		}

		#region Exit command
		private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void ExitCommand_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
		#endregion

		#region Options command
		private void OptionsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void OptionsCommand_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			VM.Options.ShowOptions(this);
		}
		#endregion

		#region Backup command
		private void BackupCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = !string.IsNullOrEmpty(VM.Options.BackupPath);
		}

		private void BackupCommand_Execute(object sender, ExecutedRoutedEventArgs e)
		{
			VM.Backup();
		}
		#endregion

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			VM.CloseWindow();
		}

		internal void UpdateDatabaseConnection()
		{
			VM.UpdateDatabaseConnection();
		}
	}
}
