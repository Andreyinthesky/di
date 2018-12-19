using System.Collections.Generic;
using System.Linq;
using TagsCloud.Core.WordFilters;

namespace TagsCloud.Core
{
    public class FrequencyWordsAnalyzer : IFrequencyWordsAnalyzer
    {
        private readonly IWordFilter[] wordFilters;

        public FrequencyWordsAnalyzer(IWordFilter[] wordFilters)
        {
            this.wordFilters = wordFilters;
        }

        public IEnumerable<KeyValuePair<string, int>> Analyze(IEnumerable<string> words)
        {
            return wordFilters
                .Aggregate(words, (cur, filter) => cur.Where(filter.Filter))
                .GroupBy(word => word)
                .ToDictionary(group => group.Key, group => group.Count());
        }
    }
}