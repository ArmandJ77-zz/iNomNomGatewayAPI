using RestSharp;

namespace Infrastructure.HttpUtilities
{
    public class ApiRequestBuilder
    {
        //, params FileDto[] files
        public static RestRequest Build(ApiRequest apiRequest, Method method)
        {
            var restRequest = new RestRequest(apiRequest.Resource + "/", method);

            if (!string.IsNullOrEmpty(apiRequest.Token))
                restRequest.AddHeader("Authorization", apiRequest.Token);

            //apiRequest.Headers.ForEach(header => restRequest.AddHeader(header.Key, header.Value));
            //apiRequest.Parameters.ForEach(param => restRequest.AddParameter(param.Key, param.Value));

            if (apiRequest.Body == null)
                return restRequest;

            restRequest.RequestFormat = apiRequest.DataFormat;
            //restRequest.AddBody(apiRequest.Body);

            return restRequest;
        }
    }
}
