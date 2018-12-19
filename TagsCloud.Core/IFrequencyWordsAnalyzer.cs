using System.Collections.Generic;

namespace TagsCloud.Core
{
    public interface IFrequencyWordsAnalyzer
    {
        IEnumerable<KeyValuePair<string, int>> Analyze(IEnumerable<string> words);
    }
}