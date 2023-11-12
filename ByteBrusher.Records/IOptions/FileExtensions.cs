namespace ByteBrusher.Core.IOptions;

public record FileExtensions
{
    public string[] VideoSuffix { get; set; } = Array.Empty<string>();
    public string[] ImageSuffix { get; set; } = Array.Empty<string>();
    public string[] DocumentSuffix { get; set; } = Array.Empty<string>();
}
