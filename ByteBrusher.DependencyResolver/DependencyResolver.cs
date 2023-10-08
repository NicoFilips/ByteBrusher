using ByteBrusher.Records.CmdOptions;
using ByteBrusher.Util.Resource;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.CompilerServices;

namespace ByteBrusher.DependencyResolver
{
    public class DependencyResolver
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
            =>

    Host.CreateApplicationBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            var options = ParseCommandLineOptions(args);
            if (options != null)
            {
                services.AddSingleton(options);
            }
            services.AddOptions();
            services.AddLogging();
            services.AddUtilServices();
        });

        public static IHostBuilder CreateHostBuilder2(string[] args)
        {
            
            IHostBuilder host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                var options = ParseCommandLineOptions(args);
                if (options != null)
                {
                    services.AddSingleton(options);
                }
                services.AddOptions();
                services.AddLogging();
                services.confi
                services.AddUtilServices(host.);
            });
            host.
        }





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