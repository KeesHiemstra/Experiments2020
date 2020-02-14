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
          Foreground = Brushes.Black,
          FontWeight = FontWeights.Normal
        };
        if (dei.IsSolution)
        {
          branch.FontWeight = FontWeights.Bold;
          branch.Foreground = Brushes.Purple;
        }
        treeView.Items.Add(branch);

        CollectFolders(item, branch);
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
  }
}
