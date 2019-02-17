using AutoMapper;
using Domain.Health.Handler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GatewayAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class HealthController: BaseController
    {
        public HealthController(IMapper mapper) : base(mapper)
        {
        }

        /// <summary>
        /// Check if the service is up
        /// </summary>
        [ProducesResponseType(typeof(HealthDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<HealthDto> Get([FromServices] IHealthCheckHandler handler)
            => await handler.ExecuteAsync();
    }
}
