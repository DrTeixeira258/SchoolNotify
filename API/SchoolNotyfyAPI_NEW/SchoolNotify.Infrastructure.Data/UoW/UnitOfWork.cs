using SchoolNotify.Infrastructure.Data.Context;
using SchoolNotify.Infrastructure.Data.Interfaces.Management;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace SchoolNotify.Infrastructure.Data.UoW
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

        public async Task BeginTransaction()
        {
            await Task.Run(() => _disposed = false);
        }

        public async Task SaveChangesAsync()
        {
            await Task.Run(() => _dbContext.SaveChangesAsync());        
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
    }
}
