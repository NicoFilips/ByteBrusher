using ByteBrusher.Core.File.FileTypes.Abstraction;

namespace ByteBrusher.Core.File.FileTypes;

public record Video : IFileType
{
    public string Name => "Video";

    private static readonly string[] SUFFIX = { ".mp4", ".avi", ".mkv", ".mov", ".flv" };
}
