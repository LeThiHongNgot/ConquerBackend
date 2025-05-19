using ConquerBackend.Shared.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ConquerBackend.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {

            var scopes = typeof(DependencyInjection).Assembly.ExportedTypes.Where(t => typeof(IServiceDependency).IsAssignableFrom(t) && t.IsClass).ToList();
            foreach (var scope in scopes)
            {
                var interfaceOfScoped = scope.GetInterface($"I{scope.Name}");
                services.AddScoped(interfaceOfScoped, scope);
            }
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }

    }
}
    