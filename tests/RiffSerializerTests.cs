// RIFF Palette Serializer
// Copyright (c) 2017 Cyotek Ltd.
// https://www.cyotek.com

// Licensed under the MIT License. See LICENSE.txt for the full text.

// If you find this code useful please consider making a donation.

using System;
using System.Drawing;
using System.IO;
using NUnit.Framework;

namespace Cyotek.Drawing.PaletteFormat.Tests
{
  [TestFixture]
  public class RiffSerializerTests
  {
    [Test]
    public void CanLoad_With18bitData_IsTrue()
    {
      // arrange
      RiffSerializer target;
      Stream data;
      bool actual;

      data = new MemoryStream(Data);

      target = new RiffSerializer();

      // act
      actual = target.CanLoad(data);

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    public void CanLoad_With24bitData_IsFalse()
    {
      // arrange
      RiffSerializer target;
      Stream data;
      bool actual;

      data = new MemoryStream(new byte[]
                              {
                                0,
                                0,
                                0,
                                255,
                                255,
                                255
                              });

      target = new RiffSerializer();

      // act
      actual = target.CanLoad(data);

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    public void CanLoad_WithFileName_IsTrue()
    {
      // arrange
      RiffSerializer target;
      bool actual;
      string fileName;

      fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\sample.pal");

      target = new RiffSerializer();

      // act
      actual = target.CanLoad(fileName);

      // assert
      Assert.IsTrue(actual);
    }

    [Test]
    public void CanLoad_WithMisalignedData_IsFalse()
    {
      // arrange
      RiffSerializer target;
      Stream data;
      bool actual;

      data = new MemoryStream(new byte[]
                              {
                                0,
                                1,
                                2,
                                4,
                                8
                              });

      target = new RiffSerializer();

      // act
      actual = target.CanLoad(data);

      // assert
      Assert.IsFalse(actual);
    }

    [Test]
    public void Extensions_ReturnsValues()
    {
      // arrange
      RiffSerializer target;
      string[] expected;
      string[] actual;

      expected = new[]
                 {
                   "pal"
                 };

      target = new RiffSerializer();

      // act
      actual = target.Extensions;

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Load_With18bitData_ReturnsPalette()
    {
      // arrange
      RiffSerializer target;
      Color[] expected;
      Color[] actual;
      Stream data;

      data = new MemoryStream(Data);
      expected = Sample;

      target = new RiffSerializer();

      // act
      actual = target.Load(data);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Load_WithFileName_ReturnsPalette()
    {
      // arrange
      RiffSerializer target;
      Color[] expected;
      Color[] actual;
      string fileName;

      fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\sample.pal");
      expected = Sample;

      target = new RiffSerializer();

      // act
      actual = target.Load(fileName);

      // assert
      CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Save_WritesValueData()
    {
      // arrange
      RiffSerializer target;
      MemoryStream output;
      Color[] data;
      byte[] expected;
      byte[] actual;

      expected = Data;
      output = new MemoryStream();
      data = Sample;

      target = new RiffSerializer();

      // act
      target.Save(output, data);

      // assert
      actual = output.ToArray();
      CollectionAssert.AreEqual(expected, actual);
    }

    private readonly byte[] Data={ 82, 73, 70, 70, 80, 0, 0, 0, 80, 65, 76, 32, 100, 97, 116, 97, 68, 0, 0, 0, 0, 3, 16, 0, 0, 0, 0, 0, 157, 157, 157, 0, 255, 255, 255, 0, 190, 38, 51, 0, 224, 111, 139, 0, 73, 60, 43, 0, 164, 100, 34, 0, 235, 137, 49, 0, 247, 226, 107, 0, 47, 72, 78, 0, 68, 137, 26, 0, 163, 206, 39, 0, 27, 38, 50, 0, 0, 87, 132, 0, 49, 162, 242, 0, 178, 220, 239, 0 };

    private readonly Color[] Sample = { Color.FromArgb(0, 0, 0),
                                        Color.FromArgb(157, 157, 157),
                                        Color.FromArgb(255, 255, 255),
                                        Color.FromArgb(190, 38, 51),
                                        Color.FromArgb(224, 111, 139),
                                        Color.FromArgb(73, 60, 43),
                                        Color.FromArgb(164, 100, 34),
                                        Color.FromArgb(235, 137, 49),
                                        Color.FromArgb(247, 226, 107),
                                        Color.FromArgb(47, 72, 78),
                                        Color.FromArgb(68, 137, 26),
                                        Color.FromArgb(163, 206, 39),
                                        Color.FromArgb(27, 38, 50),
                                        Color.FromArgb(0, 87, 132),
                                        Color.FromArgb(49, 162, 242),
                                        Color.FromArgb(178, 220, 239)};
}
}
