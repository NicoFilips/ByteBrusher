namespace ByteBrusher.Core.Parameter;

public class ByteBrusherParams : IByteBrusherParams
{
    public string Path { get; set; } = string.Empty;
    public bool DeleteFlag { get; set; }
    public bool IncludeVideos { get; set; }
    public bool IncludeDocuments { get; set; }
}
