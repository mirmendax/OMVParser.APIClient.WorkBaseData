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
            Console.ReadLine();
            var restApi = new RestApiProcessor();

            Console.WriteLine("Get Generator number 8");
            var id_gen = (await restApi.GetItemAsync<Generator>(8, "/api/v1/generator/number/")).Id;
            Console.WriteLine("Create SettingsOMVGenerator of generator number 8");
            var settings = new SettingsOMVGenerator
            {
                GeneratorId = id_gen, 
                P1 = 1000, P2 = 2, P3 = 3, P4 = 4,
                QhP0 = 0, QhP1 = 1, QhP2 = 2, QhP3 = 3, QhP4 = 4,
                QlP0 = 0, QlP1 = 1, QlP2 = 2, QlP3 = 3, QlP4 = 4,
                QmP0 = 0, QmP1 = 1, QmP2 = 2, QmP3 = 3, QmP4 = 4
            };
            Console.WriteLine(settings.GeneratorId.ToString());
            
            var create = await restApi.CreateAsync(settings, "api/v1/SettingsOMV");
            Console.WriteLine(JsonConvert.SerializeObject(create, Formatting.Indented));
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Get SettingsOMVGenerator new created");
            var getOmv = await restApi.GetItemAsync<SettingsOMVGenerator>(create.Id, "/api/v1/SettingsOMV");
            Console.WriteLine(JsonConvert.SerializeObject(getOmv, Formatting.Indented));

            Console.WriteLine("Update SettingsOMVGenerator");
            getOmv.P4 = 100;
            getOmv.GeneratorId = (await restApi.GetItemAsync<Generator>(8, "/api/v1/generator/number/")).Id;
            var update = await restApi.UpdateAsync(getOmv, getOmv.Id, "/api/v1/SettingsOMV");
            Console.WriteLine(JsonConvert.SerializeObject(update, Formatting.Indented));
            Console.WriteLine("Delete SettingsOMVGenerator");
            var del = await restApi.DeleteAsync<SettingsOMVGenerator>(getOmv.Id, "/api/v1/SettingsOMV");
            Console.WriteLine(del);

            Console.ReadKey();
        }
    }
}
