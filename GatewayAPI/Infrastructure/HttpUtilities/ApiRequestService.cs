using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using RestSharp.Authenticators;

namespace Infrastructure.HttpUtilities
{
    public class ApiRequestService
    {
        private RestClient Client { get; }

        public ApiRequestService(string baseUrl)
        {
            Client = new RestClient(baseUrl);
        }

        public void ChangeBaseUrl(string baseUrl)
            => Client.BaseUrl = new Uri(baseUrl);

        #region IRestResponse Results
        /// <summary>
        /// Returns the full IRestResponse object
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<IRestResponse> GetAsync(ApiRequest dto)
          => await Task.Run(() => Client.Execute(ApiRequestBuilder.Build(dto, Method.GET)));

        /// <summary>
        /// Returns the full IRestResponse object
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<IRestResponse> PostAsync(ApiRequest dto)
          => await Task.Run(() => Client.Execute(ApiRequestBuilder.Build(dto, Method.POST)));

        /// <summary>
        /// Returns the full IRestResponse object
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<IRestResponse> PutAsync(ApiRequest dto)
          => await Task.Run(() => Client.Execute(ApiRequestBuilder.Build(dto, Method.PUT)));

        /// <summary>
        /// Returns the full IRestResponse object
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<IRestResponse> DeleteAsync(ApiRequest dto)
          => await Task.Run(() => Client.Execute(ApiRequestBuilder.Build(dto, Method.DELETE)));
        #endregion

        #region Deserialized IRestResponse
        /// <summary>
        /// Returns a json de-serialized result from the IRestResponse 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(ApiRequest dto)
          => await Task.Run(() => JsonConvert.DeserializeObject<T>(Client.Execute(ApiRequestBuilder.Build(dto, Method.GET)).Content));

        /// <summary>
        /// Returns a json de-serialized result from the IRestResponse 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<T> PostAsync<T>(ApiRequest dto)
          => await Task.Run(() => JsonConvert.DeserializeObject<T>(Client.Execute(ApiRequestBuilder.Build(dto, Method.POST)).Content));

        /// <summary>
        /// Returns a json de-serialized result from the IRestResponse 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<T> PutAsync<T>(ApiRequest dto)
          => await Task.Run(() => JsonConvert.DeserializeObject<T>(Client.Execute(ApiRequestBuilder.Build(dto, Method.PUT)).Content));

        /// <summary>
        /// Returns a json de-serialized result from the IRestResponse 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<T> DeleteAsync<T>(ApiRequest dto)
          => await Task.Run(() => JsonConvert.DeserializeObject<T>(Client.Execute(ApiRequestBuilder.Build(dto, Method.DELETE)).Content));
        #endregion
    }
}
