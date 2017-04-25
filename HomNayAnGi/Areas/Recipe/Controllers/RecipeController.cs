using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomNayAnGi.Models.Services;

namespace HomNayAnGi.Areas.Recipe.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe/Recipe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult All()
        {
            IRecipeService service = new RecipeService();
            var recipes = service.GetAll().ToList();
            return View(recipes);
        }
    }
}