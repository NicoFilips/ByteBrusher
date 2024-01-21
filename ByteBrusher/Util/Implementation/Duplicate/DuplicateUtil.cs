using ByteBrusher.Util.Abstraction.Duplicate;
using Microsoft.Extensions.Logging;

namespace ByteBrusher.Util.Implementation.Duplicate;

public class DuplicateUtil(ILogger<DuplicateUtil> logger) : IDuplicateUtil
{
    public List<string> SortFiles(List<string> suffixes, List<string> Files)
    {
        logger.LogDebug("sortinging files");
        var sortedList = new List<string>();
        foreach (string file in Files)
        {
            if (suffixes.Any(suffix => file.EndsWith(suffix, StringComparison.Ordinal)))
                sortedList.Add(file);
        }
        return sortedList;
    }

    public List<string> SortList(List<string> suffixes, List<string> files)
    {
        logger.LogDebug("sorting list");
        var suffixSet = new HashSet<string>(suffixes);
        return files.Where(file => suffixSet.Any(file.EndsWith)).ToList();
    }
}
