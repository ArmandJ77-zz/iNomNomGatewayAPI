using ExternalPythonService.Domain.Employees.DTO;
using Infrastructure.HttpUtilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExternalPythonService.Domain.Employees.Handlers
{
    public class EmployeeGetListHandler : BaseHandler, IEmployeeGetListHandler
    {
        public async Task<List<employee>> ExecuteAsync(string token)
            => await Service.GetAsync<List<employee>>(new ApiRequest("employee", null, token));
    }

    public interface IEmployeeGetListHandler
    {
        Task<List<employee>> ExecuteAsync(string token);
    }
}