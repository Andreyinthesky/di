using System.Drawing;

namespace TagsCloud.Core.Settings
{
    public class FontSettings : IFontSettings
    {
        public FontFamily FontFamily { get; set; } = new FontFamily("Segoe UI");
        public FontStyle FontStyle { get; set; } = FontStyle.Regular;
        public int MinFontSizeInPoints { get; set; } = 10;
        public int MaxFontSizeInPoints { get; set; } = 72;

        public FontSettings()
        {
        }

        public FontSettings(FontFamily fontFamily, FontStyle fontStyle = FontStyle.Regular)
        {
            FontFamily = fontFamily;
        }

        public FontSettings(FontFamily fontFamily, int minFontSizeInPoints, int maxFontSizeInPoints, FontStyle fontStyle = FontStyle.Regular)
        {
            FontFamily = fontFamily;
            MinFontSizeInPoints = minFontSizeInPoints;
            MaxFontSizeInPoints = maxFontSizeInPoints;
        }
    }
}