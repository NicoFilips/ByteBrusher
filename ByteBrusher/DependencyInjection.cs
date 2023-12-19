using Microsoft.Extensions.DependencyInjection;

namespace ByteBrusher;

public static class DependencyInjection
{
    public static IServiceCollection AddByteBrusher(this IServiceCollection services)
    {
        services.AddTransient<IByteBrusherClient, ByteBrusherClient>();
        return services;
    }
}
