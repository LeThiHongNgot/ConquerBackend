using ConquerBackend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConquerBackend.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceDI(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext(configuration);
            return services;

        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CONQUERBACKEND");

            services.AddDbContext<ConquerBackendContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ConquerBackendContext).Assembly.FullName)));
        }
    }
}
