namespace TagsCloud.Core
{
    public interface ITagsCloudCreator
    {
        TagsCloud CreateTagsCloud(string text, string stopWordsText);
    }
}