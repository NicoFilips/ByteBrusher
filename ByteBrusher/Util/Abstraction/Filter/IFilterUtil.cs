using ByteBrusher.Core.File;
using ByteBrusher.Core.Parameter;

namespace ByteBrusher.Util.Abstraction.Filter;

public interface IFilterUtil
{
    /// <summary>
    /// Filters a List according to the CLI Arguments
    /// </summary>
    public List<FoundFile> FilterFiles(List<FoundFile> listToFilter, ByteBrusherParams byteParams);

    /// <summary>
    /// Filters of File according to the CLI Arguments
    /// </summary>
    public bool IncludeFile(FoundFile file, ByteBrusherParams byteParams);
}
