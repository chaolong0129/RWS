using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterOperationServices(this IServiceCollection services)
        {
            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationInstance>(new Operation(Guid.Empty)); // AddInstance
            return services;
        }
    }
}
