using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MasterDetails1.Model
{
	class Solution : INotifyPropertyChanged
  {

		private string name;
		private string folder;
		private ObservableCollection<Project> projects = new ObservableCollection<Project>();

		public string Name
		{
			get => name;
			set
			{
				if (name != value)
				{
					name = value;
					NotifyPropertyChanged("Name");
				}
			}
		}

		public string Folder
		{
			get => folder;
			set
			{
				if (folder != value)
				{
					folder = value;
					NotifyPropertyChanged("Folder");
				}
			}
		}
		public ObservableCollection<Project> Projects
		{
			get => projects;
		}

		#region [ Method ]

		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

    #endregion

  }
}
