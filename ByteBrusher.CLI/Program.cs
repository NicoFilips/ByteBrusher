using ByteBrusher.Util.Abstraction.Arguments;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ByteBrusher;

/// <summary>
/// Program.cs
/// </summary>
public class Program
{
    /// <summary>
    /// Set your path manually here, if you dont want to
    /// use the command argument or want to see it working in debug mode
    /// Arguments: "-p" / "--path"
    /// </summary>
    private static readonly string _pathToCleanUp = string.Empty;

    /// <summary>
    /// Logger for Program.cs
    /// </summary>
    private static ILogger<Program> _logger = null!;

    /// <summary>
    /// Gets or sets dI Object for CliOptions Service
    /// </summary>
    private static ICliOptions CliOptions { get; set; } = null!;

   /// <summary>
   /// Gets or sets dI Object for CliOptions Service
   /// </summary>
    private static IByteBrusherClient _byteBrusherClient  = null!;

    private static void Main(string[] args)
    {
        IHost host = DependencyResolver.DependencyResolver.CreateHostBuilder(args).Build();

        if (args.Length == 0)
            Console.WriteLine("there were no console arguments!");

        Console.WriteLine("---- < Starting ByteBrusher.CLI > ----");

        CliOptions = host.Services.GetRequiredService<ICliOptions>();
        _byteBrusherClient = host.Services.GetRequiredService<IByteBrusherClient>();
        _logger = host.Services.GetRequiredService<ILogger<Program>>();

        _byteBrusherClient.ExecuteAsync(CliOptions.DeleteFlag, CliOptions.Path);
        _logger.LogInformation("---- < ByteBrusher.CLI finished > ----");
    }
}
