using FVTC.LearningInnovations.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avana.Models.Operations.Devices
{
    public class ListDevicesModel : IModel
    {
        public List<Device> Devices { get; } = new List<Device>();

    }
}
