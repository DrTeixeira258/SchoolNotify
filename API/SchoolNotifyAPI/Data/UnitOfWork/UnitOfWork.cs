using Data.Context;
using Data.Interfaces.Managers;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private readonly ContextManager _contextManager = ServiceLocator.Current.GetInstance<IContextManager>() as ContextManager;

        private bool _disposed;

        public UnitOfWork()
        {
            _dbContext = _contextManager.GetContext();
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void OnError(Exception ex)
        {
            if (typeof(DbEntityValidationException) == ex.GetType())
            {
                var newEx = ex as DbEntityValidationException;
                throw new Exception(newEx.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage);
            }
            else if (typeof(DbUpdateException) == ex.GetType())
            {
                var newEx = ex as DbUpdateException;
                if (newEx.InnerException != null)
                {
                    if (newEx.InnerException.InnerException != null)
                    {
                        throw newEx.InnerException.InnerException;
                    }
                    throw newEx.InnerException;
                }
                throw newEx;
            }
            else if (typeof(NullReferenceException) == ex.GetType())
            {
                var newEx = ex as NullReferenceException;
                throw newEx.InnerException.InnerException;
            }
            throw ex;
        }
    }
}
