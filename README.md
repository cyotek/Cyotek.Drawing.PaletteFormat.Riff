RIFF Palette Serializer
=======================

This is a simple class for reading and writing `System.Drawing.Color` arrays to and from Microsoft RIFF palettes (standard only, enhanced not supported yet).

It has been designed to be either directly referenced in your own projects, or can be used as a serializer with [Cyotek Color Palette Editor](https://www.cyotek.com/cyotek-palette-editor). There are no external dependencies so the core class (plus a utility class) can be embedded directly in your project if required.

There is also a small test class to verify the critical bits of the code are doing what they should be.

## Reading Palettes

Palette data can be read from any `Stream`

    RiffSerializer reader = new RiffSerializer();
    Stream stream = GetDataStream();
    Color[] colors = reader.Load(stream);

However, for simplicity an overload is also available to load from a file

    RiffSerializer reader = new RiffSerializer();
    string fileName = "mypalette.pal";
    Color[] colors = reader.Load(fileName);

You can also use the `CanLoad` overloads to test if a given `Stream` or file contains a RIFF palette.

## Writing Palettes

As with reading, palette data can be written to either a `Stream` or a file.

    RiffSerializer writer = new RiffSerializer();
    string fileName = "mypalette.pal";
    Color[] colors = new[] { Color.Red, Color.Green, Color.Blue };
    writer.Save(fileName);

## Demonstration Application

A sample application is also available, which is based on the one created for the blog post [Reading and writing 18-bit RGB VGA Palette (pal) files with C#](https://www.cyotek.com/blog/reading-and-writing-18-bit-rgb-vga-palette-pal-files-with-csharp).

## Further Reading

* [Loading Microsoft RIFF Palette (pal) files with C#](https://www.cyotek.com/blog/loading-microsoft-riff-palette-pal-files-with-csharp)
* [Writing Microsoft RIFF Palette (pal) files with C#](https://www.cyotek.com/blog/writing-microsoft-riff-palette-pal-files-with-csharp)
