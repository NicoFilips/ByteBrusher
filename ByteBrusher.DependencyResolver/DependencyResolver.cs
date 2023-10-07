using ByteBrusher.Records.CmdOptions;
using ByteBrusher.Util.Resource;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ByteBrusher.DependencyResolver
{
    public class DependencyResolver
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
            =>

    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            var options = ParseCommandLineOptions(args);
            if (options != null)
            {
                services.AddSingleton(options);
            }
            services.AddDuplicates();
            services.AddLogging();
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