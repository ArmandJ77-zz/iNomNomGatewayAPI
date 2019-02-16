using AutoMapper;
using Domain.Authentication.DTO;
using Domain.Authentication.Handlers;
using Domain.User.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<TokenDto> Login([FromBody] UserAuthenticationDto dto, [FromServices] IAuthenticateUserHandler handler)
            => await handler.ExecuteAsync(dto);

        /// <summary>
        /// Registers a user
        /// </summary>
        [ProducesResponseType(typeof(TokenDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [AllowAnonymous]
        [HttpPost("register")]
        public TokenDto Register([FromBody] UserDto dto)
            => null;


    }
}
