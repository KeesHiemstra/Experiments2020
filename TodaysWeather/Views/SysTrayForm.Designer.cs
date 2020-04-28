namespace TodaysWeather.Views
{
  partial class SysTrayForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysTrayForm));
      this.notifyIconSysTray = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenuStripSysTray = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStripSysTray.SuspendLayout();
      this.SuspendLayout();
      // 
      // notifyIconSysTray
      // 
      this.notifyIconSysTray.BalloonTipText = "Sun: Daylight\r\nMoon: First quarter";
      this.notifyIconSysTray.ContextMenuStrip = this.contextMenuStripSysTray;
      this.notifyIconSysTray.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconSysTray.Icon")));
      this.notifyIconSysTray.Text = "Todays weather";
      this.notifyIconSysTray.Visible = true;
      this.notifyIconSysTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconSysTray_MouseClick);
      // 
      // contextMenuStripSysTray
      // 
      this.contextMenuStripSysTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
      this.contextMenuStripSysTray.Name = "contextMenuStripSysTray";
      this.contextMenuStripSysTray.Size = new System.Drawing.Size(94, 26);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // SysTrayForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(184, 61);
      this.Name = "SysTrayForm";
      this.ShowInTaskbar = false;
      this.Text = "SysTray";
      this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
      this.contextMenuStripSysTray.ResumeLayout(false);
      this.ResumeLayout(false);

    }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconSysTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSysTray;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}