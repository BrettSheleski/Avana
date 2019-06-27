using Avana.Models.Operations.Devices;
using FVTC.LearningInnovations.App;
using FVTC.LearningInnovations.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dbDevice = Avana.DataAccess.Entities.Device;

namespace Avana.Services.Devices
{
    public class EditDeviceService : GetSetWithKeyModelService<EditDeviceModel, int>
    {
        public EditDeviceService(IDataAccessService dataAccessService)
        {
            this.DataAccessService = dataAccessService;
        }

        public IDataAccessService DataAccessService { get; }

        public override async Task<ModelServiceResult<EditDeviceModel>> GetAsync(int key, CancellationToken cancellationToken)
        {
            var dbDevice = await DataAccessService.GetAsync<dbDevice>(key);

            if (dbDevice == null)
            {
                return new ModelServiceResult<EditDeviceModel>(ModelServiceResultStatus.NotFound);
            }
            else
            {
                var model = new EditDeviceModel
                {
                    Device = new Device
                    {
                        Id = key,
                        MacAddress = new System.Net.NetworkInformation.PhysicalAddress(dbDevice.MacAddress)
                    }
                };

                return new ModelServiceResult<EditDeviceModel>(model);
            }
        }

        private ModelServiceResult<EditDeviceModel> NotFound()
        {
            return ModelServiceResult.NotFound<EditDeviceModel>();
        }

        public override Task<ModelServiceResult<EditDeviceModel>> SetAsync(EditDeviceModel model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
