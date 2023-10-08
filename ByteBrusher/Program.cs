using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.Loader;
using ByteBrusher.DependencyResolver;
using ByteBrusher.Util.Resource.Scan;
using ByteBrusher.Util.Interface.Scan;

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



        private static List<string> _foundFiles = new List<string>();

        static void Main(string[] args)
        {
            if (args.Length == 0) { Console.WriteLine("Keine Argumente übergeben!"); }

            Console.WriteLine("---- < Starting ByteBrusher > ----");

            var host = DependencyResolver.DependencyResolver.CreateHostBuilder(args).Build();
            _scanUtil = host.Services.GetRequiredService<IScanUtil>();

            Console.WriteLine("Validate CLI Arguments:");

            Console.WriteLine("Get Files ...");
            var allFiles = _scanUtil.GetFileInfos(_pathToCleanUp);

            Console.WriteLine("Found: " + allFiles.Count.ToString() + " files. Filtering out Images, Pictures and Videos now.");




        }
    }



    ///Roadmap
    ///
    /// -> Get all files
    /// --> filter after -> pictures, videos, documents (todo: inject appsettings into configuration/IOptions)
    /// ---> look for duplicates
    /// 
    /// 
    /// 
    ///

    ///Todo:
    /// Unterordner berücksichtigen, Memes xcvcxv
}