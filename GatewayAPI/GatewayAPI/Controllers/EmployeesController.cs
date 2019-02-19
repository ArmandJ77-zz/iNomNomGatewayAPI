using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Employees.DTO;
using Domain.Employees.Handlers;
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
        /// Get Employees
        /// </summary>
        [ProducesResponseType(typeof(List<EmployeeDto>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<List<EmployeeDto>> GetEmployees([FromServices] IGetEmployeeListHandler handler)
            => await handler.ExecuteAsync();
    }
}
