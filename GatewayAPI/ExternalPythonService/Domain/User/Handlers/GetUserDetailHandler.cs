using System.Collections.Generic;
using System.Linq;
using Infrastructure.HttpUtilities;
using System.Threading.Tasks;
using ExternalPythonService.Domain.User.DTO;
using Newtonsoft.Json.Linq;

namespace ExternalPythonService.Domain.User.Handlers
{
    public class GetUserDetailHandler: BaseHandler, IGetUserDetailHandler
    {
        public async Task<UserDetailDto> ExecuteAsync(string token)
        {
            var result = await Service.GetAsync<List<UserDetailDto>>(new ApiRequest("user", null, token));

            return result?.FirstOrDefault();
        }
    }

    public interface IGetUserDetailHandler
    {
        Task<UserDetailDto> ExecuteAsync(string token);
    }
}
