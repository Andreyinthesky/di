using System.Drawing;

namespace TagsCloud.Core.Settings
{
    public class ImageSettings : IImageSettings
    {
        public int Width { get; set; } = 400;
        public int Height { get; set; } = 400;
        public Color ForegroundColor { get; set; } = Color.Black;
        public Color BackgroundColor { get; set; } = Color.White;

        public ImageSettings()
        {

        }

        //public ImageSettings(int width, int height)
        //{
        //    Width = width;
        //    Height = height;
        //}

        //public ImageSettings(int width, int height, Color foregroundColor, Color backgroundColor)
        //{
        //    Width = width;
        //    Height = height;
        //    ForegroundColor = foregroundColor;
        //    BackgroundColor = backgroundColor;
        //}
    }
}