using System.Diagnostics.CodeAnalysis;
using ByteBrusher.Util.Abstraction.Duplicate;
using Microsoft.Extensions.Logging;

namespace ByteBrusher.Util.Implementation.Duplicate;

public class DuplicateUtil : IDuplicateUtil
{
    private readonly ILogger<DuplicateUtil> _logger = null!;

    public DuplicateUtil(ILogger<DuplicateUtil> logger)
    {
        _logger = logger;
    }

    [SuppressMessage("Performance", "CA1848:Use LoggerMessage delegates",
                     Justification = "Einfachheit und Lesbarkeit bevorzugt.")]
    public List<string> SortFiles(List<string> suffixes, List<string> Files)
    {
        _logger.LogDebug("sortinging files");
        var sortedList = new List<string>();
        foreach (string file in Files)
        {
            if (suffixes.Any(suffix => file.EndsWith(suffix, StringComparison.Ordinal)))
                sortedList.Add(file);
        }
        return sortedList;
    }

    [SuppressMessage("Performance", "CA1848:Use LoggerMessage delegates",
                     Justification = "Einfachheit und Lesbarkeit bevorzugt.")]
    public List<string> SortList(List<string> suffixes, List<string> files)
    {
        _logger.LogDebug("sorting list");
        var suffixSet = new HashSet<string>(suffixes);
        return files.Where(file => suffixSet.Any(file.EndsWith)).ToList();
    }
}
