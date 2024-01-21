using ByteBrusher.Core.File.FileTypes.Abstraction;

namespace ByteBrusher.Core.File.FileTypes;

public record Document : IFileType
{
    public string Name => "Document";
}
