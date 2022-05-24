using Challenge.MELI.ApiClient.Extensions;
using Challenge.MELI.ApiClient.Service.Interface;
using Challenge.MELI.Configuration.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Challenge.MELI.Configuration
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //INFRASTRUCTURE
            //services.ConfigurePersistenceServices(configuration);

            //services.AddPersonConfiguration();
            services.AddServiceConfiguration();
            services.AddMediatorConfiguration();
            services.AddSwaggerConfiguration();
            services.AddIPServiceClient(configuration);
            services.AddCountryServiceClient(configuration);
            services.ConfigurePersistenceServices(configuration);
            //services.AddMapper();

            return services;
        }


        public static void Configure(
            this IApplicationBuilder app,
            IConfiguration configuration)
        {
            //using (var serviceScope = app.ApplicationServices
            //                 .GetRequiredService<IServiceScopeFactory>()
            //                 .CreateScope())
            //{
            //    using var context = serviceScope.ServiceProvider.GetService<NetExperienceDbContext>();
            //    context.Database.Migrate();
            //}

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Mercado Libre Api V1");
            });
        }
    }
}

