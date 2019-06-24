using System;
using System.Threading;
using System.Threading.Tasks;
using Avana.Models;
using FVTC.LearningInnovations.App;
using FVTC.LearningInnovations.DataAccess;

namespace Avana.Services
{

    public class DeviceIndexService : GetModelService<DeviceIndex>
    {
        public DeviceIndexService(IDataAccessService dataAccessService)
        {
            this.DataAccessService = dataAccessService;
        }

        public IDataAccessService DataAccessService { get; }

        public override Task<ModelServiceResult<DeviceIndex>> GetAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
