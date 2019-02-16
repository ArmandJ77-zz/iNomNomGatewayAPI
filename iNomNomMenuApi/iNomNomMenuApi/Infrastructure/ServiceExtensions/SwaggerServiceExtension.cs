using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace iNomNomMenuApi.Infrastructure.ServiceExtensions
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "iNomNom Menu API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var filePath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(filePath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger(c => { c.RouteTemplate = "api-docs/{documentName}/swagger.json"; });
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "iNomNom Menu API";
                c.SwaggerEndpoint("/api-docs/v1/swagger.json", "Menu API");
                c.RoutePrefix = "docs";
                c.DocExpansion(DocExpansion.None);
            });

            return app;
        }
    }
}
