using AutoMapper;
using Domain.Infrastructure;
using Domain.MenuItems.DTO;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.MenuItems.Handlers
{
    public class GetMenuItemListHandler : BaseHandler, IGetMenuItemListHandler
    {
        public GetMenuItemListHandler(IMapper autoMapper, MenuContext context) : base(autoMapper, context)
        {
        }

        public async Task<List<MenuItemDto>> ExecuteAsync(int page, int pageSize)
        {
            var entities = await Context.Items.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.Name)
                .ToListAsync();

            var response = Mapper.Map<List<MenuItem>, List<MenuItemDto>>(entities);
            return response;
        }
    }

    public interface IGetMenuItemListHandler
    {
        Task<List<MenuItemDto>> ExecuteAsync(int page, int pageSize);
    }
}
