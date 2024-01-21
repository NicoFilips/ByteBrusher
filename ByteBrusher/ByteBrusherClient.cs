using ByteBrusher.Core.File;
using ByteBrusher.Util.Abstraction.Delete;
using ByteBrusher.Util.Abstraction.Filter;
using ByteBrusher.Util.Abstraction.Hash;
using ByteBrusher.Util.Abstraction.Scan;
using Microsoft.Extensions.Logging;

namespace ByteBrusher;

public class ByteBrusherClient(ILogger<ByteBrusherClient> logger, IScanUtil scanUtil, IFilterUtil filterUtil, IHashUtil hashUtil, IDeleteUtil deleteUtil)
    : IByteBrusherClient, IDisposable
{
    public async Task<bool> ExecuteAsync(bool deleteFlag, string pathToCleanUp)
    {
        try
        {
            logger.LogInformation("get files ...");
            var foundFiles = scanUtil.GetFileInfos(pathToCleanUp).ToList();
            logger.LogInformation("found: {FoundFileCount} files. filtering out images, pictures and videos now.", foundFiles.Count);

            foundFiles = filterUtil.FilterFiles(foundFiles);
            logger.LogInformation("filtered list with console arguments. now we have : {FoundFileCount} files left.", foundFiles.Count);

            Dictionary<string, List<FoundFile>> duplicates = await hashUtil.GetDuplicatesAsync(foundFiles);
            logger.LogInformation("found {DuplicatesCount} duplicates.", duplicates.Count);

            foreach (KeyValuePair<string, List<FoundFile>> duplicate in duplicates)
            {
                if (deleteFlag)
                {
                    logger.LogInformation("deleting Files now ...");
                    deleteUtil.TryDelete(duplicate.Value).SwitchFirst(
                        deleted => Console.WriteLine("Deletation worked"),
                        error => Console.WriteLine(error.Description));
                    logger.LogInformation("deleted Files.");
                }
            }
            logger.LogInformation("---- < bytebrusher client execution finished > ----");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public void Dispose() => GC.SuppressFinalize(this);
}
