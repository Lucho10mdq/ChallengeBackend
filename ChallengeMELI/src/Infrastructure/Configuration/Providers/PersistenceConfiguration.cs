using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.MELI.Configuration.Providers
{
    public static class PersistenceConfiguration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration, bool addHealthCheck = true)
        {

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetSection("redis").Value;
            });

            return services;
        }
    }
}
