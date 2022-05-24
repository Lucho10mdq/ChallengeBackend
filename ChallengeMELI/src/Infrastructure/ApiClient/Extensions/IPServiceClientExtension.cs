using Challenge.MELI.ApiClient.Service.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Challenge.MELI.ApiClient.Extensions
{
    public static class IPServiceClientExtension
    {
        private static void AddIPServiceClient(
            this IServiceCollection services,
            string url)
        {
            services.AddRefitClient<IIPServiceClient>()
                    .ConfigureHttpClient(client => client.BaseAddress = new Uri(url));
        }

        public static void AddIPServiceClient(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var url = configuration.GetSection("IPService").Value;
            AddIPServiceClient(services, url);
        }
    }
}
