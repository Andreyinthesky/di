using System.Collections.Generic;
using System.Linq;
using TagsCloud.Core.Extensions;

namespace TagsCloud.Core.WordFilters
{
    public class TextSplitter : IMapper<string, IEnumerable<string>>
    {
        public IEnumerable<string> Map(string text)
        {
            return text
                .RemoveSpecialSymbols()
                .Split(',', ' ')
                .Where(p => p.Any());
        }
    }
}