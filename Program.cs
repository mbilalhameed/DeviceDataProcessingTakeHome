using DeviceDataProcessingTakeHome.Repositories;
using DeviceDataProcessingTakeHome.Services;
using DeviceDataProcessingTakeHome.Utils;

namespace DeviceDataProcessingTakeHome
{
    public class Program
    {
        static void Main(string[] args)
        {
            var foo1Repository = new Foo1Repository("./DeviceDataFoo1.json");
            var foo2Repository = new Foo2Repository("./DeviceDataFoo2.json");
            var mergeService = new MergeService();

            var foo1Data = foo1Repository.GetData();
            var foo2Data = foo2Repository.GetData();

            var mergedData = mergeService.MergeData(foo1Data, foo2Data);

            DataSerializer.SaveToJsonFile(mergedData, "./MergedData.json");
        }
    }
}