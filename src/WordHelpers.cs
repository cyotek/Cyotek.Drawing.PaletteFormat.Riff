// RIFF Palette Serializer
// Copyright (c) 2017 Cyotek Ltd.
// https://www.cyotek.com

// Licensed under the MIT License. See LICENSE.txt for the full text.

// If you find this code useful please consider making a donation.

namespace Cyotek.Drawing.PaletteFormat
{
  internal static class WordHelpers
  {
    #region Static Methods

    public static int MakeDWordLittleEndian(this byte[] buffer, int offset)
    {
      return ((((buffer[offset + 3] << 0x18) | (buffer[offset + 2] << 0x10)) | (buffer[offset + 1] << 8)) | buffer[offset]);
    }

    public static ushort MakeWordLittleEndian(this byte[] buffer, int offset)
    {
      return (ushort)((buffer[offset + 1] << 8) | buffer[offset]);
    }

    public static void StoreDWordLittleEndian(int value, byte[] buffer, int offset)
    {
      buffer[offset + 3] = (byte)((value & 0xff000000L) >> 0x18);
      buffer[offset + 2] = (byte)((value & 0xff0000) >> 0x10);
      buffer[offset + 1] = (byte)((value & 0xff00) >> 8);
      buffer[offset] = (byte)(value & 0xff);
    }

    public static void StoreWordLittleEndian(ushort value, byte[] buffer, int offset)
    {
      buffer[offset + 1] = (byte)((value & 0xff00) >> 8);
      buffer[offset] = (byte)(value & 0xff);
    }

    #endregion
  }
}
