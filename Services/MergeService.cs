using DeviceDataProcessingTakeHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDataProcessingTakeHome.Services
{
    public class MergeService : IMergeService
    {
        public List<MergedData> MergeData(Foo1 foo1, Foo2 foo2)
        {
            var mergedList = new List<MergedData>();

            foreach (var tracker in foo1.Trackers)
            {
                var temperatureCrumbs = tracker.Sensors.FirstOrDefault(s => s.Name == "Temperature")?.Crumbs;
                var humidityCrumbs = tracker.Sensors.FirstOrDefault(s => s.Name == "Humidty")?.Crumbs;

                var firstReading = temperatureCrumbs?.Min(c => c.CreatedDtm) ?? humidityCrumbs?.Min(c => c.CreatedDtm);
                var lastReading = temperatureCrumbs?.Max(c => c.CreatedDtm) ?? humidityCrumbs?.Max(c => c.CreatedDtm);

                mergedList.Add(new MergedData
                {
                    CompanyId = foo1.PartnerId,
                    CompanyName = foo1.PartnerName,
                    DeviceId = tracker.Id,
                    DeviceName = tracker.Model,
                    FirstReadingDtm = firstReading,
                    LastReadingDtm = lastReading,
                    TemperatureCount = temperatureCrumbs?.Count,
                    AverageTemperature = temperatureCrumbs?.Average(c => c.Value),
                    HumidityCount = humidityCrumbs?.Count,
                    AverageHumidity = humidityCrumbs?.Average(c => c.Value)
                });
            }

            foreach (var device in foo2.Devices)
            {
                var temperatureData = device.SensorData.Where(s => s.SensorType == "TEMP");
                var humidityData = device.SensorData.Where(s => s.SensorType == "HUM");

                var firstReading = temperatureData.Min(s => s.DateTime);
                var lastReading = temperatureData.Max(s => s.DateTime);

                mergedList.Add(new MergedData
                {
                    CompanyId = foo2.CompanyId,
                    CompanyName = foo2.Company,
                    DeviceId = device.DeviceID,
                    DeviceName = device.Name,
                    FirstReadingDtm = firstReading,
                    LastReadingDtm = lastReading,
                    TemperatureCount = temperatureData.Count(),
                    AverageTemperature = temperatureData.Average(s => s.Value),
                    HumidityCount = humidityData.Count(),
                    AverageHumidity = humidityData.Average(s => s.Value)
                });
            }

            return mergedList;
        }
    }
}
