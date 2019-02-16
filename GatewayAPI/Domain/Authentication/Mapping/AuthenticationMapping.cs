using AutoMapper;
using Domain.Authentication.DTO;
using ExternalPythonService.Domain.Auth.DTO;
using Repositories;

namespace Domain.Authentication.Mapping
{
    public class AuthenticationMapping : Profile
    {
        public AuthenticationMapping()
        {
            CreateMap<UserAuthenticationDto, AuthDto>()
                .ReverseMap();

            CreateMap<ClientAuthenticationDto, ClientAuthentication>()
                .ReverseMap();

            
        }
    }
}
