using AutoMapper;
using Domain.User.DTO;
using ExternalPythonService.Domain.User.DTO;
using Repositories;

namespace Domain.User.Mappings
{
    public class UserMappings: Profile
    {
        public UserMappings()
        {
            CreateMap<ClientAuthentication, UserDto>()
                .ReverseMap();

            CreateMap<UserDetailDto, UserDto>()
                .ForMember(s =>s.UserName, d => d.MapFrom(x => x.username))
                .ForMember(s => s.FirstName, d => d.MapFrom(x => x.first_name))
                .ForMember(s => s.LastName, d => d.MapFrom(x => x.id))
                .ForMember(s => s.IsActive, d => d.MapFrom(x => x.is_active))
                .ForMember(s => s.IsStaff, d => d.MapFrom(x => x.is_staff))
                .ForMember(s => s.LastName, d => d.MapFrom(x => x.last_name))
                .ForMember(s => s.Email, d => d.MapFrom(x => x.email))
                .ReverseMap();

            
        }
    }
}
