using ByteBrusher.Core.File;
using ByteBrusher.Util.Abstraction.Hash;
using ByteBrusher.Util.Abstraction.Hash.Models;
using Microsoft.Extensions.Logging;

namespace ByteBrusher.Util.Implementation.Hash;

public class HashUtil(ILogger<HashUtil> logger, IFileAbstraction fileStream) :
    IHashUtil
{
    private ILogger<HashUtil> Logger { get; init; } = logger;
    private IFileAbstraction FileStream { get; set; } = fileStream;

    public async Task<string> CalculateChecksumAsync(string file)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        await using Stream stream = FileStream.StartStream(file);
        byte[] hash = await sha256.ComputeHashAsync(stream);
        return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
    }

    public async Task<bool> CompareChecksumAsync(string file, string fileToCompare)
    {
        string checksum1 = await CalculateChecksumAsync(file);
        string checksum2 = await CalculateChecksumAsync(fileToCompare);

        if (checksum1 != checksum2)
            return false;

        Logger.LogInformation("Files {File} and {File2} are duplicates", file, fileToCompare);
        return true;
    }

    public async Task<Dictionary<string, List<FoundFile>>> GetDuplicatesAsync(List<FoundFile> files)
    {
        var checksumsToFiles = new Dictionary<string, List<FoundFile>>();
        var fileHashes = new Dictionary<string, List<FoundFile>>();

        foreach (FoundFile file in files)
        {
            string checksum = await CalculateChecksumAsync(file.FileInfo.FullName);
            if (checksumsToFiles.TryGetValue(checksum, out List<FoundFile>? fileList))
            {
                fileList.Add(file);
            }
            else
            {
                checksumsToFiles[checksum] = new List<FoundFile> { file };
            }
        }

        foreach (KeyValuePair<string, List<FoundFile>> entry in checksumsToFiles)
        {
            if (entry.Value.Count > 1)
            {
                foreach (FoundFile file in entry.Value)
                {
                    fileHashes[file.FileInfo.FullName] = entry.Value.Where(f => f != file).ToList();
                }
            }
        }

        return fileHashes;
    }
}
