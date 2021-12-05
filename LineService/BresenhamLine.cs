using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageFiltererV2
{
    public interface IColorProvider
    {
        Color GetColor(int x, int y);
    }

    public class BlackProvider : IColorProvider
    {
        public Color GetColor(int x, int y)
        {
            return Color.Black;
        }
    }

    public class BitmapProvider : IColorProvider
    {
        private DirectBitmap Bmp { get; set; }

        public BitmapProvider(DirectBitmap bmp)
        {
            this.Bmp = bmp;
        }

        public Color GetColor(int x, int y)
        {
            return Bmp.GetPixel(x, y);
        }
    }

    public class BresenhamLine
    {
        public DirectBitmap bmp { get; set; }

        public DirectBitmap backupBmp { get; set; }

        private LineService LineService { get; set; }

        public BresenhamLine(DirectBitmap bmp, LineService lineService)
        {
            this.bmp = bmp;
            this.LineService = lineService;
        }

        private void BresenhamLow(int x1, int y1, int x2, int y2, IColorProvider colorProvider)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int y_step = 1;
            if (dy < 0)
            {
                y_step = -1;
                dy = -dy;
            }
            int d = (2 * dy) - dx;
            int y = y1;
            int x = x1;

            while (x <= x2)
            {
                bmp.SetPixel(x, y, colorProvider.GetColor(x, y));
                if (d > 0)
                {
                    y += y_step;
                    d += 2 * (dy - dx);
                }
                else
                {
                    d += 2 * dy;
                }
                x++;
            }
        }

        private void BresenhamHigh(int x1, int y1, int x2, int y2, IColorProvider colorProvider)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int x_step = 1;
            if (dx < 0)
            {
                x_step = -1;
                dx = -dx;
            }
            int d = (2 * dx) - dy;
            int y = y1;
            int x = x1;

            while (y <= y2)
            {
                bmp.SetPixel(x, y, colorProvider.GetColor(x, y));
                if (d > 0)
                {
                    x += x_step;
                    d += 2 * (dx - dy);
                }
                else
                {
                    d += 2 * dx;
                }
                y++;
            }
        }

        public Line CreateLine(int x1, int y1, int x2, int y2)
        {
            var blackProvider = new BlackProvider();
            var line = new Line();
            if (x1 > 0 && x2 > 0 && y1 > 0 && y2 > 0 
                && x1 < bmp.Width && x2 < bmp.Width
                && y1 < bmp.Height && y2 < bmp.Height)
            {
                if (Math.Abs(y2 - y1) < Math.Abs(x2 - x1))
                {
                    if (x1 > x2)
                        BresenhamLow(x2, y2, x1, y1, blackProvider);
                    else
                        BresenhamLow(x1, y1, x2, y2, blackProvider);
                }
                else
                {
                    if (y1 > y2)
                        BresenhamHigh(x2, y2, x1, y1, blackProvider);
                    else
                        BresenhamHigh(x1, y1, x2, y2, blackProvider);
                }
            }
            line.AppendPoint(new Point(x1, y1));
            line.AppendPoint(new Point(x2, y2));
            return line;
        }

        public void EraseLine(Line line)
        {
            var bitmapProvider = new BitmapProvider(this.LineService.PolygonLessBmp);
            if (line.Points.Count < 2) return;
            var x1 = line.Points[0].X;
            var x2 = line.Points[1].X;
            var y1 = line.Points[0].Y;
            var y2 = line.Points[1].Y;
            if (x1 > 0 && x2 > 0 && y1 > 0 && y2 > 0
              && x1 < bmp.Width && x2 < bmp.Width
              && y1 < bmp.Height && y2 < bmp.Height)
            {
                if (Math.Abs(y2 - y1) < Math.Abs(x2 - x1))
                {
                    if (x1 > x2)
                        BresenhamLow(x2, y2, x1, y1, bitmapProvider);
                    else
                        BresenhamLow(x1, y1, x2, y2, bitmapProvider);
                }
                else
                {
                    if (y1 > y2)
                        BresenhamHigh(x2, y2, x1, y1, bitmapProvider);
                    else
                        BresenhamHigh(x1, y1, x2, y2, bitmapProvider);
                }
            }
        }
    }
}
