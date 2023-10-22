using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Core.IOptions;
using ByteBrusher.Util.Arguments.Interface;
using ByteBrusher.Util.Interface.Filter;
using ByteBrusher.Util.Resource.Scan;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ByteBrusher.Util.Resource.Filter
{
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

        /// <inheritdoc/>
        public List<FoundFile> filterFiles(List<FoundFile> ListToFilter)
        {
            List<FoundFile> matchedFiles = new List<FoundFile>();
            foreach (FoundFile file in ListToFilter)
            {
                if (includeFile(file))
                    matchedFiles.Add(file);
            }
            return matchedFiles;
        }

        /// <inheritdoc/>
        public bool includeFile(FoundFile file)
        {
            if (file.fileType.Equals(typeof(Video)))
                return this._cliOptions.includeVideos;

            if (file.fileType.Equals(typeof(Document)))
                return this._cliOptions.includeDocuments;

            return false;
        }
    }
}
