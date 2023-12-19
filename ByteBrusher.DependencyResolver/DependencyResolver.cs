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


public static class DependencyResolver
{
    private static readonly string _logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Documents");
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
                                        services.AddByteBrusher();
                                   })
                .UseSerilog( (hostContext, loggerConfiguration) =>
                             {
                                 loggerConfiguration
                                    .ReadFrom.Configuration(hostContext.Configuration)
                                    .Enrich.FromLogContext()
                                    .WriteTo.Console(formatProvider: System.Globalization.CultureInfo.InvariantCulture)
                                    .WriteTo.File("_logPath", formatProvider: System.Globalization.CultureInfo.InvariantCulture);
                             });
    public static CliOptions ParseCommandLineOptions(string[] args)
    {
        ParserResult<CliOptions>? parsedOptions = Parser.Default.ParseArguments<CliOptions>(args);
        return parsedOptions.Tag == ParserResultType.Parsed
            ? ((Parsed<CliOptions>)parsedOptions).Value
            : throw new ArgumentNullException(nameof(args));
    }
}
