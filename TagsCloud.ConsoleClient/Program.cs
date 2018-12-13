using Fclp;
using System;
using System.Drawing.Text;
using System.Linq;
using TagsCloud.Core;
using TagsCloud.Core.FileReaders;
using TagsCloud.Core.Settings;

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
            var appSettings = new ArgumentsParser().Parse(args);
            var container = new ContainerBuilder().Build();
            var reader = container.Resolve<ITextFileReader>();

            var text = reader
                .ReadText(appSettings.InputTextFilePath);
            var stopWordsText = reader
                .ReadText(appSettings.InputStopWordsFilePath);

            var imageSettings = container.Resolve<IImageSettings>();
            var fontSettings = container.Resolve<IFontSettings>();
            ApplyImageSettings(imageSettings, appSettings);
            ApplyFontSettings(fontSettings, appSettings);

            var image = container.Resolve<ITagsCloudVisualizer>().GetCloudImage(text, stopWordsText);
            image.Save("output.png");
            Console.WriteLine("Image save to output.png");
        }

        public static void ApplyImageSettings(IImageSettings imageSettings, AppSettings appSettings)
        {
            imageSettings.Width = appSettings.Width;
            imageSettings.Height = appSettings.Height;
        }

        public static void ApplyFontSettings(IFontSettings fontSettings, AppSettings appSettings)
        {
            fontSettings.FontFamily =
                new InstalledFontCollection().Families.FirstOrDefault(f => f.Name == appSettings.TypeFace) ??
                fontSettings.FontFamily;
        }
    }
}
