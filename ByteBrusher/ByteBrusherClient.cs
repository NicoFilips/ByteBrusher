using ByteBrusher.Core.File;
using ByteBrusher.Util.Abstraction.Delete;
using ByteBrusher.Util.Abstraction.Filter;
using ByteBrusher.Util.Abstraction.Hash;
using ByteBrusher.Util.Abstraction.Scan;
using Microsoft.Extensions.Logging;

namespace ByteBrusher;

public class ByteBrusherClient : IByteBrusherClient, IDisposable
{
    private readonly ILogger<ByteBrusherClient> _logger;
    private readonly IScanUtil _scanUtil;
    private readonly IFilterUtil _filterUtil;
    private readonly IHashUtil _hashUtil;
    private readonly IDeleteUtil _deleteUtil;

    public ByteBrusherClient(ILogger<ByteBrusherClient> logger, IScanUtil scanUtil, IFilterUtil filterUtil, IHashUtil hashUtil, IDeleteUtil deleteUtil)
    {
        _logger = logger;
        _scanUtil = scanUtil;
        _filterUtil = filterUtil;
        _hashUtil = hashUtil;
        _deleteUtil = deleteUtil;
    }

    public async Task<bool> ExecuteAsync(bool deleteFlag, string pathToCleanUp)
    {
        try
        {
            _logger.LogInformation("get files ...");
            var foundFiles = _scanUtil.GetFileInfos(pathToCleanUp).ToList();
            _logger.LogInformation("found: {FoundFileCount} files. filtering out images, pictures and videos now.", foundFiles.Count);

            foundFiles = _filterUtil.FilterFiles(foundFiles);
            _logger.LogInformation("filtered list with console arguments. now we have : {FoundFileCount} files left.", foundFiles.Count);

            Dictionary<string, List<FoundFile>> duplicates = await _hashUtil.GetDuplicatesAsync(foundFiles);
            _logger.LogInformation("found {DuplicatesCount} duplicates.", duplicates.Count);

            foreach (KeyValuePair<string, List<FoundFile>> duplicate in duplicates)
            {
                if (deleteFlag)
                {
                    _logger.LogInformation("deleting Files now ...");
                    _deleteUtil.TryDelete(duplicate.Value).SwitchFirst(
                        deleted => Console.WriteLine("Deletation worked"),
                        error => Console.WriteLine(error.Description));
                    _logger.LogInformation("deleted Files.");
                }
            }
            _logger.LogInformation("---- < bytebrusher client execution finished > ----");
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
