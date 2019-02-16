using Domain.Authentication.Handlers;
using Domain.Infrastructure;
using Domain.User.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace GatewayAPI.Infrastructure.ServiceExtensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomain
            (this IServiceCollection services)
        {
            

            services.AddSingleton<AppSettings>();

            services.AddTransient<IAuthenticateUserHandler, AuthenticateUserHandler>();
            services.AddTransient<IGetUserByIdHandler, GetUserByIdHandler>();

            return services;
        }
    }
}
