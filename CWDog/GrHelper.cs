using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CWDog
{
    public static class GrHelper
    {
        public static void DrawRoundedRectangle(Graphics gfx, Rectangle Bounds, int CornerRadius, Pen DrawPen, Brush FillColor)
        {
            int strokeOffset = Convert.ToInt32(Math.Ceiling(DrawPen.Width));
            Bounds = Rectangle.Inflate(Bounds, -strokeOffset, -strokeOffset);

            DrawPen.EndCap = DrawPen.StartCap = LineCap.Round;

            GraphicsPath gfxPath = GetRoundedRectanglePath(Bounds, CornerRadius);

            gfx.FillPath(FillColor, gfxPath);
            gfx.DrawPath(DrawPen, gfxPath);
        }
        public static GraphicsPath GetRoundedRectanglePath(Rectangle Bounds, int CornerRadius)
        {
            GraphicsPath gfxPath = new GraphicsPath();
            gfxPath.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            gfxPath.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            gfxPath.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            gfxPath.CloseAllFigures();
            return gfxPath;

        }
        public static int RGBLimit(int v)
        {
            if (v < 0) return 0;
            if (v > 255) return 255;
            return v;
        }
        public static Color MergeColor(Color ca, Color cb, int ratio)
        {
            int r, g, b;
            r = Convert.ToInt32((ca.R + (cb.R / ratio)) / (1.0 + 1.0 / ratio));
            g = Convert.ToInt32((ca.G + (cb.G / ratio)) / (1.0 + 1.0 / ratio));
            b = Convert.ToInt32((ca.B + (cb.B / ratio)) / (1.0 + 1.0 / ratio));
            return Color.FromArgb(255, RGBLimit(r), RGBLimit(g), RGBLimit(b));
        }
    }
}
