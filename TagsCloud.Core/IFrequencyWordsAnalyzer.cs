using System.Collections.Generic;

namespace TagsCloud.Core
{
    public interface IFrequencyWordsAnalyzer
    {
        IEnumerable<KeyValuePair<string, int>> Analyze(string text, string stopWordsText);
    }
}