using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Projects.Models
{
  public class EntityInfo
  {

    private FolderInfo FolderInfo;

    public string Name { get; set; }
    public string Extension { get; set; }
    public DateTime LastWriteTime { get; set; }
    public bool AddEntity { get; set; }

    public EntityInfo(string fileName, FolderInfo folderInfo)
    {

      FolderInfo = folderInfo;
      FileInfo fileInfo = new FileInfo(fileName);
      Name = fileInfo.Name;
      Extension = fileInfo.Extension;
      LastWriteTime = fileInfo.LastWriteTime;

      if (folderInfo.LastWriteTime < LastWriteTime)
      {
        folderInfo.LastWriteTime = LastWriteTime;
      }

      AddEntity = false;

      ExamineFile();

    }

    private void ExamineFile()
    {

      CheckEntityName();
      CheckEntityExtension();

    }

    private void CheckEntityName()
    {

      switch (Name.ToLower())
      {
        case "readme.md":
        case "history.txt":
          AddEntity = true;
          break;
        default:
          break;
      }

    }

    private void CheckEntityExtension()
    {
      switch (Extension.ToLower())
      {
        case ".sln":
          FolderInfo.IsSolution = true;
          break;
        case ".csproj":
          FolderInfo.IsProject = true;
          break;
        default:
          break;
      }
    }
  }
}
