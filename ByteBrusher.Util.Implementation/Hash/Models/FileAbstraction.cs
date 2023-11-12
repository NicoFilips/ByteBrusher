using ByteBrusher.Util.Abstraction.Hash.Models;

namespace ByteBrusher.Util.Implementation.Hash.Models;

public class FileAbstraction : IFileAbstraction
{
    public Stream StartStream(string filePath) => File.OpenRead(filePath);

    public void Delete(string filePath) => File.Delete(filePath);

    public bool Exists(string filePath) => File.Exists(filePath);
}
