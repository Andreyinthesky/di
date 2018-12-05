using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TagsCloud.Core
{
    public class TagsCloudCreator
    {
        private readonly ICloudLayouter layouter;
        private readonly Dictionary<string, int> frequencyByWord;
        private readonly FontSettings fontSettings;
        private readonly int maxFrequency;
        private readonly int minFrequency;

        public TagsCloudCreator(ICloudLayouter layouter, Dictionary<string, int> frequencyByWord, FontSettings fontSettings)
        {
            this.layouter = layouter;
            this.frequencyByWord = frequencyByWord;
            this.fontSettings = fontSettings;
            maxFrequency = frequencyByWord.Values.Max();
            minFrequency = frequencyByWord.Values.Min();
        }

        public TagsCloud CreateTagsCloud()
        {
            var tags = new List<Tag>();
            foreach (var weightedWord in frequencyByWord)
            {
                var fontSize = GetFontSize(weightedWord.Value);
                var font = new Font(fontSettings.FontFamily, fontSize, fontSettings.FontStyle, GraphicsUnit.Point);
                var frameSize = TextRenderer.MeasureText(weightedWord.Key, font);
                var frame = layouter.PutNextRectangle(frameSize);
                tags.Add(new Tag(weightedWord.Key, font, frame));
            }

            return new TagsCloud(tags, layouter.CloudWidth, layouter.CloudHeight, layouter.Center);
        }

        private int GetFontSize(int currentFrequency)
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