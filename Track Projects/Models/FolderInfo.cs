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

    private FolderInfo folderInfo;

    public bool IsFolder { get; private set; }
    public string Name { get; private set; }
    public bool IsSolution { get; set; }
    public bool IsProject { get; set; }
    public bool IsTracked { get; set; }
    public DateTime LastWriteTime { get; set; }
    public bool AddBranch { get; set; }
    public List<EntityInfo> EntityInfos { get; set; } = new List<EntityInfo>();

    public FolderInfo()
    {
      folderInfo = this;
    }

    /// <summary>
    /// Get the folder information.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public FolderInfo GetFolderInfo(string path)
    {

      IsFolder = true;
      AddBranch = true;

      DirectoryInfo info = new DirectoryInfo(path);
      Name = info.Name;

      ExamineFolder(path);

      return this;

    }

    /// <summary>
    /// Get the files of the folder.
    /// </summary>
    /// <param name="path"></param>
    private void ExamineFolder(string path)
    {

      IEnumerable<string> Entities = Directory.EnumerateFiles(path);
      foreach (string fileName in Entities)
      {
        EntityInfo entityInfo = new EntityInfo(fileName, folderInfo);
        folderInfo.EntityInfos.Add(entityInfo);
      }

      CheckFolderName(Name);

    }

    private void CheckFolderName(string folderName)
    {

      switch (folderName.ToLower())
      {
        case ".git":
          IsTracked = true;
          AddBranch = false;
          break;
        case ".vs":
        case "packages":
        case "bin":
        case "obj":
        case "properties":
          AddBranch = false;
          break;
        default:
          break;
      }

    }
  }
}
