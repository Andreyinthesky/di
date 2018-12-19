using System.Collections.Generic;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using TagsCloud.Core;
using TagsCloud.Core.FileReaders;
using TagsCloud.Core.Layouters;
using TagsCloud.Core.Settings;
using TagsCloud.Core.WordConverters;
using TagsCloud.Core.WordFilters;

namespace TagsCloud.ConsoleClient
{
    public class ContainerBuilder
    {
        public WindsorContainer Build()
        {
            var container = new WindsorContainer();

            container.AddFacility<TypedFactoryFacility>();
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));

            container.Register(Component.For<ITextFileReader>()
                .ImplementedBy<TextFileReader>());

            container.Register(Component.For<ISpiral>()
                .ImplementedBy<Spiral>());

            container.Register(Component.For<ICloudLayouter>()
                    .ImplementedBy<CircularCloudLayouter>()
                    .LifestyleTransient()
            );

            container.Register(Component.For<IMapper<string, IEnumerable<string>>>()
                .ImplementedBy<TextSplitter>()
            );
           
            container.Register(
                Component.For<IWordConverter>().ImplementedBy<ToLowerConverter>(),
                Component.For<IWordConverter>().ImplementedBy<BasicFormWordConverter>());

            container.Register(Component.For<ITextPreprocessor>()
                .ImplementedBy<TextPreprocessor>());

            container.Register(Component.For<IProvider>().ImplementedBy<StopWordsProvider>());

            container.Register(
                Component.For<IWordFilter>().ImplementedBy<StopWordFilter>());

            container.Register(Component.For<IFrequencyWordsAnalyzer>()
                .ImplementedBy<FrequencyWordsAnalyzer>());

            container.Register(Component.For<IImageSettings>()
                .ImplementedBy<ImageSettings>());

            container.Register(Component.For<IFontSettings>()
                .ImplementedBy<FontSettings>());

            container.Register(Component.For<CloudSettings>()
                .ImplementedBy<CloudSettings>());

            container.Register(Component.For<ITagsCloudCreator>()
                .ImplementedBy<TagsCloudCreator>());

            container.Register(Component.For<ITagsCloudVisualizer>()
                .ImplementedBy<TagsCloudVisualizer>());

            return container;
        }
    }
}