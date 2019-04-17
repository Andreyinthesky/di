using System.Drawing;
using System.Linq;
using TagsCloud.Core.Settings;

namespace TagsCloud.Core
{
    public class TagsCloudVisualizer : ITagsCloudVisualizer
    {
        public ITagsCloudCreator TagsCloudCreator { get; }
        public CloudSettings CloudSettings { get; }

        public TagsCloudVisualizer(ITagsCloudCreator tagsCloudCreator, CloudSettings cloudSettings)
        {
            TagsCloudCreator = tagsCloudCreator;
            CloudSettings = cloudSettings;
        }

        public Bitmap GetCloudImage()
        {
            var imageSettings = CloudSettings.ImageSettings;
            var tagsCloud = TagsCloudCreator
                .CreateTagsCloud(CloudSettings.InputTextFilePath, CloudSettings.FontSettings);
            var image = new Bitmap(imageSettings.Width, imageSettings.Height);
            var graphics = Graphics.FromImage(image);
            DrawTags(imageSettings, tagsCloud, graphics, CloudSettings.WordsCount);
            return image;
        }

        private void DrawTags(ImageSettings imageSettings, TagsCloud tagsCloud, Graphics graphics, int tagsCount)
        {
            graphics.FillRectangle(new SolidBrush(imageSettings.BackgroundColor), 0, 0, imageSettings.Width, imageSettings.Height);

            foreach (var tag in tagsCloud.Tags.Take(tagsCount))
            {
                var shiftedRectangle = ShiftRectangleToImageCenter(
                    tagsCloud,
                    tag.Rectangle, 
                    new Size(imageSettings.Width, imageSettings.Height));
                graphics.DrawString(tag.Text, tag.Font, new SolidBrush(imageSettings.ForegroundColor), shiftedRectangle);
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