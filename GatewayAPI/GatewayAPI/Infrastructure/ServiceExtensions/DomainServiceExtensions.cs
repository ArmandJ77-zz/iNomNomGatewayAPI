using Domain.Authentication.Builders;
using Domain.Authentication.Handlers;
using Domain.Infrastructure;
using Domain.User.Handlers;
using ExternalPythonService.Domain.Auth.Handler;
using Microsoft.Extensions.DependencyInjection;

namespace GatewayAPI.Infrastructure.ServiceExtensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomain
            (this IServiceCollection services)
        {

            //services.AddSingleton<ILogger>();
            services.AddSingleton<AppSettings>();

            services.AddTransient<IAuthenticateUserHandler, AuthenticateUserHandler>();
            services.AddTransient<IGetUserByIdHandler, GetUserByIdHandler>();
            services.AddTransient<IGetClientAuthenticationHandler, GetClientAuthenticationHandler>();

            services.AddTransient<IEpsGetTokenHandler, GetTokenHandler>();
            services.AddTransient<ICustomTokenBuilder, CustomTokenBuilder>();
            services.AddTransient<IInsertOrUpdateClientAuthentication, InsertOrUpdateClientAuthentication>();

            
            return services;
        }
    }
}
