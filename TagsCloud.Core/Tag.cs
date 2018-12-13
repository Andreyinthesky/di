using System.Drawing;

namespace TagsCloud.Core
{
    public class Tag
    {
        public string Text { get; set; }
        public Font Font { get; set; }
        public Rectangle Rectangle { get; set; }

        public Tag(string text, Font font, Rectangle rectangle)
        {
            Text = text;
            Font = font;
            Rectangle = rectangle;
        }
    }
}
