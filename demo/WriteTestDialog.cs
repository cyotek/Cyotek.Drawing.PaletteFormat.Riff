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
  internal partial class WriteTestDialog : Form
  {
    #region Constants

    private readonly List<FileInfo> _files;

    #endregion

    #region Constructors

    public WriteTestDialog()
    {
      this.InitializeComponent();

      _files = new List<FileInfo>();
    }

    public WriteTestDialog(List<FileInfo> files)
      : this()
    {
      _files = files;
    }

    #endregion

    #region Methods

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      if (_files.Count != 0)
      {
        for (int i = 0; i < _files.Count; i++)
        {
          paletteComboBox.Items.Insert(i, _files[i]);
        }

        paletteComboBox.SelectedIndex = 0;
      }
      else
      {
        paletteComboBox.SelectedIndex = paletteComboBox.FindStringExact("Windows (256)");
      }
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void Compare(Color[] source)
    {
      using (Stream output = new MemoryStream())
      {
        PaletteCompareResult compareResult;
        Color[] dst;

        new RiffSerializer().Save(output, source);
        output.Position = 0;

        compareResult = PaletteComparer.Compare(source, output);

        if (compareResult != PaletteCompareResult.Mismatch)
        {
          resultLabel.Text = "Files are identical";
          resultLabel.BackColor = Color.Green;
        }
        else
        {
          resultLabel.Text = "Files do not match.";
          resultLabel.BackColor = Color.Red;
        }

        output.Position = 0;
        dst = new RiffSerializer().Load(output);

        sourceView.Palette = source;
        destinationView.ComparePalette = source;
        destinationView.Palette = dst;
      }
    }

    private void paletteComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      Color[] palette;
      int index;

      index = paletteComboBox.SelectedIndex;

      if (index < _files.Count)
      {
        palette = new RiffSerializer().Load(_files[index].FullPath);
      }
      else
      {
        switch (index - _files.Count)
        {
          case 0:
            palette = ColorPalettes.HexagonPalette;
            break;
          case 1:
            palette = ColorPalettes.NamedColors;
            break;
          case 2:
            palette = ColorPalettes.PaintPalette;
            break;
          case 3:
            palette = ColorPalettes.WebSafe;
            break;
          case 4:
            palette = ColorPalettes.QbColors;
            break;
          case 5:
            palette = ColorPalettes.StandardPalette;
            break;
          case 6:
            palette = ColorPalettes.RedScale;
            break;
          case 7:
            palette = ColorPalettes.GreenScale;
            break;
          case 8:
            palette = ColorPalettes.BlueScale;
            break;
          case 9:
            palette = ColorPalettes.GreyScale;
            break;
          case 10:
            palette = ColorPalettes.SystemColors;
            break;
          default:
            palette = null;
            break;
        }
      }

      if (palette != null && palette.Length != 0)
      {
        this.Compare(palette);
      }
      else
      {
        sourceView.Palette = null;
        destinationView.Palette = null;
      }
    }

    #endregion
  }
}
