namespace Cyotek.Demonstrations.PaletteFormat
{
  partial class MainForm
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
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.filesListBox = new System.Windows.Forms.ListBox();
      this.previewGrid = new SimpleColorGrid();
      this.panel1 = new System.Windows.Forms.Panel();
      this.trackBar = new System.Windows.Forms.TrackBar();
      this.showLabelsCheckBox = new System.Windows.Forms.CheckBox();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.writeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      //
      // splitContainer
      //
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer.Location = new System.Drawing.Point(0, 24);
      this.splitContainer.Name = "splitContainer";
      //
      // splitContainer.Panel1
      //
      this.splitContainer.Panel1.Controls.Add(this.filesListBox);
      //
      // splitContainer.Panel2
      //
      this.splitContainer.Panel2.Controls.Add(this.previewGrid);
      this.splitContainer.Panel2.Controls.Add(this.panel1);
      this.splitContainer.Size = new System.Drawing.Size(687, 490);
      this.splitContainer.SplitterDistance = 250;
      this.splitContainer.TabIndex = 1;
      //
      // filesListBox
      //
      this.filesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.filesListBox.FormattingEnabled = true;
      this.filesListBox.IntegralHeight = false;
      this.filesListBox.Location = new System.Drawing.Point(0, 0);
      this.filesListBox.Name = "filesListBox";
      this.filesListBox.Size = new System.Drawing.Size(250, 490);
      this.filesListBox.TabIndex = 0;
      this.filesListBox.SelectedIndexChanged += new System.EventHandler(this.filesListBox_SelectedIndexChanged);
      //
      // previewGrid
      //
      this.previewGrid.CellSize = 24;
      this.previewGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.previewGrid.Location = new System.Drawing.Point(0, 0);
      this.previewGrid.Name = "previewGrid";
      this.previewGrid.ShowLabels = false;
      this.previewGrid.Size = new System.Drawing.Size(433, 434);
      this.previewGrid.Spacing = 3;
      this.previewGrid.TabIndex = 0;
      //
      // panel1
      //
      this.panel1.Controls.Add(this.trackBar);
      this.panel1.Controls.Add(this.showLabelsCheckBox);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 434);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(433, 56);
      this.panel1.TabIndex = 1;
      //
      // trackBar
      //
      this.trackBar.LargeChange = 8;
      this.trackBar.Location = new System.Drawing.Point(283, 6);
      this.trackBar.Maximum = 128;
      this.trackBar.Minimum = 8;
      this.trackBar.Name = "trackBar";
      this.trackBar.Size = new System.Drawing.Size(138, 45);
      this.trackBar.TabIndex = 1;
      this.trackBar.TickFrequency = 8;
      this.trackBar.Value = 24;
      this.trackBar.Scroll += new System.EventHandler(this.trackBar_ValueChanged);
      this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
      //
      // showLabelsCheckBox
      //
      this.showLabelsCheckBox.AutoSize = true;
      this.showLabelsCheckBox.Location = new System.Drawing.Point(0, 6);
      this.showLabelsCheckBox.Name = "showLabelsCheckBox";
      this.showLabelsCheckBox.Size = new System.Drawing.Size(57, 17);
      this.showLabelsCheckBox.TabIndex = 0;
      this.showLabelsCheckBox.Text = "&Labels";
      this.showLabelsCheckBox.UseVisualStyleBackColor = true;
      this.showLabelsCheckBox.CheckedChanged += new System.EventHandler(this.showLabelsCheckBox_CheckedChanged);
      //
      // menuStrip1
      //
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.testToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(687, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      //
      // fileToolStripMenuItem
      //
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      //
      // exitToolStripMenuItem
      //
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      //
      // testToolStripMenuItem
      //
      this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.writeTestToolStripMenuItem});
      this.testToolStripMenuItem.Name = "testToolStripMenuItem";
      this.testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
      this.testToolStripMenuItem.Text = "&Test";
      //
      // writeTestToolStripMenuItem
      //
      this.writeTestToolStripMenuItem.Name = "writeTestToolStripMenuItem";
      this.writeTestToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
      this.writeTestToolStripMenuItem.Text = "&Write Test...";
      this.writeTestToolStripMenuItem.Click += new System.EventHandler(this.writeTestToolStripMenuItem_Click);
      //
      // helpToolStripMenuItem
      //
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      //
      // aboutToolStripMenuItem
      //
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.aboutToolStripMenuItem.Text = "&About...";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      //
      // MainForm
      //
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(687, 514);
      this.Controls.Add(this.splitContainer);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      this.splitContainer.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.ListBox filesListBox;
    private SimpleColorGrid previewGrid;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem writeTestToolStripMenuItem;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TrackBar trackBar;
    private System.Windows.Forms.CheckBox showLabelsCheckBox;
  }
}

