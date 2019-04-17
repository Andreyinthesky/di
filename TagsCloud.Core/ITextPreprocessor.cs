using System.Collections.Generic;

namespace TagsCloud.Core
{
    public interface ITextPreprocessor
    {
        IEnumerable<string> Process(string text);
    }
}