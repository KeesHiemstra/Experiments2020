using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodaysWeather.Views
{
  public partial class SysTrayForm : Form
  {
    MainWindow MainView;

    public SysTrayForm(MainWindow mainView)
    {
      MainView = mainView;
      InitializeComponent();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MainView.CanClose = true;
      MainView.Close();
      Close();
    }

    private void notifyIconSysTray_MouseClick(object sender, MouseEventArgs e)
    {
      MainView.Visibility = System.Windows.Visibility.Visible;
      MainView.ShowInTaskbar = true;
    }
  }
}
