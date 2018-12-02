using System;
using System.Windows.Forms;
using FractalPainting.App.Actions;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Conventions;

namespace FractalPainting.App
{
    internal static class Program
    {
        ///    <summary>
        ///                    The    main    entry    point    for    the    application.
        ///    </summary>
        [STAThread]
        private static void Main()
        {
            var container = new StandardKernel();
            //container.Bind<IUiAction>().To<SaveImageAction>();
            //container.Bind<IUiAction>().To<DragonFractalAction>();
            //container.Bind<IUiAction>().To<KochFractalAction>();
            //container.Bind<IUiAction>().To<ImageSettingsAction>();
            //container.Bind<IUiAction>().To<PaletteSettingsAction>();

            container.Bind(x => x
                .FromThisAssembly() // 1
                .SelectAllClasses().InheritedFrom<IUiAction>() // 2
                .BindAllInterfaces());

            container.Bind<Palette>().ToSelf().InSingletonScope();
            container.Bind<PictureBoxImageHolder, IImageHolder>().To<PictureBoxImageHolder>().InSingletonScope();
            container.Bind<KochPainter>().ToSelf().InSingletonScope();

            container.Bind<IDragonPainterFactory>().ToFactory();

            container.Bind<IObjectSerializer>()
                .To<XmlObjectSerializer>()
                .WhenInjectedInto<SettingsManager>();

            container.Bind<IBlobStorage>()
                .To<FileBlobStorage>()
                .WhenInjectedInto<SettingsManager>();

            container.Bind<AppSettings, IImageDirectoryProvider>()
                .ToMethod(context => context.Kernel.Get<SettingsManager>().Load())
                .InSingletonScope();

            container.Bind<ImageSettings>()
                .ToMethod(context => context.Kernel.Get<AppSettings>().ImageSettings)
                .InSingletonScope();

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(container.Get<MainForm>());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}