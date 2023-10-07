﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.Loader;
using ByteBrusher.DependencyResolver;

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


        private static List<string> _foundFiles = new List<string>();

        static void Main(string[] args)
        {
            if (args.Length == 0) { Console.WriteLine("Keine Argumente übergeben!"); }
            var host = DependencyResolver.DependencyResolver.CreateHostBuilder(args).Build();




            Console.WriteLine("---- < Starting ByteBrusher > ----");


            Console.WriteLine("Validate CLI Arguments:");


            Console.WriteLine("Get Files ...");

            var allFiles = Directory.GetFiles(_pathToCleanUp).ToList();

            Console.WriteLine(allFiles.Count.ToString() +" files found");
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
    /// Unterordner berücksichtigen, Memes 
}