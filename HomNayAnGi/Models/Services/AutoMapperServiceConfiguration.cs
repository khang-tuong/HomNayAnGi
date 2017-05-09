using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HomNayAnGi.Models.Entities;
using HomNayAnGi.Models.ViewModels;

namespace HomNayAnGi.Models.Services
{
    public class AutoMapperServiceConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Dish, DishViewModel>();
                cfg.CreateMap<Material, MaterialViewModel>();
                cfg.CreateMap<Unit, UnitViewModel>();
            }
            );
        }

    }

    
}