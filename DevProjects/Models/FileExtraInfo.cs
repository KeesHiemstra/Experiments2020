using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevProjects.Models
{
  public class FileExtraInfo
  {

    public string FullPath { get; set; }
    public string Name { get; set; }
    public string Extension { get; set; }
    public DateTime LastWriteTime { get; set; }
    public bool AddFile { get; set; }

    #region [ Construction ]

    public FileExtraInfo(string fullName) 
    {

      FullPath = fullName;
      CollectFileExtraInfo(fullName);

    }

    #endregion

    private void CollectFileExtraInfo(string fullName)
    {

      FileInfo fi = new FileInfo(fullName);
      Name = fi.Name;
      Extension = fi.Extension;
      LastWriteTime = fi.LastWriteTime;
      CheckFileNames(Name);

    }

    private void CheckFileNames(string fileName)
    {

      switch (fileName.ToLower())
      {
        case "readme.md":
          AddFile = true;
          break;
        case "history.txt":
          AddFile = true;
          break;
        default:
          break;
      }

    }

  }
}
