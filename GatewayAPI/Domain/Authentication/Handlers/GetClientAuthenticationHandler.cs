using AutoMapper;
using Domain.Authentication.DTO;
using Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Threading.Tasks;

namespace Domain.Authentication.Handlers
{
    public class GetClientAuthenticationHandler : BaseHandler, IGetClientAuthenticationHandler
    {
        public GetClientAuthenticationHandler(IMapper autoMapper, GatewayContext context) : base(autoMapper, context)
        {
        }

        public async Task<ClientAuthenticationDto> ExecuteAsync(int id)
        {
            return mapper.Map<ClientAuthentication, ClientAuthenticationDto>(
                await Context.ClientAuthentications.FindAsync(id));
        }

        public async Task<ClientAuthenticationDto> ExecuteAsync(string username)
        {
            return mapper.Map<ClientAuthentication, ClientAuthenticationDto>(
                await Context.ClientAuthentications.SingleOrDefaultAsync(x => x.UserName == username));
        }
    }

    public interface IGetClientAuthenticationHandler
    {
        Task<ClientAuthenticationDto> ExecuteAsync(int id);
        Task<ClientAuthenticationDto> ExecuteAsync(string username);
    }
}
