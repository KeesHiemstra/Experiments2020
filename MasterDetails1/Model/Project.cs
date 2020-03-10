using System.ComponentModel;

namespace MasterDetails1.Model
{
  class Project : INotifyPropertyChanged
  {

    private string name;

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
