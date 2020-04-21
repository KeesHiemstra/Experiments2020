namespace Events
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
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
      this.notifyIcon1.BalloonTipText = "text";
      this.notifyIcon1.BalloonTipTitle = "Notification";
      this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = "Events";
      this.notifyIcon1.Visible = true;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(94, 26);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(251, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // hideToolStripMenuItem
      // 
      this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
      this.hideToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.hideToolStripMenuItem.Text = "Hide";
      this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
      // 
      // SysTrayForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(251, 85);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "SysTrayForm";
      this.Text = "Notification";
      this.contextMenuStrip1.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}