using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Core.Parameter;
using ByteBrusher.Util.Abstraction.Filter;
using Microsoft.Extensions.Logging;

namespace ByteBrusher.Util.Implementation.Filter;

public class FilterUtil(ILogger<FilterUtil> logger) : IFilterUtil
{
    public List<FoundFile> FilterFiles(List<FoundFile> listToFilter, ByteBrusherParams byteParams)
    {
        logger.LogDebug("Filtering files ...");

        var matchedFiles = listToFilter.Where(file => IncludeFile(file, byteParams)).ToList();

        logger.LogDebug("Found {FileCount} files", matchedFiles.Count);

        return matchedFiles;
    }

    public bool IncludeFile(FoundFile file, ByteBrusherParams byteParams)
    {
        logger.LogDebug("An exception occured while filtering files");
        bool include = false;
        if (file.GetType() == typeof(Video))
            include = byteParams.IncludeVideos;
        if (file.GetType() == typeof(Document))
            include = byteParams.IncludeDocuments;
        return include;
    }
}
