using AutoMapper;
using Domain.MenuItems.DTO;
using Repositories.Models;
using System.Collections.Generic;

namespace Domain.MenuItems.Mappings
{
    public class MenuItemMapping : Profile
    {
        public MenuItemMapping()
        {
            CreateMap<MenuItem, MenuItemDto>()
                .ReverseMap();

            CreateMap<List<MenuItem>, List<MenuItemDto>>()
                .AfterMap((s, d, context) =>
                        {
                            s.ForEach(x => d.Add(context.Mapper.Map<MenuItem, MenuItemDto>(x)));
                        })
                .ReverseMap();

            CreateMap<CreateMenuItemDto, MenuItem>()
                .ReverseMap();
        }
    }
}
