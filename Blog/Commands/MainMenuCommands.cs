using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Blog.Commands
{
  public static class MainMenuCommands
  {
    public static readonly RoutedUICommand Exit = new RoutedUICommand
      (
        "E_xit",
        "Exit",
        typeof(MainMenuCommands),
        new InputGestureCollection()
        {
          new KeyGesture(Key.F4, ModifierKeys.Alt)
        }
      );

    public static readonly RoutedUICommand Configuration = new RoutedUICommand
      (
        "_Configuration",
        "Configuration",
        typeof(MainMenuCommands),
        new InputGestureCollection() { }
      );

    public static readonly RoutedUICommand NewBlog = new RoutedUICommand
      (
        "_New",
        "NewBlog",
        typeof(MainMenuCommands),
        new InputGestureCollection()
        {
          new KeyGesture(Key.N, ModifierKeys.Control)
        }
      );
  }
}
