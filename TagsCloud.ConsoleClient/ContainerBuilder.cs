using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using TagsCloud.Core;
using TagsCloud.Core.FileReaders;
using TagsCloud.Core.Layouters;
using TagsCloud.Core.Settings;
using TagsCloud.Core.WordFilters;

namespace TagsCloud.ConsoleClient
{
    public class ContainerBuilder
    {
        public WindsorContainer Build()
        {
            var container = new WindsorContainer();

            container.AddFacility<TypedFactoryFacility>();

            container.Register(Component.For<ITextFileReader>()
                .ImplementedBy<TextFileReader>());

            container.Register(Component.For<ISpiral>()
                .ImplementedBy<Spiral>());

            container.Register(Component.For<ICloudLayouter>()
                    .ImplementedBy<CircularCloudLayouter>()
                    .LifestyleTransient()
            );

            container.Register(Component.For<ITextSplitter>()
                .ImplementedBy<TextSplitter>()
            );

            container.Register(
                Component.For<IWordsConverter>().ImplementedBy<ToLowerConverter>(),
                Component.For<IWordsConverter>().ImplementedBy<BasicFormWordConverter>());

            container.Register(Component.For<IFrequencyWordsAnalyzer>()
                .ImplementedBy<FrequencyWordsAnalyzer>()
                .DependsOn(Dependency.OnComponentCollection<IWordsConverter[]>(typeof(ToLowerConverter), typeof(BasicFormWordConverter))));

            container.Register(Component.For<IImageSettings>()
                .ImplementedBy<ImageSettings>());

            container.Register(Component.For<IFontSettings>()
                .ImplementedBy<FontSettings>());

            container.Register(Component.For<ITagsCloudCreator>()
                .ImplementedBy<TagsCloudCreator>());

            container.Register(Component.For<ITagsCloudVisualizer>()
                .ImplementedBy<TagsCloudVisualizer>());

            return container;
        }
    }
}