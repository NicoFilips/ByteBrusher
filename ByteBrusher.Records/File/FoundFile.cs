using ByteBrusher.Core.File.FileTypes.Abstraction;

namespace ByteBrusher.Core.File;

public record FoundFile : IDisposable
{
    public IFileType FileType { get; set; } = null!;

    public FileInfo FileInfo { get; set; } = null!;
    public bool GotDeleted { get; set; }

    public void Dispose() => GC.SuppressFinalize(this);
}
