using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace iNomNomMenuApi.Infrastructure.ServiceExtensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);
            return services;
        }
    }
}
