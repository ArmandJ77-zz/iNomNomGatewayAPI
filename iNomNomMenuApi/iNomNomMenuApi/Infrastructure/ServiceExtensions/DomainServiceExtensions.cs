using Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace iNomNomMenuApi.Infrastructure.ServiceExtensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomain
            (this IServiceCollection services)
        {
            services.AddSingleton<AppSettings>();
            return services;
        }
    }
}
