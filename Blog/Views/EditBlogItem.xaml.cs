using Blog.Models;
using Blog.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Blog.Views
{
  /// <summary>
  /// Interaction logic for EditBlogItem.xaml
  /// </summary>
  public partial class EditBlogItem : Window
  {
    public EditBlogItem(MainViewModel mainVM, BlogItem blogItem)
    {
      InitializeComponent();

      DataContext = blogItem;
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      DialogResult = true;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
      DialogResult = false;
    }
  }
}
