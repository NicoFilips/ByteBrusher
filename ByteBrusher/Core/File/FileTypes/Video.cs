using ByteBrusher.Core.File.FileTypes.Abstraction;

namespace ByteBrusher.Core.File.FileTypes;

public record Video : IFileType
{
    public string Name => "Video";
}
