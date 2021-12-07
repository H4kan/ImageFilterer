using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ImageFiltererV2.Enums;

namespace ImageFiltererV2
{

    public partial class Form1 : Form
    {
        const int RGB_SIZE = 256;

        Size PICTURE_MAX_SIZE;

        public DirectBitmap Bmp { get; set; }
        public DirectBitmap PolygonLessBmp { get; set; }

        public DirectBitmap OriginalBmp { get; set; }

        public int[] redCount { get; set; }
        public int[] greenCount { get; set; }
        public int[] blueCount { get; set; }

        private LineService LineService { get; set; }
        private FillingService FillingService { get; set; }
        private MemoryService MemoryService { get; set; }

        public Polygon CurrentPolygon { get; set; }

        public EditMode Mode { get; set; }

        public FilterType SelectedFilter { get; set; }

        public int brightnessChangeValue { get; set; }

        public int contrastValue { get; set; }

        public float gammaValue { get; set; }

        private Brush Brush { get; set; }

        public bool filtersChanged { get; set; }

        public List<Point> OwnFunctionPoints { get; set; }

        public int[] mappedPoints { get; set; }

        public Form1()
        {
            InitializeComponent();

            this.Bmp = new DirectBitmap(pictureBox.Width, pictureBox.Height);
            this.PolygonLessBmp = null;
            this.OriginalBmp = null;
            this.pictureBox.Image = this.Bmp.Bitmap;
            this.PICTURE_MAX_SIZE = this.pictureBox.Size;

            this.LineService = new LineService(this.Bmp, pictureBox);
            this.FillingService = new FillingService(this.LineService, this);
            this.MemoryService = new MemoryService(pictureBox, LineService, FillingService, this);

            this.filtersListBox.SetItemChecked(0, true);
            this.SelectedFilter = FilterType.Identity;

            this.Brush = new Brush(this.pictureBox, this);

            this.ownFunctionChart.ChartAreas[0].AxisX.Minimum = 0;
            this.ownFunctionChart.ChartAreas[0].AxisX.Maximum = RGB_SIZE - 1;
            this.ownFunctionChart.ChartAreas[0].AxisY.Minimum = 0;
            this.ownFunctionChart.ChartAreas[0].AxisY.Maximum = RGB_SIZE - 1;

            this.OwnFunctionPoints = new List<Point>();
            this.mappedPoints = new int[RGB_SIZE];
        }


        public void InitCharts()
        {
            var redPoints = redChart.Series["RedData"].Points;
            var greenPoints = greenChart.Series["GreenData"].Points;
            var bluePoints = blueChart.Series["BlueData"].Points;
            redPoints.Clear();
            greenPoints.Clear();
            bluePoints.Clear();
            for (int i = 0; i < RGB_SIZE; i++)
            {
                redPoints.AddXY(i, redCount[i]);
                greenPoints.AddXY(i, greenCount[i]);
                bluePoints.AddXY(i, blueCount[i]);
            }
            
        }
        private void chooseImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Browse Image Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "png",
                Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg",
                FilterIndex = 1,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = Image.FromFile(openFileDialog.FileName);

                var actualWidth = Math.Min(image.Width, this.PICTURE_MAX_SIZE.Width);
                var actualHeight = Math.Min(image.Height, this.PICTURE_MAX_SIZE.Height);
                this.pictureBox.Size = new Size(actualWidth, actualHeight);

                using (Graphics g = Graphics.FromImage(this.Bmp.Bitmap))
                {
                    g.DrawImage(image, 0, 0, actualWidth, actualHeight);
                }
                if (this.PolygonLessBmp != null)
                    this.PolygonLessBmp.Dispose();
                this.PolygonLessBmp = (DirectBitmap)this.Bmp.Clone();
                this.LineService.PolygonLessBmp = this.PolygonLessBmp;

