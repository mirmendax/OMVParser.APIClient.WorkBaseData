using OMVParser.APIClient.WorkBaseData.Domain.Entity;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WorkBaseData.Domain.DomainApi;

namespace OMVParser.APIClient.WorkBaseData.Domain
{
    public static class ApiProcessor
    {
        private static RestClient client = new RestClient("https://localhost:5001");
        private static string Route_OMVSettings = "api/v1/SettingsOMV";
        private static string Route_generator_number = "api/v1/Generator/number/";

        public static async Task<Uri> Create(ApiSettingsOMVGenerator settings)
        {
            client.UseNewtonsoftJson();
            var request = new RestRequest(Route_OMVSettings, Method.POST ,DataFormat.Json);
            
            request.AddJsonBody(settings);
            var result = await client.ExecuteAsync<SettingsOMVGenerator>(request);
            Console.WriteLine(request.Body.Value);
            return result.ResponseUri;
        }

        public static async Task<Generator> GetGenerator(int numberGenerator)
        {
            client.UseNewtonsoftJson();
            var request = new RestRequest(Route_generator_number+numberGenerator.ToString(), Method.GET);
            //request.AddParameter("number", 16);
            var result = await client.ExecuteAsync<Generator>(request);
            return result.Data;
        }
    }
}
