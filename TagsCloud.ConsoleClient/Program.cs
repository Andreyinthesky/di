using System;
using System.IO;
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
            var container = new ContainerBuilder().Build();
            var image = container.Resolve<ITagsCloudVisualizer>().GetCloudImage();
            var outputFilePath = "output.png";

            try
            {
                image.Save(outputFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine($"Image save to {Path.Combine(Path.GetFullPath(Directory.GetCurrentDirectory()), outputFilePath)}");
        }
    }
}