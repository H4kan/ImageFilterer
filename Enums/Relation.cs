using System;
using System.Collections.Generic;
using System.Text;

namespace ImageFiltererV2.Enums
{
    public enum Relation
    {
        None = 0,
        ExactLength,
        ExactRadius,
        SameLength,
        Tangency,
        Perpendicularity,
        DeleteRelation
    }
}
