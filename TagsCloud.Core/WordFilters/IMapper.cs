namespace TagsCloud.Core.WordFilters
{
    public interface IMapper<in T, out TOut>
    {
        TOut Map(T item);
    }
}