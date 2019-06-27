using Avana.Models.Operations.Devices;
using FVTC.LearningInnovations.App;
using FVTC.LearningInnovations.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Avana.Services.Devices
{
    public class ListDeviceService : GetModelService<Avana.Models.Operations.Devices.ListDevicesModel>
    {
        public ListDeviceService(IDataAccessService dataAccessService)
        {
            this.DataAccessService = dataAccessService;
        }

        public IDataAccessService DataAccessService { get; }

        public override Task<ModelServiceResult<ListDevicesModel>> GetAsync(CancellationToken cancellationToken)
        {
            var model = new ListDevicesModel
            {

            };

            var devices = DataAccessService.GetAll<DataAccess.Entities.Device>()
                                         .Select(d => new
                                         {
                                             d.Id,
                                             d.MacAddress
                                         })
                                         .AsEnumerable()
                                         .Select(d => new Device
                                         {
                                             Id = d.Id,
                                             MacAddress = new PhysicalAddress(d.MacAddress)
                                         })
                                         ;

            model.Devices.AddRange(devices);

            return Task.FromResult(new ModelServiceResult<ListDevicesModel>(model));
        }
    }
}
