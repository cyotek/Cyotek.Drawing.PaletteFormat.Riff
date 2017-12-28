// RIFF Palette Serializer
// Copyright (c) 2017 Cyotek Ltd.
// https://www.cyotek.com

// Licensed under the MIT License. See LICENSE.txt for the full text.

// If you find this code useful please consider making a donation.

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Demonstrations.PaletteFormat
{
  internal partial class AboutDialog : Form
  {
    #region Constructors

    public AboutDialog()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Methods

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);

      nameLabel.Font = new Font(this.Font, FontStyle.Bold);
    }

    protected override void OnLoad(EventArgs e)
    {
      FileVersionInfo versionInfo;

      if (!this.DesignMode)
      {
        this.Font = SystemFonts.DialogFont;
      }

      versionInfo = FileVersionInfo.GetVersionInfo(typeof(MainForm).Assembly.Location);
      nameLabel.Text = versionInfo.ProductName;
      copyrightLabel.Text = versionInfo.LegalCopyright;

      base.OnLoad(e);
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void webLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      try
      {
        Process.Start("http://www.cyotek.com");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.GetBaseException().
                           Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    #endregion
  }
}
