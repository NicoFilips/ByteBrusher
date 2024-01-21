namespace ByteBrusher.Util.Abstraction.Duplicate;

public interface IDuplicateUtil
{
    public List<string> SortFiles(List<string> suffixes, List<string> Files);

    public List<string> SortList(List<string> suffixes, List<string> files);
}
