using AutoMapper;

namespace Domain.Infrastructure
{
    public class BaseHandler
    {
        public readonly IMapper mapper;

        public BaseHandler(IMapper autoMapper)
        {
            mapper = autoMapper;
        }
    }
}
