using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TagsCloud.Core.FileReaders;
using TagsCloud.Core.Layouters;
using TagsCloud.Core.Settings;
using TagsCloud.Core.WordFilters;

namespace TagsCloud.Core
{
    public class TagsCloudCreator : ITagsCloudCreator
    {
        private readonly ICloudLayouter layouter;
        private readonly IFrequencyWordsAnalyzer wordsAnalyzer;
        private readonly ITextFileReader textFileReader;
        private readonly ITextPreprocessor preprocessor;

        public TagsCloudCreator(ICloudLayouter layouter,
            ITextFileReader textFileReader,
            IFrequencyWordsAnalyzer wordsAnalyzer,
            ITextPreprocessor preprocessor
            )
        {
            this.layouter = layouter;
            this.wordsAnalyzer = wordsAnalyzer;
            this.textFileReader = textFileReader;
            this.preprocessor = preprocessor;
        }

        public TagsCloud CreateTagsCloud(string textFilePath, FontSettings fontSettings)
        {
            var tags = new List<Tag>();
            var text = textFileReader.ReadText(textFilePath);
            var frequencyByWord = wordsAnalyzer.Analyze(preprocessor.Process(text))
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var minFrequency = frequencyByWord.Values.Min(); 
            var maxFrequency = frequencyByWord.Values.Max();

            foreach (var weightedWord in frequencyByWord)
            {
                var fontSize = GetFontSize(fontSettings, weightedWord.Value, minFrequency, maxFrequency);
                var fontFamily = new FontFamily(fontSettings.TypeFace);
                var font = new Font(fontFamily, fontSize, fontSettings.FontStyle, GraphicsUnit.Point);
                var frameSize = TextRenderer.MeasureText(weightedWord.Key, font);
                var frame = layouter.PutNextRectangle(frameSize);
                tags.Add(new Tag(weightedWord.Key, font, frame));
            }

            return new TagsCloud(tags, layouter.CloudWidth, layouter.CloudHeight, layouter.Center);
        }

        private int GetFontSize(FontSettings fontSettings, int currentFrequency, int minFrequency, int maxFrequency)
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