using System;
using AutoMapper;
using Domain.Infrastructure;
using Domain.MenuItems.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.MenuItems.Handlers
{
    public class GetMenuHandler : BaseHandler, IGetMenuHandler
    {
        public GetMenuHandler(IMapper autoMapper) : base(autoMapper)
        {
        }

        //public async Task<List<MenuItemDto>> ExecuteAsync()
        //{
        //    throw NotImplementedException
        //}
    }

    public interface IGetMenuHandler
    {
        //List<MenuItemDto> ExecuteAsync();
    }
}
