using DeviceDataProcessingTakeHome.Repositories;
using DeviceDataProcessingTakeHome.Services;
using Xunit;

namespace DeviceDataProcessingTakeHome.Tests
{
    public class MergeServiceTests
    {
        [Fact]
        public void MergeData_ShouldReturnCorrectMergedData()
        {
            // Arrange
            var foo1Repository = new Foo1Repository("../DeviceDataFoo1.json");
            var foo2Repository = new Foo2Repository("../DeviceDataFoo2.json");
            var mergeService = new MergeService();

            var foo1Data = foo1Repository.GetData();
            var foo2Data = foo2Repository.GetData();

            // Act
            var mergedData = mergeService.MergeData(foo1Data, foo2Data);

            // Assert
            Assert.NotNull(mergedData);
            Assert.NotEmpty(mergedData);
        }
    }
}
