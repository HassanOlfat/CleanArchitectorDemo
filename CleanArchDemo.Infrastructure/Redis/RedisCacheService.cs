using CleanArchDemo.Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace CleanArchDemo.Infrastructure.Redis
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
        {
            var data = await _cache.GetStringAsync(key, cancellationToken);
            return data is null ? default : JsonSerializer.Deserialize<T>(data);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan ttl, CancellationToken cancellationToken)
        {
            var options = new DistributedCacheEntryOptions();

           
                options.SetAbsoluteExpiration(ttl);

            var json = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, json, options, cancellationToken);
        }

        public Task RemoveAsync(string key, CancellationToken cancellationToken)
            => _cache.RemoveAsync(key, cancellationToken);
    }

}
