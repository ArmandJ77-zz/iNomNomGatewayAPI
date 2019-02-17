using AutoMapper;
using Domain.Infrastructure;
using Domain.User.Resolver;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Authentication.Handlers
{
    public class GetEpsTokenHandler : BaseHandler, IGetEpsTokenHandler
    {
        private readonly UserResolverService _userResolverService;

        public GetEpsTokenHandler(UserResolverService userResolverService, IMapper autoMapper, GatewayContext context) : base(autoMapper, context)
        {
            _userResolverService = userResolverService;
        }

        public async Task<string> ExecuteAsync()
        {
            var userName = _userResolverService.GetUserName();

            var entity = await Context.ClientAuthentications.SingleOrDefaultAsync(x => x.UserName == userName);

            return $"token {entity.Token}";
        }
    }

    public interface IGetEpsTokenHandler
    {
        Task<string> ExecuteAsync();
    }
}
