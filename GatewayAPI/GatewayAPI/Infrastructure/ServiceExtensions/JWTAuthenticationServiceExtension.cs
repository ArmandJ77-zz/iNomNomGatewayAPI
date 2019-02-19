using System;
using System.Data;
using System.Data.SqlClient;
using Domain.User.Handlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using System.Text;
using System.Threading.Tasks;

namespace GatewayAPI.Infrastructure.ServiceExtensions
{
    public static class JWTAuthenticationServiceExtension
    {
        public static IServiceCollection AddJWTAuthenticationServiceExtension(this IServiceCollection services, string secreteKey, string connString)
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
                    OnTokenValidated = ctx =>
                    {
                        var query = "SELECT TOP(1) [Id],[UserName] FROM [ClientAuthentications] WHERE [UserName] = @Username";
                        using (var conn = new SqlConnection(connString))
                        {
                            var command = new SqlCommand(query, conn);
                            command.Parameters.AddWithValue("@Username", ctx.Principal.Identity.Name);

                            try
                            {
                                conn.Open();
                                var reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    var username = reader[1];
                                    if (username == null)
                                    {
                                        // return unauthorized if user no longer exists
                                        ctx.Fail("Unauthorized");
                                    }
                                }
                                reader.Close();
                            }
                            catch (Exception ex)
                            {
                                ctx.Fail("Unauthorized");
                            }
                        }

                        return Task.CompletedTask;
                        //var userService = ctx.HttpContext.RequestServices.GetRequiredService<IGetUserByNameHandler>();
                        //var user = userService.ExecuteAsync(ctx.Principal.Identity.Name);
                        //if (user == null)
                        //{
                        //    // return unauthorized if user no longer exists
                        //    ctx.Fail("Unauthorized");
                        //}
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
