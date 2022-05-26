using Challenge.MELI.ApiClient.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Challenge.MELI.ApiClient.Extensions
{
    public static class ICurrencyServiceClientExtension
    {
        private static void AddCurrencyServiceClient(
            this IServiceCollection services,
            string url)
        {
            services.AddRefitClient<ICurrencyServiceClient>()
                    .ConfigureHttpClient(client => client.BaseAddress = new Uri(url));
        }

        public static void AddCurrencyServiceClient(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var url = configuration.GetSection("CurrencyService").Value;
            AddCurrencyServiceClient(services, url);
        }
    }
}
