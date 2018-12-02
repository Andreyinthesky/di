using    System.IO;
using    System.Windows.Forms;
using    FractalPainting.Infrastructure.Common;
using    FractalPainting.Infrastructure.UiActions;

namespace    FractalPainting.App.Actions
{
	public    class    SaveImageAction    :    IUiAction
	{
		private    AppSettings    appSettings;
		private    IImageHolder    imageHolder;

		public    string    Category    =>    "Файл";
		public    string    Name    =>    "Сохранить...";
		public    string    Description    =>    "Сохранить    изображение    в    файл";

	    public SaveImageAction(AppSettings appSettings, IImageHolder imageHolder)
	    {
	        this.appSettings = appSettings;
	        this.imageHolder = imageHolder;
	    }

		public    void    Perform()
		{
			var    dialog    =    new    SaveFileDialog
			{
				CheckFileExists    =    false,
				InitialDirectory    =    Path.GetFullPath(appSettings.ImagesDirectory),
                                                                DefaultExt    =    "bmp",
                                                                FileName    =    "image.bmp",
                                                                Filter    =    "Изображения    (*.bmp)|*.bmp"    
			};
			var    res    =    dialog.ShowDialog();
			if    (res    ==    DialogResult.OK)
				imageHolder.SaveImage(dialog.FileName);
		}
	}
}