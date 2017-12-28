// RIFF Palette Serializer
// Copyright (c) 2017 Cyotek Ltd.
// https://www.cyotek.com

// Licensed under the MIT License. See LICENSE.txt for the full text.

// If you find this code useful please consider making a donation.

using System.IO;

namespace Cyotek.Demonstrations.PaletteFormat
{
  internal class FileInfo
  {
    #region Constructors

    public FileInfo(string fullPath)
    {
      this.FullPath = fullPath;
    }

    #endregion

    #region Properties

    public string FullPath { get; set; }

    #endregion

    #region Methods

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>
    /// A string that represents the current object.
    /// </returns>
    public override string ToString()
    {
      return Path.GetFileName(this.FullPath) ?? base.ToString();
    }

    #endregion
  }
}
