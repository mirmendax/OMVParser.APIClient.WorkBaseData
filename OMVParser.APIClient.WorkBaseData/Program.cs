using System;
using System.Threading.Tasks;
using Base.APIClient.WorkBaseData;
using Base.APIClient.WorkBaseData.Domain.DomainApi;
using Base.APIClient.WorkBaseData.Domain.Entity;
using Newtonsoft.Json;

namespace OMVParser.APIClient.WorkBaseData
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var restApi = new RestApiProcessor();
            var omv = await restApi.GetList<SettingsOMVGenerator>("/api/v1/SettingsOMV");
            if (omv != null && omv.Count > 0)
            {
                var r = JsonConvert.SerializeObject(omv, Formatting.Indented);
                //Console.WriteLine(r);
            }
            var delomv = await restApi.DeleteAsync(Guid.Parse("a810bc46-1b6b-489a-9804-120894cd5fd4"), "/api/v1/SettingsOMV");
            Console.WriteLine(delomv);
            //var gen = await restApi.GetByNumberAsync<Generator>(10, "api/v1/generator/number");
            //Console.WriteLine(gen.Id);
            //var settings = new ApiSettingsOMVGenerator
            //{
            //    GeneratorId = gen.Id, 
            //    P1 = 1000, P2 = 2, P3 = 3, P4 = 4,
            //    QhP0 = 0, QhP1 = 1, QhP2 = 2, QhP3 = 3, QhP4 = 4,
            //    QlP0 = 0, QlP1 = 1, QlP2 = 2, QlP3 = 3, QlP4 = 4,
            //    QmP0 = 0, QmP1 = 1, QmP2 = 2, QmP3 = 3, QmP4 = 4
            //};
            //Console.WriteLine(settings.GeneratorId.ToString());
            //
            ////var create = await restApi.CreateAsync(settings, "api/v1/SettingsOMV");
            ////Console.WriteLine($"Add to generator to: "+ create.ToString());
            Console.ReadKey();
        }
    }
}
