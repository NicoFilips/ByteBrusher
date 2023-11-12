using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Core.IOptions;
using ByteBrusher.Util.Abstraction.Scan;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using ByteBrusher.Core.File.FileTypes.Abstraction;

namespace ByteBrusher.Util.Implementation.Scan;

public class ScanUtil : IScanUtil
{
    private readonly ILogger<ScanUtil> _logger;
    private readonly IOptions<FileExtensions> _options;

    public ScanUtil(ILogger<ScanUtil> logger, IOptions<FileExtensions> options)
    {
        _logger = logger;
        _options = options;
    }

    public static bool IsDuplicate(string directoryPath)
    {
        string[] files = Directory.GetFiles(directoryPath);
        var fileHashes = new Dictionary<string, List<string>>();

        foreach (string file in files)
        {
            string fileHash = ComputeSha256Hash(file);
            if (fileHashes.TryGetValue(fileHash, out List<string>? value))
                value.Add(file);
            else
                fileHashes[fileHash] = new List<string> { file };
        }
        return true;
    }

    private static string ComputeSha256Hash(string filename)
    {
        using var sha256 = SHA256.Create();
        using FileStream stream = File.OpenRead(filename);
        byte[] hash = sha256.ComputeHash(stream);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }

    public static List<string> GetFiles(string path) => Directory.GetFiles($"{path}", path).ToList();

    /// <inheritdoc/>
    public IEnumerable<FoundFile> GetFileInfos(string path)
    {
        var info = new DirectoryInfo(path);
        foreach (FileInfo file in info.GetFiles("*", SearchOption.AllDirectories).ToList())
        {
            yield return new FoundFile
            {
                FileInfo = file,
                FileType = ClassifyFile(file.Name),
            };
        }
    }

    public IFileType ClassifyFile(string filename)
    {
        try
        {
            string suffix = Path.GetExtension(filename);
            var FileDictionary = new Dictionary<IFileType, string[]>
            {
                { new Document(), _options.Value.DocumentSuffix },
                { new Image(), _options.Value.ImageSuffix },
                { new Video(), _options.Value.VideoSuffix },
            };
            return FileDictionary.FirstOrDefault(entry => entry.Value.Contains(suffix)).Key;
        }
        catch (Exception)
        {
            return new Unspecified();
        }
    }
}
