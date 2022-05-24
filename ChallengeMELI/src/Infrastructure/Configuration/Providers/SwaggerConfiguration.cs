using Microsoft.Extensions.DependencyInjection;

namespace Challenge.MELI.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Mercado Libre",
                    Version = "v1",
                    Description = "Challenge"
                });
            });

            return services;
        }
    }
}
