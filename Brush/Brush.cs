using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFiltererV2
{
    public class Brush
    {
        public int brushSize = 100;

        private Form1 form { get; set; }

        private PictureBox pictureBox { get; set; }

        public DirectBitmap Bmp { get; set; }

        public DirectBitmap PolygonLessBmp { get; set; }

        private DirectBitmap FilteredBmp { get; set; }

        public TextureBrush filterBrush { get; set; }

        private Graphics graphics { get; set; }

        private Graphics polygonLessgraphics { get; set; }

        private bool isPainting { get; set; }

        public Brush(PictureBox pictureBox, Form1 form)
        {
            this.pictureBox = pictureBox;
            this.form = form;
            this.FilteredBmp = null;
        }

        public void StartBrushTracking()
        {
            graphics = Graphics.FromImage(this.Bmp.Bitmap);
            polygonLessgraphics = Graphics.FromImage(this.PolygonLessBmp.Bitmap);
            this.pictureBox.MouseMove += FollowBrush;
            this.pictureBox.MouseDown += PaintBrush;
            this.pictureBox.MouseLeave += LeaveBrush;
            this.isPainting = false;

            if (this.FilteredBmp != null)
            {
                this.FilteredBmp.Dispose();
                this.filterBrush.Dispose();
            }
            this.FilteredBmp = this.form.GenerateFilteredBmp();
            this.filterBrush = new TextureBrush(this.FilteredBmp.Bitmap);
        }



        private void LeaveBrush(object sender, EventArgs e)
        {
            ReleaseBrush(null, null);
            this.form.RedrawPolygons();
            this.pictureBox.Invalidate();
        }

        public void StopBrushTracking()
        {
            this.pictureBox.MouseMove -= FollowBrush;
            this.pictureBox.MouseDown -= PaintBrush;
            this.pictureBox.MouseUp -= ReleaseBrush;
            this.graphics.Dispose();
            this.polygonLessgraphics.Dispose();
            if(this.FilteredBmp != null)
            {
                this.FilteredBmp.Dispose();
                this.filterBrush.Dispose();
            }
        }

        private void PaintBrush(object sender, MouseEventArgs e)
        {
            if (this.form.filtersChanged)
            {
                this.form.filtersChanged = false;
                this.StopBrushTracking();
                this.StartBrushTracking();
            }
            this.pictureBox.MouseDown -= PaintBrush;
            this.isPainting = true;
            this.pictureBox.MouseUp += ReleaseBrush;

        }

        private void ReleaseBrush(object sender, MouseEventArgs e)
        {
            this.pictureBox.MouseUp -= ReleaseBrush;
            this.isPainting = false;
            this.form.GetColorCountFromImage();
            this.form.InitCharts();
            this.pictureBox.MouseDown += PaintBrush;
        }
        

        private void FollowBrush(object sender, MouseEventArgs e)
        {
            var rect = new Rectangle(
                new Point(e.X - brushSize / 2, e.Y - brushSize / 2),
                new Size(brushSize, brushSize));

            if (this.isPainting)
            {
                polygonLessgraphics.FillEllipse(this.filterBrush, rect);
            }

            this.form.RedrawPolygons();

            graphics.DrawEllipse(Pens.Black, rect);
            this.pictureBox.Invalidate();
        }

        
    }
}
