using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using HomNayAnGi.Models.Services;
using HomNayAnGi.Models.ViewModels;

namespace HomNayAnGi.Controllers
{
    public class DishController : Controller
    {
        // GET: Dish
        public ActionResult Index()
        {
            IDishService service = new DishService();
            IEnumerable<DishViewModel> dishes = service.GetAll();
            return View(dishes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateDish(DishViewModel model)
        {
            IDishService service = new DishService();
            service.Create(model);
            return RedirectToAction("Create");
        }

        [HttpPost]
        public JsonResult GetAll()
        {
            IDishService service = new DishService();
            IEnumerable<DishViewModel> dishes = service.GetAll();
            return Json(dishes);
        }

    }
}