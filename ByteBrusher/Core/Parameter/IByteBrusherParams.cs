namespace ByteBrusher.Core.Parameter;

public interface IByteBrusherParams
{
    public string Path { get; set; }

    public bool DeleteFlag { get; set; }

    public bool IncludeVideos { get; set; }

    public bool IncludeDocuments { get; set; }
}
