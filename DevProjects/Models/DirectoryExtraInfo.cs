using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevProjects.Models
{
  public class DirectoryExtraInfo
  {

    #region [ Properties ]

    public string FullPath { get; set; }
    public string Name { get; set; }
    public bool IsSolution { get; set; }
    public List<FileExtraInfo> Files { get; set; }

    #endregion

    #region [ Construction ]

    public DirectoryExtraInfo(string fullName)
    {

      FullPath = fullName;
      Files = new List<FileExtraInfo>();
      IEnumerable<string> files = Directory.EnumerateFiles(fullName);
      foreach (string file in files)
      {
        FileExtraInfo fei = new FileExtraInfo(file);
        CheckExtensions(fei.Extension);
        if (fei.AddFile)
        {
          Files.Add(fei);
        }

      }

    }

    #endregion

    private void CheckExtensions(string extension)
    {

      switch (extension.ToLower())
      {
        case ".sln":
          IsSolution = true;
          break;
        default:
          break;
      }

    }

  }
}
