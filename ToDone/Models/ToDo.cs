using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDone.Models
{
  public class ToDo
  {
    public DateTime InitTime { get; set; }
    public string Subject { get; set; }
    public bool Completed { get; set; }
  }
}
