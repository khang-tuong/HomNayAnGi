using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomNayAnGi.Models.Services;
using HomNayAnGi.Models.ViewModels;
using Microsoft.AspNet.Identity;

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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //[Authorize]
        [HttpPost]
        public ActionResult CreateRecipe(RecipeCreateViewModel model)
        {
            IRecipeService service = new RecipeService();

            string userId = User.Identity.GetUserId();
            IAccountService accountService = new AccountService();
            int accountId = accountService.GetAccountId(userId);
            //model.authorId = accountId;
            model.authorId = 2;

            service.Create(model);
            return RedirectToAction("Create");
        }
    }
}