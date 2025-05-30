using ConquerBackend.Infrastructure.Redis.Abtractions;
using Microsoft.Extensions.Caching.Distributed;

namespace ConquerBackend.Infrastructure.Redis
{
    public class RedisService(IDistributedCache _distributedCache) :IRedisService
    {
        public async Task SetStringAsync(string prefix, string key, string jsonData, DistributedCacheEntryOptions options, CancellationToken cancellationToken)
           => await _distributedCache.SetStringAsync(GetCacheKey(prefix, key), jsonData, options, cancellationToken);
        public async Task SetAsync(string prefix, string key, byte[] data, DistributedCacheEntryOptions options, CancellationToken cancellationToken)
           => await _distributedCache.SetAsync(GetCacheKey(prefix, key), data, options, cancellationToken);
        //public async Task<TResult> GetAsync<TResult>(string key, string field, CancellationToken cancellationToken)
        //   => await _distributedCache.GetStringAsync($"{key}:{field}", cancellationToken);

        private string GetCacheKey(string prefix, string key) => $":{prefix}:{key}";
    }
}
