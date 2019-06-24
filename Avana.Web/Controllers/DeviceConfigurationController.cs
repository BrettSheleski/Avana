using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Avana.Web.Models;
using Microsoft.AspNetCore.Mvc;
using FVTC.LearningInnovations.Web.MvcCore.Extensions;
using Avana.Models;

namespace Avana.Web.Controllers
{
    public class DeviceConfigurationController : Controller
    {
        public IActionResult Upgrade(string filename)
        {
            var v = View();

            v.ContentType = "text/plain";

            return v;
        }

        public IActionResult DeviceUpgrade(DeviceInfoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                DeviceConfiguration config = viewModel.GetConfiguration();

                return new DeviceConfigurationResult(config);
            }
            else
            {
                return NotFound();
            }
        }


        public IActionResult Settings(string filename)
        {
            var v = View();

            v.ContentType = "text/plain";

            return v;
        }


        public IActionResult DeviceSettings(string model4, string model, string mac, int group)
        {
            // get existing config from db by mac address

            // if not exists create a new one and save it.

            
            var v = View();

            v.ContentType = "text/plain";

            return v;
        }
    }
}