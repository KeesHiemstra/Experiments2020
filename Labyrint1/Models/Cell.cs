using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Labyrint1.Models
{
  public enum GateType { Border, Wall, Open }

  public class Cell : Canvas
  {
    public int X { get; set; }
    public int Y { get; set; }
    public Rectangle Rect { get; set; }

    public Cell(int x, int y, double width, double height)
    {
      X = x;
      Y = y;

      Rect = new Rectangle()
      {
        Width = width,
        Height = height,
        Fill = Brushes.LightGray,
        Stroke = Brushes.White,
      };
      Canvas.SetLeft(Rect, X * width);
      Canvas.SetTop(Rect, Y * height);
    }

    
  }
}
