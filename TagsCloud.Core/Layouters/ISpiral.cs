using System.Collections.Generic;
using System.Drawing;

namespace TagsCloud.Core.Layouters
{
    public interface ISpiral
    {
        IEnumerable<Point> GetSpiralPoints();
    }
}