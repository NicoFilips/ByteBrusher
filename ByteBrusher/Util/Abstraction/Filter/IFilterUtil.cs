using ByteBrusher.Core.File;

namespace ByteBrusher.Util.Abstraction.Filter;

public interface IFilterUtil
{
    /// <summary>
    /// Filters a List according to the CLI Arguments
    /// </summary>
    public List<FoundFile> FilterFiles(List<FoundFile> listToFilter);

    /// <summary>
    /// Filters of File according to the CLI Arguments
    /// </summary>
    public bool IncludeFile(FoundFile file);
}
