using ByteBrusher.Util.Arguments;
using ByteBrusher.Util.Arguments.Interface;
using ByteBrusher.Util.Resource;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

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
                                               services.AddTransient<ICliOptions, CliOptions>();
                                           services.AddOptions();
                                           services.AddLogging();
                                           services.AddUtilServices(configuration);
                                       })
                    .UseSerilog( (hostContext, loggerConfiguration) =>
                                 {
                                     loggerConfiguration
                                         .ReadFrom.Configuration(hostContext.Configuration)
                                         .Enrich.FromLogContext()
                                         .WriteTo.Console()
                                        .WriteTo.File("C://Users/public/Documents.txt");
                                 });
        private static ICliOptions ParseCommandLineOptions(string[] args)
        {
            var parsedOptions = Parser.Default.ParseArguments<CliOptions>(args);
            if (parsedOptions.Tag == ParserResultType.Parsed)
                return ((Parsed<CliOptions>)parsedOptions).Value;

            // Optional: Loggen oder eine Ausnahme werfen, wenn Sie Fehlerbehandlung hinzufügen möchten
            return null;
        }
    }
}
