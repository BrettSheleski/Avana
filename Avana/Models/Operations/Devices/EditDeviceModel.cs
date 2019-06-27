using FVTC.LearningInnovations.App;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Avana.Models.Operations.Devices
{
    public class EditDeviceModel : NewEditDeviceModelBase, IModel<int>
    {
        
        
    }

    public abstract class NewEditDeviceModelBase 
    {
        public Device Device { get; set; }
    }
}
