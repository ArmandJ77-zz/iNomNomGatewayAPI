using AutoMapper;
using Domain.Authentication.Handlers;
using Domain.Infrastructure;
using Domain.User.DTO;
using ExternalPythonService.Domain.User.Handlers;
using Repositories;
using System.Threading.Tasks;
using ExternalPythonService.Domain.User.DTO;

namespace Domain.User.Handlers
{
    public class GetLoggedInUserDetail : BaseHandler, IGetLoggedInUserDetail
    {
        private readonly IGetUserDetailHandler _employeeGetListHandler;
        private readonly IGetEpsTokenHandler _epsTokenHandler;

        public GetLoggedInUserDetail(IGetUserDetailHandler employeeGetListHandler,
        IGetEpsTokenHandler _epsTokenHandler,
        IMapper autoMapper,
        GatewayContext context) : base(autoMapper, context)
        {
            _employeeGetListHandler = employeeGetListHandler;
            this._epsTokenHandler = _epsTokenHandler;
        }

        public async Task<UserDto> ExecuteAsync()
        {
            var token = await _epsTokenHandler.ExecuteAsync();
            var response = await _employeeGetListHandler.ExecuteAsync(token);

            return mapper.Map<UserDetailDto, UserDto>(response);

        }
    }

    public interface IGetLoggedInUserDetail
    {
        Task<UserDto> ExecuteAsync();
    }
}
