namespace ByteBrusher.Util.Interface.Hash.Models;

public interface IFileAbstraction
{
    public FileStream StartStream(string filePath);
    public void Delete(string filePath);

    public bool Exists(string filePath);
}
