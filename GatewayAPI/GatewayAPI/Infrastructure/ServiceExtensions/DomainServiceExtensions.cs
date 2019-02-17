using Domain.Authentication.Builders;
using Domain.Authentication.Handlers;
using Domain.Employees.Handlers;
using Domain.Health.Handler;
using Domain.Infrastructure;
using Domain.User.Handlers;
using Domain.User.Resolver;
using ExternalPythonService.Domain.Auth.Handler;
using ExternalPythonService.Domain.Employees.Handlers;
using Microsoft.AspNetCore.Http;
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
            services.AddTransient<UserResolverService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IGetEpsTokenHandler, GetEpsTokenHandler>();

            services.AddTransient<IAuthenticateUserHandler, AuthenticateUserHandler>();
            services.AddTransient<IGetUserByNameHandler, GetUserByNameHandler>();
            services.AddTransient<IGetClientAuthenticationHandler, GetClientAuthenticationHandler>();

            services.AddTransient<IEpsGetTokenHandler, GetTokenHandler>();
            services.AddTransient<ICustomTokenBuilder, CustomTokenBuilder>();
            services.AddTransient<IInsertOrUpdateClientAuthentication, InsertOrUpdateClientAuthentication>();

            services.AddTransient<ISearchEmployeeHandler, SearchEmployeeHandler>();
            services.AddTransient<IGetEmployeeListHandler, GetEmployeeListHandler>();
            services.AddTransient<IEmployeeGetListHandler, EmployeeGetListHandler>();
            services.AddTransient<IGetEmployeeByIdHandler, GetEmployeeByIdHandler>();

            services.AddTransient<IHealthCheckHandler, HealthCheckHandler>();
            return services;
        }
    }
}
