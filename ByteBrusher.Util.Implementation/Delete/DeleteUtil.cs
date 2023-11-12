using ByteBrusher.Core.File;
using ErrorOr;
using ByteBrusher.Util.Abstraction.Hash.Models;
using Microsoft.Extensions.Logging;
using ByteBrusher.Util.Abstraction.Delete;

namespace ByteBrusher.Util.Implementation.Delete;

public class DeleteUtil : IDeleteUtil
{
    private IFileAbstraction FileAbstraction { get; init; }
    private ILogger<DeleteUtil> Logger { get; init; }

    public DeleteUtil(ILogger<DeleteUtil> logger, IFileAbstraction fileAbstraction)
    {
        FileAbstraction = fileAbstraction;
        Logger = logger;
    }

    public ErrorOr<Deleted> TryDelete(List<FoundFile> duplicates)
    {
        if (duplicates.Count == 0)
            return Error.Unexpected("No duplicates found");

        if (!duplicates.All(file => FileAbstraction.Exists(file.FileInfo.FullName)))
            return Error.NotFound("One or more files do not exist");

        try
        {
            foreach (FoundFile duplicate in duplicates)
                FileAbstraction.Delete(duplicate.FileInfo.FullName);

            return Result.Deleted;
        }
        catch (Exception ex)
        {
            return Error.Failure(ex.Message);
        }
    }
}
