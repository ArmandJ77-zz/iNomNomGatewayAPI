using AutoMapper;
using Domain.Menu.DTO;
using Domain.MenuItems.DTO;
using Repositories.Models;
using System.Collections.Generic;

namespace Domain.Menu.Mappings
{
    public class MenuMappings : Profile
    {
        public MenuMappings()
        {
            CreateMap<Repositories.Models.Menu, MenuDto>()
                //.AfterMap((s, d, context) =>
                //{
                //    foreach (var item in s.Items)
                //    {
                //        d.MenuItems.Add(context.Mapper.Map<MenuItem, MenuItemDto>(item));
                //    }
                //})
                .ReverseMap();

            CreateMap<List<Repositories.Models.Menu>, List<MenuDto>>()
                .AfterMap((s, d, context) =>
                {
                    s.ForEach(x =>
                    {
                        var menu = context.Mapper.Map<Repositories.Models.Menu, MenuDto>(x);
                        if (x.Items != null)
                        {
                            menu.MenuItems = new List<MenuItemDto>();
                            foreach (var menuItem in x.Items)
                            {
                                menu.MenuItems.Add(context.Mapper.Map<MenuItem, MenuItemDto>(menuItem));
                            }
                        }
                        d.Add(menu);
                    });
                })
                .ReverseMap();
        }
    }
}
