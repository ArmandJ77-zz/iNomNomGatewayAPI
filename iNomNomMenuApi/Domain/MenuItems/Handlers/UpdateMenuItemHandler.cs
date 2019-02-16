using System;
using AutoMapper;
using Domain.Infrastructure;
using Domain.MenuItems.DTO;
using Repositories;
using System.Threading.Tasks;
using Repositories.Models;

namespace Domain.MenuItems.Handlers
{
    public class UpdateMenuItemHandler : BaseHandler, IUpdateMenuItemHandler
    {
        public UpdateMenuItemHandler(IMapper autoMapper, MenuContext context) : base(autoMapper, context)
        {
        }

        public async Task<int> ExecuteAsync(UpdateMenuItemDto dto)
        {
            var entity = await Context.FindAsync<MenuItem>(dto.Id);

            if (entity == null)
                throw new Exception("Object not found");

            entity.Description = dto.Description;
            entity.Name = dto.Name;
            entity.Price = dto.Price;
            entity.TimeToPrep = dto.TimeToPrep;

            Context.Items.Update(entity);
            await Context.SaveChangesAsync();

            return entity.Id;
        }
    }

    public interface IUpdateMenuItemHandler
    {
        Task<int> ExecuteAsync(UpdateMenuItemDto dto);
    }
}
