using System.Collections.Generic;

namespace TagsCloud.Core.WordFilters
{
    public interface ITextSplitter
    {
        IEnumerable<string> SplitWords(string text);
    }
}