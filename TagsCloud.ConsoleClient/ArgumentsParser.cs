using System;
using Fclp;

namespace TagsCloud.ConsoleClient
{
    public class ArgumentsParser
    {
        public AppSettings Parse(string[] args)
        {
            var argsParser = CreateArgsParser();
            var parseResult = argsParser.Parse(args);

            if (parseResult.HasErrors)
            {
                throw new ArgumentException(parseResult.ErrorText);
            }

            return argsParser.Object;
        }

        public static FluentCommandLineParser<AppSettings> CreateArgsParser()
        {
            var argsParser = new FluentCommandLineParser<AppSettings>();

            argsParser.Setup(arg => arg.InputTextFilePath)
                .As('f', "text_file")
                .WithDescription("input text file path")
                .Required();

            argsParser.Setup(arg => arg.InputStopWordsFilePath)
                .As('s', "stopwords_file")
                .WithDescription("input stop words file path")
                .Required();

            argsParser.Setup(arg => arg.TypeFace)
                .As('t', "typeface")
                .WithDescription("font typeface for tags");

            argsParser.Setup(arg => arg.Width)
                .As('w', "width")
                .WithDescription("width of output image")
                .SetDefault(400);

            argsParser.Setup(arg => arg.Height)
                .As('h', "height")
                .WithDescription("height of output image")
                .SetDefault(400);

            return argsParser;
        }
    }
}