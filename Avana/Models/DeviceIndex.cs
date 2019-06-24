using FVTC.LearningInnovations.App;
using System.Collections.Generic;

namespace Avana.Models
{
    public class DeviceIndex : IModel
    {

        public List<DeviceInfo> Devices { get; } = new List<DeviceInfo>();

        public class DeviceInfo
        {

        }
    }
}