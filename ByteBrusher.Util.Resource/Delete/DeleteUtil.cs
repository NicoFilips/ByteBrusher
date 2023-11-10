using ByteBrusher.Util.Interface.Delete;
using ByteBrusher.Core.File;
using ErrorOr;
using ByteBrusher.Util.Interface.Hash.Models;

namespace ByteBrusher.Util.Resource.Delete;

using Microsoft.Extensions.Logging;

public class DeleteUtil : IDeleteUtil
{
    private IFileAbstraction _fileAbstraction { get; init; }
    private ILogger<DeleteUtil> _logger { get; init; }

    public DeleteUtil(ILogger<DeleteUtil> logger, IFileAbstraction fileAbstraction)
    {
        _fileAbstraction = fileAbstraction;
        _logger = logger;
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
