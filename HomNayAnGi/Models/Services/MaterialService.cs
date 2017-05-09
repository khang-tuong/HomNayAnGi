using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayAnGi.Models.Entities;
using HomNayAnGi.Models.ViewModels;
using AutoMapper;

namespace HomNayAnGi.Models.Services
{
    public interface IMaterialService
    {
        IEnumerable<MaterialViewModel> GetAll();
    }

    public class MaterialService : BaseService, IMaterialService
    {
        public IEnumerable<MaterialViewModel> GetAll()
        {
            List<Material> materials = this.Repository.GetAll<Material>().ToList();
            return Mapper.Map<List<Material>, List<MaterialViewModel>>(materials);
        }
    }
}