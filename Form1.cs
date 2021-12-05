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

        public Form1()
        {
            InitializeComponent();

            this.Bmp = new DirectBitmap(pictureBox.Width, pictureBox.Height);
            this.PolygonLessBmp = null;
            this.OriginalBmp = null;
            this.pictureBox.Image = this.Bmp.Bitmap;

            this.LineService = new LineService(this.Bmp, pictureBox);
            this.FillingService = new FillingService(this.LineService, this);
            this.MemoryService = new MemoryService(pictureBox, LineService, FillingService, this);

            this.filtersListBox.SetItemChecked(0, true);
            this.SelectedFilter = FilterType.Identity;

            this.Brush = new Brush(this.pictureBox, this);
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

                using (Graphics g = Graphics.FromImage(this.Bmp.Bitmap))
                {
                    g.DrawImage(image, 0, 0, image.Width, image.Height);
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
        }

        private void HideFilterOptions()
        {
            this.brightnessChangeTrackBar.Visible = false;
            this.contrastTrackBar.Visible = false;
            this.gammaLabel.Visible = false;
            this.gammaBox.Visible = false;
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
                    break;
            }

        }

        private void brightnessChangeTrackBar_Scroll(object sender, EventArgs e)
        {
            this.brightnessChangeValue = this.brightnessChangeTrackBar.Value;
        }

        private void contrastTrackBar_Scroll(object sender, EventArgs e)
        {
            this.contrastValue = this.contrastTrackBar.Value;
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

        }

        public void gammaBox_Validating(object sender, CancelEventArgs e)
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
            this.ExitAnyMode();
            this.Mode = EditMode.Brush;
            this.Brush.StartBrushTracking();
        }

        private void brushSizeTrackBar_Scroll(object sender, EventArgs e)
        {
            this.Brush.brushSize = this.brushSizeTrackBar.Value;
        }

        public DirectBitmap GenerateFilteredBmp()
        {
            var filteredBmp = new DirectBitmap(this.Bmp.Width, this.Bmp.Height);

            var picturePoly = new Polygon(0, 0);
            var horizontalUpperLine = new Line();
            horizontalUpperLine.AppendPoint(new Point(0, 0));
            horizontalUpperLine.AppendPoint(new Point(0, this.Bmp.Width));
            var verticalRightLine = new Line();
            verticalRightLine.AppendPoint(new Point(0, 0));
            verticalRightLine.AppendPoint(new Point(0, this.Bmp.Width));
            var horizontalLowerLine = new Line();
            horizontalLowerLine.AppendPoint(new Point(0, 0));
            horizontalLowerLine.AppendPoint(new Point(0, this.Bmp.Width));
            var verticalLeftLine = new Line();
            horizontalUpperLine.AppendPoint(new Point(0, 0));
            horizontalUpperLine.AppendPoint(new Point(0, this.Bmp.Width));

            this.FillingService.InitTables()

            return filteredBmp;
        }
    }
}
