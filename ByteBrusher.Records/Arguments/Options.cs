using CommandLine;

namespace ByteBrusher.Core.Arguments
{
    public record Options
    {
        /// <summary>
        /// Path to clean up
        /// </summary>
        [Option('p', "path", Required = true, HelpText = "Set the path to the folder.")]
        public string path { get; set; } = string.Empty;

        /// <summary>
        /// Flag to delete found files
        /// </summary>
        [Option('d', "delete", Required = false, HelpText = "Flag if you want to instant delete the those files.")]
        public string deleteFlag { get; set; } = bool.FalseString;

        /// <summary>
        /// Flag to delete found files
        /// </summary>
        [Option('v', "video", Required = false, HelpText = "Flag if you also want to search for videos.")]
        public string includeVideos { get; set; } = bool.FalseString;

        /// <summary>
        /// Flag to delete found files
        /// </summary>
        [Option('t', "textdocuments", Required = false, HelpText = "Flag if you also want to search for documents.")]
        public string includeDocuments { get; set; } = bool.FalseString;

    }
}
