using ConquerBackend.Domain;
using ConquerBackend.Domain.Dapper;
using ConquerBackend.Domain.Respositories;
using ConquerBackend.Persistence.Context;
using ConquerBackend.Persistence.Dapper;
using ConquerBackend.Persistence.Repositories;
using ConquerBackend.Shared.DependencyInjection;
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
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped(typeof(IDapperRepository), typeof(DapperRepository));

            var scopes = typeof(DependencyInjection).Assembly.ExportedTypes.Where(t => typeof(IScopedDependency).IsAssignableFrom(t) && t.IsClass).ToList();
            foreach (var scope in scopes)
            {
                var interfaceOfScoped = scope.GetInterface($"I{scope.Name}");   
                services.AddScoped(interfaceOfScoped, scope);
            }
           

            services.AddScoped(typeof(IUnitOfWork), services =>
            {
                return services.GetRequiredService<ConquerBackendContext>();
            });

            var connectionString = configuration.GetConnectionString("CONQUERBACKEND");

            services.AddDbContext<ConquerBackendContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ConquerBackendContext).Assembly.FullName)));
        }
    }
}
