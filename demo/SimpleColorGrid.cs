// RIFF Palette Serializer
// Copyright (c) 2017 Cyotek Ltd.
// https://www.cyotek.com

// Licensed under the MIT License. See LICENSE.txt for the full text.

// If you find this code useful please consider making a donation.

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Cyotek.Demonstrations.PaletteFormat
{
  internal sealed class SimpleColorGrid : Control
  {
    #region Constants

    private const int _defaultCellSize = 32;

    #endregion

    #region Fields

    private int _cellSize;

    private Color[] _comparePalette;

    private Font _font;

    private Color[] _palette;

    private bool _showLabels;

    private int _spacing;

    private ToolTip _toolTip;

    #endregion

    #region Constructors

    public SimpleColorGrid()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.Selectable, false);

      _spacing = 6;
      _cellSize = _defaultCellSize;
      _showLabels = true;

      _toolTip = new ToolTip();

      _font = new Font("Small Fonts", 6);
    }

    #endregion

    #region Properties

    [DefaultValue(_defaultCellSize)]
    [Category("Appearance")]
    public int CellSize
    {
      get { return _cellSize; }
      set
      {
        if (_cellSize != value)
        {
          _cellSize = value;

          this.Invalidate();
        }
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color[] ComparePalette
    {
      get { return _comparePalette; }
      set
      {
        _comparePalette = value;

        this.Invalidate();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color[] Palette
    {
      get { return _palette; }
      set
      {
        _palette = value;

        this.Invalidate();
      }
    }

    [DefaultValue(true)]
    [Category("Appearance")]
    public bool ShowLabels
    {
      get { return _showLabels; }
      set
      {
        if (_showLabels != value)
        {
          _showLabels = value;

          this.Invalidate();
        }
      }
    }

    [DefaultValue(6)]
    [Category("Appearance")]
    public int Spacing
    {
      get { return _spacing; }
      set
      {
        if (_spacing != value)
        {
          _spacing = value;

          this.Invalidate();
        }
      }
    }

    #endregion

    #region Methods

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        _font?.Dispose();
        _font = null;

        _toolTip?.Dispose();
        _toolTip = null;
      }

      base.Dispose(disposing);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics g;
      Padding padding;
      Size size;

      base.OnPaint(e);

      g = e.Graphics;
      padding = this.Padding;
      size = this.ClientSize;

      if (_palette != null)
      {
        int x;
        int y;

        x = padding.Left;
        y = padding.Top;

        g.Clear(this.BackColor);

        for (int index = 0; index < _palette.Length; index++)
        {
          Rectangle bounds;

          if (x > size.Width - (_cellSize + padding.Right))
          {
            x = padding.Left;
            y += _cellSize + _spacing;
          }

          bounds = new Rectangle(x, y, _cellSize, _cellSize);

          this.PaintCell(g, bounds, index);

          x += _cellSize + _spacing;
        }
      }
      else if (this.DesignMode)
      {
        ControlPaint.DrawBorder(g, this.ClientRectangle, SystemColors.ControlDark, ButtonBorderStyle.Dotted);

        for (int y = padding.Top; y < size.Height - (_cellSize + padding.Right); y += (_cellSize + _spacing))
        {
          for (int x = padding.Left; x < size.Width - (_cellSize + padding.Right); x += (_cellSize + _spacing))
          {
            ControlPaint.DrawBorder(g, new Rectangle(x, y, _cellSize, _cellSize), SystemColors.ControlDark, ButtonBorderStyle.Dotted);
          }
        }
      }
    }

    private bool IsDark(Color color)
    {
      double greyscale;

      greyscale = 0.11 * color.R + 0.59 * color.G + 0.30 * color.B;

      return greyscale < 130;
    }

    private void PaintCell(Graphics g, Rectangle bounds, int index)
    {
      Color color;
      Color textColor;
      bool isDark;

      color = _palette[index];
      isDark = this.IsDark(color);
      textColor = isDark ? Color.White : Color.Black;

      using (Brush brush = new SolidBrush(color))
      {
        g.FillRectangle(brush, bounds);
      }

      if (_showLabels)
      {
        this.PaintRgbString(g, color, bounds, textColor, false);
      }

      g.DrawRectangle(Pens.Black, bounds);

      if (_comparePalette != null)
      {
        Color compare;

        compare = _comparePalette[index];

        if (_comparePalette.Length < index || color.ToArgb() != compare.ToArgb())
        {
          g.DrawRectangle(Pens.Red, bounds);

          if (_showLabels)
          {
            this.PaintRgbString(g, compare, bounds, isDark ? Color.White : Color.Red, true);
          }
        }
      }
    }

    private void PaintRgbString(Graphics g, Color color, Rectangle bounds, Color textColor, bool rightAlign)
    {
      int x;
      int y;
      int w;
      int h;
      TextFormatFlags flags;

      x = bounds.X + 2;
      y = bounds.Y + 2;
      w = bounds.Width - 4;
      h = TextRenderer.MeasureText(g, "X", _font).
                       Height;

      flags = TextFormatFlags.NoPadding | TextFormatFlags.SingleLine;

      if (rightAlign)
      {
        flags |= TextFormatFlags.Right;
      }

      TextRenderer.DrawText(g, color.R.ToString(), _font, new Rectangle(x, y, w, h), textColor, color, flags);
      TextRenderer.DrawText(g, color.G.ToString(), _font, new Rectangle(x, y + h, w, h), textColor, color, flags);
      TextRenderer.DrawText(g, color.B.ToString(), _font, new Rectangle(x, y + (h * 2), w, h), textColor, color, flags);
    }

    #endregion
  }
}
