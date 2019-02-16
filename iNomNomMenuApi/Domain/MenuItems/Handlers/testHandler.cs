using AutoMapper;
using Domain.Infrastructure;
using Repositories;

namespace Domain.MenuItems.Handlers
{
    public class testHandler : BaseHandler, ItestHandler
    {
        public testHandler(IMapper autoMapper, MenuContext context) : base(autoMapper, context)
        {
        }

        public void ExecuteAsync()
        {

        }
    }

    public interface ItestHandler
    {
        void ExecuteAsync();
    }
}
