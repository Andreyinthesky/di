using System.Collections.Generic;
using TagsCloud.Core.FileReaders;
using TagsCloud.Core.Settings;

namespace TagsCloud.Core
{
    public class StopWordsProvider : IProvider
    {
        private readonly CloudSettings cloudSettings;
        private readonly ITextFileReader fileReader;
        private readonly ITextPreprocessor textPreprocessor;

        public StopWordsProvider(CloudSettings cloudSettings, ITextFileReader fileReader, ITextPreprocessor textPreprocessor)
        {
            this.cloudSettings = cloudSettings;
            this.fileReader = fileReader;
            this.textPreprocessor = textPreprocessor;
        }

        public IEnumerable<string> Get()
        {
            var text = fileReader.ReadText(cloudSettings.InputStopWordsFilePath);
            return textPreprocessor.Process(text);
        }
    }
}