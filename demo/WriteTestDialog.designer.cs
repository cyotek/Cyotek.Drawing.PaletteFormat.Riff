namespace Cyotek.Demonstrations.PaletteFormat
{
  partial class WriteTestDialog
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
      this.sourceView = new SimpleColorGrid();
      this.destinationView = new SimpleColorGrid();
      this.closeButton = new System.Windows.Forms.Button();
      this.resultLabel = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.paletteComboBox = new System.Windows.Forms.ComboBox();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.SuspendLayout();
      //
      // splitContainer
      //
      this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer.Location = new System.Drawing.Point(12, 39);
      this.splitContainer.Name = "splitContainer";
      //
      // splitContainer.Panel1
      //
      this.splitContainer.Panel1.Controls.Add(this.sourceView);
      //
      // splitContainer.Panel2
      //
      this.splitContainer.Panel2.Controls.Add(this.destinationView);
      this.splitContainer.Size = new System.Drawing.Size(615, 452);
      this.splitContainer.SplitterDistance = 299;
      this.splitContainer.SplitterWidth = 16;
      this.splitContainer.TabIndex = 2;
      //
      // sourceView
      //
      this.sourceView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sourceView.Location = new System.Drawing.Point(0, 0);
      this.sourceView.Name = "sourceView";
      this.sourceView.Size = new System.Drawing.Size(299, 452);
      this.sourceView.TabIndex = 0;
      //
      // destinationView
      //
      this.destinationView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.destinationView.Location = new System.Drawing.Point(0, 0);
      this.destinationView.Name = "destinationView";
      this.destinationView.Size = new System.Drawing.Size(300, 452);
      this.destinationView.TabIndex = 0;
      //
      // closeButton
      //
      this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.closeButton.Location = new System.Drawing.Point(552, 526);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(75, 23);
      this.closeButton.TabIndex = 4;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
      //
      // resultLabel
      //
      this.resultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.resultLabel.AutoEllipsis = true;
      this.resultLabel.BackColor = System.Drawing.Color.Green;
      this.resultLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.resultLabel.ForeColor = System.Drawing.Color.White;
      this.resultLabel.Location = new System.Drawing.Point(12, 494);
      this.resultLabel.Name = "resultLabel";
      this.resultLabel.Padding = new System.Windows.Forms.Padding(6);
      this.resultLabel.Size = new System.Drawing.Size(615, 29);
      this.resultLabel.TabIndex = 3;
      this.resultLabel.Text = "Files are identical";
      //
      // label1
      //
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "&Palette:";
      //
      // paletteComboBox
      //
      this.paletteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.paletteComboBox.FormattingEnabled = true;
      this.paletteComboBox.Items.AddRange(new object[] {
            "Hexagon",
            "HTML",
            "Paint .NET",
            "WebSafe",
            "Windows (16)",
            "Windows (256)",
            "Red",
            "Green",
            "Blue",
            "Greyscale",
            "System"});
      this.paletteComboBox.Location = new System.Drawing.Point(58, 12);
      this.paletteComboBox.Name = "paletteComboBox";
      this.paletteComboBox.Size = new System.Drawing.Size(180, 21);
      this.paletteComboBox.TabIndex = 1;
      this.paletteComboBox.SelectedIndexChanged += new System.EventHandler(this.paletteComboBox_SelectedIndexChanged);
      //
      // WriteTestDialog
      //
      this.AcceptButton = this.closeButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.closeButton;
      this.ClientSize = new System.Drawing.Size(639, 561);
      this.Controls.Add(this.paletteComboBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.resultLabel);
      this.Controls.Add(this.closeButton);
      this.Controls.Add(this.splitContainer);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "WriteTestDialog";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Write Test";
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      this.splitContainer.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer;
    private SimpleColorGrid sourceView;
    private SimpleColorGrid destinationView;
    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.Label resultLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox paletteComboBox;
  }
}
