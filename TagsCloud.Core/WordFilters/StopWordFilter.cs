using System.Collections.Generic;
using System.Linq;

namespace TagsCloud.Core.WordFilters
{
    public class StopWordFilter : IWordFilter
    {
        private readonly IProvider stopWordsProvider;
        private HashSet<string> stopWords;

        public StopWordFilter(IProvider stopWordsProvider)
        {
            this.stopWordsProvider = stopWordsProvider;
        }

        public bool Filter(string word)
        {
            if (stopWords == null)
            {
                stopWords = GetStopWords();
            }

            return !stopWords.Contains(word);
        }

        private HashSet<string> GetStopWords()
        {
            return stopWordsProvider.Get().ToHashSet();
        }
    }
}