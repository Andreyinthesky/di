using System.Drawing;
using TagsCloud.Core.Settings;

namespace TagsCloud.Core
{
    public class TagsCloudVisualizer : ITagsCloudVisualizer
    {
        public IImageSettings ImageSettings { get; }
        public ITagsCloudCreator TagsCloudCreator { get; }

        public TagsCloudVisualizer(IImageSettings imageSettings, ITagsCloudCreator tagsCloudCreator)
        {
            ImageSettings = imageSettings;
            TagsCloudCreator = tagsCloudCreator;
        }

        public Bitmap GetCloudImage(string text, string stopWordsText)
        {
            var tagsCloud = TagsCloudCreator.CreateTagsCloud(text, stopWordsText);
            var image = new Bitmap(ImageSettings.Width, ImageSettings.Height);
            var graphics = Graphics.FromImage(image);
            DrawTags(tagsCloud, graphics, image.Size);
            return image;
        }

        private void DrawTags(TagsCloud tagsCloud, Graphics graphics, Size imageSize)
        {
            graphics.FillRectangle(new SolidBrush(ImageSettings.BackgroundColor), 0, 0, imageSize.Width, imageSize.Height);

            foreach (var tag in tagsCloud.Tags)
            {
                var shiftedRectangle = ShiftRectangleToImageCenter(tagsCloud, tag.Rectangle, imageSize);
                graphics.DrawString(tag.Text, tag.Font, new SolidBrush(ImageSettings.ForegroundColor), shiftedRectangle);
            }
        }

        private Rectangle ShiftRectangleToImageCenter(TagsCloud tagsCloud, Rectangle rectangle, Size imageSize)
        {
            var newX = rectangle.X + tagsCloud.Center.X + imageSize.Width / 2;
            var newY = rectangle.Y + tagsCloud.Center.Y + imageSize.Height / 2;
            return new Rectangle(newX, newY, rectangle.Width, rectangle.Height);
        }
    }
}