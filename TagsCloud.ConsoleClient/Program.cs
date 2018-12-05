using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
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

            var visualizer = ResolveTagsCloudVisualizer(argsParser.Object);
            var image = visualizer.GetCloudImage();
            image.Save("output.png");
            Console.WriteLine("Image save to output.png");
        }

        public static TagsCloudVisualizer ResolveTagsCloudVisualizer(AppSettings appSettings)
        {
            var container = new WindsorContainer();

            container.Register(Castle.MicroKernel.Registration.Component.For<ITextFileReader>()
                .ImplementedBy<TextFileReader>());

            container.Register(Castle.MicroKernel.Registration.Component.For<ICloudLayouter>()
                .ImplementedBy<CircularCloudLayouter>()
                .DependsOn(Dependency.OnValue<Point>(new Point(0, 0)))
            );

            container.Register(Castle.MicroKernel.Registration.Component.For<IFrequencyWordsAnalyzer>()
                .ImplementedBy<FrequencyWordsAnalyzer>());

            var words = container.Resolve<ITextFileReader>().ReadText(appSettings.InputFilePath).Split();
            var fontSettings = new FontSettings(
                appSettings.TypeFace != null 
                    ? new FontFamily(appSettings.TypeFace)
                    : FontFamily.GenericMonospace);

            container.Register(Castle.MicroKernel.Registration.Component.For<TagsCloudCreator>()
                .DependsOn(
                    Dependency.OnValue<ICloudLayouter>(container.Resolve<ICloudLayouter>()),
                    Dependency.OnValue<IOrderedEnumerable<KeyValuePair<string, int>>>(container.Resolve<IFrequencyWordsAnalyzer>().Analyze(words)),
                    Dependency.OnValue<FontSettings>(fontSettings))
            );

            container.Register(Castle.MicroKernel.Registration.Component.For<TagsCloudVisualizer>()
                .DependsOn(
                    Dependency.OnValue<ImageSettings>(new ImageSettings(appSettings.Width, appSettings.Height)),
                    Dependency.OnValue<Core.TagsCloud>(container.Resolve<TagsCloudCreator>().CreateTagsCloud()))
            );

            return container.Resolve<TagsCloudVisualizer>();
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
