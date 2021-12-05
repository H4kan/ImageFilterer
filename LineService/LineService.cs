using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageFiltererV2
{
    public class LineService
    {
        public DirectBitmap Bmp { get; set; }

        public DirectBitmap TrackingBmp { get; set; }

        public DirectBitmap OriginalBmp { get; set; }

        public DirectBitmap PolygonLessBmp { get; set; }

        public BresenhamLine BrensehamLine { get; set; }

        public BresenhamLine BrensehamTrackingLine { get; set; }

        public LineTracker LineTracker { get; set; }

        public LineTracker DoubleTracker { get; set; }

        public PictureBox PictureBox { get; set; }

        public bool IsLineTracking { get; set; }

        public LineService(DirectBitmap bmp, PictureBox pictureBox)
        {
            this.Bmp = bmp;
            this.BrensehamLine = new BresenhamLine(bmp, this);
            
            this.PictureBox = pictureBox;
        }

        public void BeginTracking(int x, int y)
        {
            this.IsLineTracking = true;
            TrackingBmp = (DirectBitmap)Bmp.Clone();
            this.BrensehamTrackingLine = new BresenhamLine(TrackingBmp, this);
            this.PictureBox.Image = TrackingBmp.Bitmap;
            this.PictureBox.Invalidate();
            LineTracker = new LineTracker(this, x, y);
            this.PictureBox.MouseMove += this.LineTracker.Update;
        }

     
        
        public void StopTracking()
        {
            var line = this.LineTracker.LastLine;
            this.CreateLine(line);

            this.PictureBox.Image = Bmp.Bitmap;
            this.TrackingBmp.Dispose();
            LineTracker = null;

            this.PictureBox.Invalidate();
        }

        public void AbortTracking()
        {

            this.PictureBox.Image = Bmp.Bitmap;
            this.TrackingBmp.Dispose();
            LineTracker = null;

            this.PictureBox.Invalidate();
            this.IsLineTracking = false;
        }

        public Line CreateLine(int x1, int y1, int x2, int y2)
        {
            return BrensehamLine.CreateLine(x1, y1, x2, y2);
        }

        public Line CreateLine(Line line)
        {
            return this.CreateLine(line.Points[0].X, line.Points[0].Y, line.Points[1].X, line.Points[1].Y);
        }

        public Line CreateTrackingLine(int x1, int y1, int x2, int y2)
        {
            return BrensehamTrackingLine.CreateLine(x1, y1, x2, y2);
        }
        public Line CreateTrackingLine(Line line)
        {
            return this.CreateTrackingLine(line.Points[0].X, line.Points[0].Y, line.Points[1].X, line.Points[1].Y);
        }


        public void EraseTrackingLine(Line line)
        {
            BrensehamTrackingLine.EraseLine(line);
        }

        public void FastHorizontalLine(int x1, int x2, int y, IFilterHandler filterHandler)
        {
            if (x1 >= Bmp.Width || x2 < 0 || y < 0 || y >= Bmp.Height) return;
            if (x1 < 0) x1 = 0;
            if (x2 >= Bmp.Width) x2 = Bmp.Width - 1;
            int x = x1;
            while (x <= x2)
            {
                Bmp.SetPixel(x, y, filterHandler.EvaluateFilter(OriginalBmp.GetPixel(x, y)));
                x++;
            }

        }
    }
}
