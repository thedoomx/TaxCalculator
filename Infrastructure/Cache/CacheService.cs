using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Cache
{
    public class CacheService : ICacheService
    {
        private static readonly SemaphoreSlim Locker = new SemaphoreSlim(1, 1);

        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            this._cache = cache;
        }

        public async Task<T> GetOrCreateAsync<T>(object key, Func<ICacheEntry, Task<T>> create)
        {
            await Locker.WaitAsync();
            try
            {
                return await this._cache.GetOrCreateAsync(key, create);
            }
            finally
            {
                Locker.Release();
            }
        }

        public async Task<T> Get<T>(object key)
        {
            await Locker.WaitAsync();
            try
            {
                return this._cache.Get<T>(key);
            }
            finally
            {
                Locker.Release();
            }
        }

        public async Task<T> Set<T>(object key, T obj)
        {
            await Locker.WaitAsync();
            try
            {
                return this._cache.Set<T>(key, obj);
            }
            finally
            {
                Locker.Release();
            }
        }
    }
}
