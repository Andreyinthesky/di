using System.Collections.Generic;

namespace TagsCloud.Core
{
    public interface IFrequencyWordsAnalyzer
    {
        Dictionary<string, int> Analyze(IEnumerable<string> words);
    }
}