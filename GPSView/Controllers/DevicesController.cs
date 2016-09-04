using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GPSView.Controllers
{
    [RoutePrefix("api/Devices")]
    public class DevicesController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> addDevice(Models.Device device)
        {
            var dm = new GPSView.Models.DB_Model();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (dm.Device.Where(x => x.IMEI == device.IMEI).Count() > 0)
            {
                return BadRequest("Device is already exists.");
            }

            dm.Device.Add(device);
            var add_res = await dm.SaveChangesAsync();

            if (add_res < 1)
            {
                return BadRequest("Device is not added.");
            }

            return Created("", device);
        }
    }
}
