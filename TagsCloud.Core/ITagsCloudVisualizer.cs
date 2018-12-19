using System.Drawing;

namespace TagsCloud.Core
{
    public interface ITagsCloudVisualizer
    {
        Bitmap GetCloudImage();
    }
}