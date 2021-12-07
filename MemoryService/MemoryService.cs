
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using ImageFiltererV2.Enums;

namespace ImageFiltererV2
{
    public class MemoryService
    {
        public List<Polygon> Polygons;

        
        public Polygon SelectedPolygon { get; set; }

        public List<VertexPicker> VertexPickers = new List<VertexPicker>();


        public PictureBox pictureBox;
        public Form1 form;
        public LineService LineService { get; set; }
        public FillingService FillingService { get; set; }

        public MemoryService(
            PictureBox pictureBox,
            LineService lineService,
            FillingService fillingService,
            Form1 form)
        {
            
            Polygons = new List<Polygon>();

            this.pictureBox = pictureBox;
            this.LineService = lineService;
            this.FillingService = fillingService;
            this.form = form;
        }

        
        public void SavePolygon(Polygon polygon)
        {
            this.Polygons.Add(polygon);
        }

        public void ExitVertexPickersMode()
        {
            foreach (var vertexPicker in this.VertexPickers)
            {
                this.pictureBox.Controls.Remove(vertexPicker);
            }
            VertexPickers.Clear();
        }

        public void EnterDeletePolygonMode()
        {
            int i = 0;
            foreach(var polygon in this.Polygons)
            {
                var deleter = new Deleter(polygon.Vertices[0], i++, this);
                this.VertexPickers.Add(deleter);
                this.pictureBox.Controls.Add(deleter);
            }
        }

        public void EnterFiltererPolygonMode()
        {
            int i = 0;
            foreach (var polygon in this.Polygons)
            {
                var filterer = new Filterer(polygon.Vertices[0], i++, this);
                this.VertexPickers.Add(filterer);
                this.pictureBox.Controls.Add(filterer);
            }
        }

        public void ApplyFilter(Polygon polygon)
        {
         
            var edgeTable = this.FillingService.InitTables(polygon);
            this.FillingService.RunFilling(edgeTable, polygon.FilterHandler);
            this.form.RedrawPolygonsLines();
            
        }

        public IFilterHandler GetFilter()
        {
            switch (this.form.SelectedFilter)
            {
                case FilterType.Identity:
                    return new Identity();
                case FilterType.Negative:
                    return new Negative();
                case FilterType.BrightnessChange:
                    return new BrightnessChange(this.form.brightnessChangeValue);
                case FilterType.GammaCorrection:
                    // we need to trigger validation manually before filter applying
                    this.form.validateGammaBox(null, null);
                    return new GammaCorrection(this.form.gammaValue);
                case FilterType.Contrast:
                    return new Contrast(this.form.contrastValue);
                case FilterType.OwnFunction:
                    return new OwnFunction(this.form.mappedPoints);
            }

            return new Identity();
        }
    }
}
