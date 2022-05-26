using Challenge.MELI.Domain.Interface.Repository.Command;
using Challenge.MELI.Domain.Interface.Repository.Query;
using Challenge.MELI.Persistence.Cache.Comand;
using Challenge.MELI.Persistence.Cache.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.MELI.Configuration.Providers
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {

            services.AddScoped<IFraudeQuery, FraudQuery>();
            services.AddScoped<IIFraudeRepository, FraudRepository>();
            services.AddScoped<IStatsQuery, StatsQuery>();
            services.AddScoped<IStatsRepository, StatsRepository>();


            return services;
        }
    }
}
