using System.Collections.Generic;
using System.Linq;
using TagsCloud.Core.WordFilters;

namespace TagsCloud.Core
{
    public class FrequencyWordsAnalyzer : IFrequencyWordsAnalyzer
    {
        private ITextSplitter textSplitter;
        private IWordsConverter[] converters;

        public FrequencyWordsAnalyzer(ITextSplitter textSplitter, IWordsConverter[] converters)
        {
            this.textSplitter = textSplitter;
            this.converters = converters;
        }

        public IEnumerable<KeyValuePair<string, int>> Analyze(string text, string stopWordsText)
        {
            var stopWords = new HashSet<string>(ConvertWords(textSplitter.SplitWords(stopWordsText)));
            var words = ConvertWords(textSplitter.SplitWords(text));

            var res = words
                .GroupBy(word => word)
                .ToDictionary(group => group.Key, group => group.Count())
                .Where(kvp => !stopWords.Contains(kvp.Key));

            return res;
        }

        private IEnumerable<string> ConvertWords(IEnumerable<string> words)
        {
            foreach (var converter in converters)
            {
                words = converter.ConvertWords(words);
            }

            return words;
        }
    }
}