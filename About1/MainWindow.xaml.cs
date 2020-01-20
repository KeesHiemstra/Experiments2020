using About1.Views;
using System.Windows;

namespace About1
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    public MainWindow()
    {
      InitializeComponent();
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {

      _ = new HistoryWindow()
      {
        Left = this.Left + 20,
        Top = this.Top + 20
      }.ShowDialog();

    }

    private void About_Click(object sender, RoutedEventArgs e)
    {

      _ = new AboutBox1().ShowDialog();

    }
  }
}
