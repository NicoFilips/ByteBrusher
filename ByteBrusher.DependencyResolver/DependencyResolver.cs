using Microsoft.Extensions.Hosting;

namespace ByteBrusher.DependencyResolver
{
    public class DependencyResolver
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddDuplica<IDuplicate, Duplicate>();
        });

    }
}