﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageFiltererV2
{
    public class FillingService
    {
        private LineService lineService;
        private Form1 form;


        public FillingService(LineService lineService, Form1 form)
        {
            this.lineService = lineService;
            this.form = form;
        }

        public List<EdgeHandler> InitTables(Polygon polygon, Line[] extraEdges = null)
        {
            var edgeTable = new List<EdgeHandler>();
            edgeTable.Clear();

            foreach (var line in polygon.Edges.Where(e => e != null))
            {
                edgeTable.Add(new EdgeHandler(line));
            }
            if (extraEdges != null)
                foreach (var line in extraEdges)
                {
                    edgeTable.Add(new EdgeHandler(line));
                }
            edgeTable = edgeTable.OrderBy(e => e.yMin).ToList();

            return edgeTable;
        }

        public void RunFilling(List<EdgeHandler> edgeTable, IFilterHandler filterHandler)
        {
            var activeEdgeTable = new List<EdgeHandler>();
            int eInd = 0;
            int y = edgeTable[eInd].yMin;
            while (eInd < edgeTable.Count)
            {
                if (y == edgeTable[eInd].yMin)
                {
                    while (eInd < edgeTable.Count && y == edgeTable[eInd].yMin)
                    {
                        activeEdgeTable.Add(edgeTable[eInd]);
                        eInd++;
                    }

                }

                activeEdgeTable = activeEdgeTable.FindAll(e => e.yMax > y);
                activeEdgeTable = activeEdgeTable.OrderBy(e => e.x).ThenBy(e => e.dX).ToList();

                for (int i = 0; i < activeEdgeTable.Count - 1; i += 2)
                {

                    this.lineService.FastHorizontalLine(
                        activeEdgeTable[i].x,
                        activeEdgeTable[i + 1].x, y,
                        filterHandler);

                }

                y++;
                activeEdgeTable.ForEach(e => { e.x = e.basicX + (y - e.yMin) * e.dX / e.dY; });

            }
            while (activeEdgeTable.Count > 0)
            {
                for (int i = 0; i < activeEdgeTable.Count - 1; i += 2)
                {

                    this.lineService.FastHorizontalLine(
                        activeEdgeTable[i].x,
                        activeEdgeTable[i + 1].x, y,
                        filterHandler);
                }

                activeEdgeTable = activeEdgeTable.FindAll(e => e.yMax > y);
                activeEdgeTable = activeEdgeTable.OrderBy(e => e.x).ThenBy(e => e.dX).ToList();

                y++;
                activeEdgeTable.ForEach(e => { e.x = e.basicX + (y - e.yMin) * e.dX / e.dY; });

            }
        }
        public (int, int) GetBmpOffset(List<EdgeHandler> edgeTable)
        {
            var yMin = edgeTable[0].yMin;
            var xMin = edgeTable.Min(e => e.xMin);
            return (xMin, yMin);
        }

    }
}
