using AutoMapper;
using Repositories;

namespace Domain.Infrastructure
{
    public class BaseHandler
    {
        public readonly IMapper Mapper;
        public readonly MenuContext Context;

        public BaseHandler(IMapper autoMapper, MenuContext context)
        {
            Mapper = autoMapper;
            Context = context;
        }
    }
}
