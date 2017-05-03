using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayAnGi.Models.Repositories;
using System.Data.Entity;
using HomNayAnGi.Models.Entities;
using System.Reflection;

namespace HomNayAnGi.Models.Services
{

    public class BaseService
    {
        private static Repository repository;
        protected IRepository Repository
        {
            get
            {
                if (repository == null)
                {
                    repository = new Repository(new EntityManager());
                }
                return repository;
            }
        }

        protected TDestination MapToEntity<TSource, TDestination>(TSource source, TDestination destination)
        {
            PropertyInfo[] sourceProps = source.GetType().GetProperties();
            PropertyInfo[] destinationProps = destination.GetType().GetProperties();
            PropertyInfo p;
            foreach (var prop in sourceProps)
            {
                if ((p = destinationProps.SingleOrDefault(q => q.Name == prop.Name)) != null)
                {
                    p.SetValue(destination, prop.GetValue(source, null));
                }
            }

            return destination;
        }
    }
}