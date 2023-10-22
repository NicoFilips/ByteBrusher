namespace ByteBrusher.Util.Interface.Hash;

using Core.File;

public interface IHashUtil
{
    /// <summary>
    /// Uses MD5 to calculate the checksum of a file
    /// </summary>
    public Task<string> CalculateChecksumAsync(string file);

    /// <summary>
    /// Compares the checksum of two files
    /// </summary>
    public Task<bool> CompareChecksumAsync(string file, string fileToCompare);

    /// <summary>
    /// Returns a dictionary of files that have the same checksum
    /// </summary>
    public Task<Dictionary<string, List<FoundFile>>> GetDuplicatesAsync(List<FoundFile> files);
}
