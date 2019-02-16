using AutoMapper;
using Domain.Infrastructure;
using Domain.Menu.DTO;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Menu.Handlers
{
    public class GetMenusHandler: BaseHandler, IGetMenusHandler
    {
        public GetMenusHandler(IMapper autoMapper, MenuContext context) : base(autoMapper, context)
        {
        }

        public async Task<List<MenuDto>> ExecuteAsync()
        {
            var entity = await Context.Menus
                .Include(x => x.Items)
                .ToListAsync();

            var result = Mapper.Map<List<Repositories.Models.Menu>, List<MenuDto>>(entity);
            return result;
        }
    }

    public interface IGetMenusHandler
    {
        Task<List<MenuDto>> ExecuteAsync();
    }
}
