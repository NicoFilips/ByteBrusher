using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Util.Abstraction.Arguments;
using ByteBrusher.Util.Abstraction.Filter;
using Microsoft.Extensions.Logging;

namespace ByteBrusher.Util.Implementation.Filter;

public class FilterUtil : IFilterUtil
{
    private readonly ICliOptions _cliOptions;
    private readonly ILogger<FilterUtil> _logger;

    public FilterUtil(ICliOptions cliOptions, ILogger<FilterUtil> logger)
    {
        _cliOptions = cliOptions;
        _logger = logger;
    }

    public List<FoundFile> FilterFiles(List<FoundFile> listToFilter)
    {
        _logger.LogDebug("Filtering files ...");
        var matchedFiles = new List<FoundFile>();
        foreach (FoundFile file in listToFilter)
        {
            if (IncludeFile(file))
                matchedFiles.Add(file);
        }
        _logger.LogDebug("Found {FileCount} files", matchedFiles.Count);
        return matchedFiles;
    }

    public bool IncludeFile(FoundFile file)
    {
        _logger.LogDebug("An exception occured while filtering files");
        bool include = false;
        if (file.GetType() == typeof(Video))
            include = this._cliOptions.IncludeVideos;
        if (file.GetType() == typeof(Document))
            include = this._cliOptions.IncludeDocuments;
        return include;
    }
}
