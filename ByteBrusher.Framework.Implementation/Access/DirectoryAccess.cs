using ByteBrusher.Framework.Abstraction.Access;

namespace ByteBrusher.Framework.Implementation.Access;

public class DirectoryAccess : IDirectoryAccess
{
    public List<string> GetFilesInPath(string path) => Directory.GetFiles(path).ToList<string>();

    public Stream OpenRead(string filename) => File.OpenRead(filename);
}
