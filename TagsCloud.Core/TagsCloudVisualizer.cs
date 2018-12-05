using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloud.Core
{
    public class TagsCloudVisualizer
    {
        public ImageSettings ImageSettings { get; }
        public TagsCloud TagsCloud { get; }

        public TagsCloudVisualizer(ImageSettings imageSettings, TagsCloud tagsCloud)
        {
            ImageSettings = imageSettings;
            TagsCloud = tagsCloud;
        }

        public Bitmap GetCloudImage()
        {
            var image = new Bitmap(ImageSettings.Width, ImageSettings.Height);
            var graphics = Graphics.FromImage(image);
            DrawTags(graphics, image.Size);
            return image;
        }

        private void DrawTags(Graphics graphics, Size imageSize)
        {
            graphics.FillRectangle(new SolidBrush(ImageSettings.BackgroundColor), 0, 0, imageSize.Width, imageSize.Height);

            foreach (var tag in TagsCloud.Tags)
            {
                var shiftedRectangle = ShiftRectangleToImageCenter(tag.Rectangle, imageSize);
                graphics.DrawString(tag.Text, tag.Font, new SolidBrush(ImageSettings.ForegroundColor), shiftedRectangle);
            }
        }

        private Rectangle ShiftRectangleToImageCenter(Rectangle rectangle, Size imageSize)
        {
            var newX = rectangle.X + TagsCloud.Center.X + imageSize.Width / 2;
            var newY = rectangle.Y + TagsCloud.Center.Y + imageSize.Height / 2;
            return new Rectangle(newX, newY, rectangle.Width, rectangle.Height);
        }
    }
}