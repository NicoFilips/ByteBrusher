using ByteBrusher.Util.Arguments.Interface;
using CommandLine;

namespace ByteBrusher.Util.Arguments
{
    public record CliOptions : ICliOptions
    {
        /// <inheritdoc/>
        [Option('p', "path", Required = true, HelpText = "Set the path to the folder.")]
        public string path { get; set; }

        /// <inheritdoc/>
        [Option('d', "delete", Required = false, HelpText = "Flag if you want to instant delete the those files.")]
        public bool deleteFlag { get; set; } = false;

        /// <inheritdoc/>
        [Option('v', "video", Required = false, HelpText = "Flag if you also want to search for videos.")]
        public bool includeVideos { get; set; } = false;

        /// <inheritdoc/>
        [Option('t', "textdocuments", Required = false, HelpText = "Flag if you also want to search for documents.")]
        public bool includeDocuments { get; set; } = false;

    }
}
