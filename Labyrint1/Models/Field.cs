using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Labyrint1.Models
{
  public class Field
  {
    internal Canvas FieldCanvas { get; set; } = new Canvas();
    internal List<Cell> Cells { get; set; } = new List<Cell>();

    public double CellWidth { get; set; }
    public double CellHeight { get; set; }

    public Field(int width, int height, double size)
    {
      CellWidth = size;
      CellHeight = size;

      for (int x = 0; x < width; x++)
      {
        for (int y = 0; y < height; y++)
        {
          Cell cell = new Cell(x, y, CellWidth, CellHeight);
          //Cells.Add(cell);
          FieldCanvas.Children.Add(cell.Rect);
        }
      }
    }

    public void SetColorCell(int x, int y, Brushes color)
    {

    }

  }
}
