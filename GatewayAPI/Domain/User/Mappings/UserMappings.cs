using AutoMapper;
using Domain.User.DTO;
using Repositories;

namespace Domain.User.Mappings
{
    public class UserMappings: Profile
    {
        public UserMappings()
        {
            CreateMap<ClientAuthentication, UserDto>()
                .ReverseMap();
        }
    }
}
