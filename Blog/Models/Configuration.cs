using CHi.Extensions;

using Newtonsoft.Json;

using System.ComponentModel;

namespace Blog.Models
{
  public class Configuration : INotifyPropertyChanged
  {
    #region [ Fields ]


    #endregion

    #region [ Properties ]

    public int LastId { get; set; }
    public double Left { get; set; } = 50;
    public double Top { get; set; } = 50;
    public double Width { get; set; } = 600;
    public double Height { get; set; } = 500;
    public string FileName { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;

    [JsonIgnore]

    public bool IsChanged { get; set; }

    #endregion

    #region [ Construction ]


    #endregion

    #region [ Event ]

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged(string propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      IsChanged = true;
    }

    #endregion

    #region [ Public methods ] 

    public int NewId()
    {
      LastId++;
      IsChanged = true;
      return LastId;
    }

    public string BlogFileName()
    {
      return FileName.TranslatePath();
    }

    public string BlogFileSave()
    {
      return FileName.SavePath();
    }

    #endregion
  }
}
