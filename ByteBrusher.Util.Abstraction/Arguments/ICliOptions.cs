namespace ByteBrusher.Util.Abstraction.Arguments;

public interface ICliOptions
{
    /// <summary>
    /// Path to clean up
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// Flag to delete found files
    /// </summary>
    public bool DeleteFlag { get; set; }

    /// <summary>
    /// Flag to delete found files
    /// </summary>
    public bool IncludeVideos { get; set; }

    /// <summary>
    /// Flag to delete found files
    /// </summary>
    public bool IncludeDocuments { get; set; }
}
