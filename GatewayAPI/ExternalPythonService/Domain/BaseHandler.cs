using Infrastructure.HttpUtilities;

namespace ExternalPythonService.Domain
{
    public class BaseHandler
    {
        public ApiRequestService Service { get; set; }
        public BaseHandler()
        {
            Service = new ApiRequestService("http://staging.tangent.tngnt.co/api");
            
        }

        //private async Task<string> GetToken()
        //{
        //    var response = Service.PostAsync(new ApiRequest("api-token-auth", new AuthDto{username = "pravin.gordhan", password = ""}))
        //}
    }
}
