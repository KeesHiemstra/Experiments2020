using Blog.Models;
using Blog.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
  public class EditBlogItemViewModel : INotifyPropertyChanged
  {

    #region [ Fields ]

    MainViewModel MainVM;

    #endregion

    #region [ Properties ]

    public BlogItem Blog { get; set; }

    #endregion

    #region [ Construction ]

    public EditBlogItemViewModel(MainViewModel mainVM, BlogItem blog)
    {
      MainVM = mainVM;
      Blog = blog;
    }

    #endregion

    #region [ Public methods ]

    public event PropertyChangedEventHandler PropertyChanged;

    public bool ShowBlogItem()
    {
      EditBlogItem editBlogItem = new EditBlogItem(MainVM, Blog);

      return editBlogItem.ShowDialog().Value;
    }

    #endregion
  }
}
