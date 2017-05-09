using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayAnGi.Models.Entities;
using HomNayAnGi.Models.ViewModels;
using AutoMapper;

namespace HomNayAnGi.Models.Services
{
    public interface IUnitService
    {
        IEnumerable<UnitViewModel> GetAll();
    }

    public class UnitlService : BaseService, IUnitService
    {
        public IEnumerable<UnitViewModel> GetAll()
        {
            List<Unit> materials = this.Repository.GetAll<Unit>().ToList();
            return Mapper.Map<List<Unit>, List<UnitViewModel>>(materials);
        }
    }
}