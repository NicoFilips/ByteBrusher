using Microsoft.Extensions.DependencyInjection;
using ByteBrusher.Util.Interface.Scan;
using ByteBrusher.Util.Interface.Filter;
using ByteBrusher.Util.Interface.Hash;
using ByteBrusher.Core.File;
using ByteBrusher.Util.Arguments.Interface;

namespace ByteBrusher
{
    public class Program
    {
        /// <summary>
        //Set your path manually here, if you dont want to
        //use the command argument or want to see it working in debug mode
        //Arguments: "-p" / "--path"
        /// </summary>
        private static string _pathToCleanUp = "C://users/nicof/pictures";

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

        /// <summary>
        /// DI Object for ScanUtil Service
        /// </summary>
        private static IScanUtil _scanUtil { get; set; } = null;

        /// <summary>
        /// DI Object for FilterUtil Service
        /// </summary>
        private static IFilterUtil _filterUtil { get; set; } = null;

        /// <summary>
        /// DI Object for CliOptions Service
        /// </summary>
        private static ICliOptions _cliOptions { get; set; } = null;

        private static IHashUtil _hashUtil { get; set; } = null;

        /// <summary>
        /// List of found Files
        /// </summary>
        private static List<FoundFile> _foundFiles = new List<FoundFile>();

        static void Main(string[] args)
        {
            if (args.Length == 0)
                Console.WriteLine("Keine Argumente übergeben!");

            Console.WriteLine("---- < Starting ByteBrusher > ----");

            var host = DependencyResolver.DependencyResolver.CreateHostBuilder(args).Build();

            _scanUtil = host.Services.GetRequiredService<IScanUtil>();
            _filterUtil = host.Services.GetRequiredService<IFilterUtil>();
            _cliOptions = host.Services.GetRequiredService<ICliOptions>();
            _hashUtil = host.Services.GetRequiredService<IHashUtil>();

            Console.WriteLine("Validate CLI Arguments:");

            Console.WriteLine("Get Files ...");
            _foundFiles = _scanUtil.GetFileInfos(_pathToCleanUp).ToList();
            Console.WriteLine("Found: " + _foundFiles.Count.ToString() + " files. Filtering out Images, Pictures and Videos now.");

            _foundFiles = _filterUtil.filterFiles(_foundFiles);
            Console.WriteLine("Filtered List with Console Arguments. Now we have : " + _foundFiles.Count.ToString() + " files left.");

            Dictionary<string, List<FoundFile>> duplicates = _hashUtil.GetDuplicatesAsync(_foundFiles).Result;
            Console.WriteLine("Found " + duplicates.Count.ToString() + " duplicates.");


            Console.WriteLine("---- < ByteBrusher finished > ----");
            Console.ReadKey();

        }
    }



    ///Roadmap
    ///
    /// -> Get all files
    /// --> filter after -> pictures, videos, documents (todo: inject appsettings into configuration/IOptions)
    /// ---> look for duplicates with Hashing
    ///
    ///
    ///
    ///

    ///Todo:
    /// Unterordner berücksichtigen, Memes xcvcxv
}
