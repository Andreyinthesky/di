using System;
using System.Linq;
using NHunspell;

namespace TagsCloud.Core.WordConverters
{
    public class BasicFormWordConverter : IWordConverter, IDisposable
    {
        private readonly Hunspell hunspell = new Hunspell("RU_Dict/ru_RU.aff", "RU_Dict/ru_RU.dic");

        public string ConvertWord(string word)
        {
            return hunspell.Stem(word).Any() ? hunspell.Stem(word).First() : word;
        }

        public void Dispose()
        {
            hunspell?.Dispose();
        }
    }
}