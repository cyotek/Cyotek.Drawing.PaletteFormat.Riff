// RIFF Palette Serializer
// Copyright (c) 2017 Cyotek Ltd.
// https://www.cyotek.com

// Licensed under the MIT License. See LICENSE.txt for the full text.

// If you find this code useful please consider making a donation.

using System.Drawing;
using System.IO;
using Cyotek.Drawing.PaletteFormat;

namespace Cyotek.Demonstrations.PaletteFormat
{
  internal static class PaletteComparer
  {
    #region Static Methods

    public static PaletteCompareResult Compare(string x, string y)
    {
      using (Stream source = File.OpenRead(x))
      {
        using (Stream dest = File.OpenRead(y))
        {
          return Compare(source, dest);
        }
      }
    }

    public static PaletteCompareResult Compare(Stream x, Stream y)
    {
      PaletteCompareResult result;

      if (!AreFilesEqual(x, y))
      {
        y.Position = 0;
        y.Position = 0;

        result = !ArePalettesEqual(x, y) ? PaletteCompareResult.Mismatch : PaletteCompareResult.ColorMatch;
      }
      else
      {
        result = PaletteCompareResult.Match;
      }

      return result;
    }

    public static PaletteCompareResult Compare(Color[] palette, string y)
    {
      PaletteCompareResult result;

      using (Stream dest = File.OpenRead(y))
      {
        result = Compare(palette, dest);
      }

      return result;
    }

    public static PaletteCompareResult Compare(Color[] palette, Stream y)
    {
      PaletteCompareResult result;

      result = !ArePalettesEqual(palette, y) ? PaletteCompareResult.Mismatch : PaletteCompareResult.ColorMatch;

      return result;
    }

    private static bool AreFilesEqual(Stream source, Stream dest)
    {
      bool result;

      result = source.Length == dest.Length;

      if (result)
      {
        byte[] sourceBuffer;
        byte[] destBuffer;
        int sourceRead;
        int destRead;
        int bufferSize;

        bufferSize = 4096;
        sourceBuffer = new byte[bufferSize];
        destBuffer = new byte[bufferSize];

        do
        {
          sourceRead = source.Read(sourceBuffer, 0, bufferSize);
          destRead = dest.Read(destBuffer, 0, bufferSize);

          if (sourceRead != destRead)
          {
            result = false;
          }
          else
          {
            for (int i = 0; i < sourceRead; i++)
            {
              if (sourceBuffer[i] != destBuffer[i])
              {
                result = false;
                break;
              }
            }
          }
        } while ((sourceRead != 0 || destRead != 0) && result);
      }

      return result;
    }

    private static bool ArePalettesEqual(Stream x, Stream y)
    {
      Color[] palette;
      bool result;

      palette = new RiffSerializer().Load(x);

      result = ArePalettesEqual(palette, y);

      return result;
    }

    private static bool ArePalettesEqual(Color[] x, Stream y)
    {
      Color[] destination;
      bool result;

      try
      {
        destination = new RiffSerializer().Load(y);
      }
      catch
      {
        destination = new Color[0];
      }

      result = ArePalettesEqual(x, destination);

      return result;
    }

    private static bool ArePalettesEqual(Color[] x, Color[] y)
    {
      bool result;

      if (x.Length == y.Length)
      {
        result = true;

        for (int i = 0; i < x.Length; i++)
        {
          Color cx;
          Color cy;

          cx = x[i];
          cy = y[i];

          if (cx.ToArgb() != cy.ToArgb())
          {
            result = false;
            break;
          }
        }
      }
      else
      {
        result = false;
      }

      return result;
    }

    #endregion
  }
}
