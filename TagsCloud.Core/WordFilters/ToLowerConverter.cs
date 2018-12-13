using System.Collections.Generic;
using System.Linq;

namespace TagsCloud.Core.WordFilters
{
    public class ToLowerConverter : IWordsConverter
    {
        public IEnumerable<string> ConvertWords(IEnumerable<string> words)
        {
            return words
                .Select(w => w.ToLower());
        }
    }
}