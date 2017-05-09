using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayAnGi.Models.ViewModels;
using HomNayAnGi.Models.Entities;

namespace HomNayAnGi.Models.Services
{
    public interface IIngredientService
    {
        void Create(MaterialUnitViewModel[] models, int recipeId);
    }


    public class IngredientService : BaseService, IIngredientService
    {
        public void Create(MaterialUnitViewModel[] models, int recipeId)
        {
            IMaterialUnitMappingService service = new MaterialUnitMappingService();
            foreach (var item in models)
            {
                Ingredient ingredient = new Ingredient();
                ingredient.quantity = item.Quantity;
                ingredient.recipeId = recipeId;
                ingredient.materialUnitMappingId = service.GetByMaterialUnit(item.MaterialId, item.UnitId).id;

                this.Repository.Add(ingredient);
            }
        }
    }
}