using ConquerBackend.Application;
using ConquerBackend.Infrastructure;
using ConquerBackend.Persistence;

namespace ConquerBackend.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI().AddInfrastructureDI(configuration).AddPersistenceDI(configuration);

            return services;
        }
    }
}
