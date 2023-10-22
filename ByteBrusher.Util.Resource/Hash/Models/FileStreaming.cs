using ByteBrusher.Util.Interface.Hash.Models;

namespace ByteBrusher.Util.Resource.Hash.Models;

public class FileStreaming : IFileStreaming
{
    public FileStream Start(string filePath)
    {
        return File.OpenRead(filePath);
    }
}
