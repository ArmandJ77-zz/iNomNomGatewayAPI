using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GatewayAPI.Infrastructure.ServiceExtensions
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "iNomNom Gateway API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var filePath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(filePath);

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger(c => { c.RouteTemplate = "api-docs/{documentName}/swagger.json"; });
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "iNomNom Gateway API";
                c.SwaggerEndpoint("/api-docs/v1/swagger.json", "Gateway API");
                c.RoutePrefix = "docs";
                c.DocExpansion(DocExpansion.None);
            });

            return app;
        }
    }
}
