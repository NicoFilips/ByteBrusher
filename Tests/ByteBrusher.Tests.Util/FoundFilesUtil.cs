using ByteBrusher.Core.File;
using ByteBrusher.Core.File.FileTypes.Abstraction;

namespace ByteBrusher.Tests.Util;

public class FoundFilesUtil
{
    // Hilfsmethode zum Erstellen einer Datei und Rückgabe ihres Pfades
    public static string CreateFile(string directoryPath, string fileName)
    {
        string filePath = Path.Combine(directoryPath, fileName);
        File.Create(filePath).Close();
        return filePath;
    }

    public static FoundFile CreateFoundFile(string directoryPath, string fileName, IFileType type)
    {
        string filePath = Path.Combine(directoryPath, fileName);
        File.Create(filePath).Close();
        return new FoundFile()
        {
            FileInfo = new FileInfo(filePath),
            FileType = type,
            GotDeleted = false
        };
    }

    public static Dictionary<string, List<FoundFile>> CreateDuplicateFileEntry(string filePath, FoundFile[] foundFiles)
    {
        var duplicateFiles = new Dictionary<string, List<FoundFile>>();
        ArgumentNullException.ThrowIfNull(filePath);

        foreach (FoundFile file in foundFiles)
        {
            if (duplicateFiles.TryGetValue(file.FileInfo.Name, out List<FoundFile>? value))
            {
                value.Add(file);
            }
            else
            {
                duplicateFiles.Add(file.FileInfo.Name, new List<FoundFile> {file});
            }
        }
        return duplicateFiles;
    }

    public static Dictionary<string, List<FoundFile>> CreateDuplicateFileEntry(string filePath, string? tempDirectory, IFileType type)
    {
        var random = new Random();
        int loopCount = random.Next(1, 6); // Generiert eine Zahl zwischen 1 und 5

        tempDirectory ??= Path.GetTempPath();
        var listFiles = new List<FoundFile>();
        for (int i = 0; i < loopCount; i++)
        {
            listFiles.Add(CreateFoundFile(tempDirectory, Path.GetRandomFileName(), type));
        }
        return new Dictionary<string, List<FoundFile>> { { filePath, listFiles } };
    }

    public static Dictionary<string, List<FoundFile>> CreateDuplicateRange(List<FoundFile> files)
    {
        var duplicateFiles = new Dictionary<string, List<FoundFile>>();
        foreach (FoundFile file in files)
        {
            CreateDuplicateFileEntry(file.FileInfo.Name, file.FileInfo.DirectoryName, file.FileType);
            duplicateFiles.TryAdd(file.FileInfo.Name, new List<FoundFile> {file});
        }
        return duplicateFiles;
    }
}
