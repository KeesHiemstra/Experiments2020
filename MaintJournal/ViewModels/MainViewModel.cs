using CHi.Extensions;
using CHi.Log;

using MaintJournal.Models;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaintJournal.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{

		#region [ Fields ]

		public MainWindow View;

		#endregion

		#region [ Properties ]

		public OptionsViewModel Options { get; set; }
		public ObservableCollection<Journal> Journals = new ObservableCollection<Journal>();

		public int JournalsCount
		{
			get => Journals.Count;
		}

		#endregion

		#region [ Construction ]

		public MainViewModel(MainWindow mainWindow)
		{
			View = mainWindow;
			Options = new OptionsViewModel();
			OpenOptions();
			GetJournal();
			View.MainDataGrid.ItemsSource = Journals;
		}

		#endregion

		#region [ Public methods ]

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		private void NotifyPropertyChanged(string propertyName = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		private void OpenOptions()
		{
			if (File.Exists(Options.JsonPath))
			{
				using StreamReader stream = File.OpenText(Options.JsonPath);
				string json = stream.ReadToEnd();
				Options = JsonConvert.DeserializeObject<OptionsViewModel>(json);
				Log.Write($"Opened options from '{Options.JsonPath}'");
			}
		}

		internal void Backup()
		{
			if (!Directory.Exists(Options.BackupPath.TranslatePath()))
			{
				Log.Write($"Folder '{Options.BackupPath}' doesn't exist");
				MessageBox.Show($"Folder '{Options.BackupPath}' doesn't exist",
					"Backup path",
					MessageBoxButton.OK,
					MessageBoxImage.Warning);
				return;
			}

			string backupDate = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
			string backupFolder = $"{Options.BackupPath.TranslatePath()}\\{Options.DbName}\\{backupDate}";
			Directory.CreateDirectory(backupFolder);

			string backupFile = $"{backupFolder}\\{backupDate}.bak";

			string sql = $"BACKUP DATABASE [{Options.DbName}] TO DISK = '{backupFile}' WITH NOFORMAT, " +
					$"NOFORMAT, NOINIT, SKIP, NOREWIND, NOUNLOAD, STATS = 10, NAME = " +
					$"N'Journal-Full Database Backup';\n" +
				$"BACKUP DATABASE [{Options.DbName}] TO DISK = '{backupFile}' WITH DIFFERENTIAL, NOFORMAT, " +
					$"NOINIT, SKIP, NOREWIND, NOUNLOAD, STATS = 10, NAME = N'Journal-Diff Database Backup';\n" +
				$"BACKUP LOG [{Options.DbName}] TO DISK = '{backupFile}' WITH NOFORMAT, NOINIT, SKIP, " +
					$"NOREWIND, NOUNLOAD, STATS = 10, NAME = N'Journal-Log Database Backup';\n";

			try
			{
				using JournalDbContext db = new JournalDbContext(Options.DbConnection);
				db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql);
				Log.Write($"Database '{Options.DbConnection}' is backed up");
			}
			catch (Exception ex)
			{
				Log.Write($"Error backup: {ex.Message}");
				MessageBox.Show($"{ex.Message}",
					"Backup exception",
					MessageBoxButton.OK,
					MessageBoxImage.Exclamation);
				return;
			}

			MessageBox.Show($"Backup created successful",
				"Backup",
				MessageBoxButton.OK,
				MessageBoxImage.Information);
		}

		internal void CloseWindow()
		{
			Log.Write("Closing Journal");
		}

		internal void UpdateDatabaseConnection()
		{
			View.MainDataGrid.ItemsSource = null;
			GetJournal();
			View.MainDataGrid.ItemsSource = Journals;
			Log.Write($"Connection is changed to {Options.DbName}");
		}

		private void GetJournal()
		{
			using JournalDbContext db = new JournalDbContext(Options.DbConnection);
			List<Journal> journals = (from j in db.Journals
																orderby j.DTStart descending, j.DTCreation descending
																select j).ToList();
			Journals = new ObservableCollection<Journal>(journals);
			Log.Write("Loaded Journal table");
		}

	}
}
