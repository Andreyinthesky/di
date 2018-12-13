using System.Collections.Generic;
using System.Linq;
using TagsCloud.Core.Extensions;

namespace TagsCloud.Core.WordFilters
{
    public class TextSplitter : ITextSplitter
    {
        public IEnumerable<string> SplitWords(string text)
        {
            return text
                .RemoveSpecialSymbols()
                .Split(',', ' ')
                .Where(p => p.Any());
        }
    }
}