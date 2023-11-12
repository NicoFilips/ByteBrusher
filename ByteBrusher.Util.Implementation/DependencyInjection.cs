using ByteBrusher.Core.IOptions;
using ByteBrusher.Util.Abstraction.Delete;
using ByteBrusher.Util.Abstraction.Duplicate;
using ByteBrusher.Util.Abstraction.Filter;
using ByteBrusher.Util.Abstraction.Scan;
using ByteBrusher.Util.Implementation.Filter;
using ByteBrusher.Util.Abstraction.Hash;
using ByteBrusher.Util.Abstraction.Hash.Models;
using ByteBrusher.Util.Implementation.Delete;
using ByteBrusher.Util.Implementation.Hash;
using ByteBrusher.Util.Implementation.Hash.Models;
using ByteBrusher.Util.Implementation.Scan;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ByteBrusher.Util.Implementation;

/// <summary>
/// Returns Services for the byteBruhser.Util Namespace
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddUtilServices(this IServiceCollection services, IConfiguration configuration)
        => services
          .AddTransient<IDuplicate, Duplicate.Duplicate>()
          .AddTransient<IScanUtil, ScanUtil>()
          .AddTransient<IFilterUtil, FilterUtil>()
          .AddTransient<IFileAbstraction, FileAbstraction>()
          .AddTransient<IHashUtil, HashUtil>()
          .AddTransient<IDeleteUtil, DeleteUtil>()
          .Configure<FileExtensions>(configuration.GetSection("FileExtensions"));
}
