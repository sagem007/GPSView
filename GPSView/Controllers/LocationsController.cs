using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GPSView.Controllers
{
    [RoutePrefix("api/Locations")]
    public class LocationsController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> addLocation(GPSView.Models.Locations location)
        {
            var dm = new GPSView.Models.DB_Model();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dm.Locations.Add(location);
            var add_res = await dm.SaveChangesAsync();

            if (add_res < 1)
            {
                return BadRequest("Location is not added.");
            }

            return Created("", location);
        }
    }
}
