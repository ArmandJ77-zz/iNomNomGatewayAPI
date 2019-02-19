using System;
using AutoMapper;
using Domain.Authentication.DTO;
using Domain.Infrastructure;
using ExternalPythonService.Domain.Auth.DTO;
using ExternalPythonService.Domain.Auth.Handler;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Authentication;
using System.Threading.Tasks;
using Domain.Authentication.Builders;
using Domain.Infrastructure.CustomExceptions;
using Repositories;

namespace Domain.Authentication.Handlers
{
    public class AuthenticateUserHandler : BaseHandler, IAuthenticateUserHandler
    {
        private readonly IInsertOrUpdateClientAuthentication _authentication;
        private readonly IOptions<AppSettings> _options;
        private readonly IEpsGetTokenHandler _epsGetTokenHandler;
        private readonly ICustomTokenBuilder _tokenBuilder;
        private readonly ILogger<IAuthenticateUserHandler> _logger;

        public AuthenticateUserHandler(
            IMapper autoMapper,
            GatewayContext context,
            IOptions<AppSettings> options,
            ILogger<IAuthenticateUserHandler> logger,
            IEpsGetTokenHandler epsGetTokenHandler,
            ICustomTokenBuilder tokenBuilder,
            IInsertOrUpdateClientAuthentication authentication
            ) : base(autoMapper, context)
        {
            _authentication = authentication;
            _options = options;
            _epsGetTokenHandler = epsGetTokenHandler;
            _tokenBuilder = tokenBuilder;
            _logger = logger;
        }

        public async Task<TokenDto> ExecuteAsync(UserAuthenticationDto dto)
        {
            var epsToken = await _epsGetTokenHandler.ExecuteAsync(mapper.Map<UserAuthenticationDto, AuthDto>(dto));

            if (epsToken == "Unable to authenticate with credentials")
                throw new UnauthorizedException("Invalid user credentials");

            try
            {
                await _authentication.ExecuteAsync(new ClientAuthenticationDto
                {
                    UserName = dto.UserName,
                    Token = epsToken,
                    IsValid = true
                });
            }
            catch (Exception e)
            {
                _logger.LogError("Unable to save/update client authentication during login", e);
                throw e;
            }

            var result = _tokenBuilder.Build(_options.Value.SecreteKey, dto);

            return result;
        }
    }

    public interface IAuthenticateUserHandler
    {
        Task<TokenDto> ExecuteAsync(UserAuthenticationDto dto);
    }
}
