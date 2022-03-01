using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Cache
{
	public interface ICacheService
	{
		Task<T> GetOrCreateAsync<T>(object key, Func<ICacheEntry, Task<T>> create);

		Task<T> Get<T>(object key);

		Task<T> Set<T>(object key, T obj);
	}
}
