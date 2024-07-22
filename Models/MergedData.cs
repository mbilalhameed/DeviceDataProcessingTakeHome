﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDataProcessingTakeHome.Models
{
    public class MergedData
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int? DeviceId { get; set; }
        public string DeviceName { get; set; }
        public DateTime? FirstReadingDtm { get; set; }
        public DateTime? LastReadingDtm { get; set; }
        public int? TemperatureCount { get; set; }
        public double? AverageTemperature { get; set; }
        public int? HumidityCount { get; set; }
        public double? AverageHumidity { get; set; }
    }
}
