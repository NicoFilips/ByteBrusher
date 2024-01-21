using System.Security.Cryptography;
using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes;
using ByteBrusher.Core.File.FileTypes.Abstraction;
using ByteBrusher.Core.IOptions;
using ByteBrusher.Framework.Abstraction.Access;
using ByteBrusher.Util.Abstraction.Scan;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ByteBrusher.Util.Implementation.Scan;

public class ScanUtil(ILogger<ScanUtil> logger, IDirectoryAccess directoryAccess, IOptions<FileExtensions> options) : IScanUtil
{
    private readonly string[] documents = options.Value.DocumentSuffix;

    private readonly string[] images = options.Value.ImageSuffix;

    private readonly string[] videos = options.Value.VideoSuffix;

    /// <summary>
    ///  Checks if there are any duplicate files in the given directory and returns the list of duplicates
    /// Keep in Mind, that every picture will be hashed and compared so it is a costly operation
    /// </summary>
    public bool GetsAllDuplicates(string directoryPath)
    {
        List<string> files = directoryAccess.GetFilesInPath(directoryPath);
        var fileHashes = new Dictionary<string, List<string>>();

        foreach (string file in files)
        {
            string fileHash = ComputeSha256Hash(file);
            if (fileHashes.TryGetValue(fileHash, out List<string>? fileList))
            {
                if (!fileList.Contains(file))
                    fileList.Add(file);
            }
            else
            {
                fileHashes[fileHash] = [file];
            }
        }
        return true;
    }

    public string ComputeSha256Hash(string filename)
    {
        using var sha256 = SHA256.Create();
        using Stream stream = directoryAccess.OpenRead(filename);
        byte[] hash = sha256.ComputeHash(stream);
        return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
    }

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
            var fileDictionary = new Dictionary<IFileType, string[]>
            {
                { new Document(), documents },
                { new Image(), images },
                { new Video(), videos },
            };

            IFileType? fileType = fileDictionary.FirstOrDefault(entry => entry.Value.Contains(suffix)).Key;
            return fileType ?? new Unspecified();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "An exception occured {ErrorMessage}", exception.Message);
            return new Unspecified();
        }
    }
}
