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

        return checksum1 == checksum2;
    }

    public async Task<Dictionary<string, List<FoundFile>>> GetDuplicatesAsync(List<FoundFile> files)
    {
        var fileHashes = new Dictionary<string, List<FoundFile>>();

        foreach (FoundFile file in files)
        {
            foreach (FoundFile fileToCompare in files)
            {
                if (file.FileInfo.Name != fileToCompare.FileInfo.Name)
                {
                    if (await CompareChecksumAsync(file.FileInfo.FullName, fileToCompare.FileInfo.FullName))
                    {
                        if (fileHashes.TryGetValue(file.FileInfo.FullName, out List<FoundFile>? value))
                            value.Add(fileToCompare);
                        else
                            fileHashes[file.FileInfo.FullName] = [new() { FileInfo = fileToCompare.FileInfo, FileType = fileToCompare.FileType }];
                    }
                }
            }
        }
        return fileHashes;
    }
}
