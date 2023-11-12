using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Core.IOptions;
using ByteBrusher.Util.Abstraction.Arguments;
using ByteBrusher.Util.Abstraction.Filter;
using ByteBrusher.Util.Implementation.Scan;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ByteBrusher.Util.Implementation.Filter;

public class FilterUtil : IFilterUtil
{
    private readonly ILogger<ScanUtil> _logger;
    private readonly IOptions<FileExtensions> _options;
    private readonly ICliOptions _cliOptions;

    public FilterUtil(ILogger<ScanUtil> logger, IOptions<FileExtensions> options, ICliOptions cliOptions)
    {
        _logger = logger;
        _options = options;
        _cliOptions = cliOptions;
    }

    public List<FoundFile> FilterFiles(List<FoundFile> listToFilter)
    {
        var matchedFiles = new List<FoundFile>();
        foreach (FoundFile file in listToFilter)
        {
            if (IncludeFile(file))
                matchedFiles.Add(file);
        }
        return matchedFiles;
    }

    public bool IncludeFile(FoundFile file)
    {
        bool include = false;
        if (file.GetType() == typeof(Video))
            include = this._cliOptions.IncludeVideos;
        if (file.GetType() == typeof(Document))
            include = this._cliOptions.IncludeDocuments;
        return include;
    }
}
