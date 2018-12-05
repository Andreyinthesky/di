using System;
using System.IO;

namespace TagsCloud.Core
{
    public class TextFileReader : ITextFileReader
    {
        public string ReadText(string filePath)
        {
            string text;
            try
            {
                text = File.ReadAllText(filePath);
            }
            catch (FileNotFoundException e)
            {
                throw new ArgumentException(e.Message);
            }

            return text;
        }
    }
}