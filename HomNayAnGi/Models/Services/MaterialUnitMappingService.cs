using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayAnGi.Models.Entities;
using HomNayAnGi.Models.ViewModels;

namespace HomNayAnGi.Models.Services
{
    public interface IMaterialUnitMappingService
    {
        MaterialUnitMapping GetByMaterialUnit(int materialId, int unitId);
    }


    public class MaterialUnitMappingService : BaseService, IMaterialUnitMappingService
    {
        public MaterialUnitMapping GetByMaterialUnit(int materialId, int unitId)
        {
            return this.Repository.SingleOrDefault<MaterialUnitMapping>(q => q.materialId == materialId && q.unitId == unitId);
        }
    }
}