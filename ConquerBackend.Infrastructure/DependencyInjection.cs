using ConquerBackend.Application.Common;
using ConquerBackend.Infrastructure.Quartz;
using ConquerBackend.Infrastructure.Redis.Abtractions;
using ConquerBackend.Infrastructure.Redis;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Quartz;
using Quartz.AspNetCore;


namespace ConquerBackend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDispatch, Dispatch>();
            services.AddScoped<IRedisService, RedisService>();

            //services.AddScoped<StoreToRedisJob>();
            services.AddQuartz(q =>
            {
                // Register the job
                var jobKey = new JobKey("StoreToRedisJob");

                q.AddJob<StoreToRedisJob>(opts => opts.WithIdentity(jobKey));

                // Trigger chạy mỗi 5 phút
                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("StoreToRedisJob-trigger")
                    .WithSimpleSchedule(x => x
                        .WithInterval(TimeSpan.FromSeconds(5))
                        .RepeatForever()
                    )
                );
            });

            // ASP.NET Core hosting (để job chạy nền)
            services.AddQuartzServer(options =>
            {
                options.WaitForJobsToComplete = true;
            });
            // đăng ký redis
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Hangfire:Redis:Configuration"];
                options.InstanceName = configuration["Hangfire:Redis:InstanceName"]; // mặc định là ""
            });
            // đăng ký hangfire
            services.AddHangfire(config =>
            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                  .UseSimpleAssemblyNameTypeSerializer()
                  .UseRecommendedSerializerSettings()
                  .UseSqlServerStorage(configuration.GetConnectionString("CONQUERBACKEND")));
            services.AddHangfireServer();
            return services;
        }
    }
}
