namespace TagsCloud.Core.WordConverters
{
    public class ToLowerConverter : IWordConverter
    {
        public string ConvertWord(string word)
        {
            return word.ToLower();
        }
    }
}