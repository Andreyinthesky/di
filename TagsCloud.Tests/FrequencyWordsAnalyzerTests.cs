using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TagsCloud.Core;
using TagsCloud.Core.WordFilters;

namespace TagsCloud.Tests
{
    [TestFixture]
    public class FrequencyWordsAnalyzerTests
    {
        private IFrequencyWordsAnalyzer analyzer;

        [SetUp]
        public void SetUp()
        {
            analyzer = new FrequencyWordsAnalyzer(new IWordFilter[0]);
        }

        [Test]
        public void Analyze_ReturnCorrectWordsFrequencies()
        {
            var words = new List<string>()
                {"он", "не", "рассказал", "всей", "эх", "правда", "не", "правда", "эх", "эх"};
            var expected = new Dictionary<string, int>()
            {
                ["рассказал"] = 1,
                ["он"] = 1,
                ["эх"] = 3,
                ["не"] = 2,
                ["правда"] = 2,
                ["всей"] = 1
            };

            analyzer.Analyze(words).Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Analyze_WhenWordsListIsEmpty_ReturnEmptyDict()
        {
            analyzer.Analyze(new List<string>())
                .Should()
                .BeEquivalentTo
                (
                    new Dictionary<string, int>()
                );
        }
    }
}