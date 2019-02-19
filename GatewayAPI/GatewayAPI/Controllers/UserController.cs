using AutoMapper;
using Domain.User.DTO;
using Domain.User.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GatewayAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController: BaseController
    {
        public UserController(IMapper mapper) : base(mapper)
        {
        }

        /// <summary>
        /// Get logged in user detail
        /// </summary>
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<UserDto> Get([FromServices] IGetLoggedInUserDetail handler)
            => await handler.ExecuteAsync();
    }
}
