using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBrusher.Models.Util.Duplicate
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDuplicates(IServiceCollection services) 
        {
            services => services.AddTransient<Duplicate, IDuplicate>();
        }
    }
}
