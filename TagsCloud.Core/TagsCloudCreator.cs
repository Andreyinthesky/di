using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TagsCloud.Core.Layouters;
using TagsCloud.Core.Settings;

namespace TagsCloud.Core
{
    public class TagsCloudCreator : ITagsCloudCreator
    {
        private readonly ICloudLayouter layouter;
        private readonly IFrequencyWordsAnalyzer wordsAnalyzer;
        private readonly IFontSettings fontSettings;
        
        public TagsCloudCreator(ICloudLayouter layouter, IFrequencyWordsAnalyzer wordsAnalyzer, IFontSettings fontSettings)
        {
            this.layouter = layouter;
            this.wordsAnalyzer = wordsAnalyzer;
            this.fontSettings = fontSettings;
        }

        public TagsCloud CreateTagsCloud(string text, string stopWordsText)
        {
            var tags = new List<Tag>();
            var frequencyByWord = wordsAnalyzer.Analyze(text, stopWordsText)
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var minFrequency = frequencyByWord.Values.Min(); 
            var maxFrequency = frequencyByWord.Values.Max();

            foreach (var weightedWord in frequencyByWord)
            {
                var fontSize = GetFontSize(weightedWord.Value, minFrequency, maxFrequency);
                var font = new Font(fontSettings.FontFamily, fontSize, fontSettings.FontStyle, GraphicsUnit.Point);
                var frameSize = TextRenderer.MeasureText(weightedWord.Key, font);
                var frame = layouter.PutNextRectangle(frameSize);
                tags.Add(new Tag(weightedWord.Key, font, frame));
            }

            return new TagsCloud(tags, layouter.CloudWidth, layouter.CloudHeight, layouter.Center);
        }

        private int GetFontSize(int currentFrequency, int minFrequency, int maxFrequency)
        {
            var minFontSize = fontSettings.MinFontSizeInPoints;
            var maxFontSize = fontSettings.MaxFontSizeInPoints;

            return currentFrequency > minFrequency 
                ? (int)Math.Ceiling((double)(maxFontSize * (currentFrequency - minFrequency))/(maxFrequency - minFrequency))
                    + minFontSize
                : minFontSize;
        }
    }
}