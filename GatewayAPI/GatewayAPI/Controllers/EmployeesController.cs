using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GatewayAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : BaseController
    {
        public EmployeesController(IMapper mapper) : base(mapper)
        {
        }

        /// <summary>
        /// Get Employee by Id
        /// </summary>
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpGet("/{id}")]
        public string GetEmployee([FromRoute] int id)
            => id.ToString();

        /// <summary>
        /// Get Employees
        /// </summary>
        [ProducesResponseType(typeof(List<string>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpGet("/")]
        public List<string> GetEmployees()
            => new List<string>
            {
                "asdf",
                "qwerty"
            };
    }
}
