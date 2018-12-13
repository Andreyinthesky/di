using System.Collections.Generic;
using System.Linq;
using NHunspell;

namespace TagsCloud.Core.WordFilters
{
    public class BasicFormWordConverter : IWordsConverter
    {
        public IEnumerable<string> ConvertWords(IEnumerable<string> words)
        {
            IEnumerable<string> wordsInBasicForm;
            using (var hunspell = new Hunspell("RU_Dict/ru_RU.aff", "RU_Dict/ru_RU.dic"))
            {
                wordsInBasicForm = words
                    .Select(word => hunspell.Stem(word).Any() ? hunspell.Stem(word).First() : word).ToList();
            }
            return wordsInBasicForm;
        }
    }
}