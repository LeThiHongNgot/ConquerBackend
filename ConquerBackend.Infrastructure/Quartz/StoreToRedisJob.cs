using System.Text.Json;
using ConquerBackend.Application.Features.User.Interface;
using ConquerBackend.Domain.Jobs;
using Microsoft.Extensions.Caching.Distributed;
using Quartz;

namespace ConquerBackend.Infrastructure.Quartz
{
    public class StoreToRedisJob : IJobBase, IJob
    {
        private readonly IGetUserQuery _dataService;
        private readonly IDistributedCache _redisCache;

        public StoreToRedisJob(IGetUserQuery dataService, IDistributedCache redisCache)
        {
            _dataService = dataService;
            _redisCache = redisCache;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await ExecuteAsync(CancellationToken.None);
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                var data = await _dataService.GetAll(cancellationToken);
                var json = JsonSerializer.Serialize(data);

                await _redisCache.SetStringAsync("important_data", json, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                }, cancellationToken);
            }
            catch (Exception ex)
            {
                // Log lỗi ra console hoặc logger để biết nguyên nhân
                Console.WriteLine($"StoreToRedisJob error: {ex}");
                // Nếu bạn có logger, dùng logger.Error(ex, "...");
                // Không throw lại nếu muốn job không bị crash
            }
        }

    }

}
