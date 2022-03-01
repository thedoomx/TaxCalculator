using Infrastructure.Cache;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class InfrastructureConfiguration
	{
        public static IServiceCollection AddInfrastructure(
          this IServiceCollection services)
          => services
              .AddTransient<ICacheService, CacheService>();
    }
}
