using AutoMapper;
using Domain.Infrastructure;
using Domain.User.DTO;

namespace Domain.User.Handlers
{
    public class GetUserByIdHandler : BaseHandler, IGetUserByIdHandler
    {
        public GetUserByIdHandler(IMapper autoMapper) : base(autoMapper)
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
