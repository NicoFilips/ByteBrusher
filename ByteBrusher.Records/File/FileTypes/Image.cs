using ByteBrusher.Core.File.FileTypes.Abstraction;

namespace ByteBrusher.Core.File.FileTypes;

public record Image : IFileType
{
    public string Name => "Image";

    private static readonly string[] SUFFIX = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
}
