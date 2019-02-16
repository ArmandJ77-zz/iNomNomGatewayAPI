using AutoMapper;
using Domain.Infrastructure;
using Repositories;
using System;
using System.Threading.Tasks;

namespace Domain.MenuItems.Handlers
{
    public class DeleteMenuItemHandler : BaseHandler, IDeleteMenuItemHandler
    {
        public DeleteMenuItemHandler(IMapper autoMapper, MenuContext context) : base(autoMapper, context)
        {
        }

        public async Task<int> ExecuteAsync(int id)
        {
            var entity = await Context.Items.FindAsync(id);

            if (entity == null)
                throw new Exception("Entity not found");

            entity.IsDeleted = true;

            Context.Items.Update(entity);
            await Context.SaveChangesAsync();

            return entity.Id;
        }
    }

    public interface IDeleteMenuItemHandler
    {
        Task<int> ExecuteAsync(int id);
    }
}
