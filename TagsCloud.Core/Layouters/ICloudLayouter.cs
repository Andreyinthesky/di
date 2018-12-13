using System.Collections.Generic;
using System.Drawing;

namespace TagsCloud.Core.Layouters
{
    public interface ICloudLayouter
    {
        Rectangle PutNextRectangle(Size rectangleSize);
        IEnumerable<Rectangle> GetPlacedRectangles();
        Point Center { get; }
        int CloudWidth { get; }
        int CloudHeight { get; }
    }
}
