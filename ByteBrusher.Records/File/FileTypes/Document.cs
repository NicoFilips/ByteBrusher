using ByteBrusher.Core.File.FileTypes.Abstraction;

namespace ByteBrusher.Core.File.FileTypes;

public record Document : IFileType
{
    public string Name => "Document";

    private static readonly string[] Suffix = { ".doc", ".docx", ".pdf", ".txt", ".xlsx", ".xls" };
}
