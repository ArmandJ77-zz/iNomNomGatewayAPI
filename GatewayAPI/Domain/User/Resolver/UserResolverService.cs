using Microsoft.AspNetCore.Http;

namespace Domain.User.Resolver
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;

        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string GetUserName()
            => _context.HttpContext.User?.Identity.Name;

    }

    //public interface IUserResolverService
    //{
    //    string GetUserName();
    //}
}
