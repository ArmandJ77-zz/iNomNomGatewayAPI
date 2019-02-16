using AutoMapper;
using Domain.Infrastructure;
using Domain.MenuItems.DTO;
using Repositories;
using Repositories.Models;
using System;
using System.Threading.Tasks;

namespace Domain.MenuItems.Handlers
{
    public class GetMenuItemHandler : BaseHandler, IGetMenuItemHandler
    {
        public GetMenuItemHandler(IMapper autoMapper, MenuContext context) : base(autoMapper, context)
        {
        }

        public async Task<MenuItemDto> ExecuteAsync(int id)
        {
            var entity = await Context.Items.FindAsync(id);

            if (entity == null || entity.IsDeleted)
                throw new Exception("Entity Not found");

            return Mapper.Map<MenuItem, MenuItemDto>(entity);
        }
    }

    public interface IGetMenuItemHandler
    {
        Task<MenuItemDto> ExecuteAsync(int id);
    }
}
