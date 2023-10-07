
using CommandLine;


namespace ByteBrusher
{
    public class Program
    {
        /// <summary>
        //Set your path manually here, if you dont want to
        //use the command argument or want to see it working in debug mode
        //Arguments: "-p" / "--path"
        /// </summary>
        private static string _pathToCleanUp = "";

        /// <summary>
        /// Flag: should found files be deleted
        /// </summary>
        private static bool _deleteFlag = false;

        /// <summary>
        /// Flag: should Documents be included
        /// </summary>
        private static bool _includeDocuments = false;

        /// <summary>
        /// Flag: should Videos be included
        /// </summary>
        private static bool _includeVideos = false;

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            if (args.Length == 0) { Console.WriteLine("Keine Argumente übergeben!"); }

            Parser.Default.ParseArguments<Options>(args)
    .WithParsed<Options>(o =>
    {
        if (!string.IsNullOrEmpty(o.path))
        {
            Console.WriteLine($"Path to be used: {o.path}");
            _pathToCleanUp += o.path;
        }
        if (!string.IsNullOrEmpty(o.deleteFlag))
        {
            if (o.deleteFlag == "yes" || o.deleteFlag == "true" || o.deleteFlag == "y")
            {
                _deleteFlag = true;
            }
        }
        if (!string.IsNullOrEmpty(o.includeDocuments))
        {
            if (o.includeDocuments == "yes" || o.includeDocuments == "true" || o.includeDocuments == "y")
            {
                _includeDocuments = true;
            }
        }
        if (!string.IsNullOrEmpty(o.includeVideos))
        {
            if (o.includeVideos == "yes" || o.includeVideos == "true" || o.includeVideos == "y")
            {
                _includeVideos = true;
            }
        }


    });

            Console.WriteLine("---- < Starting ByteBrusher > ----");


            Console.WriteLine("Validate CLI Arguments:");


            Console.WriteLine("Get Files ...");

            var allFiles = Directory.GetFiles(_pathToCleanUp).ToList();

            Console.WriteLine(allFiles.Count.ToString() +" files found");
        }
    }
}