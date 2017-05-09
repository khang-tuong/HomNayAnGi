using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayAnGi.Models.ViewModels;
using HomNayAnGi.Models.Entities;
using AutoMapper;

namespace HomNayAnGi.Models.Services
{
    public interface IDishService
    {
        IEnumerable<DishViewModel> GetAll();
        void Create(DishViewModel dish);
    }

    public class DishService : BaseService, IDishService
    {
        public void Create(DishViewModel model)
        {
            Dish dish = new Dish();
            this.MapToEntity<DishViewModel, Dish>(model, dish);
            this.Repository.Add(dish);
        }

        public IEnumerable<DishViewModel> GetAll()
        {
            List<Dish> dishes = this.Repository.GetAll<Dish>().ToList();
            return Mapper.Map<List<Dish>, List<DishViewModel>>(dishes);
        }

    }
}