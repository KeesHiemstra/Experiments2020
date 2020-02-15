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
    public bool AddFolder { get; set; } = true;
    public bool IsSolution { get; set; }
    public bool IsProject { get; set; }
    public bool IsTracked { get; set; }
    public DateTime LastWriteTime { get; set; }
    public List<FileExtraInfo> Files { get; set; }

    #endregion

    #region [ Construction ]

    public DirectoryExtraInfo(string fullName)
    {

      FullPath = fullName;
      DirectoryInfo folder = new DirectoryInfo(fullName);
      Name = folder.Name;
      LastWriteTime = folder.LastWriteTime;
      IsTracked = Directory.Exists($"{fullName}\\.git");

      Files = new List<FileExtraInfo>();
      IEnumerable<string> files = Directory.EnumerateFiles(fullName);
      foreach (string file in files)
      {
        FileExtraInfo fei = new FileExtraInfo(file);
        CheckExtensions(fei.Extension);

        if (fei.LastWriteTime > LastWriteTime)
        {
          LastWriteTime = fei.LastWriteTime;
        }

        if (fei.AddFile)
        {
          Files.Add(fei);
        }
      }
      CheckAddFolder();

    }

    #endregion

    private void CheckAddFolder()
    {

      switch (Name.ToLower())
      {
        case ".git":
          AddFolder = false;
          IsTracked = true;
          break;
        case ".vs":
        case "packages":
        case "bin":
        case "obj":
        case "properties":
          AddFolder = false;
          break;
        default:
          break;
      }

    }

    private void CheckExtensions(string extension)
    {

      switch (extension.ToLower())
      {
        case ".sln":
          IsSolution = true;
          break;
        case ".csproj":
          IsProject = true;
          break;
        default:
          break;
      }

    }

  }
}
