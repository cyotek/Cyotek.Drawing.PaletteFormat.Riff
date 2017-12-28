// RIFF Palette Serializer
// Copyright (c) 2017 Cyotek Ltd.
// https://www.cyotek.com

// Licensed under the MIT License. See LICENSE.txt for the full text.

// If you find this code useful please consider making a donation.

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

// TODO: This class won't work as-on non-Windows platforms as it is assuming little endian

// For Cyotek Color Palette Editor to detect this class as a serializer without having to take
// dependencies on other Cyotek libraries the following conditions must be met
//
// * The class must be public and not abstract
// * The class name must end in Serializer
// * There must be an instance of DescriptionAttribute on the class with a simple name for use in file filters
// * There must be a readable property named Extensions of type string[]
// * To enable load support, the following are required
// *   A method named CanLoad, that accepts a Stream and returns a bool
// *   A method named Load, that accepts a Stream and returns Color[]
// * To enable save support, the following are required
// *   A method named Save, that accepts a Stream and Color[] and returns void
//
// Methods and properties can be public or private.
//
// Cyotek Color Palette Editor 1.7 and above can load serialisers following the above rules,
// older versions can only load ones that are explicitly inheriting a more complicated base class.
// The ability to specific advanced functionality such as minimum/maximum counts, color types,
// etc are not available from this simplified form.
//
// The Load(String) and Save(String) overloads are convenience helpers for consumers of
// the class and are not directly used by Cyotek Color Palette Editor.

namespace Cyotek.Drawing.PaletteFormat
{
  [Description("Microsoft RIFF Palette")]
  public class RiffSerializer
  {
    #region Properties

    public string[] Extensions
    {
      get
      {
        return new[]
               {
                 "pal"
               };
      }
    }

    #endregion

    #region Methods

    public bool CanLoad(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentNullException(nameof(fileName));
      }

      if (!File.Exists(fileName))
      {
        throw new FileNotFoundException("Cannot find file '" + fileName + "'.", fileName);
      }

      using (Stream stream = File.OpenRead(fileName))
      {
        return this.CanLoad(stream);
      }
    }

    public bool CanLoad(Stream stream)
    {
      bool result;

      if (stream == null)
      {
        throw new ArgumentNullException(nameof(stream));
      }

      try
      {
        byte[] buffer;

        buffer = new byte[12];

        stream.Read(buffer, 0, 12);

        result = buffer[0] == 'R' && buffer[1] == 'I' && buffer[2] == 'F' && buffer[3] == 'F' && buffer[8] == 'P' && buffer[9] == 'A' && buffer[10] == 'L' && buffer[11] == ' ';
      }
      catch
      {
        result = false;
      }

      return result;
    }

    public Color[] Load(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentNullException(nameof(fileName));
      }

      if (!File.Exists(fileName))
      {
        throw new FileNotFoundException("Cannot find file '" + fileName + "'.", fileName);
      }

