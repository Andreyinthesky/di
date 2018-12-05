using System.Collections.Generic;
using System.Drawing;

namespace TagsCloud.Core
{
    public class TagsCloud
    {
        public IEnumerable<Tag> Tags { get; }
        public int Width { get; }
        public int Height { get; }
        public Point Center { get; }

        public TagsCloud(IEnumerable<Tag> tags, int width, int height, Point center)
        {
            Tags = tags;
            Width = width;
            Height = height;
            Center = center;
        }
    }
}