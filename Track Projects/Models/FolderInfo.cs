using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Track_Projects.Models
{
  public class FolderInfo
  {

    public bool IsFolder { get; private set; }
    public string Name { get; private set; }
    public bool IsSolution { get; set; }
    public bool IsProject { get; set; }
    public List<EntityInfo> EntityInfos { get; set; } = new List<EntityInfo>();

    /// <summary>
    /// Get the folder information.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public FolderInfo GetFolderInfo(string path)
    {

      IsFolder = true;
      DirectoryInfo info = new DirectoryInfo(path);
      Name = info.Name;

      return this;

    }

  }
}
