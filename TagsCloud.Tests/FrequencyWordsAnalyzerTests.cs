using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TagsCloud.Core;

namespace TagsCloud.Tests
{
    [TestFixture]
    public class FrequencyWordsAnalyzerTests
    {
        private FrequencyWordsAnalyzer analyzer;

        [SetUp]
        public void SetUp()
        {
            analyzer = new FrequencyWordsAnalyzer();
        }

        [Test]
        public void Analyze_ReturnCorrectWordsFrequenciesWithOrderByDescending()
        {
            var words = new List<string>()
                {"он", "не", "рассказал", "мне", "всей", "правды", "эх", "правда", "не", "правда"};

            var frequencyByWord = analyzer.Analyze(words);

            frequencyByWord.Should()
                .BeEquivalentTo
                (
                    new Dictionary<string, int>()
                    {
                        ["рассказал"] = 1,
                        ["эх"] = 1,
                        ["правда"] = 2,
                        ["правды"] = 1,
                        ["всей"] = 1,
                        ["мне"] = 1
                    }
                ).And
                .BeInDescendingOrder(kvp => kvp.Value);

        }

        [Test]
        public void Analyze_WhenWordsListIsEmpty_ReturnEmptyDict()
        {
            var words = new List<string>();

            analyzer.Analyze(words)
                .Should()
                .BeEquivalentTo
                (
                    new Dictionary<string, int>()
                );
        }
    }
}