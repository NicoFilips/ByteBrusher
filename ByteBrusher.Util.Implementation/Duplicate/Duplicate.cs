using Microsoft.Extensions.Logging;
using ByteBrusher.Util.Abstraction.Duplicate;

namespace ByteBrusher.Util.Implementation.Duplicate;


public class Duplicate : IDuplicate
{
    private ILogger<Duplicate> Logger { get; init; }

    public Duplicate(ILogger<Duplicate> logger)
    {
        Logger = logger;
    }

    public static List<string> SortFiles(List<string> suffixes, List<string> Files)
    {
        var sortedList = new List<string>();
        foreach (string file in Files)
        {
            if (suffixes.Any(suffix => file.EndsWith(suffix, StringComparison.Ordinal)))
                sortedList.Add(file);
        }
        return sortedList;
    }

    public static List<string> SortList(List<string> suffixes, List<string> files)
    {
        var suffixSet = new HashSet<string>(suffixes);
        return files.Where(file => suffixSet.Any(file.EndsWith)).ToList();
    }
}
