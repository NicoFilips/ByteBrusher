using System.Diagnostics.CodeAnalysis;

namespace ByteBrusher.Core.IOptions;

[ExcludeFromCodeCoverage]
public record FileExtensions
{
    public string[] VideoSuffix { get; set; } = [];
    public string[] ImageSuffix { get; set; } = [];
    public string[] DocumentSuffix { get; set; } = [];
}
