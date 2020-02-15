using DevProjects.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DevProjects.ViewModels
{
  public class MainViewModel
  {

    #region [ Fields ]

    MainWindow View;
    private string currentFolder = "Z:\\Dev";
    private TreeViewItem currentBranch;

    #endregion

    #region [ Construction ]

    public MainViewModel(MainWindow view)
    {

      View = view;
      currentBranch = View.RootTreeViewItem;

      CollectFolders(currentFolder, currentBranch);

    }

    #endregion

    internal void CollectFolders(string folder, TreeViewItem treeView)
    {

      IEnumerable<string> folders = Directory.EnumerateDirectories(folder);

      foreach (string item in folders)
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(item);
        DirectoryExtraInfo dei = new DirectoryExtraInfo(item);

        TreeViewItem branch = new TreeViewItem()
        {
          Header = directoryInfo.Name,
          IsExpanded = false,
          Foreground = Brushes.Black,
          FontWeight = FontWeights.Normal
        };
        if (dei.IsSolution)
        {
          branch.IsExpanded = true;
        }

        if (dei.IsSolution)
        {
          if (dei.IsTracked)
          {
            branch.FontWeight = FontWeights.Bold;
          }
          branch.Foreground = Brushes.Red;
        }
        if (dei.AddFolder)
        {
          if (dei.LastWriteTime > trackLastWriteTime)
          {
            trackLastWriteTime = dei.LastWriteTime;
          }
          branch.ToolTip = $"{dei.LastWriteTime}";
          treeView.Items.Add(branch);
        }

        CollectFolders(item, branch);
        foreach (FileExtraInfo file in dei.Files)
        {
          TreeViewItem tvi = new TreeViewItem()
          {
            Header = file.Name,
            FontWeight = FontWeights.Normal,
            FontStyle = FontStyles.Italic,
            Foreground = Brushes.Blue
          };
          treeView.Items.Add(tvi);
        }
        //CollectFiles(item, branch);
      }

    }

    private void CollectFiles(string folder, TreeViewItem branch)
    {

      IEnumerable<string> files = Directory.EnumerateFiles(folder);

      foreach (string item in files)
      {
        branch.Items.Add(item);
      }

    }

    private static void CollapseRecursive(TreeViewItem item)
    {
      // Collapse item if expanded.
      if (item.IsExpanded)
      {
        item.IsExpanded = false;
      }

      // If the item has sub items...
      if (item.Items.Count > 0)
      {
        // ... iterate them...
        foreach (TreeViewItem subItem in item.Items)
        {
          // ... and if they themselves have sub items...
          if (subItem.Items.Count > 0)
          {
            // ... collapse the sub item and its sub items.
            CollapseRecursive(subItem);
          }
        }
      }
    }

  }
}
