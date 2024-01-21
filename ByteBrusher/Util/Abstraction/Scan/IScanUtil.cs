using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes.Abstraction;

namespace ByteBrusher.Util.Abstraction.Scan;

public interface IScanUtil
{
    /// <summary>
    /// Grabs every file with a lot of information and stores it in a List
    /// --> Tested with 100k Images and videos, RAM usage is within a few Megabytes
    /// </summary>
    public IEnumerable<FoundFile> GetFileInfos(string path);

    /// <summary>
    /// Checks the Filetype of the document
    /// </summary>
    public IFileType ClassifyFile(string filename);
}
