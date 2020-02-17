using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Track_Projects.Models;

namespace Track_Projects.ViewModels
{
  public class MainViewModel
  {

    #region [ Fields ]

    private MainWindow View;
    private readonly TreeViewItem currentTreeViewItem;
    private readonly string currentFolder = @"Z:\Dev\Banking";

    #endregion

    #region [ Construction ]

    public MainViewModel(MainWindow view)
    {

      View = view;
      View.FolderTreeViewItem.Header = currentFolder;
      currentTreeViewItem = View.FolderTreeViewItem;

      CollectAll(currentTreeViewItem, currentFolder);

    }

    #endregion

    internal void CollectAll(TreeViewItem treeViewItem, string path)
    {

      IEnumerable<string> folders = Directory.EnumerateDirectories(path);

      foreach (string folder in folders)
      {
        //FolderInfo folderFile = new FolderInfo();

        TreeViewItem brance = new TreeViewItem()
        {
          ToolTip = folder,
          Tag = new FolderInfo().GetFolderInfo(folder),
        };
        brance.Header = ((FolderInfo)brance.Tag).Name;

        treeViewItem.Items.Add(brance);
        CollectAll(brance, folder);
      }

    }
  }
}
