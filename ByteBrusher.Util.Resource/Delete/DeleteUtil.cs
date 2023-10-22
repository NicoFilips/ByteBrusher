using ByteBrusher.Util.Interface.Delete;
using ByteBrusher.Core.File;
using ErrorOr;
using ByteBrusher.Util.Interface.Hash.Models;

namespace ByteBrusher.Util.Resource.Delete;

public class DeleteUtil : IDeleteUtil
{
    private IFileAbstraction _fileAbstraction { get; init; }

    public DeleteUtil(IFileAbstraction fileAbstraction)
    {
        _fileAbstraction = fileAbstraction;
    }
    public ErrorOr<Deleted> Try(List<FoundFile> duplicates)
    {
        if (duplicates.Count == 0)
            return Error.Unexpected("No duplicates found");

        if (!duplicates.All(file => _fileAbstraction.Exists(file.fileInfo.FullName)))
            return Error.NotFound("One or more files do not exist");

        try
        {
            foreach (var duplicate in duplicates)
                _fileAbstraction.Delete(duplicate.fileInfo.FullName);

            return Result.Deleted;
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
