using System.Drawing;

namespace TagsCloud.Core.Settings
{
    public class ImageSettings : IImageSettings
    {
        public int Width { get; set; } = 1000;
        public int Height { get; set; } = 1000;
        public Color ForegroundColor { get; set; } = Color.Black;
        public Color BackgroundColor { get; set; } = Color.White;
    }
}