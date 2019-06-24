using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FVTC.LearningInnovations.App.Web.MvcCore;

namespace Avana.Web.Areas.Admin.Controllers
{
    public class DevicesController : AdminController
    {
        public Task<IActionResult> Index()
        {
            return this.ViewAsync<Avana.Models.DeviceIndex>();
        }
    }
}