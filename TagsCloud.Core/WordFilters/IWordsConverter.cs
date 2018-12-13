using System.Collections.Generic;

namespace TagsCloud.Core.WordFilters
{
    public interface IWordsConverter
    {
        IEnumerable<string> ConvertWords(IEnumerable<string> words);
    }
}