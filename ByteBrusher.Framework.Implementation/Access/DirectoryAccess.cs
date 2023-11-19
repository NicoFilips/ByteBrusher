using ByteBrusher.Framework.Abstraction.Access;

namespace ByteBrusher.Framework.Implementation.Access;

public class DirectoryAccess : IDirectoryAccess
{
    public IEnumerable<FileInfo> GetFiles(string path, string searchPattern, SearchOption searchOption)
    {
        var info = new DirectoryInfo(path);
        return info.GetFiles(searchPattern, searchOption);
    }

    public List<string> GetFilesInPath(string path) => Directory.GetFiles(path).ToList<string>();

    public Stream OpenRead(string filename) => File.OpenRead(filename);
}
