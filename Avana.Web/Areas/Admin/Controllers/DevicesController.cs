using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FVTC.LearningInnovations.App.Web.MvcCore;
using Avana.Models.Operations.Devices;
using FVTC.LearningInnovations.Web.Mvc;
using FVTC.LearningInnovations.Web.MvcCore.Extensions;
using FVTC.LearningInnovations.Web.MvcCore;

namespace Avana.Web.Areas.Admin.Controllers
{
    public class DevicesController : AdminController
    {
        public Task<IActionResult> Index()
        {
            return this.ViewAsync<Avana.Models.Operations.Devices.ListDevicesModel>();
        }

        [ImportModelState]
        public Task<IActionResult> New()
        {
            return this.ViewAsync<EditDeviceModel>(nameof(Edit));
        }

        [HttpPost]
        [ExportModelState]
        public async Task<IActionResult> New(IViewModel<EditDeviceModel> viewModel)
        {
            if (await this.PostAsync(viewModel))
            {
                return this.RedirectTo<DevicesController>(c => c.Index());
            }
            else
            {
                return this.RedirectTo<DevicesController>(c => c.New());
            }
        }

        [ImportModelState]
        public Task<IActionResult> Edit(int id)
        {
            return this.ViewAsync<EditDeviceModel, int>(id, nameof(Edit));
        }

        [HttpPost]
        [ExportModelState]
        public async Task<IActionResult> Edit(IViewModel<EditDeviceModel> viewModel)
        {
            if (await this.PostAsync(viewModel))
            {
                return this.RedirectTo<DevicesController>(c => c.Index());
            }
            else
            {
                return this.RedirectTo<DevicesController>(c => c.Edit(viewModel.OperationModel.Device.Id ?? 0));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await this.GetModelAsync<DeleteDeviceModel>();

            throw new NotImplementedException();
        }
    }
}