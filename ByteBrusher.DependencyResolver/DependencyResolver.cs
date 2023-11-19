using ByteBrusher.Framework.Implementation;
using ByteBrusher.Util.Abstraction.Arguments;
using ByteBrusher.Util.Implementation;
using ByteBrusher.Util.Implementation.Arguments;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ByteBrusher.DependencyResolver;


public class DependencyResolver
{
    public static IHostBuilder CreateHostBuilder(string[] args)
        =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                                   {
                                       IConfiguration configuration = hostContext.Configuration;
                                       ICliOptions? options = ParseCommandLineOptions(args);
                                       if (options != null)
                                           services.AddTransient<ICliOptions, CliOptions>();
                                       services.AddOptions();
                                       services.AddLogging();
                                       services.AddUtilServices(configuration);
                                        services.AddFrameworkServices();
                                   })
                .UseSerilog( (hostContext, loggerConfiguration) =>
                             {
                                 loggerConfiguration
                                    .ReadFrom.Configuration(hostContext.Configuration)
                                    .Enrich.FromLogContext()
                                    .WriteTo.Console(formatProvider: System.Globalization.CultureInfo.InvariantCulture)
                                    .WriteTo.File("C://Users/public/Documents.txt", formatProvider: System.Globalization.CultureInfo.InvariantCulture);
                             });
    private static CliOptions ParseCommandLineOptions(string[] args)
    {
        ParserResult<CliOptions>? parsedOptions = Parser.Default.ParseArguments<CliOptions>(args);
        if (parsedOptions.Tag == ParserResultType.Parsed)
            return ((Parsed<CliOptions>)parsedOptions).Value;

        // Optional: Loggen oder eine Ausnahme werfen, wenn Sie Fehlerbehandlung hinzufügen möchten
        throw new ArgumentNullException(nameof(args));
    }
}
