using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace TagsCloud.Core
{
    public class FrequencyWordsAnalyzer : IFrequencyWordsAnalyzer
    {
        private readonly HashSet<string> stopWords = new HashSet<string>()
        {
            "но",
            "бы",
            "если",
            "то",
            "а",
            "и",
            "не",
            "да",
            "нет",
            "к",
            "из",
            "за",
            "из-за",
            "я",
            "мы",
            "ты",
            "вы",
            "он",
            "она",
            "оно",
            "они",
        };

        public FrequencyWordsAnalyzer()
        {
            
        }

        public IOrderedEnumerable<KeyValuePair<string, int>> Analyze(IEnumerable<string> words)
        {
            return words
                .Select(w => w.ToLower())
                .Where(word => word != "")
                .GroupBy(word => word)
                .ToDictionary(group => group.Key, group => group.Count())
                .Where(kvp => !stopWords.Contains(kvp.Key))
                .OrderByDescending(kvp => kvp.Value);
        }
    }
}