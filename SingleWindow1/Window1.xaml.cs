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

namespace SingleWindow1
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class Window1 : Window
  {
    Window _Parent;
    public Window1(Window parent)
    {
      InitializeComponent();
      _Parent = parent;
      _Parent.Hide();
    }

    private void CloseWindow(object sender, RoutedEventArgs e)
    {
      _Parent.Show();
      Close();
    }
  }
}
