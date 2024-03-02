using ByteBrusher.Framework.Abstraction.Access;

namespace ByteBrusher.Framework.Implementation.Access;

public class DirectoryAccess : IDirectoryAccess
{
#pragma warning disable IDE0305
    public List<string> GetFilesInPath(string path) => Directory.GetFiles(path).ToList();
#pragma warning restore IDE0305
    public Stream OpenRead(string filename) => File.OpenRead(filename);
}
