using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using TagsCloud.Core;

namespace TagsCloud.Tests
{
    [TestFixture]
    public class FrequencyWordsAnalyzerTests
    {
        private IFrequencyWordsAnalyzer analyzer;

        [SetUp]
        public void SetUp()
        {
            analyzer = A.Fake<IFrequencyWordsAnalyzer>();
        }

        [Test]
        public void Analyze_ReturnCorrectWordsFrequenciesWithOrderByDescending()
        {
            var text = "не рассказал мне не всей правды эх эх эх";
            var expected = new Dictionary<string, int>()
            {
                ["рассказал"] = 1,
                ["эх"] = 3,
                ["не"] = 2,
                ["правды"] = 1,
                ["всей"] = 1,
                ["мне"] = 1
            };

            A.CallTo(() => analyzer.Analyze(text, string.Empty)).Returns(expected);
        }

        [Test]
        public void Analyze_WhenWordsListIsEmpty_ReturnEmptyDict()
        {
            analyzer.Analyze(string.Empty, string.Empty)
                .Should()
                .BeEquivalentTo
                (
                    new Dictionary<string, int>()
                );
        }
    }
}