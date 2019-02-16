using AutoMapper;
using Domain.Authentication.DTO;
using Domain.Authentication.Handlers;
using Domain.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GatewayAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : BaseController
    {
        public AuthController(IMapper mapper) : base(mapper)
        {
        }

        /// <summary>
        /// Authenticate a User
        /// </summary>
        [ProducesResponseType(typeof(TokenDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [AllowAnonymous]
        [HttpPost("login")]
        public TokenDto Login([FromBody] UserAuthenticationDto dto, [FromServices] IAuthenticateUserHandler handler)
            => handler.ExecuteAsync(dto);


    }
}
