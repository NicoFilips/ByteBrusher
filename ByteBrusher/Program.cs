using ByteBrusher.Core.File;
using ByteBrusher.Util.Abstraction.Arguments;
using ByteBrusher.Util.Abstraction.Delete;
using ByteBrusher.Util.Abstraction.Filter;
using ByteBrusher.Util.Abstraction.Hash;
using ByteBrusher.Util.Abstraction.Scan;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ByteBrusher;

/// <summary>
/// Program.cs
/// </summary>
internal sealed class Program
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
    /// Flag: should found files be deleted
    /// </summary>
    public static bool DeleteFlag { get; }

    /// <summary>
    /// Gets or sets dI Object for ScanUtil Service
    /// </summary>
    private static IScanUtil ScanUtil { get; set; } = null!;

    /// <summary>
    /// Gets or sets dI Object for FilterUtil Service
    /// </summary>
    private static IFilterUtil FilterUtil { get; set; } = null!;

    /// <summary>
    /// Gets or sets dI Object for CliOptions Service
    /// </summary>
    private static ICliOptions CliOptions { get; set; } = null!;

    private static IHashUtil HashUtil { get; set; } = null!;

    private static IDeleteUtil DeleteUtil { get; set; } = null!;

    private static void Main(string[] args)
    {
        IHost host = DependencyResolver.DependencyResolver.CreateHostBuilder(args).Build();

        if (args.Length == 0)
            Console.WriteLine("there were no console arguments!");

        Console.WriteLine("---- < Starting ByteBrusher > ----");

        // Like this instead of an constructor because DI injection doesn't work before building the host - obviously  🤓👆
        _logger = host.Services.GetRequiredService<ILogger<Program>>();
        ScanUtil = host.Services.GetRequiredService<IScanUtil>();
        FilterUtil = host.Services.GetRequiredService<IFilterUtil>();
        CliOptions = host.Services.GetRequiredService<ICliOptions>();
        HashUtil = host.Services.GetRequiredService<IHashUtil>();
        DeleteUtil = host.Services.GetRequiredService<IDeleteUtil>();

        _logger.LogInformation("Starting ByteBrusher ...");
        _logger.LogInformation("Validate CLI Arguments:");

        _logger.LogInformation("Get Files ...");
         var foundFiles = ScanUtil.GetFileInfos(_pathToCleanUp).ToList();
        _logger.LogInformation("Found: {FoundFileCount} files. Filtering out Images, Pictures and Videos now.", foundFiles.Count);

        foundFiles = FilterUtil.FilterFiles(foundFiles);
        _logger.LogInformation("Filtered List with Console Arguments. Now we have : {FoundFileCount} files left.", foundFiles.Count);

        Dictionary<string, List<FoundFile>> duplicates = HashUtil.GetDuplicatesAsync(foundFiles).Result;
        _logger.LogInformation("Found {DuplicatesCount} duplicates.", duplicates.Count);

        foreach (KeyValuePair<string, List<FoundFile>> duplicate in duplicates)
        {
            if (DeleteFlag)
            {
                _logger.LogInformation("Deleting Files now ...");
                DeleteUtil.TryDelete(duplicate.Value).SwitchFirst(
                                                            deleted => Console.WriteLine("Deletation worked"),
                                                            error => Console.WriteLine(error.Description));
                _logger.LogInformation("Deleted Files.");
            }
        }

        _logger.LogInformation("---- < ByteBrusher finished > ----");
    }
}
