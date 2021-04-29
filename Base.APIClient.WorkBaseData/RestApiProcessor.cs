using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Base.APIClient.WorkBaseData.Domain.DomainApi;
using Base.APIClient.WorkBaseData.Domain.Entity;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Base.APIClient.WorkBaseData
{
    public class RestApiProcessor : IRestApiProcessor
    {

        private RestClient client = new RestClient("https://localhost:5001");

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
            {
                throw new ArgumentException($"{nameof(route)} не может быть неопределенным или пустым.", nameof(route));
            }
            string route_full = route[route.Length - 1] == '/'
                ? route + subroute.ToString()
                : route + '/' + subroute.ToString();
            return route_full;
        }

        public async Task<Uri> CreateAsync<T>(T api, string route)
        {
            try
            {
                var req = new RestRequest(route, Method.POST, DataFormat.Json);
                req.AddJsonBody(api);
                var result = await client.ExecuteAsync<T>(req);
                if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
                return result.ResponseUri;
            }
            catch (Exception e) { }
            return null;
        }

        public async Task<T> GetByIdAsync<T>(Guid id, string route)
        {
            string route_full = RouteCancat(route, id);
            var request = new RestRequest(route_full, Method.GET, DataFormat.Json);
            var result = await client.ExecuteAsync<T>(request);
            if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
            return result.Data;
        }

        public async Task<T> GetByNumberAsync<T>(int number, string route)
        {
            string route_full = RouteCancat(route, number);
            var request = new RestRequest(route_full, Method.GET, DataFormat.Json);
            var result = await client.ExecuteAsync<T>(request);
            if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
            return result.Data;
        }


        public async Task<HttpStatusCode> DeleteAsync(Guid id, string route)
        {
            string route_full = RouteCancat(route, id);
            var request = new RestRequest(route_full, Method.DELETE, DataFormat.Json);
            var result = await client.ExecuteAsync(request);
            if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
            return result.StatusCode;
        }

        public async Task<HttpStatusCode> UpdateAsync<T>(T api, Guid id, string route)
        {
            string fullRoute = RouteCancat(route, id);
            var request = new RestRequest(fullRoute, Method.PUT, DataFormat.Json);
            request.AddJsonBody(api);
            var result = await client.ExecuteAsync(request);
            if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
            return result.StatusCode;
        }

        public async Task<List<T>> GetList<T>(string route)
        {
            var request = new RestRequest(route, Method.GET, DataFormat.Json);
            var result = await client.ExecuteAsync<List<T>>(request);
            if (result.StatusCode != HttpStatusCode.OK) lastErrorResult = result.StatusDescription;
            return result.Data;
        }
    }
}
