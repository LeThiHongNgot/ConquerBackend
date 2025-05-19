using ConquerBackend.Application.Common;
using Microsoft.Extensions.DependencyInjection;

namespace ConquerBackend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddTransient<IDispatch, Dispatch>();
            return services;
        }
    }
}
