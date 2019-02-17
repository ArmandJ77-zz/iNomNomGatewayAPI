using ExternalPythonService.Domain.Auth.DTO;
using Infrastructure.HttpUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Serilog;
using SimpleJson;

namespace ExternalPythonService.Domain.Auth.Handler
{
    public class GetTokenHandler: BaseHandler, IEpsGetTokenHandler
    {
        public ILogger<IEpsGetTokenHandler> Log;

        public GetTokenHandler(ILogger<IEpsGetTokenHandler> log) : base()
        {
            Log = log;
        }

        public async Task<string> ExecuteAsync(AuthDto dto)
        {
            Service.ChangeBaseUrl("http://staging.tangent.tngnt.co");

            try
            {
                var result = await Service.PostAsync(new ApiRequest("api-token-auth", dto));
                
                return result.StatusCode != HttpStatusCode.OK ? "Unable to authenticate with credentials" : (string)JObject.Parse(result.Content)["token"];
            }
            catch (Exception e)
            {
                Log.LogError(e.ToString());
                return "Request Failure";
            }
        }
    }

    public interface IEpsGetTokenHandler
    {
        Task<string> ExecuteAsync(AuthDto dto);
    }
}
