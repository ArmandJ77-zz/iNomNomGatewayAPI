using AutoMapper;
using Domain.Employees.DTO;
using Domain.Infrastructure;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Authentication.Handlers;
using ExternalPythonService.Domain.Employees.DTO;
using ExternalPythonService.Domain.Employees.Handlers;

namespace Domain.Employees.Handlers
{
    public class GetEmployeeListHandler: BaseHandler, IGetEmployeeListHandler
    {
        private readonly IGetEpsTokenHandler _epsTokenHandler;
        public IEmployeeGetListHandler EmployeeGetListHandler { get; }

        public GetEmployeeListHandler(IMapper autoMapper, 
            GatewayContext context,
            IEmployeeGetListHandler employeeGetListHandler,
            IGetEpsTokenHandler epsTokenHandler) : base(autoMapper, context)
        {
            _epsTokenHandler = epsTokenHandler;
            EmployeeGetListHandler = employeeGetListHandler;
        }

        public async Task<List<EmployeeDto>> ExecuteAsync()
        {
            var token = await _epsTokenHandler.ExecuteAsync();
            var serviceResult = await EmployeeGetListHandler.ExecuteAsync(token);

            var response = mapper.Map<List<employee>,List<EmployeeDto>>(serviceResult);

            return response;
        }
    }

    public interface IGetEmployeeListHandler
    {
        Task<List<EmployeeDto>> ExecuteAsync();
    }
}
