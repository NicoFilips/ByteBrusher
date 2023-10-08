using ByteBrusher.Records.CmdOptions;
using ByteBrusher.Util.Resource;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;

namespace ByteBrusher.DependencyResolver
{
    public class DependencyResolver
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        =>  
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                IConfiguration configuration = hostContext.Configuration;
                var options = ParseCommandLineOptions(args);
                if (options != null)
                {
                    services.AddSingleton(options);
                }
                services.AddOptions();
                services.AddLogging();
                services.AddUtilServices(configuration);
            });
            





        private static Options ParseCommandLineOptions(string[] args)
        {
            var parsedOptions = Parser.Default.ParseArguments<Options>(args);
            if (parsedOptions.Tag == ParserResultType.Parsed)
            {
                return ((Parsed<Options>)parsedOptions).Value;
            }

            // Optional: Loggen oder eine Ausnahme werfen, wenn Sie Fehlerbehandlung hinzufügen möchten
            return null;
        }
    }
}