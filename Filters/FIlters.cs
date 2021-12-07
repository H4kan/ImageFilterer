using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFiltererV2
{
    public interface IFilterHandler
    {
        Color EvaluateFilter(Color color);
    }

    public class BrightnessChange : IFilterHandler
    {
        private int val;

        public BrightnessChange(int val)
        {
            this.val = val;
        }

        public Color EvaluateFilter(Color color)
        {
            return Color.FromArgb(
                Math.Min(Math.Max((int)color.R + val, 0), 255),
                Math.Min(Math.Max((int)color.G + val, 0), 255),
                Math.Min(Math.Max((int)color.B + val, 0), 255));
        }
    }

    public class Negative : IFilterHandler
    {
        public Color EvaluateFilter(Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }
    }

    public class Identity : IFilterHandler
    {
        public Color EvaluateFilter(Color color)
        {
            return color;
        }
    }

    public class Contrast : IFilterHandler
    {
        private double factor;

        public Contrast(int val)
        {
            this.factor = 259 * (255 + val) / (double)(255 * (259 - val));
        }

        // contrast algorithm from here
        // https://ie.nitk.ac.in/blog/2020/01/19/algorithms-for-adjusting-brightness-and-contrast-of-an-image/
        public Color EvaluateFilter(Color color)
        {
            return Color.FromArgb(
                Math.Min(Math.Max(Convert.ToInt32((factor * (color.R - 128) + 128)), 0), 255),
                Math.Min(Math.Max(Convert.ToInt32((factor * (color.G - 128) + 128)), 0), 255),
                Math.Min(Math.Max(Convert.ToInt32((factor * (color.B - 128) + 128)), 0), 255));
        }
    }

    public class GammaCorrection : IFilterHandler
    {
        private float gammaCorrection;

        public GammaCorrection(float gamma)
        {
            this.gammaCorrection = 1 / gamma;
        }

        // gamma correction algorithm from here
        // https://www.dfstudios.co.uk/articles/programming/image-programming-algorithms/image-processing-algorithms-part-6-gamma-correction/
        public Color EvaluateFilter(Color color)
        {
            return Color.FromArgb(
                Math.Min(Math.Max(Convert.ToInt32(255 * Math.Pow(color.R / (double)255, gammaCorrection)), 0), 255),
                Math.Min(Math.Max(Convert.ToInt32(255 * Math.Pow(color.G / (double)255, gammaCorrection)), 0), 255),
                Math.Min(Math.Max(Convert.ToInt32(255 * Math.Pow(color.B / (double)255, gammaCorrection)), 0), 255));
        }
    }

    public class OwnFunction : IFilterHandler
    {
        private int[] points;
        public OwnFunction(int [] points)
        {
            this.points = points;
        }

        // gamma correction algorithm from here
        // https://www.dfstudios.co.uk/articles/programming/image-programming-algorithms/image-processing-algorithms-part-6-gamma-correction/
        public Color EvaluateFilter(Color color)
        {
            return Color.FromArgb(points[color.R], points[color.G], points[color.B]);
        }
    }
}
