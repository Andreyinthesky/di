using System.Collections.Generic;
using System.Linq;
using TagsCloud.Core.WordConverters;
using TagsCloud.Core.WordFilters;

namespace TagsCloud.Core
{
    public class TextPreprocessor : ITextPreprocessor
    {
        private readonly IWordConverter[] converters;
        private readonly IMapper<string, IEnumerable<string>> textSplitter;

        public TextPreprocessor(IWordConverter[] converters, IMapper<string, IEnumerable<string>> textSplitter)
        {
            this.converters = converters;
            this.textSplitter = textSplitter;
        }

        public IEnumerable<string> Process(string text)
        {
            var words = textSplitter.Map(text);
            return converters
                .Aggregate(words, (convertedWords, converter) => convertedWords.Select(converter.ConvertWord));
        }
    }
}