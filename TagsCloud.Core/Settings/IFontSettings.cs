using System.Drawing;

namespace TagsCloud.Core.Settings
{
    public interface IFontSettings
    {
        string TypeFace { get; set; }
        FontStyle FontStyle { get; set; }
        int MinFontSizeInPoints { get; set; } 
        int MaxFontSizeInPoints { get; set; }
    }
}