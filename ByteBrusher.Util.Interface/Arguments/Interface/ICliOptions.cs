namespace ByteBrusher.Util.Arguments.Interface
{
    public interface ICliOptions
    {
        /// <summary>
        /// Path to clean up
        /// </summary>
        public string path { get; set; }

        /// <summary>
        /// Flag to delete found files
        /// </summary>
        public bool deleteFlag { get; set; }

        /// <summary>
        /// Flag to delete found files
        /// </summary>
        public bool includeVideos { get; set; }

        /// <summary>
        /// Flag to delete found files
        /// </summary>
        public bool includeDocuments { get; set; }
    }
}
