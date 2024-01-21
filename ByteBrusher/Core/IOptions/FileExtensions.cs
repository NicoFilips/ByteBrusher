namespace ByteBrusher.Core.IOptions;

public record FileExtensions
{
    public string[] VideoSuffix { get; set; } = [];
    public string[] ImageSuffix { get; set; } = [];
    public string[] DocumentSuffix { get; set; } = [];
}
