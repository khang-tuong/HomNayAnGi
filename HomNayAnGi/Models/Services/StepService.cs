using HomNayAnGi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayAnGi.Models.Entities;

namespace HomNayAnGi.Models.Services
{
    public interface IStepService
    {
        void Create(StepCreateViewModel[] steps);
    }


    public class StepService : BaseService, IStepService
    {
        public void Create(StepCreateViewModel[] steps)
        {
            foreach (var step in steps)
            {
                Step s = new Step();
                s = this.MapToEntity<StepCreateViewModel, Step>(step, s);
                this.Repository.Add(s);
            }
        }
    }
}