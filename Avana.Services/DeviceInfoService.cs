using System;
using System.Threading;
using System.Threading.Tasks;
using Avana.Models;
using FVTC.LearningInnovations.App;

namespace Avana.Services
{
    public class DeviceInfoService : GetModelService<DeviceConfiguration>
    {
        public override Task<ModelServiceResult<DeviceConfiguration>> GetAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