      using (Stream stream = File.OpenRead(fileName))
      {
        return this.Load(stream);
      }
    }

    public Color[] Load(Stream stream)
    {
      Color[] results;
      byte[] buffer;
      bool eof;

      buffer = new byte[1032]; // create a buffer big enough to hold a default 256 color palette
      results = null;

      // first read and validate the form header
      // this is comprised of
      // * RIFF header
      // * document size
      // * FORM header
      stream.Read(buffer, 0, 12);
      if (buffer[0] != 'R' || buffer[1] != 'I' || buffer[2] != 'F' || buffer[3] != 'F')
      {
        throw new InvalidDataException("Source stream is not a RIFF document.");
      }

      // TODO: Validate the document size if required

      if (buffer[8] != 'P' || buffer[9] != 'A' || buffer[10] != 'L' || buffer[11] != ' ')
      {
        throw new InvalidDataException("Source stream is not a palette.");
      }

      eof = false;

      while (!eof)
      {
        // a RIFF document can have one or more chunks.
        // for our purposes, each chunk has a 4 letter
        // identifier and a size of the data part of the
        // chunk. We can use these two values to either
        // process the palette data, or skip data we
        // don't recognise

        // TODO: This procedure only supports simple, not extended, palettes

        if (stream.Read(buffer, 0, 8) == 8)
        {
          int chunkSize;

          chunkSize = buffer.MakeDWordLittleEndian(4);

          // see if we have the palette data
          if (buffer[0] == 'd' && buffer[1] == 'a' && buffer[2] == 't' && buffer[3] == 'a')
          {
            if (chunkSize > buffer.Length)
            {
              buffer = new byte[chunkSize];
            }

            if (stream.Read(buffer, 0, chunkSize) != chunkSize)
            {
              throw new InvalidDataException("Failed to read enough data to match chunk size.");
            }

            results = this.ReadPalette(buffer);

            // only one palette in a file, so break out of the chunk scan
            eof = true;
          }
          else
          {
            // not the palette data? advance the stream to the next chunk

            // riff chunks are word-aligned. if the size is odd
            // then a padding byte is included after the chunk
            // data. This is junk data, so we just skip it
            if (chunkSize % 2 != 0)
            {
              chunkSize++;
            }

            stream.Position += chunkSize;
          }
        }
        else
        {
          // nothing to read, abort
          eof = true;
        }
      }

      return results;
    }

    public void Save(string fileName, Color[] values)
    {
      if (string.IsNullOrEmpty(fileName))
      {
        throw new ArgumentNullException(nameof(fileName));
      }

      this.CheckValues(values);

      using (Stream stream = File.Create(fileName))
      {
        this.Save(stream, values);
      }
    }

    public void Save(Stream stream, Color[] values)
    {
      byte[] buffer;
      int length;
      ushort count;
      ushort chunkSize;

      this.CheckValues(values);

      count = (ushort)values.Length;
      chunkSize = (ushort)(4 + count * 4);

      // 4 bytes for RIFF
      // 4 bytes for document size
      // 4 bytes for PAL
      // 4 bytes for data
      // 4 bytes for chunk size
      // 2 bytes for the version
      // 2 bytes for the count
      // (4*n) for the colors
      length = 4 + 4 + 4 + 4 + 4 + 2 + 2 + count * 4;
      buffer = new byte[length];

      // the riff header
      buffer[0] = (byte)'R';
      buffer[1] = (byte)'I';
      buffer[2] = (byte)'F';
      buffer[3] = (byte)'F';
      WordHelpers.StoreDWordLittleEndian(length - 8, buffer, 4);

      // the form type
      buffer[8] = (byte)'P';
      buffer[9] = (byte)'A';
      buffer[10] = (byte)'L';
      buffer[11] = (byte)' ';

      // data chunk header
      buffer[12] = (byte)'d';
      buffer[13] = (byte)'a';
      buffer[14] = (byte)'t';
      buffer[15] = (byte)'a';
      WordHelpers.StoreDWordLittleEndian(chunkSize, buffer, 16);

      // logpalette
      buffer[20] = 0;
      buffer[21] = 3;
      WordHelpers.StoreWordLittleEndian(count, buffer, 22);

      for (int i = 0; i < count; i++)
      {
        Color color;
        int offset;

        color = values[i];

        offset = 24 + i * 4;

        buffer[offset] = color.R;
        buffer[offset + 1] = color.G;
        buffer[offset + 2] = color.B;
      }

      stream.Write(buffer, 0, length);
    }

    private void CheckValues(Color[] values)
    {
      if (values == null)
      {
        throw new ArgumentNullException(nameof(values));
      }

      if (values.Length > short.MaxValue)
      {
        throw new ArgumentException("Palettes containing more than 32767 colors are not supported.", nameof(values));
      }
    }

    private Color[] ReadPalette(byte[] buffer)
    {
      Color[] palette;
      ushort count;

      // The buffer should hold a LOGPALETTE structure containing
      // OS version (2 bytes, always 03)
      // Color count (2 bytes)
      // Color data (4 bytes * color count)

      count = buffer.MakeWordLittleEndian(2);

      palette = new Color[count];

      for (int i = 0; i < count; i++)
      {
        byte r;
        byte g;
        byte b;
        int offset;

        offset = i * 4 + 4;
        r = buffer[offset];
        g = buffer[offset + 1];
        b = buffer[offset + 2];

        // TODO: The fourth byte are flags, which we have no use for here

        palette[i] = Color.FromArgb(r, g, b);
      }

      return palette;
    }

    #endregion
  }
}
