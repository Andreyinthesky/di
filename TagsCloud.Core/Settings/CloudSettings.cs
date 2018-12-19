namespace TagsCloud.Core.Settings
{
    public class CloudSettings
    {
        public string InputTextFilePath { get; set; } = "Samples/sample_words.txt";
        public string InputStopWordsFilePath { get; set; } = "Samples/sample_stopwords.txt";
        public int WordsCount { get; set; } = 50;
        public ImageSettings ImageSettings { get; set; } = new ImageSettings();
        public FontSettings FontSettings  { get; set; } = new FontSettings();
    }
}