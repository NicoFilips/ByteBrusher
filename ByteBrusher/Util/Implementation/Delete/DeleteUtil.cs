using ByteBrusher.Core.File;
using ByteBrusher.Util.Abstraction.Delete;
using ByteBrusher.Util.Abstraction.Hash.Models;
using ErrorOr;
using Microsoft.Extensions.Logging;

namespace ByteBrusher.Util.Implementation.Delete;

public class DeleteUtil(ILogger<DeleteUtil> logger, IFileAbstraction fileAbstraction) : IDeleteUtil
{
    private IFileAbstraction FileAbstraction { get; init; } = fileAbstraction;

    public ErrorOr<Deleted> TryDelete(List<FoundFile> duplicates)
    {
        if (duplicates.Count == 0)
            return Error.Unexpected("No duplicates found");
        logger.LogInformation("No duplicates found");

        if (!duplicates.All(file => FileAbstraction.Exists(file.FileInfo.FullName)))
            return Error.NotFound("One or more files do not exist");
        logger.LogInformation("One or more files do not exist");

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
