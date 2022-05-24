using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Challenge.MELI.Configuration.Providers
{
    public static class MediatorConfiguration
    {
        private const string APPLICATION_NAMESPACE = "Challenge.MELI.Application";
        public static IServiceCollection AddMediatorConfiguration(this IServiceCollection services)
        {
            var types = Assembly.Load(APPLICATION_NAMESPACE).GetTypes().Where(a => a.IsClass && a.Namespace != null && a.Name.EndsWith("Handler")).ToArray();
            if (types.Any()) 
            {
             services.AddMediatR(types);
            }

            return services;
        }
    }
}
