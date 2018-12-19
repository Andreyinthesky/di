using TagsCloud.Core.Settings;

namespace TagsCloud.Core
{
    public interface ITagsCloudCreator
    {
        TagsCloud CreateTagsCloud(string textFilePath, FontSettings fontSettings);
    }
}