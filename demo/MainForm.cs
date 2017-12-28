// RIFF Palette Serializer
// Copyright (c) 2017 Cyotek Ltd.
// https://www.cyotek.com

// Licensed under the MIT License. See LICENSE.txt for the full text.

// If you find this code useful please consider making a donation.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Cyotek.Drawing.PaletteFormat;

namespace Cyotek.Demonstrations.PaletteFormat
{
  internal partial class MainForm : Form
  {
    #region Fields

    private List<FileInfo> _fileInfo;

    private Color[] _loadedPalette;

    #endregion

    #region Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data. </param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      this.Text = Application.ProductName;
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      _fileInfo = new List<FileInfo>(16);

      this.AddFiles("pal");

      if (filesListBox.Items.Count != 0)
      {
        filesListBox.SelectedIndex = 0;
      }
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (Form dialog = new AboutDialog())
      {
        dialog.ShowDialog(this);
      }
    }

    private void AddFiles(string extension)
    {
      string path;

      path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");

      foreach (string fileName in Directory.GetFiles(path, "*." + extension))
      {
        FileInfo info;

        info = new FileInfo(fileName);

        _fileInfo.Add(info);
        filesListBox.Items.Add(info);
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void filesListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      FileInfo selectedFile;

      selectedFile = filesListBox.SelectedItem as FileInfo;

      if (selectedFile != null)
      {
        _loadedPalette = new RiffSerializer().Load(selectedFile.FullPath);

        this.Text = string.Format("{0} - {1}", Path.GetFileName(selectedFile.FullPath), Application.ProductName);
      }
      else
      {
        _loadedPalette = null;
        this.Text = Application.ProductName;
      }

      previewGrid.Palette = _loadedPalette;
    }

    private void showLabelsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      previewGrid.ShowLabels = showLabelsCheckBox.Checked;
    }

    private void trackBar_ValueChanged(object sender, EventArgs e)
    {
      previewGrid.CellSize = trackBar.Value;
    }

    private void writeTestToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (WriteTestDialog dialog = new WriteTestDialog(_fileInfo))
      {
        dialog.ShowDialog(this);
      }
    }

    #endregion
  }
}
