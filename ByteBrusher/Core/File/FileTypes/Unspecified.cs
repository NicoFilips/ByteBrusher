//# me gustaría seguir partiendo #//

using ByteBrusher.Core.Exceptions;
using ByteBrusher.Core.File.FileTypes.Abstraction;

namespace ByteBrusher.Core.File.FileTypes;

public record Unspecified : IFileType
{
    public string Name => throw new FileTypeNotSpecifiedException("File wasn't recognized with the suffixes in the appsettings.json List");
}
