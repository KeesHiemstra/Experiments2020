using Blog.Models;

using Newtonsoft.Json;

using Sudoku1.ViewModels;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
  public class MainViewModel
  {
    public MainWindow MainV;

    public List<BlogItem> Blogs { get; set; }

    public MainViewModel(MainWindow mainView)
    {
      Log.Write("Started MainViewModel");

      MainV = mainView;
      LoadBlog();
    }

    internal void LoadBlog()
    {
      if (!string.IsNullOrEmpty(MainV.Config.FileName))
      {
        Blogs = new List<BlogItem>();
        if (File.Exists(MainV.Config.FileName))
        {
          string jsonPath = MainV.Config.FileName;
          using (StreamReader stream = File.OpenText(jsonPath))
          {
            string json = stream.ReadToEnd();
            Blogs = JsonConvert.DeserializeObject<List<BlogItem>>(json);
          }
        }
      }
    }

    public void ShowConfiguration()
    {
      _ = new ConfigurationViewModel(this.MainV);
    }

    public void NewBlog()
    {
      EditBlog(-1);
    }

    public void EditBlog(int id)
    {
      BlogItem blogItem;
      if (id == -1)
      {
        blogItem = new BlogItem(MainV.Config);
        Log.Write($"Created new blog");
      }
      else
      {
        blogItem = Blogs.Where(x => x.Id == id).FirstOrDefault();
        Log.Write($"Edit blog item {blogItem.Id}");
      }

      EditBlogItemViewModel editBlogItemVM = new EditBlogItemViewModel(MainV.MainVM, blogItem);

      if (editBlogItemVM.ShowBlogItem())
      {
        if (id == -1)
        {
          Blogs.Add(blogItem);
        }

        SaveBlogs();
      }
    }

    private void SaveBlogs()
    {
      string json = JsonConvert.SerializeObject(Blogs, Formatting.Indented);
      using (StreamWriter stream = new StreamWriter(MainV.Config.BlogFileName()))
      {
        stream.Write(json);
      }
    }
  }
}
