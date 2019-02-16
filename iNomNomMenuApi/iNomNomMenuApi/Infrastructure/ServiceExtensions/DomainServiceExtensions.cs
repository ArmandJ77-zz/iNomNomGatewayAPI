using Domain.Infrastructure;
using Domain.Menu.Handlers;
using Domain.MenuItems.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace iNomNomMenuApi.Infrastructure.ServiceExtensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddSingleton<AppSettings>();

            services.AddTransient<ICreateMenuItemHandler, CreateMenuItemHandler>();
            services.AddTransient<IDeleteMenuItemHandler, DeleteMenuItemHandler>();
            services.AddTransient<IGetMenuItemHandler, GetMenuItemHandler>();
            services.AddTransient<IUpdateMenuItemHandler, UpdateMenuItemHandler>();
            services.AddTransient<IGetMenusHandler, GetMenusHandler>();


            services.AddTransient<IGetMenuItemListHandler, GetMenuItemListHandler>();
            return services;
        }
    }
}
