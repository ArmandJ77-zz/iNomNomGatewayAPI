using AutoMapper;
using Domain.Infrastructure;
using Domain.MenuItems.DTO;
using Repositories;
using Repositories.Models;
using System.Threading.Tasks;

namespace Domain.MenuItems.Handlers
{
    public class CreateMenuItemHandler: BaseHandler, ICreateMenuItemHandler
    {
        public CreateMenuItemHandler(IMapper autoMapper, MenuContext context) : base(autoMapper, context)
        {
        }

        public async Task<int> ExecuteAsync(CreateMenuItemDto dto)
        {
            var entity = Mapper.Map<CreateMenuItemDto, MenuItem>(dto);
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }
    }

    public interface ICreateMenuItemHandler
    {
        Task<int> ExecuteAsync(CreateMenuItemDto dto);
    }
}
