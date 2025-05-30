using ConquerBackend.Infrastructure.Redis.Abtractions;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ConquerBackend.Infrastructure.Redis
{
    public class RedisService(IDistributedCache _distributedCache) :IRedisService
    {
        public async Task SetStringAsync(string prefix, string key, string jsonData, DistributedCacheEntryOptions options, CancellationToken cancellationToken)
           => await _distributedCache.SetStringAsync(GetCacheKey(prefix, key), jsonData, options, cancellationToken);
        public async Task SetAsync(string prefix, string key, byte[] data, DistributedCacheEntryOptions options, CancellationToken cancellationToken)
           => await _distributedCache.SetAsync(GetCacheKey(prefix, key), data, options, cancellationToken);
        public async Task<TResult> GetAsync<TResult>(string prefix, string key, CancellationToken cancellationToken)
        {
            string cacheKey = GetCacheKey(prefix, key);
            string json = await _distributedCache.GetStringAsync(cacheKey, cancellationToken);

            if (string.IsNullOrEmpty(json)) return default;

            return JsonConvert.DeserializeObject<TResult>(json);
        }
        public async Task RemoveAsync(string key, string field, CancellationToken cancellationToken = default)
        {
            await _distributedCache.RemoveAsync($"{key}:{field}", cancellationToken);
        }
        private string GetCacheKey(string prefix, string key) => $":{prefix}:{key}";
    }
}
