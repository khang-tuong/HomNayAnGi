using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace HomNayAnGi.Models.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }

    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SaveChanges()
        {
            ((IObjectContextAdapter)this.dbContext).ObjectContext.SaveChanges();
        }

        #region Implementation of IDisposable

        private bool _disposed;

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, 
        ///     releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Disposes off the managed and unmanaged resources used.
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (_disposed)
                return;

            _disposed = true;
        }

        #endregion
    }
}