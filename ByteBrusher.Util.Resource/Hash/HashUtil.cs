using ByteBrusher.Util.Interface.Hash;

namespace ByteBrusher.Util.Resource.Hash;

using Core.File;
using Interface.Hash.Models;

public class HashUtil : IHashUtil
{
    public IFileAbstraction _fileStream { get; set; }

    public HashUtil(IFileAbstraction fileStream)
    {
        _fileStream = fileStream;
    }

    public async Task<string> CalculateChecksumAsync(string filePath)
    {
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            using (FileStream stream = _fileStream.StartStream(filePath))
            {
                byte[] hash = await md5.ComputeHashAsync(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }

    public async Task<bool> CompareChecksumAsync(string file, string fileToCompare)
    {
        string checksum1 = await CalculateChecksumAsync(file);
        string checksum2 = await CalculateChecksumAsync(fileToCompare);

        return checksum1 == checksum2;
    }

    public async Task<Dictionary<string, List<FoundFile>>> GetDuplicatesAsync(List<FoundFile> files)
    {
        Dictionary<string, List<FoundFile>> fileHashes = new Dictionary<string, List<FoundFile>>();

        foreach (var file in files)
        {
            foreach (var fileToCompare in files)
            {
                if (file.fileInfo.Name != fileToCompare.fileInfo.Name)
                {
                    if (await CompareChecksumAsync(file.fileInfo.FullName, fileToCompare.fileInfo.FullName))
                    {
                        if (fileHashes.ContainsKey(file.fileInfo.FullName))
                            fileHashes[file.fileInfo.FullName].Add(fileToCompare);
                        else
                            fileHashes[file.fileInfo.FullName] = new List<FoundFile> { new FoundFile { fileInfo = fileToCompare.fileInfo, fileType = fileToCompare.fileType } };
                    }
                }
            }
        }
        return fileHashes;
    }
}
