using OMVParser.APIClient.WorkBaseData.Domain;
using System;
using System.Threading.Tasks;
using WorkBaseData.Domain.DomainApi;

namespace OMVParser.APIClient.WorkBaseData
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var gen = await ApiProcessor.GetGenerator(16);
            var settings = new ApiSettingsOMVGenerator
            {
                GeneratorId = gen.Id,
                P1 = 1,
                P2 = 2,
                P3 = 3,
                P4 = 4,
                QhP0 = 0,
                QhP1 = 1,
                QhP2 = 2,
                QhP3 = 3,
                QhP4 = 4,
                QlP0 = 0,
                QlP1 = 1,
                QlP2 = 2,
                QlP3 = 3,
                QlP4 = 4,
                QmP0 = 0,
                QmP1 = 1,
                QmP2 = 2,
                QmP3 = 3,
                QmP4 = 4
            };
            Console.WriteLine(settings.GeneratorId.ToString());
            var r = await ApiProcessor.Create(settings);
            Console.WriteLine($"Add to generator to: "+r.ToString());
            Console.ReadKey();
        }
    }
}
