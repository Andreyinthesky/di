using    System;
using    FractalPainting.App.Fractals;
using    FractalPainting.Infrastructure.Common;
using    FractalPainting.Infrastructure.UiActions;
using    Ninject;

namespace    FractalPainting.App.Actions
{
	public    class    DragonFractalAction    :    IUiAction
	{
		private    IImageHolder    imageHolder;
		private    IDragonPainterFactory    painterFactory;
	    private Func<Random, DragonSettingsGenerator> settingsFactory;

		public    string    Category    =>    "Фракталы";
		public    string    Name    =>    "Дракон";
		public    string    Description    =>    "Дракон    Хартера-Хейтуэя";

		public    void    Perform()
		{
		    var dragonSettings = CreateRandomSettings();
			//    редактируем    настройки:
			SettingsForm.For(dragonSettings).ShowDialog();
		    var painter = painterFactory.Create(dragonSettings);

            painter.Paint();
		}

		private       DragonSettings    CreateRandomSettings()
		{
			return    settingsFactory(new    Random()).Generate();
		}

	    public DragonFractalAction(IDragonPainterFactory painterFactory, IImageHolder imageHolder, Func<Random, DragonSettingsGenerator> settingsFactory)
	    {
	        this.painterFactory = painterFactory;
	        this.settingsFactory = settingsFactory;
	        this.imageHolder = imageHolder;
	    }
	}

    public interface IDragonPainterFactory
    {
        DragonPainter Create(DragonSettings  settings);
    }
}