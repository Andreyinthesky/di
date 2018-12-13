using System.Drawing;

namespace TagsCloud.Core.Settings
{
    public interface IFontSettings
    {
        FontFamily FontFamily { get; set; }
        FontStyle FontStyle { get; set; }
        int MinFontSizeInPoints { get; set; } 
        int MaxFontSizeInPoints { get; set; }
    }
}