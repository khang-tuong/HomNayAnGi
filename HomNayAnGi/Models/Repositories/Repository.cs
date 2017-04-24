using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace HomNayAnGi.Models.Repositories
{
    public interface IRepository : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        TEntity SingleOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        TEntity GetById<TEntity>(int id) where TEntity : class;
        TEntity Update<TEntity>(TEntity entity) where TEntity : class;
        TEntity Delete<TEntity>(TEntity entity) where TEntity : class;
        TEntity Add<TEntity>(TEntity entity) where TEntity : class;
        IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

    }

    public class Repository : IRepository
    {

        //Private Variables
        private bool bDisposed;
        private DbContext context;
        private IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (this.unitOfWork == null)
                {
                    this.unitOfWork = new UnitOfWork(this.context);
                }
                return this.unitOfWork;
            }
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return this.context.Set<TEntity>().Add(entity);
        }

        public TEntity Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return this.context.Set<TEntity>().Remove(entity);
        }

        public void Dispose()
        {
            Close();
        }

        public TEntity FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return GetAll<TEntity>().FirstOrDefault<TEntity>(predicate);
        }

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return GetAll<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            string entityName = GetEntityName<TEntity>();
            return ((IObjectContextAdapter)this.context).ObjectContext.CreateQuery<TEntity>(entityName);
        }

        public TEntity GetById<TEntity>(int id) where TEntity : class
        {
            EntityKey key = GetEntityKey<TEntity>(id);

            object originalItem;
            if (((IObjectContextAdapter)this.context).
            ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                return (TEntity)originalItem;
            }

            return default(TEntity);
        }

        public TEntity SingleOrDefault<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return GetAll<TEntity>().SingleOrDefault<TEntity>(predicate);
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            string fqen = GetEntityName<TEntity>();

            object originalItem;
            EntityKey key =
            ((IObjectContextAdapter)this.context).ObjectContext.CreateEntityKey(fqen, entity);
            if (((IObjectContextAdapter)this.context).ObjectContext.TryGetObjectByKey
            (key, out originalItem))
            {
                ((IObjectContextAdapter)this.context).ObjectContext.ApplyCurrentValues
                (key.EntitySetName, entity);
            }
            return entity;
        }

        private EntityKey GetEntityKey<TEntity>(object keyValue) where TEntity : class
        {
            string entitySetName = GetEntityName<TEntity>();
            ObjectSet<TEntity> objectSet =
            ((IObjectContextAdapter)this.context).ObjectContext.CreateObjectSet<TEntity>();
            string keyPropertyName = objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
            var entityKey = new EntityKey
            (entitySetName, new[] { new EntityKeyMember(keyPropertyName, keyValue) });
            return entityKey;
        }

        private string GetEntityName<TEntity>() where TEntity : class
        {
            // Thanks to Kamyar Paykhan -
            // http://huyrua.wordpress.com/2011/04/13/
            // entity-framework-4-poco-repository-and-specification-pattern-upgraded-to-ef-4-1/
            // #comment-688
            string entitySetName = ((IObjectContextAdapter)this.context).ObjectContext
                .MetadataWorkspace
                .GetEntityContainer(((IObjectContextAdapter)this.context).
                    ObjectContext.DefaultContainerName,
                    DataSpace.CSpace)
                .BaseEntitySets.Where(bes => bes.ElementType.Name == typeof(TEntity).Name).First().Name;
            return string.Format("{0}.{1}",
            ((IObjectContextAdapter)this.context).ObjectContext.DefaultContainerName,
                entitySetName);
        }

        #region Disposing Methods

        protected void Dispose(bool bDisposing)
        {
            if (!bDisposed)
            {
                if (bDisposing)
                {
                    if (null != context)
                    {
                        context.Dispose();
                    }
                }
                bDisposed = true;
            }
        }

        public void Close()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}