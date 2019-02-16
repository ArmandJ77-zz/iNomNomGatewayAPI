using AutoMapper;
using Domain.Infrastructure;
using Domain.User.DTO;
using Repositories;

namespace Domain.User.Handlers
{
    public class GetUserByIdHandler : BaseHandler, IGetUserByIdHandler
    {
        public GetUserByIdHandler(IMapper autoMapper, GatewayContext context) : base(autoMapper, context)
        {
        }

        public UserDto ExecuteAsync()
        {
            return new UserDto()
            {
                Password = "qwerty",
                Name = "asdf"
            };
        }
    }

    public interface IGetUserByIdHandler
    {
        UserDto ExecuteAsync();
    }
}
