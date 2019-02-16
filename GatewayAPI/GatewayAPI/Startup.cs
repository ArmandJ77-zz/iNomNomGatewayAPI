using Domain.Infrastructure;
using FluentValidation.AspNetCore;
using GatewayAPI.Infrastructure.ServiceExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Repositories;
using Serilog;
using System.Linq;
using System.Reflection;

namespace GatewayAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; set; }

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));

            if (HostingEnvironment.IsEnvironment("Testing"))
                services.AddDbContext<GatewayContext>(opt => opt.UseInMemoryDatabase("TestDB"));
            else
                services.AddDbContext<GatewayContext>(
                    option => option.UseSqlServer(Configuration.GetConnectionString("Database"),
                        opt => opt.UseRowNumberForPaging()));


            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddDomain();
            services.AddJWTAuthenticationServiceExtension(appSettings.SecreteKey);
            services.AddAutoMapperConfiguration(GetType().GetTypeInfo().Assembly.GetReferencedAssemblies().Select(c => Assembly.Load(c)).ToArray());
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddSwaggerDocumentation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCors(options => options.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowCredentials());

            app.UseHttpsRedirection();
            app.UsePathBase("/api");
            app.UseSwaggerDocumentation();
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
