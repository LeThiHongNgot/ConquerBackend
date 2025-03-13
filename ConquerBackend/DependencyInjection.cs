using ConquerBackend.Application;

namespace ConquerBackend.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI(configuration);

              return services;
        }
    }
}
