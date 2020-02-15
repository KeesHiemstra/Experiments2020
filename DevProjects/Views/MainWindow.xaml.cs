using DevProjects.ViewModels;
using System.Windows;

namespace DevProjects
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    MainViewModel MainVM;

    public MainWindow()
    {
      
      InitializeComponent();

      MainVM = new MainViewModel(this);

    }

  }
}
