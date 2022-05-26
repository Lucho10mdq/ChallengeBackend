using Challenge.MELI.ApiClient.Extensions;
using Challenge.MELI.Configuration.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.MELI.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServiceConfiguration();
            services.AddMediatorConfiguration();
            services.AddSwaggerConfiguration();
            services.AddRepositoryConfiguration();
            services.AddIPServiceClient(configuration);
            services.AddCountryServiceClient(configuration);
            services.AddCurrencyServiceClient(configuration);
            services.ConfigurePersistenceServices(configuration);

            return services;
        }

        public static void Configure(
            this IApplicationBuilder app,
            IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Mercado Libre Api V1");
            });
        }
    }
}

