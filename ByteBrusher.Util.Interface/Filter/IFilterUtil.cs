using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes.Interface;

namespace ByteBrusher.Util.Interface.Filter
{
    public interface IFilterUtil
    {
        /// <summary>
        /// Filters a List according to the CLI Arguments
        /// </summary>
        public IEnumerable<FoundFile> filterFiles(List<FoundFile> ListToFilter);
        
        /// <summary>
        /// Filters the Type of File according to the CLI Arguments
        /// </summary>
        public IFileType filterFileByFileType(string filename);
    }
}
