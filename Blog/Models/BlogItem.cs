using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
  public class BlogItem : INotifyPropertyChanged
  {

    #region [ Fields ]

    Configuration Config;

    #endregion

    #region [ Properties ]

    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string Title { get; set; }
    public string Summary { get; set; }
    public List<string> Subject { get; set; } = new List<string>();
    public string BlogText { get; set; }
    public List<string> Attachment { get; set; } = new List<string>();

    #endregion

    #region [ Construction ]

    public BlogItem(Configuration config)
    {
      Config = config;

      Id = Config.NewId();
    }

    #endregion

    #region [ Public methods ]

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion
  }
}
