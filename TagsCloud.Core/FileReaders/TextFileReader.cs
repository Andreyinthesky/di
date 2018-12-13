using System.IO;

namespace TagsCloud.Core.FileReaders
{
    public class TextFileReader : ITextFileReader
    {
        public string ReadText(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}