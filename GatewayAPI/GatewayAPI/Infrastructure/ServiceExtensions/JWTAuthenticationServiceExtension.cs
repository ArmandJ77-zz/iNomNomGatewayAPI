using System.Text;
using System.Threading.Tasks;
using Domain.User.Handlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GatewayAPI.Infrastructure.ServiceExtensions
{
    public static class JWTAuthenticationServiceExtension
    {
        public static IServiceCollection AddJWTAuthenticationServiceExtension(this IServiceCollection services, string secreteKey)
        {
            var key = Encoding.ASCII.GetBytes(secreteKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IGetUserByIdHandler>();
                        //var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.ExecuteAsync();//(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
