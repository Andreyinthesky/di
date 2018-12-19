using System.Drawing;

namespace TagsCloud.Core.Settings
{
    public class FontSettings : IFontSettings
    {
        public string TypeFace { get; set; } = "Segoe UI";
        public FontStyle FontStyle { get; set; } = FontStyle.Regular;
        public int MinFontSizeInPoints { get; set; } = 14;
        public int MaxFontSizeInPoints { get; set; } = 72;
    }
}