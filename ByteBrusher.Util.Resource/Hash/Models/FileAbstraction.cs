using ByteBrusher.Util.Interface.Hash.Models;

namespace ByteBrusher.Util.Resource.Hash.Models;

public class FileAbstraction : IFileAbstraction
{
    public FileStream Start(string filePath)
    {
        return File.OpenRead(filePath);
    }

    public FileStream StartStream(string filePath) => File.OpenRead(filePath);

    public void Delete(string filePath) => File.Delete(filePath);

    public bool Exists(string filePath) => File.Exists(filePath);
}
