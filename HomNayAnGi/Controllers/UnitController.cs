using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomNayAnGi.Models.Services;

namespace HomNayAnGi.Controllers
{
    public class UnitController : Controller
    {
        // GET: Unit
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAll()
        {
            IUnitService service = new UnitlService();
            return Json(service.GetAll());
        }
    }
}