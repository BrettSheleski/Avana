using System.Threading.Tasks;
using Avana.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avana.Web.Controllers
{
    internal class DeviceConfigurationResult : IActionResult
    {
        public DeviceConfiguration Config { get; }

        public string Filename { get; }

        public DeviceConfigurationResult(DeviceConfiguration config) : this(config, null)
        {

        }

        public DeviceConfigurationResult(DeviceConfiguration config, string filename)
        {
            this.Config = config;
            this.Filename = filename;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.ContentType = System.Net.Mime.MediaTypeNames.Text.Plain;

            if (!string.IsNullOrEmpty(Filename))
            {
                System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = Filename
                };

                context.HttpContext.Response.Headers["Content-Disposition"] = cd.ToString();
            }

            

           await Config.WriteToAsync(context.HttpContext.Response.Body);
        }
    }
}