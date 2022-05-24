using Challenge.MELI.ApiClient.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Challenge.MELI.ApiClient.Extensions
{
    public static class ICountryServiceClientExtension
    {
        private static void AddCountryServiceClient(
            this IServiceCollection services,
            string url)
        {
            services.AddRefitClient<ICountryServiceCliente>()
                    .ConfigureHttpClient(client => client.BaseAddress = new Uri(url));
        }

        public static void AddCountryServiceClient(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var url = configuration.GetSection("CountryService").Value;
            AddCountryServiceClient(services, url);
        }
    }
}
