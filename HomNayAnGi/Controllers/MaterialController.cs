﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomNayAnGi.Models.Services;

namespace HomNayAnGi.Controllers
{
    public class MaterialController : Controller
    {
        // GET: Material
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAll()
        {
            IMaterialService service = new MaterialService();
            return Json(service.GetAll());
        }
    }
}