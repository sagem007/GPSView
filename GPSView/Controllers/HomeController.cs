using GPSView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPSView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = new DB_Model();
            return View(data.Locations.AsEnumerable<Locations>());
        }
    }
}