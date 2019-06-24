using Avana.Models;
using System;

namespace Avana.Web.Models
{
    public class DeviceInfoViewModel
    {
        public string Model4 { get; set; }
        public string Model { get; set; }
        public string Mac { get; set; }
        public int? Group { get; set; }

        public DeviceConfiguration GetConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}