namespace ByteBrusher.Framework.Abstraction.Access;

public interface IDirectoryAccess
{
    public List<string> GetFilesInPath(string path);

    public Stream OpenRead(string filename);
}
