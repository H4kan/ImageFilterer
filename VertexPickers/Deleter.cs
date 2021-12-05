using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFiltererV2
{
    public class Deleter : VertexPicker
    {
        private MemoryService MemoryService { get; set; }

        public Deleter(Point Origin, int index, MemoryService memoryService): base(Origin, index)
        {
            this.MemoryService = memoryService;
            this.MouseClick += DeletePolygon;
        }

        public void DeletePolygon(object sender, EventArgs e)
        {
            
            this.MemoryService.Polygons.RemoveAt(this.Index);
            this.MemoryService.form.RedrawPolygons();
            this.MemoryService.form.GetColorCountFromImage();
            this.MemoryService.form.InitCharts();
            this.MemoryService.ExitVertexPickersMode();
            this.MemoryService.pictureBox.Invalidate();
        }

    }
}
