using AutoMapper;
using Repositories;

namespace Domain.Infrastructure
{
    public class BaseHandler
    {
        public GatewayContext Context { get; }
        public readonly IMapper mapper;

        public BaseHandler(IMapper autoMapper, GatewayContext context)
        {
            Context = context;
            mapper = autoMapper;
        }
    }
}
