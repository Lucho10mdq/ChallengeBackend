using Challenge.MELI.ApiClient.Service;
using Challenge.MELI.ApiClient.Service.Interface;
using Challenge.MELI.Application.Service;
using Challenge.MELI.Domain.Interface.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.MELI.Configuration.Providers
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services)
        {
           
            services.AddScoped<IFraudeService, FraudeService>();
            services.AddScoped<IIPService, IPService>();
            services.AddScoped<ICountryService, CountryService>();
            return services;
        }
    }
}
