using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrint1.Models
{
  public enum Direction { Up, Right, Down, Left }

  public class Step
  {
    public Direction Direction { get; set; }
    public int Distance { get; set; }
  }
}
