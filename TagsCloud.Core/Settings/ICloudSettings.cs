namespace TagsCloud.Core.Settings
{
    public interface ICloudSettings
    {
        string InputTextFilePath { get; set; }
        string InputStopWordsFilePath { get; set; }
        int WordsCount { get; set; }
        ImageSettings ImageSettings{ get; set; }
        FontSettings FontSettings{ get; set; }
    }
}