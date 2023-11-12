namespace ByteBrusher.Util.Abstraction.Hash.Models;

public interface IFileAbstraction
{
    public Stream StartStream(string filePath);
    public void Delete(string filePath);

    public bool Exists(string filePath);
}
