using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayAnGi.Models.Entities;
using HomNayAnGi.Models.ViewModels;
using HomNayAnGi.Models.Repositories;
using AutoMapper;
using HomNayAnGi.Models.Enum;
using Microsoft.AspNet.Identity;

namespace HomNayAnGi.Models.Services
{
    public interface IRecipeService
    {
        RecipeViewModel GetById(int id);
        IEnumerable<RecipeViewModel> GetAll();
        int Create(RecipeCreateViewModel model);
    }


    public class RecipeService : BaseService, IRecipeService
    {
        public int Create(RecipeCreateViewModel model)
        {
            

            Recipe recipe = new Recipe();
            recipe = this.MapToEntity<RecipeCreateViewModel, Recipe>(model, recipe);
            recipe.status = (int) RecipeStatusEnum.Waiting;
            recipe.Account = this.Repository.GetById<Account>(model.authorId);
            //recipe.Dish = this.Repository.GetById<Dish>(model.dishId);
            recipe.authorId = model.authorId;
            recipe.dateCreated = DateTime.Now;
            recipe.dishId = model.dishId;
            recipe = this.Repository.Add(recipe);

            foreach (var step in model.Step)
            {
                step.recipeId = recipe.id;
            }

            IStepService stepService = new StepService();
            stepService.Create(model.Step);

            IIngredientService ingredientService = new IngredientService();
            ingredientService.Create(model.Material, recipe.id);

            return recipe.id;
        }

        public IEnumerable<RecipeViewModel> GetAll()
        {
            IEnumerable<Recipe> recipes = this.Repository.GetAll<Recipe>().AsEnumerable();
            Mapper.Initialize(cfg => cfg.CreateMap<Recipe, RecipeViewModel>());
            return Mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeViewModel>>(recipes);
        }

        public RecipeViewModel GetById(int id)
        {
            Recipe recipe = this.Repository.GetById<Recipe>(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Recipe, RecipeViewModel>());
            return Mapper.Map<RecipeViewModel>(recipe);
        }
    }
}