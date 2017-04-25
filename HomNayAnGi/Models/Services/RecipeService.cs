using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayAnGi.Models.Entities;
using HomNayAnGi.Models.ViewModels;
using HomNayAnGi.Models.Repositories;
using AutoMapper;

namespace HomNayAnGi.Models.Services
{
    public interface IRecipeService
    {
        RecipeViewModel GetById(int id);
        IEnumerable<RecipeViewModel> GetAll();
    }


    public class RecipeService : BaseService, IRecipeService
    {
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