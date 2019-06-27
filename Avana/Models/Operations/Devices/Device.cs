using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Avana.Models.Operations.Devices
{
    public class Device
    {
        public int? Id { get; set; }

        public PhysicalAddress MacAddress { get; set; }
    }
}
