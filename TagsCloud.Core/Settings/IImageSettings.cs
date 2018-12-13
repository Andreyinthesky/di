using System.Drawing;

namespace TagsCloud.Core.Settings
{
    public interface IImageSettings
    {
        int Width { get; set; }
        int Height { get; set; }
        Color ForegroundColor { get; set; }
        Color BackgroundColor { get; set; }
    }
}