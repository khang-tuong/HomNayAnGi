using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomNayAnGi.Models.Services;
using HomNayAnGi.Models.ViewModels;

namespace HomNayAnGi.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Find(int id)
        {
            IRecipeService service = new RecipeService();
            RecipeViewModel recipe = service.GetById(id);
            return View(recipe);
        }
    }
}