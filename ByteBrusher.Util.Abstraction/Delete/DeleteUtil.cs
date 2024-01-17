using ByteBrusher.Core.File;
using ErrorOr;

namespace ByteBrusher.Util.Abstraction.Delete;

public interface IDeleteUtil
{
    /// <summary>
    /// Deletes duplicate entrys in the list
    /// </summary>
    /// <returns>Monad of the result</returns>
    public ErrorOr<Deleted> TryDelete(List<FoundFile> duplicates);
}
