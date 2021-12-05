using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFiltererV2.Enums
{
    // this must be kept in same order as displayed in view
    public enum FilterType
    {
        Identity = 0,
        Negative,
        BrightnessChange,
        GammaCorrection,
        Contrast,
        OwnFunction
    }
}
