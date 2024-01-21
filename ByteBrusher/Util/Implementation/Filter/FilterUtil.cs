using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Core.Parameter;
using ByteBrusher.Util.Abstraction.Filter;
using Microsoft.Extensions.Logging;

namespace ByteBrusher.Util.Implementation.Filter;

public class FilterUtil(ByteBrusherParams cliByteBrusherParams, ILogger<FilterUtil> logger) : IFilterUtil
{
    public List<FoundFile> FilterFiles(List<FoundFile> listToFilter)
    {
        logger.LogDebug("Filtering files ...");
        var matchedFiles = new List<FoundFile>();
        foreach (FoundFile file in listToFilter)
        {
            if (IncludeFile(file))
                matchedFiles.Add(file);
        }
        logger.LogDebug("Found {FileCount} files", matchedFiles.Count);
        return matchedFiles;
    }

    public bool IncludeFile(FoundFile file)
    {
        logger.LogDebug("An exception occured while filtering files");
        bool include = false;
        if (file.GetType() == typeof(Video))
            include = cliByteBrusherParams.IncludeVideos;
        if (file.GetType() == typeof(Document))
            include = cliByteBrusherParams.IncludeDocuments;
        return include;
    }
}
