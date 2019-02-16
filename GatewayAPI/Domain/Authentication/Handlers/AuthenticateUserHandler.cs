using AutoMapper;
using Domain.Authentication.DTO;
using Domain.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace Domain.Authentication.Handlers
{
    public class AuthenticateUserHandler : BaseHandler, IAuthenticateUserHandler
    {
        private readonly IOptions<AppSettings> _options;

        public AuthenticateUserHandler(IMapper autoMapper, IOptions<AppSettings> options) : base(autoMapper)
        {
            _options = options;
        }

        public TokenDto ExecuteAsync(UserAuthenticationDto dto)
        {
            if (dto == null)
                throw new InvalidCredentialException();

            if (string.IsNullOrEmpty(dto.UserName) || string.IsNullOrEmpty(dto.Password))
                throw new InvalidCredentialException();

            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.Name, dto.Password)
            //};

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SecreteKey));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //var token = new JwtSecurityToken(
            //    claims: claims,
            //    expires: DateTime.Now.AddMinutes(5),
            //    signingCredentials: creds);

            //var response = new JwtSecurityTokenHandler().WriteToken(token);
            return null;
        }
    }

    public interface IAuthenticateUserHandler
    {
        TokenDto ExecuteAsync(UserAuthenticationDto dto);
    }
}
