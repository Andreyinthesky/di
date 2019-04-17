using System.Collections.Generic;

namespace TagsCloud.Core
{
    public interface IProvider
    {
        IEnumerable<string> Get();
    }
}