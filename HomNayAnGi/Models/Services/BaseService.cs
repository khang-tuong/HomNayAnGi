using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayAnGi.Models.Repositories;
using System.Data.Entity;
using HomNayAnGi.Models.Entities;

namespace HomNayAnGi.Models.Services
{

    public abstract class BaseService
    {
        private Repository repository;
        protected IRepository Repository
        {
            get
            {
                if (repository == null)
                {
                    repository = new Repository(new EntityManager());
                }
                return this.repository;
            }
        }
    }
}