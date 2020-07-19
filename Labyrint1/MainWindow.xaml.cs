using Labyrint1.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labyrint1
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public Field FieldArea { get; set; }
    public List<Step> Route { get; set; } = new List<Step>();

    public MainWindow()
    {
      InitializeComponent();

      CreateFieldArea();
      //CreateRoute();
    }

    private void CreateFieldArea() 
    {
      FieldArea = new Field(20, 30, 20);
      FieldGrid.Children.Add(FieldArea.FieldCanvas);
     
    }


    //private void CreateRoute()
    //{
    //  Route.Add(new Step { Direction = Direction.Right, Distance = 1 });
    //  Route.Add(new Step { Direction = Direction.Down, Distance = 6 });
    //  Route.Add(new Step { Direction = Direction.Left, Distance = 1 });
    //  Route.Add(new Step { Direction = Direction.Down, Distance = 9 });
    //  Route.Add(new Step { Direction = Direction.Right, Distance = 7 });
    //  Route.Add(new Step { Direction = Direction.Up, Distance = 13 });
    //  Route.Add(new Step { Direction = Direction.Right, Distance = 13 });
    //}
  }
}
