using Microsoft.Extensions.DependencyInjection;

namespace ByteBrusher.Util.Resource
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDuplicates(this IServiceCollection services)
        {
            services => services.AddTransient<IDuplicate, Duplicate>();
            return services;
        }
    }
}
