using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Base.APIClient.WorkBaseData
{
    public class RestApiProcessor : IRestApiProcessor
    {

        private RestClient client = new RestClient();

        private const string BaseUrl = "https://localhost:5001";
        private string lastErrorResult = string.Empty;

        public string ErrorResult { get { return lastErrorResult; } }

        public RestApiProcessor() : this(BaseUrl) { }        

        public RestApiProcessor(string url)
        {
            client = new RestClient(url);
            client.UseNewtonsoftJson();
        }


        private string RouteCancat(string route, object subroute)
        {
            if (string.IsNullOrEmpty(route))            
                throw new ArgumentException($"{nameof(route)} не может быть неопределенным или пустым.", nameof(route));
            
            if (subroute is null)           
                throw new ArgumentNullException(nameof(subroute));
            //Проверка последнего символа [^1] в route для добавления subroute
            return route[^1] == '/'
                ? route + subroute.ToString()
                : route + '/' + subroute.ToString();
        }

        private async Task<IRestResponse<T>> ExecuteAsync<T>(string route, object id, Method method)
        {
            var fullroute = RouteCancat(route, id);
            var req = new RestRequest(fullroute, method, DataFormat.Json);
            return await client.ExecuteAsync<T>(req);
            //if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
             
        }

        private async Task<IRestResponse<T>> ExecuteAsync<T>(string route, object id, T item, Method method)
        {
            var fullroute = RouteCancat(route, id);
            var req = new RestRequest(fullroute, method, DataFormat.Json);
            req.AddJsonBody(item);
            return await client.ExecuteAsync<T>(req);
        }

        public async Task<T> CreateAsync<T>(T api, string route)
        {
            var result = await ExecuteAsync(route, "", api, Method.POST);
            if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
            return result.Data;            
        }

        public async Task<T> GetItemAsync<T>(Guid id, string route)
        {
            var result = await ExecuteAsync<T>(route, id, Method.GET);
            if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
            return result.Data;
        }

        public async Task<T> GetItemAsync<T>(int number, string route)
        {
            var result = await ExecuteAsync<T>(route, number, Method.GET);
            if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
            return result.Data;
        }


        public async Task<HttpStatusCode> DeleteAsync<T>(Guid id, string route)
        {
            //string route_full = RouteCancat(route, id);
            //var request = new RestRequest(route_full, Method.DELETE, DataFormat.Json);
            //var result = await client.ExecuteAsync(request);
            //if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
            var result = await ExecuteAsync<T>(route, id, Method.DELETE);
            if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
            return result.StatusCode;
        }

        public async Task<T> UpdateAsync<T>(T api, Guid id, string route)
        {
            var result = await ExecuteAsync(route, id, api, Method.PUT);
            if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
            return result.Data;
        }

        public async Task<List<T>> GetItemsAsync<T>(string route)
        {
            var request = new RestRequest(route, Method.GET, DataFormat.Json);
            var result = await client.ExecuteAsync<List<T>>(request);
            if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
            return result.Data;
        }
    }
}
