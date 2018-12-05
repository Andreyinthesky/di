using System.Collections.Generic;
using System.Linq;

namespace TagsCloud.Core
{
    public interface IFrequencyWordsAnalyzer
    {
        IOrderedEnumerable<KeyValuePair<string, int>> Analyze(IEnumerable<string> words);
    }
}