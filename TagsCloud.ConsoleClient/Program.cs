using System;
using System.Drawing;
using Fclp;
using TagsCloud.Core;

namespace TagsCloud.ConsoleClient
{
    class Program
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var argsParser = CreateArgsParser();
            var parseResult = argsParser.Parse(args);
            if (parseResult.HasErrors)
            {
                Console.WriteLine(parseResult.ErrorText);
            }
            Execute(argsParser.Object);
        }

        public static void Execute(AppSettings appSettings)
        {
            var text = new TextFileReader().ReadText(appSettings.InputFilePath);
            var tagsCloudLayouter = new CircularCloudLayouter(new Point(0, 0));
            var fontSettings = new FontSettings(
                appSettings.TypeFace != null 
                ? new FontFamily(appSettings.TypeFace)
                : FontFamily.GenericMonospace);
            var imageSettings = new ImageSettings(appSettings.Width, appSettings.Height);
            var tagsCloud = new TagsCloudCreator(tagsCloudLayouter, new FrequencyWordsAnalyzer().Analyze(text.Split()), fontSettings)
                .CreateTagsCloud();
            var image = new TagsCloudVisualizer(imageSettings, tagsCloud).GetCloudImage();
            image.Save("output.png");
        }

        public static FluentCommandLineParser<AppSettings> CreateArgsParser()
        {
            var argsParser = new FluentCommandLineParser<AppSettings>();
            argsParser.Setup(arg => arg.InputFilePath)
                .As('f', "file")
                .WithDescription("input file path")
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
