using ByteBrusher.Framework.Abstraction.Access;
using ByteBrusher.Framework.Implementation.Access;
using Microsoft.Extensions.DependencyInjection;

namespace ByteBrusher.Framework.Implementation;

/// <summary>
/// Returns Services for the byteBruhser.Util Namespace
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddFrameworkServices(this IServiceCollection services)
        => services
           .AddTransient<IDirectoryAccess, DirectoryAccess>();
}