                if (this.OriginalBmp != null)
                    this.OriginalBmp.Dispose();
                this.OriginalBmp = (DirectBitmap)this.Bmp.Clone();
                this.LineService.OriginalBmp = this.OriginalBmp;

                this.Brush.Bmp = this.Bmp;
                this.Brush.PolygonLessBmp = this.PolygonLessBmp;

                this.pictureBox.Invalidate();
                this.GetColorCountFromImage();
                this.InitCharts();
                this.filtersPanel.Visible = true;
                this.pictureBox.Visible = true;
            }
        }

        public void GetColorCountFromImage()
        {
            redCount = new int[RGB_SIZE];
            greenCount = new int[RGB_SIZE];
            blueCount = new int[RGB_SIZE];
            for (int i = 0; i < this.Bmp.Bits.Length; i++)
            {
                var pixelColor = Color.FromArgb(this.Bmp.Bits[i]);

                redCount[pixelColor.R]++;
                greenCount[pixelColor.G]++;
                blueCount[pixelColor.B]++;
            }
        }

        private void BeginPolygon(object sender, MouseEventArgs e)
        {
            CurrentPolygon = new Polygon(e.X, e.Y);
            pictureBox.Invalidate();
            this.pictureBox.MouseClick -= BeginPolygon;
            this.LineService.BeginTracking(e.X, e.Y);

            this.pictureBox.MouseClick += ContinuePolygon;

        }

        private void ContinuePolygon(object sender, MouseEventArgs e)
        {

            this.pictureBox.MouseClick -= ContinuePolygon;
            if (e.Button == MouseButtons.Left)
            {
                this.pictureBox.MouseMove -= this.LineService.LineTracker.Update;
                CurrentPolygon.AppendLine(this.LineService.LineTracker.LastLine);
                this.LineService.StopTracking();
                pictureBox.Invalidate();
                this.LineService.BeginTracking(e.X, e.Y);

                this.pictureBox.MouseClick += ContinuePolygon;

            }
            else if (e.Button == MouseButtons.Right)
            {
                this.pictureBox.MouseMove -= this.LineService.LineTracker.Update;

                var lastLine = this.LineService.LineTracker.LastLine;

                this.LineService.AbortTracking();

                CurrentPolygon.CompletePolygon(
                    this.LineService.CreateLine(CurrentPolygon.Vertices[0].X,
                    CurrentPolygon.Vertices[0].Y,
                    CurrentPolygon.Vertices[CurrentPolygon.Vertices.Count - 1].X,
                    CurrentPolygon.Vertices[CurrentPolygon.Vertices.Count - 1].Y));

                this.MemoryService.SavePolygon(CurrentPolygon);

                this.Mode = EditMode.Default;

            }
        }

        public void ExitAnyMode()
        {
            switch (this.Mode)
            {
                case EditMode.AddPolygon:
                    this.pictureBox.MouseClick -= BeginPolygon;
                    this.pictureBox.MouseClick -= ContinuePolygon;
                    break;
                case EditMode.FilterPolygon:
                case EditMode.DeletePolygon:
                    this.MemoryService.ExitVertexPickersMode();
                    break;
                case EditMode.Brush:
                    this.Brush.StopBrushTracking();
                    break;
                
            }
            this.Mode = EditMode.Default;
        }

        private void addPolygonBtn_Click(object sender, EventArgs e)
        {
            this.ExitAnyMode();
            this.Mode = EditMode.AddPolygon;
            this.pictureBox.MouseClick += BeginPolygon;
        }

        private void deletePolygonBtn_Click(object sender, EventArgs e)
        {
            this.ExitAnyMode();
            this.Mode = EditMode.DeletePolygon;
            this.MemoryService.EnterDeletePolygonMode();
        }

        public void RedrawPolygons()
        {
            using (Graphics g = Graphics.FromImage(this.Bmp.Bitmap))
            {
                g.DrawImage(this.PolygonLessBmp.Bitmap, 0, 0, this.PolygonLessBmp.Bitmap.Width, this.PolygonLessBmp.Bitmap.Height);
            }
            foreach (var polygon in this.MemoryService.Polygons)
            {
                if (polygon.FilterHandler != null)
                {
                    this.MemoryService.ApplyFilter(polygon);
                }
            }
            this.RedrawPolygonsLines();
        }

        public void RedrawPolygonsLines()
        {
            foreach (var polygon in this.MemoryService.Polygons)
            {
                foreach (var line in polygon.Edges)
                {
                    this.LineService.CreateLine(line);
                }
            }
        }

        private void filterPolygonBtn_Click(object sender, EventArgs e)
        {
            this.ExitAnyMode();
            this.Mode = EditMode.FilterPolygon;
            this.MemoryService.EnterFiltererPolygonMode();
        }

        private void filtersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = this.filtersListBox.SelectedIndex;
            for (int i = 0; i < this.filtersListBox.Items.Count; i++)
            {
                this.filtersListBox.SetItemChecked(i, false);
            }
            this.filtersListBox.SetItemChecked(index, true);

            this.SelectedFilter = (FilterType)index;

            this.DisplayFilterOptions();

            this.filtersChanged = true;

        }


        private void HideFilterOptions()
        {
            this.brightnessChangeTrackBar.Visible = false;
            this.contrastTrackBar.Visible = false;
            this.gammaLabel.Visible = false;
            this.gammaBox.Visible = false;
            this.ownFunctionPanel.Visible = false;
        }

        private void DisplayFilterOptions()
        {
            this.HideFilterOptions();
            switch (this.SelectedFilter)
            {
                case FilterType.Identity:
                case FilterType.Negative:
                    break;
                case FilterType.BrightnessChange:
                    this.brightnessChangeTrackBar.Value = 0;
                    this.brightnessChangeValue = 0;
                    this.brightnessChangeTrackBar.Visible = true;
                    break;
                case FilterType.GammaCorrection:
                    this.gammaLabel.Visible = true;
                    this.gammaBox.Text = "1.00";
                    this.gammaBox.Visible = true;
                    this.gammaValue = 1;
                    break;
                case FilterType.Contrast:
                    this.contrastTrackBar.Value = 0;
                    this.contrastValue = 0;
                    this.contrastTrackBar.Visible = true;
                    break;
                case FilterType.OwnFunction:
                    this.InitOwnFunctionChart();
                    this.ownFunctionPanel.Visible = true;
                    break;
            }

        }

        private void brightnessChangeTrackBar_Scroll(object sender, EventArgs e)
        {
            this.brightnessChangeValue = this.brightnessChangeTrackBar.Value;
            this.filtersChanged = true;
        }

        private void contrastTrackBar_Scroll(object sender, EventArgs e)
        {
            this.contrastValue = this.contrastTrackBar.Value;
            this.filtersChanged = true;
        }

        private void gammaBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (this.Text.IndexOf(".") >= 0 || this.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
            this.filtersChanged = true;
        }

        public void validateGammaBox(object sender, CancelEventArgs e)
        {
            float value;
            if (!float.TryParse(gammaBox.Text, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out value) || value <= 0) 
            { 
                gammaBox.Text = "1.00";
                this.gammaValue = 1;
            }
            else
            {
                this.gammaValue = value;
            }
        }

        private void brushSizeTrackBar_Scroll(object sender, EventArgs e)
        {
            this.Brush.brushSize = this.brushSizeTrackBar.Value;
            this.filtersChanged = true;
        }

        private void brushBtn_Click(object sender, EventArgs e)
        {
            this.ExitAnyMode();
            this.Mode = EditMode.Brush;
            this.Brush.StartBrushTracking();
        }

        public DirectBitmap GenerateFilteredBmp()
        {
            var filteredBmp = new DirectBitmap(this.Bmp.Width, this.Bmp.Height);

            var picturePoly = new Polygon(0, 0);
            var horizontalUpperLine = new Line();
            horizontalUpperLine.AppendPoint(new Point(0, 0));
            horizontalUpperLine.AppendPoint(new Point(this.Bmp.Width - 1, 0));
            var verticalRightLine = new Line();
            verticalRightLine.AppendPoint(new Point(this.Bmp.Width - 1, 0));
            verticalRightLine.AppendPoint(new Point(this.Bmp.Width - 1, this.Bmp.Height - 1));
            var horizontalLowerLine = new Line();
            horizontalLowerLine.AppendPoint(new Point(this.Bmp.Width - 1, this.Bmp.Height - 1));
            horizontalLowerLine.AppendPoint(new Point(0, this.Bmp.Height - 1));
            var verticalLeftLine = new Line();
            verticalLeftLine.AppendPoint(new Point(0, this.Bmp.Height - 1));
            verticalLeftLine.AppendPoint(new Point(0, 0));

            picturePoly.AppendLine(horizontalUpperLine);
            picturePoly.AppendLine(verticalRightLine);
            picturePoly.AppendLine(horizontalLowerLine);
            picturePoly.CompletePolygon(verticalLeftLine);

            var edgeTable = this.FillingService.InitTables(picturePoly);
            
            this.LineService.Bmp = filteredBmp;
            this.FillingService.RunFilling(edgeTable, this.MemoryService.GetFilter());
            this.LineService.Bmp = this.Bmp;

         
            return filteredBmp;
        }

        public void InitOwnFunctionChart()
        {
            OwnFunctionPoints.Clear();
            OwnFunctionPoints.Add(new Point(0, 0));
            OwnFunctionPoints.Add(new Point(255, 255));
            this.RenderOwnFunction();
        }

        public void AddPointToOwnFunctionChart(int x, int y)
        {
            var pointSameXIdx = this.OwnFunctionPoints.FindIndex(p => p.X == x);
            if (pointSameXIdx >= 0)
            {
                this.OwnFunctionPoints[pointSameXIdx] = new Point(x, y);
            }
            else
            {
                this.OwnFunctionPoints.Add(new Point(x, y));
                this.OwnFunctionPoints = this.OwnFunctionPoints.OrderBy(p => p.X).ToList();
            }
        }

        public void RenderOwnFunction()
        {
            var charPoints = this.ownFunctionChart.Series["OwnFunctionData"].Points;
            charPoints.Clear();
            for (int i = 0; i < OwnFunctionPoints.Count - 1; i++)
            {
                float a = (OwnFunctionPoints[i + 1].Y - OwnFunctionPoints[i].Y) /
                    (float)(OwnFunctionPoints[i + 1].X - OwnFunctionPoints[i].X);
                for (int j = OwnFunctionPoints[i].X; j < OwnFunctionPoints[i + 1].X; j++)
                {
                    charPoints.AddXY(j, OwnFunctionPoints[i].Y + a * (j - OwnFunctionPoints[i].X));
                    // this math min max are done in case of rounding error cause overflow to -1 or 256
                    this.mappedPoints[j] = Math.Max(Math.Min(
                        Convert.ToInt32(OwnFunctionPoints[i].Y + a * (j - OwnFunctionPoints[i].X)), 255), 0);
                }
            }
            charPoints.AddXY(OwnFunctionPoints[OwnFunctionPoints.Count - 1].X, OwnFunctionPoints[OwnFunctionPoints.Count - 1].Y);
            this.mappedPoints[OwnFunctionPoints[OwnFunctionPoints.Count - 1].X] = Math.Max(Math.Min(
                        Convert.ToInt32(OwnFunctionPoints[OwnFunctionPoints.Count - 1].Y), 255), 0);
        }

        private void addPointBtn_Click(object sender, EventArgs e)
        {
            this.AddPointToOwnFunctionChart(Convert.ToInt32(this.xNumeric.Value), Convert.ToInt32(this.yNumeric.Value));
            this.RenderOwnFunction();
            this.filtersChanged = true;
        }
    }
}
