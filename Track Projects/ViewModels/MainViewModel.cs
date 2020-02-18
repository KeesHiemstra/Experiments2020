using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Track_Projects.Models;

namespace Track_Projects.ViewModels
{
  public class MainViewModel
  {

    #region [ Fields ]

    private MainWindow View;
    private readonly TreeViewItem currentTreeViewItem;
    private readonly string currentFolder = @"Z:\Dev";

    #endregion

    #region [ Construction ]

    public MainViewModel(MainWindow view)
    {

      View = view;

      View.FolderTreeViewItem.ToolTip = currentFolder;
      View.FolderTreeViewItem.Tag = new FolderInfo().GetFolderInfo(currentFolder);
      View.FolderTreeViewItem.Header = ((FolderInfo)View.FolderTreeViewItem.Tag).Name;
      View.FolderTreeViewItem.IsExpanded = true;

      currentTreeViewItem = View.FolderTreeViewItem;

      CollectAll(currentTreeViewItem, currentFolder);

    }

    #endregion

    internal void CollectAll(TreeViewItem treeViewItem, string path)
    {

      IEnumerable<string> folders = Directory.EnumerateDirectories(path);

      foreach (string folder in folders)
      {
        TreeViewItem branch = new TreeViewItem()
        {
          Tag = new FolderInfo().GetFolderInfo(folder),
        };
        branch.Header = ((FolderInfo)branch.Tag).Name;
        branch.ToolTip = $"{folder} ({((FolderInfo)branch.Tag).LastWriteTime})";

        if (((FolderInfo)branch.Tag).IsSolution)
        {
          branch.IsExpanded = true;
          branch.Foreground = Brushes.Red;
        }

        if (((FolderInfo)branch.Tag).AddBranch)
        {
          treeViewItem.Items.Add(branch);
        }

        CollectAll(branch, folder);

      }

      ProcessFiles(treeViewItem, ((FolderInfo)treeViewItem.Tag).EntityInfos);

    }

    private void ProcessFiles(TreeViewItem branch, List<EntityInfo> entityInfos)
    {
      foreach (EntityInfo entityInfo in entityInfos)
      {
        if (entityInfo.AddEntity)
        {
          TreeViewItem tvi = new TreeViewItem()
          {
            Header = entityInfo.Name,
            ToolTip = entityInfo.LastWriteTime,
          };
          branch.Items.Add(tvi);
        }
      }
    }
  }
}
