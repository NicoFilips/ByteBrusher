using ByteBrusher.Core.IOptions;
using ByteBrusher.Util.Interface.Filter;
using ByteBrusher.Util.Interface.Scan;
using ByteBrusher.Util.Resource.Duplicate;
using ByteBrusher.Util.Resource.Filter;
using ByteBrusher.Util.Resource.Scan;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ByteBrusher.Util.Resource
{
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
                .Configure<FileExtensions>(configuration.GetSection("FileExtensions"));
            
    }
}
