using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Core.File.FileTypes.Interface;
using ByteBrusher.Core.FileTypes;
using ByteBrusher.Core.IOptions;
using ByteBrusher.Util.Interface.Filter;
using ByteBrusher.Util.Resource.Scan;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace ByteBrusher.Util.Resource.Filter
{
    public class FilterUtil : IFilterUtil
    {
        private readonly ILogger<ScanUtil> _logger;
        private readonly IOptions<FileExtensions> _options;
        private readonly Options

        public FilterUtil(ILogger<ScanUtil> logger, IOptions<FileExtensions> options)
        {
            _logger = logger;
            _options = options;
        }


        /// <inheritdoc/>
        public IEnumerable<FoundFile> filterFiles(List<FoundFile> ListToFilter)
        {
            foreach (FoundFile file in ListToFilter)
            {
                file.fileType = GetFileType(file.fileInfo.Name);
                yield return file;
            }
        }



        /// <inheritdoc/>
        public FoundFile filterFileByFileType(FoundFile file)
        {
            if (file.fileType.Equals(typeof(Video))) 
            {
                
            }
            if (file.fileType.Equals(typeof(Video))) 
            {
            
            }
        }
    }
}
