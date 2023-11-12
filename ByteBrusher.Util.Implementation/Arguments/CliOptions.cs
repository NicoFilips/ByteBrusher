using ByteBrusher.Util.Abstraction.Arguments;
using CommandLine;

namespace ByteBrusher.Util.Implementation.Arguments;

public record CliOptions : ICliOptions
{
    /// <inheritdoc/>
    [Option('p', "path", Required = true, HelpText = "Set the path to the folder.")]
    public string Path { get; set; } = string.Empty;

    /// <inheritdoc/>
    [Option('d', "delete", Required = false, HelpText = "Flag if you want to instant delete the those files.")]
    public bool DeleteFlag { get; set; } = false;

    /// <inheritdoc/>
    [Option('v', "video", Required = false, HelpText = "Flag if you also want to search for videos.")]
    public bool IncludeVideos { get; set; } = false;

    /// <inheritdoc/>
    [Option('t', "textdocuments", Required = false, HelpText = "Flag if you also want to search for documents.")]
    public bool IncludeDocuments { get; set; } = false;
}
