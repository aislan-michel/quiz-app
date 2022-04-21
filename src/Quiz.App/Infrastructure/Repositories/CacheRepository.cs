using System;
using Microsoft.Extensions.Caching.Memory;

namespace Quiz.App.Infrastructure.Repositories
{
    public class CacheRepository<T> : ICacheRepository<T>
    {
        private readonly IMemoryCache _cache;

        public CacheRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Set(string key, T entry)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30));

            _cache.Set(key, entry, cacheEntryOptions);
        }

        public T Get(string key)
        {
            var t = _cache.Get(key);
            var x = _cache.Get<T>(key);
            
            return _cache.Get<T>(key);
        }
    }
}