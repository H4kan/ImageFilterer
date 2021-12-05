using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFiltererV2
{
    public class Filterer : VertexPicker
    {
        private MemoryService MemoryService { get; set; }

        public Filterer(Point Origin, int index, MemoryService memoryService) : base(Origin, index)
        {
            this.MemoryService = memoryService;
            this.MouseClick += FilterPolygon;
        }

        public void FilterPolygon(object sender, EventArgs e)
        {
            this.MemoryService.Polygons[Index].FilterHandler = this.MemoryService.GetFilter();
            this.MemoryService.ApplyFilter(this.MemoryService.Polygons[Index]);
            this.MemoryService.ExitVertexPickersMode();
            this.MemoryService.pictureBox.Invalidate();
            this.MemoryService.form.GetColorCountFromImage();
            this.MemoryService.form.InitCharts();
        }

    }
}
