using DeviceDataProcessingTakeHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceDataProcessingTakeHome.Services
{
    public interface IMergeService
    {
        List<MergedData> MergeData(Foo1 foo1, Foo2 foo2);
    }
}
