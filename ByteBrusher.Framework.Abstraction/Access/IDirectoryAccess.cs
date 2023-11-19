namespace ByteBrusher.Framework.Abstraction.Access;

public interface IDirectoryAccess
{
    public IEnumerable<FileInfo> GetFiles(string path, string searchPattern, SearchOption searchOption);

    public List<string> GetFilesInPath(string path);

    public Stream OpenRead(string filename);
}
