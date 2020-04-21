using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Events
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

    private void hideToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show("Hide");
    }
  }
}
