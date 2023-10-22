using ByteBrusher.Core.File;
using ErrorOr;

namespace ByteBrusher.Util.Interface.Delete;

public interface IDeleteUtil
{
    /// <summary>
    /// Deletes all duplicates in the list
    /// </summary>
    /// <returns>Monad of the result</returns>
    public ErrorOr<Deleted> Try(List<FoundFile> duplicates);

}
